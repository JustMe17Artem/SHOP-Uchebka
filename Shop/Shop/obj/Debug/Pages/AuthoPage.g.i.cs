﻿#pragma checksum "..\..\..\Pages\AuthoPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9C35ADA12A250034FA27CDCF7E3EE4C130D1E31EEF79C237533791696EF5B390"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Shop.Pages;
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


namespace Shop.Pages {
    
    
    /// <summary>
    /// AuthoPage
    /// </summary>
    public partial class AuthoPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\Pages\AuthoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBLogin;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Pages\AuthoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox TBPassword;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\AuthoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox RememberUser;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\Pages\AuthoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAuthorize;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\Pages\AuthoPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnRegistrate;
        
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
            System.Uri resourceLocater = new System.Uri("/Shop;component/pages/authopage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\AuthoPage.xaml"
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
            this.TBLogin = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TBPassword = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 3:
            this.RememberUser = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 4:
            this.BtnAuthorize = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\Pages\AuthoPage.xaml"
            this.BtnAuthorize.Click += new System.Windows.RoutedEventHandler(this.BtnAuthorize_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BtnRegistrate = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Pages\AuthoPage.xaml"
            this.BtnRegistrate.Click += new System.Windows.RoutedEventHandler(this.BtnRegistrate_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

