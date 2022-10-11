namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IDialog
    {
        string Text { get; set; }

        UIDialogResult ShowModal();
    }
}
