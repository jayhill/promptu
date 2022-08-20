﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IConfirmDialog : IDialog
    {
        IButton AffirmativeButton { get; }

        IButton NegativeButton { get; }

        string MainInstructions { set; }

        string SupplementalInstructions { set; }
    }
}
