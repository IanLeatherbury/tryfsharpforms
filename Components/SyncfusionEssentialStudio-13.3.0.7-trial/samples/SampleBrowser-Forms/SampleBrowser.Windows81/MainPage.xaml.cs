#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfDataGrid.XForms.WinRT;
using Syncfusion.SfChart.XForms.WinRT;
using Syncfusion.SfBarcode.XForms.WinRT;
using Syncfusion.SfGauge.XForms.WinRT;
using Syncfusion.SfAutoComplete.XForms.WinRT;
using Syncfusion.SfNumericTextBox.XForms.WinRT;
using Syncfusion.SfRangeSlider.XForms.WinRT;
using Syncfusion.SfBusyIndicator.XForms.WinRT;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SampleBrowser.Windows81
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            SampleBrowser.App.ScreenWidth = Window.Current.Bounds.Width;
            new SfChartRenderer();
            new SfGaugeRenderer();
            new SfBarcodeRenderer();
            new SfBusyIndicatorRenderer();
            new SfAutoCompleteRenderer();
            new SfRangeSliderRenderer();
            new SfNumericTextBoxRenderer();
            SfDataGridRenderer.Init();
            LoadApplication(new SampleBrowser.App());
        }
    }
}
