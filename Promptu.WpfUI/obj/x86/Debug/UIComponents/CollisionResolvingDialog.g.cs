﻿#pragma checksum "..\..\..\..\UIComponents\CollisionResolvingDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5B1CAF87DFCC40AF474EA8D88FF17CA9A3B206C9C5DCDFBD9AAA23A1309F8461"
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
    
    
    internal partial class CollisionResolvingDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 201 "..\..\..\..\UIComponents\CollisionResolvingDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock mainInstructions;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\..\UIComponents\CollisionResolvingDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.UIComponents.CommandLink userChange;
        
        #line default
        #line hidden
        
        
        #line 203 "..\..\..\..\UIComponents\CollisionResolvingDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.UIComponents.CommandLink externalChange;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\..\UIComponents\CollisionResolvingDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ZachJohnson.Promptu.WpfUI.UIComponents.WpfCheckBox doForTheRemaining;
        
        #line default
        #line hidden
        
        
        #line 214 "..\..\..\..\UIComponents\CollisionResolvingDialog.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Promptu.WpfUI;component/uicomponents/collisionresolvingdialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UIComponents\CollisionResolvingDialog.xaml"
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
            this.mainInstructions = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.userChange = ((ZachJohnson.Promptu.WpfUI.UIComponents.CommandLink)(target));
            return;
            case 3:
            this.externalChange = ((ZachJohnson.Promptu.WpfUI.UIComponents.CommandLink)(target));
            return;
            case 4:
            this.doForTheRemaining = ((ZachJohnson.Promptu.WpfUI.UIComponents.WpfCheckBox)(target));
            return;
            case 5:
            this.cancelButton = ((ZachJohnson.Promptu.WpfUI.UIComponents.WpfButton)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
