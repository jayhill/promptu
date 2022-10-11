﻿namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IUnhandledExceptionDialog : IDialog
    {
        string Message { set; }

        string MainInstructions { set; }

        IButton OkButton { get; }
    }
}
