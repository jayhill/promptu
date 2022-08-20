﻿//-----------------------------------------------------------------------
// <copyright file="KeyAbstractionCollection.cs" company="ZachJohnson">
//     Copyright (c) Zach Johnson. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZachJohnson.Promptu.Collections
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class KeyAbstractionCollection<TRecursiveCharCollection> : IKeyAbstractionCollection
        where TRecursiveCharCollection : TrieNodeBase<TRecursiveCharCollection>
    {
        private List<TRecursiveCharCollection> endingNodes;

        public KeyAbstractionCollection(List<TRecursiveCharCollection> endingNodes)
        {
            this.endingNodes = endingNodes;
        }

        public int Count
        {
            get { return this.endingNodes.Count; }
        }

        public string this[int index]
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                this.endingNodes[index].FollowUp(builder);
                return builder.ToString();
            }
        }

        public bool Contains(string key)
        {
            foreach (string value in this)
            {
                if (key == value)
                {
                    return true;
                }
            }

            return false;
        }

        public int IndexOf(string key)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i] == key)
                {
                    return i;
                }
            }

            return -1;
        }

        public void CopyTo(string[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            else if (this.Count < array.Length)
            {
                throw new ArgumentException("The array is too short.", "array");
            }

            for (int i = 0; i < this.Count; i++)
            {
                array[i] = this[i];
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            StringBuilder builder;
            foreach (TRecursiveCharCollection endingNode in this.endingNodes)
            {
                builder = new StringBuilder();
                endingNode.FollowUp(builder);
                yield return builder.ToString();
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
