﻿#pragma checksum "..\..\..\ModuleDataPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "117E46C4203FB3257B8CA05408B2ED96AFB96580"
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
using System.Windows.Controls.Ribbon;
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
using TimeManagementApp;


namespace TimeManagementApp {
    
    
    /// <summary>
    /// ModuleDataPage
    /// </summary>
    public partial class ModuleDataPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TimeManagementApp.ModuleDataPage pgModuleData;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RowDefinition DataRow;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblHoursWorked;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel stkInput;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox chkToday;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpHoursWorked;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtHoursWorked;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnConfirm;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border brdData;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txbModuleData;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\ModuleDataPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnViewSemester;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TimeManagementApp;component/moduledatapage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ModuleDataPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.pgModuleData = ((TimeManagementApp.ModuleDataPage)(target));
            return;
            case 2:
            this.DataRow = ((System.Windows.Controls.RowDefinition)(target));
            return;
            case 3:
            this.lblHoursWorked = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.stkInput = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.chkToday = ((System.Windows.Controls.CheckBox)(target));
            
            #line 22 "..\..\..\ModuleDataPage.xaml"
            this.chkToday.Checked += new System.Windows.RoutedEventHandler(this.chkToday_Checked);
            
            #line default
            #line hidden
            
            #line 22 "..\..\..\ModuleDataPage.xaml"
            this.chkToday.Unchecked += new System.Windows.RoutedEventHandler(this.chkToday_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dtpHoursWorked = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 7:
            this.txtHoursWorked = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\ModuleDataPage.xaml"
            this.txtHoursWorked.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnConfirm = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\ModuleDataPage.xaml"
            this.btnConfirm.Click += new System.Windows.RoutedEventHandler(this.btnConfirm_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.brdData = ((System.Windows.Controls.Border)(target));
            return;
            case 10:
            this.txbModuleData = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.btnViewSemester = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\..\ModuleDataPage.xaml"
            this.btnViewSemester.Click += new System.Windows.RoutedEventHandler(this.btnViewSemester_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
