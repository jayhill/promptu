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

namespace ZachJohnson.Promptu.Itl
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;

    public class FeedbackCollection : IList<FeedbackMessage>
    {
        private List<FeedbackMessage> feedback;

        public FeedbackCollection()
        {
            this.feedback = new List<FeedbackMessage>();
        }

        public int Count
        {
            get { return this.feedback.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public FeedbackMessage this[int index]
        {
            get { return this.feedback[index]; }
            set { this.feedback[index] = value; }
        }

        public void Add(string description, FeedbackType typeOfMessage)
        {
            this.Add(new FeedbackMessage(description, typeOfMessage));
        }

        public void Add(string description, FeedbackType typeOfMessage, object associatedObject)
        {
            this.Add(new FeedbackMessage(description, typeOfMessage, associatedObject));
        }

        public void Add(string description, FeedbackType typeOfMessage, int start, int end, bool canLocate)
        {
            this.Add(new FeedbackMessage(description, typeOfMessage, start, end, canLocate));
        }

        public void Add(FeedbackMessage item)
        {
            this.feedback.Add(item);
        }

        public void AddRange(IEnumerable<FeedbackMessage> items)
        {
            foreach (FeedbackMessage item in items)
            {
                this.Add(item);
            }
        }

        public void AddError(string description, int start, int length, bool canLocate)
        {
            this.Add(description, FeedbackType.Error, start, length, canLocate);
        }

        [Obsolete]
        public void AddError(string description)
        {
            this.Add(description, FeedbackType.Error);
        }

        public void AddError(string description, object associatedObject)
        {
            this.Add(description, FeedbackType.Error, associatedObject);
        }

        public void AddWarning(string description, int start, int length, bool canLocate)
        {
            this.Add(description, FeedbackType.Warning, start, length, canLocate);
        }

        [Obsolete]
        public void AddWarning(string description)
        {
            this.Add(description, FeedbackType.Warning);
        }

        public void AddWarning(string description, object associatedObject)
        {
            this.Add(description, FeedbackType.Warning, associatedObject);
        }

        public void AddMessage(string description, int start, int length, bool canLocate)
        {
            this.Add(description, FeedbackType.Message, start, length, canLocate);
        }

        [Obsolete]
        public void AddMessage(string description)
        {
            this.Add(description, FeedbackType.Message);
        }

        public void AddMessage(string description, object associatedObject)
        {
            this.Add(description, FeedbackType.Message, associatedObject);
        }

        public void Clear()
        {
            this.feedback.Clear();
        }

        public bool Contains(FeedbackMessage item)
        {
            return this.feedback.Contains(item);
        }

        public bool Has(FeedbackType typeOfMessage)
        {
            foreach (FeedbackMessage message in this)
            {
                if (message.MessageType == typeOfMessage)
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(FeedbackMessage[] array, int arrayIndex)
        {
            this.feedback.CopyTo(array, arrayIndex);
        }

        public bool Remove(FeedbackMessage item)
        {
            return this.feedback.Remove(item);
        }

        public int IndexOf(FeedbackMessage item)
        {
            return this.feedback.IndexOf(item);
        }

        public void Insert(int index, FeedbackMessage item)
        {
            this.feedback.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this.feedback.RemoveAt(index);
        }

        public IEnumerator<FeedbackMessage> GetEnumerator()
        {
            return this.feedback.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.feedback.GetEnumerator();
        }
    }
}
