using System;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IToolbarMenuItem : IGenericToolbarItem
    {
        event EventHandler Click;

        string Text { get; set; }

        string ToolTipText { get; set; }

        bool Enabled { get; set; }
    }
}
