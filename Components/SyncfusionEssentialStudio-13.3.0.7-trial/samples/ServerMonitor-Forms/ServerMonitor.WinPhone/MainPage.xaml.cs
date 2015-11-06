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

using Xamarin.Forms;
using Syncfusion.SfGauge.XForms.WinPhone;
using Syncfusion.SfChart.XForms.WinPhone;


namespace ServerMonitor.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            new SfGaugeRenderer();
            new SfChartRenderer();
            InitializeComponent();

            Forms.Init();
            Content = ServerMonitor.App.GetMainPage().ConvertPageToUIElement(this);
        }
    }
}
