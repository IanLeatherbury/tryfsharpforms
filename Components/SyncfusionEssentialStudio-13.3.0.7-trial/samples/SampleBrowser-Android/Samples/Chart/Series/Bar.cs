#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;


namespace SampleBrowser
{
    public class Bar : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.PrimaryAxis = new CategoryAxis();
            chart.SecondaryAxis = new NumericalAxis {Interval = 20, EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift};
            var series = new BarSeries
            {
                DataSource = MainPage.GetData1(),
            };
            series.DataMarker.ShowLabel = true;
            chart.Series.Add(series);
            return chart;
        }
    }
}