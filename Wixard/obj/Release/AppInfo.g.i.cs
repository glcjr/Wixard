﻿#pragma checksum "..\..\AppInfo.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A5D4A34F6DD738C1F71B485CE4ADDD7BB06C02EF"
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
using Wixard;


namespace Wixard {
    
    
    /// <summary>
    /// AppInfo
    /// </summary>
    public partial class AppInfo : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 46 "..\..\AppInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAppName;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AppInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAppVersion;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\AppInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPubName;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\AppInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtHelpLink;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\AppInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Appicon;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\AppInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnchangeicon;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\AppInfo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveicon;
        
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
            System.Uri resourceLocater = new System.Uri("/Wixard;component/appinfo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AppInfo.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.txtAppName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.txtAppVersion = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtPubName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtHelpLink = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Appicon = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.btnchangeicon = ((System.Windows.Controls.Button)(target));
            
            #line 70 "..\..\AppInfo.xaml"
            this.btnchangeicon.Click += new System.Windows.RoutedEventHandler(this.Btnchangeicon_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnRemoveicon = ((System.Windows.Controls.Button)(target));
            
            #line 73 "..\..\AppInfo.xaml"
            this.btnRemoveicon.Click += new System.Windows.RoutedEventHandler(this.btnRemoveicon_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

