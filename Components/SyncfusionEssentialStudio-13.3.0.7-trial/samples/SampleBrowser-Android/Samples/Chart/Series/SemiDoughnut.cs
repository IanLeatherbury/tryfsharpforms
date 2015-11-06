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
using Android.Content.Res;

namespace SampleBrowser
{
    public class SemiDoughnut : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context); ;
            chart.SetBackgroundColor(Color.White);
            chart.Title.Text = "Products Growth - 2015";
            chart.Legend.Visibility = Visibility.Visible;

            if (context.Resources.DisplayMetrics.HeightPixels > context.Resources.DisplayMetrics.WidthPixels)
            {
                int padding = (context.Resources.DisplayMetrics.HeightPixels -
                        context.Resources.DisplayMetrics.WidthPixels) / 2;
                chart.SetPadding(0, padding / 2, 0, padding);
                chart.Legend.DockPosition = ChartDock.Bottom;
            }
            else
            {
                int padding = (context.Resources.DisplayMetrics.WidthPixels -
                        context.Resources.DisplayMetrics.HeightPixels) / 2;
                chart.SetPadding(padding, 0, padding, 0);
                chart.Legend.ItemMarginRight = padding / 6;
                chart.Legend.DockPosition = ChartDock.Right;
            }

            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("Product A", 14));
            datas.Add(new ChartDataPoint("Product B", 54));
            datas.Add(new ChartDataPoint("Product C", 23));
            datas.Add(new ChartDataPoint("Product D", 53));

            var doughnutSeries = new DoughnutSeries
            {
                DataSource = datas,
                StartAngle = 180,
                EndAngle = 360
            };
            doughnutSeries.DataMarker.ShowLabel = true;
            doughnutSeries.DataMarker.LabelContent = LabelContent.Percentage;
            doughnutSeries.DataMarkerPosition = CircularSeriesDataMarkerPosition.Outside;
            chart.Series.Add(doughnutSeries);
            return chart;
        }
    }
}