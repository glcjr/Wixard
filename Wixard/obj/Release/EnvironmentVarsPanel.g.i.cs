﻿#pragma checksum "..\..\EnvironmentVarsPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "21D6C61066090A32240E1130E906F42F6A5B0862"
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
    /// EnvironmentVarsPanel
    /// </summary>
    public partial class EnvironmentVarsPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\EnvironmentVarsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid EvarList;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\EnvironmentVarsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox EvarsList;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\EnvironmentVarsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid EvarListButtons;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\EnvironmentVarsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddEvar;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\EnvironmentVarsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRmvEvar;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\EnvironmentVarsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddNewEvar;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\EnvironmentVarsPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnupdateaddevar;
        
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
            System.Uri resourceLocater = new System.Uri("/Wixard;component/environmentvarspanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\EnvironmentVarsPanel.xaml"
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
            this.EvarList = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.EvarsList = ((System.Windows.Controls.ListBox)(target));
            
            #line 26 "..\..\EnvironmentVarsPanel.xaml"
            this.EvarsList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.EvarsList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EvarListButtons = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.btnAddEvar = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\EnvironmentVarsPanel.xaml"
            this.btnAddEvar.Click += new System.Windows.RoutedEventHandler(this.btnAddEvar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnRmvEvar = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\EnvironmentVarsPanel.xaml"
            this.btnRmvEvar.Click += new System.Windows.RoutedEventHandler(this.btnRmvEvar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddNewEvar = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.btnupdateaddevar = ((System.Windows.Controls.Button)(target));
            
            #line 114 "..\..\EnvironmentVarsPanel.xaml"
            this.btnupdateaddevar.Click += new System.Windows.RoutedEventHandler(this.btnupdateaddevar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

