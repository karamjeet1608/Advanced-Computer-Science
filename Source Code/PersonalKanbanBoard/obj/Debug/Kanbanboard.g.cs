﻿#pragma checksum "..\..\Kanbanboard.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "608308BCCE9C9E27EA93B293BD3A9FA87112D58068D265A20F0A5637115C042D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PersonalKanbanBoard;
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


namespace PersonalKanbanBoard {
    
    
    /// <summary>
    /// Kanbanboard
    /// </summary>
    public partial class Kanbanboard : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid todo;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox taskstodo;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox tasksinprogress;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox tasksdone;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button createtask;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button gotoProjectboard;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel prodetail;
        
        #line default
        #line hidden
        
        
        #line 83 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock projecttitle;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock todolimit;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock wiplimit;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\Kanbanboard.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock donelimit;
        
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
            System.Uri resourceLocater = new System.Uri("/PersonalKanbanBoard;component/kanbanboard.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Kanbanboard.xaml"
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
            
            #line 8 "..\..\Kanbanboard.xaml"
            ((PersonalKanbanBoard.Kanbanboard)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.todo = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.taskstodo = ((System.Windows.Controls.ListBox)(target));
            
            #line 17 "..\..\Kanbanboard.xaml"
            this.taskstodo.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Taskstodo_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.tasksinprogress = ((System.Windows.Controls.ListBox)(target));
            
            #line 37 "..\..\Kanbanboard.xaml"
            this.tasksinprogress.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Tasksinprogress_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.tasksdone = ((System.Windows.Controls.ListBox)(target));
            
            #line 56 "..\..\Kanbanboard.xaml"
            this.tasksdone.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Tasksdone_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.createtask = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\Kanbanboard.xaml"
            this.createtask.Click += new System.Windows.RoutedEventHandler(this.createtask_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.gotoProjectboard = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\Kanbanboard.xaml"
            this.gotoProjectboard.Click += new System.Windows.RoutedEventHandler(this.GotoProjectboard_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.prodetail = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 9:
            this.projecttitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.todolimit = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.wiplimit = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.donelimit = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

