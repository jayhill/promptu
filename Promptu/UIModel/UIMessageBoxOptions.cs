using System;

namespace ZachJohnson.Promptu.UIModel
{
    [Flags]
    internal enum UIMessageBoxOptions
    {
        None = 0,
        ServiceNotification = 1,
        DefaultDesktopOnly = 2,
        RightAlign = 4,
        RtlReading = 8
    }
}
