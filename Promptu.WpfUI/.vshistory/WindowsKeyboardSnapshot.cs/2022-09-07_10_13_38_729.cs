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

namespace ZachJohnson.Promptu.WpfUI
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using ZachJohnson.Promptu.UIModel;

    internal class WindowsKeyboardSnapshot : KeyboardSnapshot
    {
        private byte[] keyStates;

        public WindowsKeyboardSnapshot()
        {
            this.keyStates = new byte[255];
            NativeMethods.GetKeyboardState(this.keyStates);
        }

        protected override bool KeyPressedCore(Keys key)
        {
            int index = (int)key;
            if (index >= 0 && index < this.keyStates.Length)
            {
                byte keyState = this.keyStates[index];
                switch (keyState >> 7)
                {
                    case 1:
                        return true;
                    default:
                        break;
                }
            }

            return false;
        }
    }
}