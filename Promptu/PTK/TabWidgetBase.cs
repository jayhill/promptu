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

namespace ZachJohnson.Promptu.PTK
{
    using System;
    using System.Collections.Generic;
    using ZachJohnson.Promptu.UIModel.Interfaces;

    internal abstract class TabWidgetBase<TPage, TTabPage> : GenericWidget<ITabControl>, IEnumerable<TPage> 
        where TPage : TabPageBase<TPage, TTabPage> 
        where TTabPage : ITabPage
    {
        private List<TPage> pages = new List<TPage>();

        internal TabWidgetBase(string id, ITabControl nativeInterface)
            : base(id, nativeInterface)
        {
            this.NativeInterface.SelectedTabChanged += this.RaiseSelectedTabChanged;
        }

        public event EventHandler<TabPageEventArgs<TPage, TTabPage>> TabPageAdded;

        public event EventHandler<TabPageEventArgs<TPage, TTabPage>> TabPageRemoved;

        public event EventHandler SelectedTabChanged;

        public int PageCount
        {
            get { return this.pages.Count; }
        }

        public TPage SelectedTab
        {
            get
            {
                if (this.NativeInterface.SelectedTabIndex >= 0)
                {
                    return this.pages[this.NativeInterface.SelectedTabIndex];
                }

                return null;
            }

            set
            {
                this.NativeInterface.SelectedTabIndex = this.pages.IndexOf(value);
            }
        }

        public int SelectedIndex
        {
            get { return this.NativeInterface.SelectedTabIndex; }
            set { this.NativeInterface.SelectedTabIndex = value; }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Add(TPage tabPage)
        {
            if (tabPage == null)
            {
                throw new ArgumentNullException("tabPage");
            }

            this.Insert(this.PageCount, tabPage);
        }

        public void Insert(int index, TPage tabPage)
        {
            if (tabPage == null)
            {
                throw new ArgumentNullException("tabPage");
            }
            else if (index < 0 || index > this.PageCount)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (tabPage.CurrentOwner != null)
            {
                tabPage.CurrentOwner.Remove(tabPage);
            }

            this.NativeInterface.Insert(index, tabPage.NativeInterface);
            this.pages.Insert(index, tabPage);
            tabPage.CurrentOwner = this;
            this.OnTabPageAdded(new TabPageEventArgs<TPage, TTabPage>(tabPage));
        }

        public void Remove(TPage tabPage)
        {
            if (tabPage == null)
            {
                throw new ArgumentNullException("tabPage");
            }

            if (tabPage.CurrentOwner == this)
            {
                this.pages.Remove(tabPage);
                this.NativeInterface.Remove(tabPage.NativeInterface);
                tabPage.CurrentOwner = null;
                this.OnTabPageRemoved(new TabPageEventArgs<TPage, TTabPage>(tabPage));
            }
        }

        public void RaiseSelectedTabChanged(object sender, EventArgs e)
        {
            this.OnSelectedTabChanged(EventArgs.Empty);
        }

        public IEnumerator<TPage> GetEnumerator()
        {
            return this.pages.GetEnumerator();
        }

        protected virtual void OnTabPageAdded(TabPageEventArgs<TPage, TTabPage> e)
        {
            EventHandler<TabPageEventArgs<TPage, TTabPage>> handler = this.TabPageAdded;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnTabPageRemoved(TabPageEventArgs<TPage, TTabPage> e)
        {
            EventHandler<TabPageEventArgs<TPage, TTabPage>> handler = this.TabPageRemoved;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnSelectedTabChanged(EventArgs e)
        {
            EventHandler handler = this.SelectedTabChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
