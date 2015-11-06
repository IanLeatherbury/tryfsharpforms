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
    public class StackingColumn100 : SamplePage
    {
        public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);

            chart.PrimaryAxis = new CategoryAxis { LabelPlacement = LabelPlacement.BetweenTicks };
            chart.SecondaryAxis = new NumericalAxis { ShowMajorGridLines = false };

            var series = new StackingColumn100Series
            {
                DataSource = MainPage.GetData1(),
                DataMarkerPosition = DataMarkerPosition.Center,
            };
            series.DataMarker.ShowLabel = true;
            series.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Center;
            chart.Series.Add(series);

            series =new StackingColumn100Series
            {                
                DataSource = MainPage.GetData2(),
                DataMarkerPosition = DataMarkerPosition.Center,
            };
            series.DataMarker.ShowLabel = true;
            series.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Center;
            chart.Series.Add(series);

            series =new StackingColumn100Series
            {
                
                DataSource = MainPage.GetData3(),
                DataMarkerPosition = DataMarkerPosition.Center,
            };
            series.DataMarker.ShowLabel = true;
            series.DataMarker.LabelStyle.LabelPosition = DataMarkerLabelPosition.Center;
            chart.Series.Add(series);

            return chart;
        }
    }
}
