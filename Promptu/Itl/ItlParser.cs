﻿// Copyright 2022 Zach Johnson
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace ZachJohnson.Promptu.Itl
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using ZachJohnson.Promptu.Itl.AbstractSyntaxTree;

    internal class ItlParser
    {
        private static Predicate<ScanToken> closeAngleBracketPredicate = new Predicate<ScanToken>(IsCloseAngleBracket);
        private static Predicate<ScanToken> openParenthesesPredicate = new Predicate<ScanToken>(IsOpenParentheses);
        private static Predicate<ScanToken> closeParenthesesPredicate = new Predicate<ScanToken>(IsCloseParentheses);
        private static Predicate<ScanToken> commaPredicate = new Predicate<ScanToken>(IsComma);

        private List<ScanToken> tokens;
        private FeedbackCollection feedback;
        private int index;
        private int lengthOfInput;
        private bool allowUnterminatedFunctionCalls;

        public ItlParser(List<ScanToken> tokens, FeedbackCollection feedback, int lengthOfInput, bool allowUnterminatedFunctionCalls)
        {
            if (tokens == null)
            {
                throw new ArgumentNullException("tokens");
            }

            this.allowUnterminatedFunctionCalls = allowUnterminatedFunctionCalls;

            if (feedback != null)
            {
                this.feedback = feedback;
            }
            else
            {
                this.feedback = new FeedbackCollection();
            }

            this.tokens = tokens;
            this.lengthOfInput = lengthOfInput;
        }

        public FeedbackCollection Feedback
        {
            get { return this.feedback; }
        }

        public Expression Parse()
        {
            return this.ParseExpressionGroup(this.tokens.Count);
        }

        private static bool IsCloseAngleBracket(ScanToken token)
        {
            return token.Value.Equals(ScanTokenLiteral.CloseAngleBracket);
        }

        private static bool IsOpenParentheses(ScanToken token)
        {
            return token.Value.Equals(ScanTokenLiteral.OpenParantheses);
        }

        private static bool IsCloseParentheses(ScanToken token)
        {
            return token.Value.Equals(ScanTokenLiteral.CloseParantheses);
        }

        private static bool IsComma(ScanToken token)
        {
            return token.Value.Equals(ScanTokenLiteral.Comma);
        }

        private ExpressionGroup ParseExpressionGroup(int stopBeforeIndex)
        {
            ExpressionGroup group = new ExpressionGroup(new List<Expression>());
            while (this.index < stopBeforeIndex)
            {
                Expression expression = this.ParseExpression();
                if (expression != null)
                {
                    group.Expressions.Add(expression);
                }
            }

            return group;
        }

        private Expression ParseExpression()
        {
            Expression result;

            if (this.index == this.tokens.Count)
            {
               throw new ParseException(Localization.ItlMessages.ExpressionExpected);
            }

            ScanToken currentToken = this.tokens[this.index];

            if (currentToken.Value is StringBuilder)
            {
                this.index++;
                result = new StringLiteral(currentToken.Value.ToString());
            }
            else if (currentToken.Value.Equals(ScanTokenLiteral.OpenAngleBracket))
            {
                this.index++;
                int indexOfCloseAngleBracket = this.tokens.FindIndex(this.index, closeAngleBracketPredicate);

                if (indexOfCloseAngleBracket == -1)
                {
                    this.feedback.AddError(Localization.ItlMessages.CloseAngleBracketExpected, this.lengthOfInput, 0, true);
                    indexOfCloseAngleBracket = this.tokens.Count;
                }

                result = this.ParseExpressionGroup(indexOfCloseAngleBracket);
                this.index++;
            }
            else if (currentToken.Value.Equals(ScanTokenLiteral.ExclamationPoint))
            {
                this.index++;
                ImperativeSubstitution substitution = this.ParseArgumentSubstitution(
                    ScanTokenLiteral.ExclamationPoint,
                    new Predicate<ScanToken>(delegate { return true; }));

                this.index++;

                if (substitution != null)
                {
                    return substitution;
                }
                else
                {
                    return null;
                }
            }
            else if (currentToken.Value.Equals(ScanTokenLiteral.QuestionMark))
            {
                Predicate<ScanToken> delineator = new Predicate<ScanToken>(
                    delegate(ScanToken token)
                    {
                        return !token.Value.Equals(ScanTokenLiteral.QuestionMark) && !token.Value.Equals(ScanTokenLiteral.Colon);
                    });

                this.index++;
                ImperativeSubstitution substitution = this.ParseArgumentSubstitution(
                    ScanTokenLiteral.QuestionMark,
                    delineator);

                Expression defaultValue = null;

                if (this.index != this.tokens.Count)
                {
                    currentToken = this.tokens[this.index];

                    if (currentToken.Value.Equals(ScanTokenLiteral.Colon))
                    {
                        int indexOfColon = currentToken.Position;
                        this.index++;

                        if (this.index == this.tokens.Count)
                        {
                            substitution = null;
                            this.feedback.AddError(Localization.ItlMessages.QuestionMarkExpected, this.lengthOfInput, 0, true);
                        }
                        else
                        {
                            currentToken = this.tokens[this.index];
                            this.index++;
                            bool checkToken = true;
                            if (currentToken.Value.Equals(ScanTokenLiteral.OpenParantheses))
                            {
                                int indexOfCloseParentheses = this.FindIndexOfToken(closeParenthesesPredicate, openParenthesesPredicate);

                                if (indexOfCloseParentheses == -1)
                                {
                                    substitution = null;
                                    this.feedback.AddError(Localization.ItlMessages.CloseParenthesesExpected, this.lengthOfInput, 0, true);
                                    indexOfCloseParentheses = this.tokens.Count;
                                }

                                defaultValue = this.ParseExpressionGroup(indexOfCloseParentheses);
                            }
                            else if (currentToken.Value is StringBuilder)
                            {
                                defaultValue = new StringLiteral(currentToken.Value.ToString());
                            }
                            else if (currentToken.Value.Equals(ScanTokenLiteral.QuestionMark))
                            {
                                substitution = null;
                                this.feedback.AddError(Localization.ItlMessages.ExpressionExpected, indexOfColon + 1, 0, true);
                                checkToken = false;
                            }
                            else
                            {
                                substitution = null;
                                this.feedback.AddError(Localization.ItlMessages.ExpressionExpected, indexOfColon + 1, 0, true);

                                while (true)
                                {
                                    if (this.index == this.tokens.Count)
                                    {
                                        this.feedback.AddError(Localization.ItlMessages.QuestionMarkExpected, this.lengthOfInput - 1, 0, true);
                                        break;
                                    }

                                    if (currentToken.Value.Equals(ScanTokenLiteral.QuestionMark))
                                    {
                                        checkToken = false;
                                        break;
                                    }

                                    this.feedback.AddError(
                                        String.Format(CultureInfo.CurrentCulture, Localization.ItlMessages.NotUnderstoodFormat, currentToken.Value.ToString()), 
                                        currentToken.Position, 
                                        currentToken.EndPosition - currentToken.Position, 
                                        true);

                                    currentToken = this.tokens[this.index];

                                    this.index++;
                                }
                            }

                            this.index++;

                            if (checkToken && (this.index >= this.tokens.Count || !(currentToken = this.tokens[this.index - 1]).Value.Equals(ScanTokenLiteral.QuestionMark)))
                            {
                                substitution = null;
                                this.feedback.AddError(Localization.ItlMessages.QuestionMarkExpected, currentToken.Position, currentToken.EndPosition - currentToken.Position, true);
                            }
                        }
                    }

                    this.index++;
                }

                if (substitution != null)
                {
                    return new OptionalSubsitution(
                        substitution.ArgumentNumber, 
                        substitution.LastArgumentNumber, 
                        substitution.SingularSubstitution, 
                        defaultValue);
                }
                else
                {
                    return null;
                }
            }
            else if (currentToken.Value is string)
            {
                this.index++;
                Identifier identifier = new Identifier((string)currentToken.Value);
                List<Expression> parameters = new List<Expression>();

                if (this.index == this.tokens.Count)
                {
                    throw new ParseException(Localization.ItlMessages.BothParenthesesExpected);
                }

                currentToken = this.tokens[this.index];

                if (!currentToken.Value.Equals(ScanTokenLiteral.OpenParantheses))
                {
                    this.feedback.AddError(
                        Localization.ItlMessages.OpenParenthesesExpected, 
                        currentToken.Position,
                        0,
                        true);
                }

                this.index++;

                if (this.index == this.tokens.Count)
                {
                    if (this.allowUnterminatedFunctionCalls)
                    {
                        result = new FunctionCall(identifier, parameters);
                    }
                    else
                    {
                        throw new ParseException(Localization.ItlMessages.CloseParenthesesExpected);
                    }
                }
                else
                {
                    currentToken = this.tokens[this.index];

                    int closeParentheses = this.FindIndexOfToken(closeParenthesesPredicate, openParenthesesPredicate);

                    if (currentToken.Value.Equals(ScanTokenLiteral.CloseParantheses))
                    {
                        result = new FunctionCall(identifier, parameters);
                        this.index++;
                    }
                    else
                    {
                        while (true)
                        {
                            ScanToken nextItemToken = null;
                            int nextComma = this.FindFirstIndexOf(openParenthesesPredicate, closeParenthesesPredicate, commaPredicate);

                            int indexOfNextItem;
                            if (closeParentheses != -1 && (closeParentheses < nextComma || nextComma == -1))
                            {
                                indexOfNextItem = closeParentheses;
                                nextItemToken = this.tokens[closeParentheses];
                            }
                            else if (nextComma != -1 && nextComma < closeParentheses)
                            {
                                indexOfNextItem = nextComma;
                                nextItemToken = this.tokens[nextComma];
                            }
                            else
                            {
                                indexOfNextItem = this.tokens.Count;
                            }

                            parameters.Add(this.ParseExpressionGroup(indexOfNextItem));

                            if (nextItemToken != null)
                            {
                                this.index = indexOfNextItem + 1;

                                if (nextItemToken.Value.Equals(ScanTokenLiteral.Comma))
                                {
                                    if (this.index == this.tokens.Count)
                                    {
                                        if (this.allowUnterminatedFunctionCalls)
                                        {
                                            result = new FunctionCall(identifier, parameters);
                                            break;
                                        }
                                        else
                                        {
                                            throw new ParseException(Localization.ItlMessages.CloseParenthesesExpected);
                                        }
                                    }
                                    else
                                    {
                                        currentToken = this.tokens[this.index];

                                        bool isCloseParentheses = currentToken.Value.Equals(ScanTokenLiteral.CloseParantheses);

                                        if (isCloseParentheses || currentToken.Value.Equals(ScanTokenLiteral.Comma))
                                        {
                                            result = null;
                                            this.feedback.AddError(Localization.ItlMessages.ParameterMissing, currentToken.Position - 1, 0, true);
                                            if (isCloseParentheses)
                                            {
                                                this.index++;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else if (nextItemToken.Value.Equals(ScanTokenLiteral.CloseParantheses))
                                {
                                    result = new FunctionCall(identifier, parameters);
                                    break;
                                }
                            }
                            else
                            {
                                if (this.allowUnterminatedFunctionCalls)
                                {
                                    result = new FunctionCall(identifier, parameters);
                                    break;
                                }
                                else
                                {
                                    throw new ParseException(Localization.ItlMessages.CloseParenthesesExpected);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                result = null;
                this.feedback.AddError(String.Format(CultureInfo.CurrentCulture, Localization.ItlMessages.NotUnderstoodFormat, currentToken.Value.ToString()), currentToken.Position, currentToken.EndPosition - currentToken.Position, true);
                this.index++;
            }

            return result;
        }

        private int FindFirstIndexOf(params Predicate<ScanToken>[] matches)
        {
            for (int i = this.index; i < this.tokens.Count; i++)
            {
                ScanToken token = this.tokens[i];
                foreach (Predicate<ScanToken> match in matches)
                {
                    if (match(token))
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        private int FindFirstIndexOf(Predicate<ScanToken> openEnclosing, Predicate<ScanToken> closeEnclosing, params Predicate<ScanToken>[] matches)
        {
            int nestedLevel = 0;

            for (int i = this.index; i < this.tokens.Count; i++)
            {
                ScanToken token = this.tokens[i];
                if (openEnclosing(token))
                {
                    nestedLevel++;
                    continue;
                }
                else if (closeEnclosing(token))
                {
                    nestedLevel--;
                    continue;
                }

                if (nestedLevel == 0)
                {
                    foreach (Predicate<ScanToken> match in matches)
                    {
                        if (match(token))
                        {
                            return i;
                        }
                    }
                }
            }

            return -1;
        }

        private int FindIndexOfToken(Predicate<ScanToken> match, Predicate<ScanToken> matchForEnclosingPair)
        {
            int enclosingPair = 0;
            bool isEnclosingPair = matchForEnclosingPair != null;

            for (int i = this.index; i < this.tokens.Count; i++)
            {
                ScanToken token = this.tokens[i];
                if (isEnclosingPair && matchForEnclosingPair(token))
                {
                    enclosingPair++;
                }
                else if (match(token))
                {
                    if (enclosingPair == 0)
                    {
                        return i;
                    }
                    else
                    {
                        enclosingPair--;
                    }
                }
            }

            return -1;
        }

        private ImperativeSubstitution ParseArgumentSubstitution(object endOfSubstitution, Predicate<ScanToken> substitutionBoundDelineator)
        {
            int? argumentIndex = null;
            int? lastArgumentIndex = null;
            bool singularSubstitution = true;
            bool valid = true;
            int indexOfBeginning = this.index - 1;

            if (this.index == this.tokens.Count)
            {
                throw new ParseException(Localization.ItlMessages.ArgumentNumberOrNExpected);
            }
            else
            {
                ScanToken currentToken = this.tokens[this.index];
                while (substitutionBoundDelineator(currentToken))
                {
                    int relativeIndex = this.index - indexOfBeginning;
                    switch (relativeIndex)
                    {
                        case 3:
                        case 1:
                            bool mustBeNumber = relativeIndex == 1
                                    && this.index + 1 < this.tokens.Count
                                    && this.tokens[this.index + 1].Value.Equals(ScanTokenLiteral.Hyphen);

                            string tokenValue = currentToken.Value as string;
                            if (tokenValue != null)
                            {
                                if (tokenValue.ToUpperInvariant() != "N")
                                {
                                    valid = false;

                                    if (mustBeNumber)
                                    {
                                        this.feedback.AddError(Localization.ItlMessages.ArgumentNumberExpected, currentToken.Position, currentToken.EndPosition - currentToken.Position, true);
                                    }
                                    else
                                    {
                                        this.feedback.AddError(Localization.ItlMessages.ArgumentNumberOrNExpected, currentToken.Position, currentToken.EndPosition - currentToken.Position, true);
                                    }
                                }
                                else
                                {
                                    if (mustBeNumber)
                                    {
                                        valid = false;
                                        this.feedback.AddError(Localization.ItlMessages.ValueBeforeHypenCannotBeN, currentToken.Position, currentToken.EndPosition - currentToken.Position, true);
                                    }
                                }
                            }
                            else if (currentToken.Value is int)
                            {
                                int intValue = (int)currentToken.Value;
                                if (intValue == 0)
                                {
                                    valid = false;
                                    this.feedback.AddError(Localization.ItlMessages.ArgumentNumberCannotBeZero, currentToken.Position, currentToken.EndPosition - currentToken.Position, true);
                                }
                                else
                                {
                                    if (relativeIndex == 1)
                                    {
                                        argumentIndex = intValue;
                                    }
                                    else
                                    {
                                        lastArgumentIndex = intValue;
                                    }
                                }
                            }
                            else
                            {
                                valid = false;
                                if (mustBeNumber)
                                {
                                    this.feedback.AddError(Localization.ItlMessages.ArgumentNumberExpected, currentToken.Position, currentToken.EndPosition - currentToken.Position, true);
                                }
                                else
                                {
                                    this.feedback.AddError(Localization.ItlMessages.ArgumentNumberOrNExpected, currentToken.Position, currentToken.EndPosition - currentToken.Position, true);
                                }
                            }

                            break;
                        case 2:
                            if (currentToken.Value.Equals(ScanTokenLiteral.Hyphen))
                            {
                                singularSubstitution = false;
                            }
                            else if (!currentToken.Value.Equals(endOfSubstitution))
                            {
                                valid = false;
                                this.feedback.AddError(Localization.ItlMessages.HypenExpected, currentToken.Position, 0, true);
                            }

                            break;
                    }

                    if (currentToken.Value.Equals(endOfSubstitution))
                    {
                        break;
                    }
                    else if (relativeIndex == 4)
                    {
                        valid = false;

                        while (true)
                        {
                            if (this.index == this.tokens.Count)
                            {
                                throw new ParseException(String.Format(CultureInfo.CurrentCulture, Localization.ItlMessages.GeneralExpectedFormat, endOfSubstitution));
                            }

                            currentToken = this.tokens[this.index];

                            this.index++;

                            if (currentToken.Value.Equals(endOfSubstitution))
                            {
                                break;
                            }

                            this.feedback.AddError(String.Format(CultureInfo.CurrentCulture, Localization.ItlMessages.NotUnderstoodFormat, currentToken.Value.ToString()), currentToken.Position, currentToken.EndPosition - currentToken.Position, true);
                        }

                        return null;
                    }
                    else
                    {
                        this.index++;
                    }

                    if (this.index == this.tokens.Count)
                    {
                        throw new ParseException(String.Format(CultureInfo.CurrentCulture, Localization.ItlMessages.GeneralExpectedFormat, endOfSubstitution));
                    }
                    else
                    {
                        currentToken = this.tokens[this.index];
                    }
                }
            }

            if (valid)
            {
                if (!singularSubstitution && argumentIndex != null && lastArgumentIndex != null)
                {
                    if (argumentIndex > lastArgumentIndex)
                    {
                        valid = false;
                        this.feedback.AddError(
                            Localization.ItlMessages.FirstArgumentNumberLessThanLastArgumentNumber, 
                            this.tokens[indexOfBeginning].Position, 
                            this.tokens[this.index - 1].Position - 1, 
                            true);
                    }
                }
            }

            if (valid)
            {
                return new ImperativeSubstitution(argumentIndex, lastArgumentIndex, singularSubstitution);
            }
            else
            {
                return null;
            }
        }
    }
}
