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
    internal class RangeColumn : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);

            chart.PrimaryAxis = new CategoryAxis { LabelPlacement = LabelPlacement.BetweenTicks };
            chart.SecondaryAxis = new NumericalAxis() { ShowMajorGridLines = false };

            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("Jan", 35, 17));
            datas.Add(new ChartDataPoint("Feb", 42, -11));
            datas.Add(new ChartDataPoint("Mar", 25, 5));
            datas.Add(new ChartDataPoint("Apr", 32, 10));
            datas.Add(new ChartDataPoint("May", 20, 3));
            datas.Add(new ChartDataPoint("Jun", 41, 30));

            var series = new RangeColumnSeries
            {
                DataSource = datas,
            };

            series.DataMarker.ShowLabel = true;
            chart.Series.Add(series);

            return chart;
        }
    }
}