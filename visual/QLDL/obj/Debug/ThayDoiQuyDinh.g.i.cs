﻿#pragma checksum "..\..\ThayDoiQuyDinh.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8F84BBB8048A34A3EC7C8FB14DB41AFCB5E0ED65C2800C001E90F859766BAC14"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using QLDL;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace QLDL {
    
    
    /// <summary>
    /// ThayDoiQuyDinh
    /// </summary>
    public partial class ThayDoiQuyDinh : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\ThayDoiQuyDinh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ThayDoiQuyDinhButton;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\ThayDoiQuyDinh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button QLDLVDVButton;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\ThayDoiQuyDinh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\ThayDoiQuyDinh.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.UserControl usc;
        
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
            System.Uri resourceLocater = new System.Uri("/QLDL;component/thaydoiquydinh.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ThayDoiQuyDinh.xaml"
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
            this.ThayDoiQuyDinhButton = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\ThayDoiQuyDinh.xaml"
            this.ThayDoiQuyDinhButton.Click += new System.Windows.RoutedEventHandler(this.ThayDoiQuyDinhButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.QLDLVDVButton = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\ThayDoiQuyDinh.xaml"
            this.QLDLVDVButton.Click += new System.Windows.RoutedEventHandler(this.QLDLVDVButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.usc = ((System.Windows.Controls.UserControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

