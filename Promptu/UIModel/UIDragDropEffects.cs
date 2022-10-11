using System;

namespace ZachJohnson.Promptu.UIModel
{
    [Flags]
    internal enum UIDragDropEffects
    {
        None = 0,
        Move = 1,
        Copy = 2,
        Link = 4
    }
}
