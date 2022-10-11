namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    interface IHotkeyInUseNewHotkey
    {
        string MainInstructions { set; }

        IHotkeyControl Hotkey { get; }

        //string HotkeySupplement { set; }
    }
}
