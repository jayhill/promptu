using System;

namespace ZachJohnson.Promptu.UIModel
{
    internal class ObjectEventArgs<T> : EventArgs
    {
        private T obj;

        public ObjectEventArgs(T obj)
        {
            this.obj = obj;
        }

        public T Object
        {
            get { return this.obj; }
        }
    }
}