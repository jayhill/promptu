using ZachJohnson.Promptu.UIModel.Interfaces;

namespace ZachJohnson.Promptu.UIModel
{
    internal class UITabPageInternal : UITabPage, ILockedInternal
    {
        public UITabPageInternal(string id)
            : base(id)
        {
        }
    }
}
