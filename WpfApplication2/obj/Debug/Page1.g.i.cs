﻿#pragma checksum "..\..\Page1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "10FD8D7EB36F51949AE0540A80352E4A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
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


namespace WpfApplication2 {
    
    
    /// <summary>
    /// Page1
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
    public partial class Page1 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 4 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WpfApplication2.Page1 Page;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard ShipwreckHover_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard JungleHover_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.Animation.BeginStoryboard TempleHover_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas MainCanvas;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border JungleB;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Jungle;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ShipB;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Shipwreck;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border TempleB;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image Temple;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse rightEllipse;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\Page1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse leftEllipse;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApplication2;component/page1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Page1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Page = ((WpfApplication2.Page1)(target));
            
            #line 8 "..\..\Page1.xaml"
            this.Page.Loaded += new System.Windows.RoutedEventHandler(this.setUpKinect);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Page1.xaml"
            this.Page.Unloaded += new System.Windows.RoutedEventHandler(this.removeNUIEventHandler);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ShipwreckHover_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 3:
            this.JungleHover_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 4:
            this.TempleHover_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 5:
            this.MainCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.JungleB = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.Jungle = ((System.Windows.Controls.Image)(target));
            
            #line 50 "..\..\Page1.xaml"
            this.Jungle.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.selectSetting);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ShipB = ((System.Windows.Controls.Border)(target));
            return;
            case 9:
            this.Shipwreck = ((System.Windows.Controls.Image)(target));
            
            #line 53 "..\..\Page1.xaml"
            this.Shipwreck.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.selectSetting);
            
            #line default
            #line hidden
            return;
            case 10:
            this.TempleB = ((System.Windows.Controls.Border)(target));
            return;
            case 11:
            this.Temple = ((System.Windows.Controls.Image)(target));
            
            #line 56 "..\..\Page1.xaml"
            this.Temple.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.selectSetting);
            
            #line default
            #line hidden
            return;
            case 12:
            this.rightEllipse = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 13:
            this.leftEllipse = ((System.Windows.Shapes.Ellipse)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

