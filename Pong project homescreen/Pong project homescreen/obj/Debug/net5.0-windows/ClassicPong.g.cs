﻿#pragma checksum "..\..\..\ClassicPong.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "320F7A8295842756FEF9151C6416CF95E5630E04"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Pong_project_homescreen;
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


namespace Pong_project_homescreen {
    
    
    /// <summary>
    /// ClassicPong
    /// </summary>
    public partial class ClassicPong : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\ClassicPong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas PongCanvas;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\ClassicPong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Player11;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\ClassicPong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Player22;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\ClassicPong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle Bal2;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\ClassicPong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ScoreP11;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\ClassicPong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label ScoreP22;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\ClassicPong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TimerMin2;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\ClassicPong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TimerSec2;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\ClassicPong.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TimerCs2;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Pong project homescreen;component/classicpong.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ClassicPong.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.PongCanvas = ((System.Windows.Controls.Canvas)(target));
            
            #line 12 "..\..\..\ClassicPong.xaml"
            this.PongCanvas.KeyDown += new System.Windows.Input.KeyEventHandler(this.PongCanvas_KeyDown);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\ClassicPong.xaml"
            this.PongCanvas.KeyUp += new System.Windows.Input.KeyEventHandler(this.PongCanvas_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Player11 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 3:
            this.Player22 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 4:
            this.Bal2 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 5:
            this.ScoreP11 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.ScoreP22 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.TimerMin2 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.TimerSec2 = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.TimerCs2 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

