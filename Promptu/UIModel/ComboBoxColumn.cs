﻿using System.Collections.Generic;

namespace ZachJohnson.Promptu.UIModel
{
    internal class ComboBoxColumn : Column
    {
        public List<object> values = new List<object>();

        public ComboBoxColumn(string text)
            : base(text)
        {
        }

        public List<object> Values
        {
            get { return this.values; }
            set { this.values = value; }
        }
    }
}
