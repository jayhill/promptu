namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IChooseOverrideOrNewHotkey
    {
        string MainInstructions { set; }

        ICommandLink OverrideHotkey { get; }

        ICommandLink ChooseNewHotkey { get; }
    }
}
