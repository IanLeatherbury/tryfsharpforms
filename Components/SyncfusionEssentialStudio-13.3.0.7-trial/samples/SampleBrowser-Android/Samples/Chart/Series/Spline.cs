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


namespace SampleBrowser
{
    public class Spline : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.PrimaryAxis = new CategoryAxis {PlotOffset = 20};
            chart.SecondaryAxis = new NumericalAxis();

            var series = new SplineSeries
            {
                DataSource = MainPage.GetData1(),
                StrokeWidth = 3,
            };

            series.DataMarker.ShowLabel = true;
            chart.Series.Add(series);

            return chart;
        }
    }
}