﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZachJohnson.Promptu.UserModel {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Defaults {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Defaults() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ZachJohnson.Promptu.UserModel.Defaults", typeof(Defaults).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;AssemblyReferences nextId=&quot;-2147483639&quot;&gt;
        ///  &lt;AssemblyReference id=&quot;-2147483648&quot; path=&quot;Common\CommonFunctions.dll&quot; name=&quot;CommonFunctions&quot; cachedAs=&quot;CommonFunctions - (5).dll&quot; lastUpdated=&quot;5245742714062711958&quot; /&gt;
        ///&lt;/AssemblyReferences&gt;.
        /// </summary>
        internal static string AssemblyReferences {
            get {
                return ResourceManager.GetString("AssemblyReferences", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;OwnedReferences&gt;
        ///  &lt;Reference name=&quot;CommonFunctions&quot; /&gt;
        ///&lt;/OwnedReferences&gt;.
        /// </summary>
        internal static string AssemblyReferencesManifest {
            get {
                return ResourceManager.GetString("AssemblyReferencesManifest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Commands nextId=&quot;-2147483563&quot;&gt;
        ///  &lt;Command id=&quot;-2147483584&quot; name=&quot;desktop&quot;&gt;
        ///    &lt;Invokes&gt;&amp;lt;Environment.GetDesktopPath()&amp;gt;&lt;/Invokes&gt;
        ///    &lt;Notes&gt;Opens the desktop in folder view.&lt;/Notes&gt;
        ///  &lt;/Command&gt;
        ///  &lt;Command id=&quot;-2147483578&quot; name=&quot;directions.yahoomaps&quot;&gt;
        ///    &lt;Invokes&gt;http://maps.yahoo.com/&lt;/Invokes&gt;
        ///    &lt;Notes&gt;Get directions using Yahoo Maps.&lt;/Notes&gt;
        ///  &lt;/Command&gt;
        ///  &lt;Command id=&quot;-2147483577&quot; name=&quot;directions.googlemaps,google.maps&quot;&gt;
        ///    &lt;Invokes&gt;http://maps.google.com/&lt;/Invokes&gt;
        ///    &lt;Notes&gt;Get [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Commands {
            get {
                return ResourceManager.GetString("Commands", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Functions nextId=&quot;-2147483633&quot;&gt;
        ///  &lt;Function id=&quot;-2147483643&quot; name=&quot;DateTime.Now.ToString&quot; invocationClass=&quot;Promptu.CommonFunctions&quot; method=&quot;DateTimeNowToString&quot; assemblyReference=&quot;CommonFunctions&quot; returns=&quot;String&quot;&gt;
        ///    &lt;Parameters&gt;
        ///      &lt;Parameter valueType=&quot;String&quot; /&gt;
        ///    &lt;/Parameters&gt;
        ///  &lt;/Function&gt;
        ///  &lt;Function id=&quot;-2147483644&quot; name=&quot;Environment.GetDesktopDirectoryPath&quot; invocationClass=&quot;Promptu.CommonFunctions&quot; method=&quot;GetDesktopDirectoryPath&quot; assemblyReference=&quot;CommonFunctions&quot; returns=&quot;String&quot;&gt;
        /// [rest of string was truncated]&quot;;.
        /// </summary>
        internal static string Functions {
            get {
                return ResourceManager.GetString("Functions", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;List name=&quot;{currentuser}&apos;s Base List&quot; /&gt;.
        /// </summary>
        internal static string List {
            get {
                return ResourceManager.GetString("List", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;Profile name=&quot;{CurrentUser}&apos;s Profile&quot;&gt;
        ///  &lt;Sync every=&quot;30min&quot; /&gt;
        ///  &lt;Skin name=&quot;Default&quot; /&gt;
        ///  &lt;Hotkey modifierKeys=&quot;Win&quot; key=&quot;Q&quot; /&gt;
        ///  &lt;Defaults&gt;
        ///    &lt;Command saveParameterHistory=&quot;False&quot; /&gt;
        ///  &lt;/Defaults&gt;
        ///  &lt;Prompt&gt;
        ///    &lt;WhileSuggesting&gt;
        ///      &lt;Spacebar accepts=&quot;True&quot; eatCharacter=&quot;True&quot; /&gt;
        ///    &lt;/WhileSuggesting&gt;
        ///  &lt;/Prompt&gt;
        ///  &lt;Lists selectedIndex=&quot;0&quot;&gt;
        ///    &lt;List folder=&quot;0&quot; owner=&quot;true&quot;/&gt;
        ///  &lt;/Lists&gt;
        ///&lt;/Profile&gt;.
        /// </summary>
        internal static string Profile {
            get {
                return ResourceManager.GetString("Profile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &lt;ValueLists nextId=&quot;-2147483645&quot;&gt;
        ///  &lt;ValueList id=&quot;-2147483646&quot; name=&quot;WeatherCities&quot; translate=&quot;True&quot;&gt;
        ///    &lt;Item value=&quot;Denver, CO&quot; translation=&quot;USCO0105&quot; useTranslation=&quot;True&quot; /&gt;
        ///    &lt;Item value=&quot;Houston, TX&quot; translation=&quot;USTX0617&quot; useTranslation=&quot;True&quot; /&gt;
        ///    &lt;Item value=&quot;New York, NY&quot; translation=&quot;USNY0996&quot; useTranslation=&quot;True&quot; /&gt;
        ///    &lt;Item value=&quot;San Diego, CA&quot; translation=&quot;USCA0982&quot; useTranslation=&quot;True&quot; /&gt;
        ///  &lt;/ValueList&gt;
        ///&lt;/ValueLists&gt;.
        /// </summary>
        internal static string ValueLists {
            get {
                return ResourceManager.GetString("ValueLists", resourceCulture);
            }
        }
    }
}
