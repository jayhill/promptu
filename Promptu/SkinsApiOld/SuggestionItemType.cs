﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZachJohnson.Promptu.SkinsApi
{
    [Flags]
    public enum SuggestionItemType
    {
        None = 0,
        History = 1,
        NativePromptuCommand = 2,
        Command = 4,
        Function = 8,
        Folder = 16,
        File = 32,
        Namespace = 64,
        ValueListItem = 128
    }
}
