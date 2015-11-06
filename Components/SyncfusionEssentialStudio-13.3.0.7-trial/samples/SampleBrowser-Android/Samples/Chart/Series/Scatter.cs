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
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Android.Graphics;
using Com.Syncfusion.Charts.Enums;

namespace SampleBrowser
{
    internal class Scatter : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);

            chart.PrimaryAxis = new CategoryAxis { ShowMajorGridLines = false, PlotOffset = 20 };
            chart.SecondaryAxis = new NumericalAxis() { ShowMajorGridLines = false, PlotOffset = 20 };

            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2005", 54));
            datas.Add(new ChartDataPoint("2006", 34));
            datas.Add(new ChartDataPoint("2007", 53));
            datas.Add(new ChartDataPoint("2008", 63));
            datas.Add(new ChartDataPoint("2009", 35));
            datas.Add(new ChartDataPoint("2010", 27));
            datas.Add(new ChartDataPoint("2011", 13));
            datas.Add(new ChartDataPoint("2012", 40));
            datas.Add(new ChartDataPoint("2013", 25));

            var scatterSeries = new ScatterSeries
            {
                DataSource = datas,
                ScatterHeight = 20,
                ScatterWidth = 20
            };
            
            scatterSeries.DataMarker.ShowLabel = true;
            chart.Series.Add(scatterSeries);

            return chart;
       }    
    }
}