﻿#pragma checksum "..\..\UsersPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E641CA154D7845CDDED996B363FFFF1933DEAE73"
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
    /// UsersPanel
    /// </summary>
    public partial class UsersPanel : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\UsersPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid UserList;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\UsersPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox UsersList;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\UsersPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid UserListButtons;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\UsersPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddUser;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\UsersPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRmvUser;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\UsersPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid AddNewUser;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\UsersPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnupdateadduser;
        
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
            System.Uri resourceLocater = new System.Uri("/Wixard;component/userspanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\UsersPanel.xaml"
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
            this.UserList = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.UsersList = ((System.Windows.Controls.ListBox)(target));
            
            #line 26 "..\..\UsersPanel.xaml"
            this.UsersList.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.UsersList_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            this.UserListButtons = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.btnAddUser = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\UsersPanel.xaml"
            this.btnAddUser.Click += new System.Windows.RoutedEventHandler(this.btnAddUser_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnRmvUser = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\UsersPanel.xaml"
            this.btnRmvUser.Click += new System.Windows.RoutedEventHandler(this.btnRmvUser_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AddNewUser = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.btnupdateadduser = ((System.Windows.Controls.Button)(target));
            
            #line 86 "..\..\UsersPanel.xaml"
            this.btnupdateadduser.Click += new System.Windows.RoutedEventHandler(this.btnupdateadduser_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

