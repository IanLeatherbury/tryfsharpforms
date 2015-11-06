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
    public class Category : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.ToggleSeriesVisibility = true;

            var categoryAxis = new CategoryAxis {LabelPlacement = LabelPlacement.BetweenTicks};
            categoryAxis.Title.Text = "Category Axis";

            chart.PrimaryAxis = categoryAxis;

            var numericalAxis = new NumericalAxis();
            numericalAxis.Title.Text = "Numerical Axis";
            chart.SecondaryAxis = numericalAxis;

            chart.SecondaryAxis = numericalAxis;
            chart.Series = new ChartSeriesCollection();

            chart.Series.Add(new ColumnSeries()
            {
                Label = "Column Series",
                DataSource = MainPage.GetCategoryData()
            });
            return chart;
        }
    }
}