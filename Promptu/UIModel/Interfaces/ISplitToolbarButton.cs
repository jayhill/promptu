using System;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface ISplitToolbarButton : IGenericToolbarItem
    {
        event EventHandler ButtonClick;

        string ToolTipText { get; set; }

        bool Enabled { get; set; }
    }
}
