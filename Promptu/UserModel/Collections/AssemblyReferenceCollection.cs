﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Xml;
using System.IO;
using ZachJohnson.Promptu.Collections;
using ZachJohnson.Promptu.UserModel.Differencing;

namespace ZachJohnson.Promptu.UserModel.Collections
{
    internal class AssemblyReferenceCollection : ItemWithIdChangeNotifiedList<AssemblyReference>, IDisposable
    {
        internal const string XmlAlias = "assemblyreferences";

        public AssemblyReferenceCollection()
        {
            //this.syncCallback = syncCallback;
        }

        public event EventHandler<ItemEventArgs<AssemblyReference>> ItemCachedNameChanged;

        //public ParameterlessVoid SyncCallback
        //{
        //    get { return this.syncCallback; }
        //}

        public AssemblyReference this[string name]
        {
            get
            {
                using (DdMonitor.Lock(this))
                {
                    foreach (AssemblyReference reference in this)
                    {
                        if (reference.Name == name)
                        {
                            return reference;
                        }
                    }
                }

                throw new ArgumentOutOfRangeException("No AssemblyReference with that name was found in the list.");
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            this.Clear();
        }

        public AssemblyReferenceCollection Clone()
        {
            return this.CloneCore();
        }

        protected virtual AssemblyReferenceCollection CloneCore()
        {
            AssemblyReferenceCollection clone = new AssemblyReferenceCollection();
            using (DdMonitor.Lock(this))
            {
                foreach (AssemblyReference item in this)
                {
                    clone.Add(item.Clone(item.SyncCallback));
                }
            }

            return clone;
        }

        public TrieList GetNames()
        {
            TrieList names = new TrieList(SortMode.Alphabetical);
            using (DdMonitor.Lock(this))
            {
                foreach (AssemblyReference reference in this)
                {
                    names.Add(reference.Name);
                }
            }

            return names;
        }

        public bool Remove(string name)
        {
            AssemblyReference toRemove = null;
            using (DdMonitor.Lock(this))
            {
                foreach (AssemblyReference reference in this)
                {
                    if (reference.Name == name)
                    {
                        toRemove = reference;
                    }
                }

                if (toRemove == null)
                {
                    return false;
                }
                else
                {
                    this.Remove(toRemove);
                    return true;
                }
            }
        }

        public bool Contains(string name)
        {
            using (DdMonitor.Lock(this))
            {
                foreach (AssemblyReference reference in this)
                {
                    if (reference.Name == name)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public AssemblyReference TryGet(string name)
        {
            int? index;
            return this.TryGet(name, out index);
        }

        public AssemblyReference TryGet(string name, out int? index)
        {
            using (DdMonitor.Lock(this))
            {
                for (int i = 0; i < this.Count; i++)
                {
                    AssemblyReference reference = this[i];
                    if (reference.Name == name)
                    {
                        index = i;
                        return reference;
                    }
                }
            }

            index = null;
            return null;
        }

        //public AssemblyReference TryGet(string name, AssemblyReferenceIdentifierChangeCollection identifierChanges, out int? index)
        //{
        //    if (identifierChanges == null)
        //    {
        //        return this.TryGet(name, out index);
        //    }

        //    for (int i = 0; i < this.Count; i++)
        //    {
        //        AssemblyReference reference = this[i];
        //        IAssemblyReference compareAs;

        //        AssemblyReferenceIdentifierChange change = identifierChanges.TryGetIdentifierChangeFromRevisedItem(reference);

        //        if (change != null)
        //        {
        //            compareAs = change.CreateFilter(ItemType.Base);
        //        }
        //        else
        //        {
        //            compareAs = reference;
        //        }

        //        if (compareAs.Name == name)
        //        {
        //            index = i;
        //            return reference;
        //        }
        //    }

        //    index = null;
        //    return null;
        //}

        public FunctionCollection LoadAllLoadExportedFunctions()
        {
            FunctionCollection collection = new FunctionCollection();
            // TODO add collision handling
            foreach (AssemblyReference reference in this)
            {
                collection.AddRange(reference.LoadExportedFunctions());
            }

            return collection;
        }

        public static AssemblyReferenceCollection FromXml(XmlNode node, ParameterlessVoid syncCallback)
        {
            TrieList loadedNames = new TrieList(SortMode.DecendingFromLastAdded);
            List<int> loadedIds = new List<int>();
            AssemblyReferenceCollection references = new AssemblyReferenceCollection();
            if (node.Name.ToLowerInvariant() == XmlAlias)
            {
                foreach (XmlNode innerNode in node.ChildNodes)
                {
                    if (innerNode.Name.ToLowerInvariant() == AssemblyReference.XmlAlias)
                    {
                        try
                        {
                            // 2010-07-28: removing check for cached name
                            AssemblyReference assemblyReference = AssemblyReference.FromXml(innerNode, syncCallback);
                            if (!loadedNames.Contains(assemblyReference.Name, CaseSensitivity.Insensitive))
                                //&& !string.IsNullOrEmpty(assemblyReference.CachedName))
                            {
                                if (assemblyReference.Id != null)
                                {
                                    if (!loadedIds.Contains(assemblyReference.Id.Value))
                                    {
                                        loadedIds.Add(assemblyReference.Id.Value);
                                    }
                                    else
                                    {
                                        assemblyReference.Id = null;
                                    }
                                }

                                references.Add(assemblyReference);
                                loadedNames.Add(assemblyReference.Name);
                            }
                            else
                            {
                            }
                        }
                        catch (LoadException)
                        {
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentException("The node is not named " + XmlAlias + ".");
            }

            return references;
        }

        public XmlNode ToXml(XmlDocument document)
        {
            XmlNode node = document.CreateElement("AssemblyReferences");
            using (DdMonitor.Lock(this))
            {
                foreach (AssemblyReference item in this)
                {
                    node.AppendChild(item.ToXml(document));
                }
            }

            return node;
        }

        protected override List<AssemblyReference> GetConflictsWithCore(AssemblyReference item)
        {
            List<AssemblyReference> conficts = new List<AssemblyReference>();
            if (item != null)
            {
                AssemblyReference assemblyReference = this.TryGet(item.Name);
                if (assemblyReference != null)
                {
                    conficts.Add(assemblyReference);
                }
            }

            return conficts;
        }

        //public AssemblyReference[] ToArray()
        //{
        //    AssemblyReference[] references = new AssemblyReference[this.Count];
        //    this.CopyTo(references, 0);
        //    return references;
        //}

        protected override void OnItemAdded(ItemAndIndexEventArgs<AssemblyReference> e)
        {
            e.Item.CachedNameChanged += this.ForwardItemCachedNameChanged;
            base.OnItemAdded(e);
        }

        protected override void OnItemRemoved(ItemAndIndexEventArgs<AssemblyReference> e)
        {
            e.Item.CachedNameChanged -= this.ForwardItemCachedNameChanged;
            base.OnItemRemoved(e);
        }

        protected virtual void OnItemCachedNameChanged(ItemEventArgs<AssemblyReference> e)
        {
            EventHandler<ItemEventArgs<AssemblyReference>> handler = this.ItemCachedNameChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        private void ForwardItemCachedNameChanged(object sender, EventArgs e)
        {
            this.OnItemCachedNameChanged(new ItemEventArgs<AssemblyReference>(sender as AssemblyReference));
        }
    }
}
