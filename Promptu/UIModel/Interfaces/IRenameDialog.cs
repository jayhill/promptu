﻿namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IRenameDialog : IDialog
    {
        ITextInput Value { get; }

        IButton OkButton { get; }

        IButton CancelButton { get; }

        string MainInstructions { set; }

        bool ShowCancelButton { get; set; }
    }
}
