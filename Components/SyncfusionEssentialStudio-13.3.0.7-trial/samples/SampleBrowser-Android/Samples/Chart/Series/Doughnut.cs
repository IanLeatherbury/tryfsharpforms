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
    public class Doughnut : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.Legend.Visibility = Visibility.Visible;

            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 8000));
            datas.Add(new ChartDataPoint("2011", 8100));
            datas.Add(new ChartDataPoint("2012", 8250));
            datas.Add(new ChartDataPoint("2013", 8600));
            datas.Add(new ChartDataPoint("2014", 8700));

            var doughnutSeries = new DoughnutSeries
            {
                ExplodeIndex = 3,
                DataSource = datas,
                DataMarkerPosition = CircularSeriesDataMarkerPosition.OutsideExtended,
            };

            doughnutSeries.DataMarker.ShowLabel = true;
            doughnutSeries.ConnectorType = ConnectorType.Bezier;

            chart.Series.Add(doughnutSeries);
            return chart;
        }
    }
}