#pragma checksum "..\..\..\SemesterWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90041FFBE27FF0A169004B19B0D1AF1F3FADCB8B"
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
    /// SemesterWindow
    /// </summary>
    public partial class SemesterWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal TimeManagementApp.SemesterWindow wndNewSemester;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblSemesterName;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSemesterName;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNumWeeks;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtNumWeeks;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblStartDate;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dtpStartDate;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblModules;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlusModule;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinusModule;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstModules;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\SemesterWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubmit;
        
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
            System.Uri resourceLocater = new System.Uri("/TimeManagementApp;component/semesterwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SemesterWindow.xaml"
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
            this.wndNewSemester = ((TimeManagementApp.SemesterWindow)(target));
            
            #line 8 "..\..\..\SemesterWindow.xaml"
            this.wndNewSemester.Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblSemesterName = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.txtSemesterName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.lblNumWeeks = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.txtNumWeeks = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\SemesterWindow.xaml"
            this.txtNumWeeks.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.lblStartDate = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.dtpStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 8:
            this.lblModules = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.btnPlusModule = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\SemesterWindow.xaml"
            this.btnPlusModule.Click += new System.Windows.RoutedEventHandler(this.btnPlusModule_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnMinusModule = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\SemesterWindow.xaml"
            this.btnMinusModule.Click += new System.Windows.RoutedEventHandler(this.btnMinusModule_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.lstModules = ((System.Windows.Controls.ListBox)(target));
            return;
            case 12:
            this.btnSubmit = ((System.Windows.Controls.Button)(target));
            
            #line 36 "..\..\..\SemesterWindow.xaml"
            this.btnSubmit.Click += new System.Windows.RoutedEventHandler(this.btnSubmit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

