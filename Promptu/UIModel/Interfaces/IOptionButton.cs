using System;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IOptionButton
    {
        string Text { get; set; }

        bool Enabled { get; set; }

        bool Visible { get; set; }

        int Indent { set; }

        event EventHandler Click;

        string ToolTipText { get; set; }
    }
}
