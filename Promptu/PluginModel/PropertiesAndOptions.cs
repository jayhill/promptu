﻿//-----------------------------------------------------------------------
// <copyright file="PropertiesAndOptions.cs" company="ZachJohnson">
//     Copyright (c) Zach Johnson. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZachJohnson.Promptu.PluginModel
{
    public class PropertiesAndOptions
    {
        private OptionPage options;
        private ObjectPropertyCollection properties;

        public PropertiesAndOptions()
            : this(new OptionPage(), new ObjectPropertyCollection())
        {
        }

        public PropertiesAndOptions(OptionPage options, ObjectPropertyCollection properties)
        {
            this.options = options;
            this.properties = properties;
        }

        public OptionPage Options
        {
            get { return this.options; }
        }

        public ObjectPropertyCollection Properties
        {
            get { return this.properties; }
        }

        public void ApplyTo(object obj)
        {
            foreach (ObjectPropertyBase property in this.Properties)
            {
                IAppliable appliable = property as IAppliable;

                if (appliable != null)
                {
                    appliable.ApplyTo(obj);
                }
            }
        }
    }
}
