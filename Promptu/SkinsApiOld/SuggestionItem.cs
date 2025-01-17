﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ZachJohnson.Promptu.UI;

namespace ZachJohnson.Promptu.SkinsApi
{
    public class SuggestionItem : IHasImageIndex, IHasFallbackImageIndex
    {
        private SuggestionItemType type;
        private string text;
        private int? fallbackImageIndex;
        private int imageIndex;

        public SuggestionItem(SuggestionItemType type, string text, int imageIndex)
            : this(type, text, imageIndex, null)
        {
        }

        public SuggestionItem(SuggestionItemType type, string text, int imageIndex, int? fallbackImageIndex)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            this.text = text;
            this.type = type;
            this.imageIndex = imageIndex;
            this.fallbackImageIndex = fallbackImageIndex;
        }

        public SuggestionItemType Type
        {
            get { return this.type; }
        }

        public string Text
        {
            get { return this.text; }
        }

        public int ImageIndex
        {
            get { return this.imageIndex; }
            set { this.imageIndex = value; }
        }

        public int? FallbackImageIndex
        {
            get { return this.fallbackImageIndex; }
        }

        public override string ToString()
        {
            return this.text;
        }
    }
}
