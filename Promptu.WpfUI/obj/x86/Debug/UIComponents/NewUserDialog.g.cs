﻿#pragma checksum "..\..\..\..\UIComponents\NewUserDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4EC3E96D7271C4F01AB31A7B86DD07A7C0E478ADF080580C27B9E2F206427480"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using ZachJohnson.Promptu.WpfUI.UIComponents;


namespace ZachJohnson.Promptu.WpfUI.UIComponents {
    
    
    internal partial class NewUserDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\..\UIComponents\NewUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border stepContainer;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\UIComponents\NewUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.UIComponents.WpfButton backButton;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\UIComponents\NewUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.UIComponents.WpfButton nextButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\UIComponents\NewUserDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.UIComponents.WpfButton cancelButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Promptu.WpfUI;component/uicomponents/newuserdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UIComponents\NewUserDialog.xaml"
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
            this.stepContainer = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.backButton = ((ZachJohnson.Promptu.WpfUI.UIComponents.WpfButton)(target));
            return;
            case 3:
            this.nextButton = ((ZachJohnson.Promptu.WpfUI.UIComponents.WpfButton)(target));
            return;
            case 4:
            this.cancelButton = ((ZachJohnson.Promptu.WpfUI.UIComponents.WpfButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

