﻿namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IProfileFinish
    {
        string MainInstructions { set; }

        string SupplementalInstructions { set; }

        ICheckBox StartPromptuWithComputer { get; }
    }
}
