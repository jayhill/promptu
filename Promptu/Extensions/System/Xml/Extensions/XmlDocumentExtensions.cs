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

namespace System.Xml.Extensions
{
    using System;
    using System.Xml;

    internal static class XmlDocumentExtensions
    {
        public static void AppendHeader(this XmlDocument document)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }

            document.AppendChild(document.CreateProcessingInstruction("xml", "version=\"1.0\""));
        }

        public static XmlNode CreateNewNode(this XmlDocument document, string name, string value)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }
            else if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            else if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            XmlNode node = document.CreateElement(name);
            node.InnerText = value;
            return node;
        }
    }
}
