﻿using System;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    interface ICommandLink
    {
        string Label { get; set; }

        string SupplementalExplaination { get; set; }

        bool Enabled { get; set; }

        event EventHandler Click;

        bool Visible { get;  set; }
    }
}
