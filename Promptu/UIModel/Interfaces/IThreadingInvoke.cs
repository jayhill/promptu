﻿using System;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IThreadingInvoke
    {
        void BeginInvoke(Delegate method, object[] args);

        object Invoke(Delegate method, object[] args);

        bool InvokeRequired { get; }
    }
}
