namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface IDragSource
    {
        void DoDragDrop(object data, UIDragDropEffects allowedEffects);
    }
}
