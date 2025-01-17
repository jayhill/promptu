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

namespace System.IO.Extensions
{
    using System.IO;
    using System.Reflection;

    internal static class StringReaderExtensions
    {
        private static FieldInfo positionInfo;

        public static int GetPosition(this StringReader reader)
        {
            if (positionInfo == null)
            {
                positionInfo = reader.GetType().GetField("_pos", BindingFlags.Instance | BindingFlags.NonPublic);
            }

            return (int)positionInfo.GetValue(reader);
        }
    }
}
