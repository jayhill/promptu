namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    interface IExistingProfile
    {
        string MainInstructions { set; }

        IComboInput ExistingProfiles { get; }
    }
}
