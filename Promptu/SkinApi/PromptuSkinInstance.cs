﻿//-----------------------------------------------------------------------
// <copyright file="PromptuSkinInstance.cs" company="ZachJohnson">
//     Copyright (c) Zach Johnson. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ZachJohnson.Promptu.SkinApi
{
    using ZachJohnson.Promptu.PluginModel;
    using ZachJohnson.Promptu.Skins;

    public class PromptuSkinInstance
    {
        private ILayoutManager layoutManager;
        private IPrompt prompt;
        private ISuggestionProvider suggestionProvider;
        private PropertiesAndOptions informationBoxPropertiesAndOptions;

        public PromptuSkinInstance(
            ILayoutManager layoutManager, 
            IPrompt prompt, 
            ISuggestionProvider suggestionProvider,
            PropertiesAndOptions informationBoxPropertiesAndOptions)
            : this(
                layoutManager, 
                prompt, 
                suggestionProvider,
                informationBoxPropertiesAndOptions,
                false)
        {
        }

        internal PromptuSkinInstance(
            ILayoutManager layoutManager,
            IPrompt prompt,
            ISuggestionProvider suggestionProvider,
            PropertiesAndOptions informationBoxPropertiesAndOptions,
            bool isDefault)
        {
            this.informationBoxPropertiesAndOptions =
                informationBoxPropertiesAndOptions ??
                InternalGlobals.GuiManager.ToolkitHost.Factory.ConstructDefaultInformationBoxPropertiesAndOptions();

            if (!isDefault)
            {
                PromptuSkinInstance defaultSkin = InternalGlobals.GuiManager.ToolkitHost.CreateDefaultSkinInstance();
                this.layoutManager = layoutManager ?? defaultSkin.LayoutManager;
                this.prompt = prompt ?? defaultSkin.Prompt;
                this.suggestionProvider = suggestionProvider ?? defaultSkin.SuggestionProvider;
            }
            else
            {
                this.layoutManager = layoutManager;
                this.prompt = prompt;
                this.suggestionProvider = suggestionProvider;
            }
        }

        public PropertiesAndOptions InformationBoxPropertiesAndOptions
        {
            get { return this.informationBoxPropertiesAndOptions; }
        }

        public ILayoutManager LayoutManager
        {
            get { return this.layoutManager; }
        }

        public IPrompt Prompt
        {
            get { return this.prompt; }
        }

        public ISuggestionProvider SuggestionProvider
        {
            get { return this.suggestionProvider; }
        }

        public ITextInfoBox CreateTextInfoBox()
        {
            ITextInfoBox infoBox = this.CreateTextInfoBoxCore();
            if (infoBox == null)
            {
                infoBox = InternalGlobals.GuiManager.ToolkitHost.Factory.ConstructDefaultTextInfoBox();
            }

            PropertiesAndOptions propertiesAndOptions = this.InformationBoxPropertiesAndOptions;
            propertiesAndOptions.ApplyTo(infoBox);
            return infoBox;
        }

        public IProgressInfoBox CreateProgressInfoBox()
        {
            IProgressInfoBox infoBox = this.CreateProgressInfoBoxCore();
            if (infoBox == null)
            {
                infoBox = InternalGlobals.GuiManager.ToolkitHost.Factory.ConstructDefaultProgressInfoBox();
            }

            PropertiesAndOptions propertiesAndOptions = this.InformationBoxPropertiesAndOptions;
            propertiesAndOptions.ApplyTo(infoBox);
            return infoBox;
        }

        public void GiveContextualErrorMessage(string message)
        {
            PromptHandler.GetInstance().GiveContextualError(message);
        }

        protected virtual ITextInfoBox CreateTextInfoBoxCore()
        {
            return null;
        }

        protected virtual IProgressInfoBox CreateProgressInfoBoxCore()
        {
            return null;
        }
    }
}