namespace ZachJohnson.Promptu.UIModel.Interfaces
{
    internal interface ICollectionWidget
    {
        void Insert(int index, object nativeObject);

        void Remove(object nativeObject);
    }
}
