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
    public class Numerical : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.ToggleSeriesVisibility = true;

            var xAxis = new NumericalAxis {Interval = 1};
            xAxis.Title.Text = "X Axis";
            chart.PrimaryAxis = xAxis;

            var yAxis = new NumericalAxis();
            yAxis.Title.Text = "Y Axis";
            chart.SecondaryAxis = yAxis;
            chart.Series.Clear();

            chart.Series.Add(new ColumnSeries()
            {
                Label = "Column Series",
                DataSource = MainPage.GetNumericalData(),
            });
            return chart;
        }
    }
}