using System;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IRadioButton : IButton
    {
        bool Checked { get; set; }

        event EventHandler CheckedChanged;
    }
}
