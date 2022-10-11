namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IPromptuOptionsPanel
    {
        string MainInstructions { set; }

        IObjectPropertyCollectionEditor Editor { get; }
    }
}
