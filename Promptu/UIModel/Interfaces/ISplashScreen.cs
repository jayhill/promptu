using System.Threading;

namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface ISplashScreen
    {
        //event EventHandler Closing;

        void Show(int? suggestedDuration, ManualResetEvent closedSignal);

        void Close();
    }
}
