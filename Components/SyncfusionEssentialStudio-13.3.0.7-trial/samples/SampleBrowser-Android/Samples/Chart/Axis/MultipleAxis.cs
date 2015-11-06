#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.OS;
using Android.Graphics;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Views;


namespace SampleBrowser
{
    public class MultipleAxis : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.ToggleSeriesVisibility = true;
            chart.Legend.Visibility = Visibility.Visible;

            var primary = new CategoryAxis();
            primary.Title.Text = "Years";
            primary.Title.TextColor = Color.Black;
            primary.LabelPlacement = LabelPlacement.BetweenTicks;
            chart.PrimaryAxis = primary;

            var secondaryAxis = new NumericalAxis()
            {
                Minimum = 6200,
                Maximum = 8800,
                Interval = 200,
                ShowMajorGridLines = false
            };

            secondaryAxis.Title.Text = "Revenue";
            secondaryAxis.LabelStyle.LabelFormat = "$####";
            chart.SecondaryAxis = secondaryAxis;

            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 8000));
            datas.Add(new ChartDataPoint("2011", 8100));
            datas.Add(new ChartDataPoint("2012", 8250));
            datas.Add(new ChartDataPoint("2013", 8600));
            datas.Add(new ChartDataPoint("2014", 8700));

            var datas1 = new ObservableArrayList();
            datas1.Add(new ChartDataPoint("2010", 6));
            datas1.Add(new ChartDataPoint("2011", 15));
            datas1.Add(new ChartDataPoint("2012", 35));
            datas1.Add(new ChartDataPoint("2013", 65));
            datas1.Add(new ChartDataPoint("2014", 75));

            chart.Series.Add(new ColumnSeries()
            {
                Label = "Revenue",
                DataSource = datas
            });

            var lineSeries = new FastLineSeries()
            {
                Label = "Customers",
                DataSource = datas1,
                StrokeWidth = 7,
                YAxis = new NumericalAxis()
                {
                    OpposedPosition = true,
                    Minimum = 0,
                    Maximum = 80,
                    Interval = 5,
                    ShowMajorGridLines = false,
                }
            };
            chart.Series.Add(lineSeries);
            lineSeries.YAxis.Title.Text = "Number of Customers";
            return chart;
        }
    }
}