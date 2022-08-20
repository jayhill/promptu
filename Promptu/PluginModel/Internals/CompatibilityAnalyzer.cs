﻿//-----------------------------------------------------------------------
// <copyright file="CompatibilityAnalyzer.cs" company="ZachJohnson">
//     Copyright (c) Zach Johnson. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZachJohnson.Promptu.PluginModel.Internals
{
    using System;
    using System.Windows.Forms;
    using Mono.Cecil;
    using Mono.Cecil.Cil;

    internal static class CompatibilityAnalyzer
    {
        public static bool PluginAssemblyIsCompatible(FileSystemFile assemblyFile, string traceCategory)
        {
            AssemblyDefinition promptu = AssemblyDefinition.ReadAssembly(Application.ExecutablePath);
            PromptuAssemblyResolver promptuResolver = new PromptuAssemblyResolver(promptu);

            ReaderParameters pluginParameters = new ReaderParameters();
            pluginParameters.AssemblyResolver = promptuResolver;

            AssemblyDefinition pluginAssembly = AssemblyDefinition.ReadAssembly(assemblyFile, pluginParameters);

            foreach (ModuleDefinition module in pluginAssembly.Modules)
            {
                foreach (TypeDefinition type in module.Types)
                {
                    foreach (MethodDefinition method in type.Methods)
                    {
                        if (!MethodDefinitionIsCompatible(method, promptu, traceCategory))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static bool MethodDefinitionIsCompatible(MethodDefinition method, AssemblyDefinition assemblyToVerifyAgainst, string traceCategory)
        {
            if (!method.HasBody)
            {
                return true;
            }

            foreach (Instruction instruction in method.Body.Instructions)
            {
                if (instruction.OpCode.Name == OpCodes.Newobj.Name || instruction.OpCode.Name == OpCodes.Callvirt.Name || instruction.OpCode.Name == OpCodes.Call.Name)
                {
                    MethodReference methodReference = instruction.Operand as MethodReference;
                    if (methodReference != null)
                    {
                        if (!CallGoesThrough(methodReference, assemblyToVerifyAgainst, traceCategory))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private static bool CallGoesThrough(MethodReference methodReference, AssemblyDefinition assemblyToVerifyAgainst, string traceCategory)
        {
            if (methodReference == null)
            {
                throw new ArgumentNullException("methodReference");
            }

            if (methodReference.DeclaringType.Scope.Name == assemblyToVerifyAgainst.Name.Name)
            {
                string fullName = methodReference.DeclaringType.FullName;

                GenericInstanceType genericType = methodReference.DeclaringType as GenericInstanceType;
                if (genericType != null)
                {
                    fullName = String.Format("{0}.{1}", genericType.Namespace, genericType.Name);
                }

                TypeDefinition calledType = assemblyToVerifyAgainst.MainModule.GetType(fullName);

                if (calledType == null)
                {
                    ErrorConsole.WriteLineFormat(traceCategory, "Incompatible assembly.  Referenced type \"{0}\" not found.", fullName);
                    return false;
                }

                MethodDefinition definition = methodReference.Resolve();

                bool found = definition != null;

                if (definition != null && definition.IsConstructor)
                {
                    if (definition.DeclaringType.FullName != fullName)
                    {
                        found = false;
                    }
                }

                if (!found)
                {
                    ErrorConsole.WriteLineFormat(traceCategory, "Incompatible assembly.  Method \"{0}\" not found.", methodReference);
                }

                return found;
            }

            return true;
        }
    }
}
