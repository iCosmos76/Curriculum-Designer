﻿#pragma checksum "..\..\..\ListKategoriy.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C121B28A890525F0951E862924601E4AC4DB0D6D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kernel_of_curriculum;
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
using Xceed.Wpf.Toolkit;
using Xceed.Wpf.Toolkit.Chromes;
using Xceed.Wpf.Toolkit.Converters;
using Xceed.Wpf.Toolkit.Core;
using Xceed.Wpf.Toolkit.Core.Converters;
using Xceed.Wpf.Toolkit.Core.Input;
using Xceed.Wpf.Toolkit.Core.Media;
using Xceed.Wpf.Toolkit.Core.Utilities;
using Xceed.Wpf.Toolkit.Mag.Converters;
using Xceed.Wpf.Toolkit.Panels;
using Xceed.Wpf.Toolkit.Primitives;
using Xceed.Wpf.Toolkit.PropertyGrid;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using Xceed.Wpf.Toolkit.PropertyGrid.Commands;
using Xceed.Wpf.Toolkit.PropertyGrid.Converters;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using Xceed.Wpf.Toolkit.Zoombox;


namespace Kernel_of_curriculum {
    
    
    /// <summary>
    /// ListKategoriy
    /// </summary>
    public partial class ListKategoriy : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\ListKategoriy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtKategories;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\ListKategoriy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGridTextColumn nmKat;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\ListKategoriy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSelectKat;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\ListKategoriy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddKat;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\ListKategoriy.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelKat;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Kernel_of_curriculum;component/listkategoriy.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ListKategoriy.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.2.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.dtKategories = ((System.Windows.Controls.DataGrid)(target));
            
            #line 31 "..\..\..\ListKategoriy.xaml"
            this.dtKategories.BeginningEdit += new System.EventHandler<System.Windows.Controls.DataGridBeginningEditEventArgs>(this.dtKategories_BeginningEdit);
            
            #line default
            #line hidden
            
            #line 32 "..\..\..\ListKategoriy.xaml"
            this.dtKategories.RowEditEnding += new System.EventHandler<System.Windows.Controls.DataGridRowEditEndingEventArgs>(this.dtKategories_RowEditEnding);
            
            #line default
            #line hidden
            
            #line 33 "..\..\..\ListKategoriy.xaml"
            this.dtKategories.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.dtKategories_CellEditEnding);
            
            #line default
            #line hidden
            return;
            case 2:
            this.nmKat = ((System.Windows.Controls.DataGridTextColumn)(target));
            return;
            case 3:
            this.btnSelectKat = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\ListKategoriy.xaml"
            this.btnSelectKat.Click += new System.Windows.RoutedEventHandler(this.btnSelectKat_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAddKat = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\ListKategoriy.xaml"
            this.btnAddKat.Click += new System.Windows.RoutedEventHandler(this.btnAddKat_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnDelKat = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\ListKategoriy.xaml"
            this.btnDelKat.Click += new System.Windows.RoutedEventHandler(this.btnDelKat_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

