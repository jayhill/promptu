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
    /// Interaction logic for RenameDialog.xaml
    /// </summary>
    internal partial class RenameDialog : Window, IRenameDialog
    {
        public RenameDialog()
        {
            InitializeComponent();
        }

        public ITextInput Value
        {
            get { return this.value; }
        }

        public IButton OkButton
        {
            get { return this.okButton; }
        }

        public IButton CancelButton
        {
            get { return this.cancelButton; }
        }

        public string MainInstructions
        {
            set { this.mainInstructions.Content = value; }
        }

        public bool ShowCancelButton
        {
            get
            {
                return this.cancelButton.Visibility == Visibility.Visible;
            }
            set
            {
                this.cancelButton.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
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
    }
}
