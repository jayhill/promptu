using ZachJohnson.Promptu.UIModel.Interfaces;

namespace ZachJohnson.Promptu.UIModel
{
    internal class UIMenuSeparatorInternal : UIMenuSeparator, ILockedInternal
    {
        public UIMenuSeparatorInternal(string id)
            : base(id)
        {
        }
    }
}
