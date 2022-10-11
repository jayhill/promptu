namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface INativeContextMenu
    {
        INativeUICollection<IGenericMenuItem> Items { get; }

        //event CancelEventHandler Opening;
    }
}
