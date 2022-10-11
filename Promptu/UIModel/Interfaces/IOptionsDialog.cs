namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IOptionsDialog : IDialog
    {
        ITabControl SuperTabs { get; }

        IButton OkButton { get; }

        void ActivateAndBringToFront();
    }
}
