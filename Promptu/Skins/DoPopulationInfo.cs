﻿//-----------------------------------------------------------------------
// <copyright file="DoPopulationInfo.cs" company="ZachJohnson">
//     Copyright (c) Zach Johnson. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZachJohnson.Promptu.Skins
{
    using System;
    using System.Collections.Generic;
    using ZachJohnson.Promptu.Collections;
    using ZachJohnson.Promptu.SkinApi;

    internal class DoPopulationInfo
    {
        private ISuggestionProvider suggester;
        private TrieDictionary<Int32Encapsulator> suggestionItemsAndIndexes = new TrieDictionary<Int32Encapsulator>(SortMode.Alphabetical);
        private CompositeList<SuggestionItem> suggestionItems = new CompositeList<SuggestionItem>();
        private TrieList folderSuggestions = new TrieList(SortMode.DecendingFromLastAdded);
        private Queue<IconLoadOrder> iconLoadOrders;
        private ParameterHelpContext contextInfo;

        public DoPopulationInfo(
            ISuggestionProvider suggester, 
            ParameterHelpContext contextInfo, 
            Queue<IconLoadOrder> iconLoadOrders)
        {
            if (suggester == null)
            {
                throw new ArgumentNullException("suggester");
            }

            this.contextInfo = contextInfo;
            this.suggester = suggester;
            this.iconLoadOrders = iconLoadOrders;
        }

        public Queue<IconLoadOrder> IconLoadOrders
        {
            get { return this.iconLoadOrders; }
        }

        public ISuggestionProvider Suggester
        {
            get { return this.suggester; }
        }

        public ParameterHelpContext ContextInfo
        {
            get { return this.contextInfo; }
        }

        public TrieDictionary<Int32Encapsulator> SuggestionItemsAndIndexes
        {
            get { return this.suggestionItemsAndIndexes; }
            set { this.suggestionItemsAndIndexes = value; }
        }

        public CompositeList<SuggestionItem> SuggestionItems
        {
            get { return this.suggestionItems; }
            set { this.suggestionItems = value; }
        }

        public TrieList FolderSuggestions
        {
            get { return this.folderSuggestions; }
        }
    }
}
