namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IProfileTabPanel
    {
        ITabControl ListTabs { get; }

        IListSelector ListSelector { get; }

        string MainInstructions { set; }

        ParameterlessVoid SettingChangedCallback { set; }
    }
}
