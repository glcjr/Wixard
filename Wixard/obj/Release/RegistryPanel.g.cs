﻿#pragma checksum "..\..\RegistryPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1EAC1A4676A3E1CE652D0CD77FCC3EF3D9B2D7E5"
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
    /// RegistryPanel
    /// </summary>
    public partial class RegistryPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\RegistryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid RegVarList;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\RegistryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox RegVarsList;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\RegistryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid RegVarListButtons;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\RegistryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddRegVar;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\RegistryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRmvRegVar;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\RegistryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddNewRegVar;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\RegistryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRegHive;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\RegistryPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnupdateaddRegVar;
        
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
            System.Uri resourceLocater = new System.Uri("/Wixard;component/registrypanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\RegistryPanel.xaml"
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
            this.RegVarList = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.RegVarsList = ((System.Windows.Controls.ListBox)(target));
            
            #line 25 "..\..\RegistryPanel.xaml"
            this.RegVarsList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.RegVarsList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RegVarListButtons = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.btnAddRegVar = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\RegistryPanel.xaml"
            this.btnAddRegVar.Click += new System.Windows.RoutedEventHandler(this.btnAddRegVar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnRmvRegVar = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\RegistryPanel.xaml"
            this.btnRmvRegVar.Click += new System.Windows.RoutedEventHandler(this.btnRmvRegVar_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddNewRegVar = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.cbRegHive = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.btnupdateaddRegVar = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\RegistryPanel.xaml"
            this.btnupdateaddRegVar.Click += new System.Windows.RoutedEventHandler(this.btnupdateaddRegVar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

