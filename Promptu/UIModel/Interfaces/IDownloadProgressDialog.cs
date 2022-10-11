namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IDownloadProgressDialog : IDialog, IThreadingInvoke
    {
        string MainInstructions { set; }

        void Show();

        void Close();

        IIndicatesProgress ProgressIndicator { set; }
    }
}
