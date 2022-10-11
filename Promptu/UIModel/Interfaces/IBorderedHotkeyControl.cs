namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IBorderedHotkeyControl
    {
        string Title { get; set; }

        IHotkeyControl HotkeyControl { get; }
    }
}
