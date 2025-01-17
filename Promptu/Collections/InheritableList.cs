﻿// Copyright 2022 Zach Johnson
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace ZachJohnson.Promptu.Collections
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    internal class InheritableList<T> : IEnumerable<T>
    {
        private List<T> items = new List<T>();

        public InheritableList()
        {
        }

        public InheritableList(IEnumerable<T> collection)
        {
            this.AddRange(collection);
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int Count
        {
            get { return this.items.Count; }
        }

        public T this[int index]
        {
            get
            {
                return this.items[index];
            }
        }

        public void Add(T item)
        {
            this.Insert(this.Count, item);
        }

        public void Insert(int index, T item)
        {
            if (!this.items.Contains(item))
            {
                this.InsertCore(index, item);
            }
        }

        public void AddRange(IEnumerable<T> collection)
        {
            this.AddRangeCore(collection);
        }

        public int IndexOf(T item)
        {
            return this.items.IndexOf(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            this.items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return this.RemoveCore(item);
        }

        public void RemoveAt(int index)
        {
            this.RemoveAtCore(index);
        }

        public bool Contains(T item)
        {
            return this.items.Contains(item);
        }

        public void Clear()
        {
            this.ClearCore();
        }

        public T[] ToArray()
        {
            return this.items.ToArray();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }

        protected virtual void InsertCore(int index, T item)
        {
            this.items.Insert(index, item);
        }

        protected virtual bool RemoveCore(T item)
        {
            return this.items.Remove(item);
        }

        protected virtual void RemoveAtCore(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index cannot be less than zero.");
            }
            else if (index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Index cannot be greater than or equal to the number of items.");
            }

            T item = this[index];
            this.items.RemoveAt(index);
        }

        protected virtual void ClearCore()
        {
            this.items.Clear();
        }

        protected virtual void AddRangeCore(IEnumerable<T> collection)
        {
            this.items.AddRange(collection);
        }
    }
}
