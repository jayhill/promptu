namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface INativeUICollection<TIObject>
    {
        void Insert(int index, TIObject item);

        void Clear();

        void Remove(TIObject item);
    }
}
