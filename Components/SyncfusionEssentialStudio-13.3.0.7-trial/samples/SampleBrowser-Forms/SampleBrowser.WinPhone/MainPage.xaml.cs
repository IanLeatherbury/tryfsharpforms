#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Syncfusion.SfChart.XForms.WinPhone;
using Syncfusion.SfBusyIndicator.XForms.WinPhone;
using Syncfusion.SfGauge.XForms.WinPhone;
using Syncfusion.SfRangeSlider.XForms.WinPhone;
using Syncfusion.SfDataGrid.XForms.WinPhone;
using Syncfusion.SfBarcode.XForms.WinPhone;
using Syncfusion.SfNumericTextBox.XForms.WinPhone;
using Syncfusion.SfAutoComplete.XForms.WinPhone;
using Syncfusion.SfTreeMap.XForms;
using Syncfusion.SfTreeMap.XForms.WinPhone;

namespace SampleBrowser.WinPhone
{
    public partial class MainPage : global::Xamarin.Forms.Platform.WinPhone.FormsApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            SampleBrowser.App.ScreenWidth = System.Windows.Application.Current.Host.Content.ActualWidth;

            SupportedOrientations = SupportedPageOrientation.PortraitOrLandscape;
            global::Xamarin.Forms.Forms.Init();

            SfDataGridRenderer.Init();

            new SfChartRenderer();

            new SfBusyIndicatorRenderer();
            new SfTreeMapRenderer();

            new SfDigitalGaugeRenderer();
            new SfGaugeRenderer();
            new SfBarcodeRenderer();
            new SfLinearGaugeRenderer();

            new SfRangeSliderRenderer();
            new SfNumericTextBoxRenderer();
            new SfAutoCompleteRenderer();
            LoadApplication(new SampleBrowser.App());
        }
    }
}
