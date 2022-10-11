using System;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IFunctionViewer : IDialog
    {
        event EventHandler Closed;

        ISimpleCollectionViewer FunctionsList { get; }

        IButton OkButton { get; }

        string MainInstructions { set; }

        string SelectedFunctionName { set; }

        string SelectedFunctionDescription { set; }

        void Show(object owner);
    }
}
