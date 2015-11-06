#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Android.OS;
using Android.App;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Graphics;
using Android.Views;

namespace SampleBrowser
{
    public class Date : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.ToggleSeriesVisibility = true;

            var dateAxis = new DateTimeAxis
            {
                EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift,
                LabelRotationAngle = -45,
            };
            dateAxis.LabelStyle.LabelFormat = "MM/dd/yyyy";

            chart.PrimaryAxis = dateAxis;
            dateAxis.Title.Text = "DateTime Axis";

            var numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Numerical Axis";
            chart.SecondaryAxis = numericalAxis;

            chart.Series.Add(new ColumnSeries
            {
                Label = "Column Series",
                DataSource = MainPage.GetDateTimValue(),
            });

            return chart;
        }
    }
}