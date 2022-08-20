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
    using ZachJohnson.Promptu.UIModel.Interfaces;

    internal class TabWidget : TabWidgetBase<TabPage, ITabPage>
    {
        public TabWidget(string id)
            : this(id, InternalGlobals.GuiManager.ToolkitHost.Factory.ConstructTabControl())
        {
        }

        internal TabWidget(string id, ITabControl nativeInterface)
            : base(id, nativeInterface)
        {
        }
    }
}
