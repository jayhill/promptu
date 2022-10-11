using System;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IMenuItem : IGenericMenuItem
    {
        event EventHandler Click;

        string Text { set; }

        string ToolTipText { set; }

        bool Enabled { set; }

        bool Available { set; }

        TextStyle TextStyle { set; }

        object Image { set; }

        INativeUICollection<IGenericMenuItem> SubItems { get; }
    }
}
