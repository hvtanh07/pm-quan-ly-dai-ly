﻿#pragma checksum "..\..\ChiTietBaoCaoDoanhSo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "542B460A586DCA5E801F9903984CB66D0ECE4628AAB27BA676695BDE2520864B"
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
    /// ChiTietBaoCaoDoanhSo
    /// </summary>
    public partial class ChiTietBaoCaoDoanhSo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\ChiTietBaoCaoDoanhSo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Matxt;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\ChiTietBaoCaoDoanhSo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock thang;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\ChiTietBaoCaoDoanhSo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tongtientxt;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\ChiTietBaoCaoDoanhSo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonXacNhan;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\ChiTietBaoCaoDoanhSo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtKeyword;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\ChiTietBaoCaoDoanhSo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button1;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\ChiTietBaoCaoDoanhSo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView dsDL;
        
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
            System.Uri resourceLocater = new System.Uri("/QLDL;component/chitietbaocaodoanhso.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\ChiTietBaoCaoDoanhSo.xaml"
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
            
            #line 11 "..\..\ChiTietBaoCaoDoanhSo.xaml"
            ((QLDL.ChiTietBaoCaoDoanhSo)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 13 "..\..\ChiTietBaoCaoDoanhSo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Matxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.thang = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.tongtientxt = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.ButtonXacNhan = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\ChiTietBaoCaoDoanhSo.xaml"
            this.ButtonXacNhan.Click += new System.Windows.RoutedEventHandler(this.ButtonXacNhan_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.txtKeyword = ((System.Windows.Controls.TextBox)(target));
            
            #line 32 "..\..\ChiTietBaoCaoDoanhSo.xaml"
            this.txtKeyword.KeyDown += new System.Windows.Input.KeyEventHandler(this.TxtKeyword_KeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.button1 = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\ChiTietBaoCaoDoanhSo.xaml"
            this.button1.Click += new System.Windows.RoutedEventHandler(this.Search_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.dsDL = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

