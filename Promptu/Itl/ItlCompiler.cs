﻿//-----------------------------------------------------------------------
// <copyright file="ItlCompiler.cs" company="ZachJohnson">
//     Copyright (c) Zach Johnson. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZachJohnson.Promptu.Itl
{
    using System;
    using System.IO;
    using ZachJohnson.Promptu.Itl.AbstractSyntaxTree;

    internal class ItlCompiler
    {
        public ItlCompiler()
        {
        }

        public Expression Compile(ItlType type, string text, out FeedbackCollection feedback)
        {
            return this.Compile(type, text, false, out feedback);
        }

        public Expression Compile(ItlType type, string text, bool allowUnterminatedFunctionCalls, out FeedbackCollection feedback)
        {
            bool isJustText;
            return this.Compile(type, text, allowUnterminatedFunctionCalls, out feedback, out isJustText);
        }

        public Expression Compile(ItlType type, string text, out FeedbackCollection feedback, out bool isJustText)
        {
            return this.Compile(type, text, false, out feedback, out isJustText);
        }

        public Expression Compile(ItlType type, string text, bool allowUnterminatedFunctionCalls, out FeedbackCollection feedback, out bool isJustText)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            feedback = new FeedbackCollection();

            IItlScanner scanner;

            if (type == ItlType.InlineExecution)
            {
                scanner = new InlineItlScanner(new StringReader(text), feedback, type == ItlType.SingleFunction);
            }
            else
            {
                scanner = new StandardItlScanner(new StringReader(text), feedback, type == ItlType.SingleFunction);
            }

            isJustText = scanner.HasJustText;

            ItlParser parser = new ItlParser(scanner.Results, feedback, text.Length, allowUnterminatedFunctionCalls);

            Expression expression = null;

            try
            {
                expression = parser.Parse();
            }
            catch (ParseException ex)
            {
                feedback.AddError(ex.Message, text.Length - 1, 0, true);
            }

            return expression;
        }
    }
}
