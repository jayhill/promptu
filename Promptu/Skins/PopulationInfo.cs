﻿//-----------------------------------------------------------------------
// <copyright file="PopulationInfo.cs" company="ZachJohnson">
//     Copyright (c) Zach Johnson. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZachJohnson.Promptu.Skins
{
    using System;
    using ZachJohnson.Promptu.Collections;

    internal class PopulationInfo
    {
        private bool success;
        private TrieDictionary<Int32Encapsulator> suggestionItemsAndIndexes;

        public PopulationInfo(bool success, TrieDictionary<Int32Encapsulator> suggestionItemsAndIndexes)
        {
            this.success = success;
            this.suggestionItemsAndIndexes = suggestionItemsAndIndexes;
        }

        public bool Success
        {
            get { return this.success; }
        }

        public int TranslateToIndex(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            bool found;
            Int32Encapsulator index = this.suggestionItemsAndIndexes.TryGetItem(value, CaseSensitivity.Insensitive, out found);

            if (!found || index == null)
            {
                return -1;
            }
            else
            {
                return index;
            }
        }

        public bool ContainsItemName(string value)
        {
            return this.suggestionItemsAndIndexes.Contains(value, CaseSensitivity.Insensitive);
        }

        public int TranslateToNearestMatchIndex(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string nearestMatch = this.suggestionItemsAndIndexes.TryFindKey(value, CaseSensitivity.Insensitive);
            if (nearestMatch != null)
            {
                return this.TranslateToIndex(nearestMatch);
            }
            else
            {
                return -1;
            }
        }
    }
}
