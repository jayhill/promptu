﻿#pragma checksum "..\..\..\..\UIComponents\SetupPanel.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "15945C9F868E701B41BE7C05C004F96134BA32B25C8DE5969BEDE92E1C259490"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Windows.Themes;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using ZachJohnson.Promptu.WpfUI;
using ZachJohnson.Promptu.WpfUI.UIComponents;


namespace ZachJohnson.Promptu.WpfUI {
    
    
    internal partial class SetupPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\..\..\UIComponents\SetupPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.SetupPanel UserControl;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\UIComponents\SetupPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock itemsCountDisplay;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\UIComponents\SetupPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.UIComponents.WpfToolbarButton newItemButton;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\..\UIComponents\SetupPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.UIComponents.WpfToolbarButton editItemButton;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\..\UIComponents\SetupPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.UIComponents.WpfToolbarButton deleteItemButton;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\UIComponents\SetupPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.UIComponents.SimpleCollectionViewer collectionViewer;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\UIComponents\SetupPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.GridView grid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Promptu.WpfUI;component/uicomponents/setuppanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UIComponents\SetupPanel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UserControl = ((ZachJohnson.Promptu.WpfUI.SetupPanel)(target));
            return;
            case 2:
            this.itemsCountDisplay = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.newItemButton = ((ZachJohnson.Promptu.WpfUI.UIComponents.WpfToolbarButton)(target));
            return;
            case 4:
            this.editItemButton = ((ZachJohnson.Promptu.WpfUI.UIComponents.WpfToolbarButton)(target));
            return;
            case 5:
            this.deleteItemButton = ((ZachJohnson.Promptu.WpfUI.UIComponents.WpfToolbarButton)(target));
            return;
            case 6:
            this.collectionViewer = ((ZachJohnson.Promptu.WpfUI.UIComponents.SimpleCollectionViewer)(target));
            return;
            case 7:
            this.grid = ((System.Windows.Controls.GridView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

