using System;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IButton
    {
        string Text { get; set; }

        bool Enabled { get; set; }

        event EventHandler Click;

        string ToolTipText { get; set; }

        object Image { set; }

        bool Visible { get; set; }
    }
}
