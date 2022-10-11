﻿namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IUpdateAvailableDialog : IDialog
    {
        string MainInstructions { set; }

        string SupplementalInstructions { set; }

        IButton InstallNow { get; }

        IButton RemindMeLater { get; }

        //ICommandLink IgnoreThisUpdate { get; }
    }
}
