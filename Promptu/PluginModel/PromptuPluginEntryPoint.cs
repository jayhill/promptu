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

namespace ZachJohnson.Promptu.PluginModel
{
    using System;
    using System.Collections.Generic;
    using ZachJohnson.Promptu.Configuration;

    public abstract class PromptuPluginEntryPoint
    {
        private PromptuHooks hooks = new PromptuHooks();
        private IList<NamedOptionPage> options = InternalGlobals.GuiManager.ToolkitHost.Factory.ConstructBindingList<NamedOptionPage>();
        private ObjectPropertyCollection savingProperties = new ObjectPropertyCollection();
        private bool isEnabled;
        private SettingsBase savingSettings;
        private PromptuPluginFactory factory = new PromptuPluginFactory();

        public PromptuPluginEntryPoint()
        {
        }

        internal event EventHandler SavingSettingsChanged;

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            internal set { this.isEnabled = value; }
        }

        public IList<NamedOptionPage> Options
        {
            get { return this.options; }
        }

        public ObjectPropertyCollection SavingProperties
        {
            get { return this.savingProperties; }
        }

        public SettingsBase SavingSettings
        {
            get
            {
                return this.savingSettings;
            }

            set
            {
                SettingsBase previousSettings = this.savingSettings;
                if (previousSettings != null)
                {
                    previousSettings.SettingChanged -= this.HandleSavingSettingChanged;
                }

                this.savingSettings = value;

                if (value != null)
                {
                    value.SettingChanged += this.HandleSavingSettingChanged;
                }
            }
        }

        protected internal PromptuPluginFactory Factory
        {
            get { return this.factory; }
        }

        protected internal PromptuHooks Hooks
        {
            get { return this.hooks; }
        }

        protected internal virtual void OnLoad()
        {
        }

        protected internal virtual void OnUnload()
        {
        }

        protected void ShowOptionsDialog()
        {
            InternalGlobals.PluginConfigWindowManager.ShowConfigFor(this);
        }

        private void HandleSavingSettingChanged(object sender, EventArgs e)
        {
            this.OnSavingSettingsChanged(EventArgs.Empty);
        }

        private void OnSavingSettingsChanged(EventArgs e)
        {
            EventHandler handler = this.SavingSettingsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
