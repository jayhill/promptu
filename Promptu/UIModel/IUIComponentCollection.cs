using System.Collections.Generic;

namespace ZachJohnson.Promptu.UIModel
{
    internal interface IUIComponentCollection<TUIComponent> : IEnumerable<TUIComponent>
    {
        int Count { get; }

        TUIComponent this[int index] { get; }

        void Add(TUIComponent item);

        void InsertAfter(string id, TUIComponent item);

        void InsertBefore(string id, TUIComponent item);

        void Insert(int index, TUIComponent item);

        int IndexOf(TUIComponent item);

        void RemoveAt(int index);

        bool Remove(TUIComponent item);
    }
}
