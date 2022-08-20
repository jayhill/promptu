﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ZachJohnson.Promptu.UIModel.Interfaces;

namespace ZachJohnson.Promptu.WpfUI.UIComponents
{
    /// <summary>
    /// Interaction logic for OptionsDialog.xaml
    /// </summary>
    internal partial class OptionsDialog : PromptuWindow, IOptionsDialog
    {
        public OptionsDialog()
        {
            InitializeComponent();
        }

        public ITabControl SuperTabs
        {
            get { return this.superTabs; }
        }

        public string Text
        {
            get { return this.Title; }
            set { this.Title = value; }
        }

        public UIModel.UIDialogResult ShowModal()
        {
            return WpfToolkitHost.ShowDialogUIDialogResult(this);
        }

        public IButton OkButton
        {
            get { return this.okButton; }
        }

        public void ActivateAndBringToFront()
        {
            this.Activate();
        }
    }
}
