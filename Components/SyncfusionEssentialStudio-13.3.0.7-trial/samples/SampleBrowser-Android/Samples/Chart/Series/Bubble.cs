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

    internal class Bubble : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);

            chart.PrimaryAxis = new CategoryAxis {PlotOffset = 50};
            chart.SecondaryAxis = new NumericalAxis();

            var bubble = new BubbleSeries();
           
            bubble.ColorModel.ColorPalette = ChartColorPalette.Metro;
            bubble.DataMarker.ShowLabel = true;
            bubble.DataMarker.UseSeriesPalette = false;
            bubble.DataMarker.LabelStyle.TextColor = Color.White;

            var datas = new ObservableArrayList();
            datas.Add(new ChartDataPoint("2010", 45, 30));
            datas.Add(new ChartDataPoint("2011", 86, 20));
            datas.Add(new ChartDataPoint("2012", 23, 15));
            datas.Add(new ChartDataPoint("2013", 43, 25));
            datas.Add(new ChartDataPoint("2014", 54, 20));

            bubble.DataSource = datas;
            chart.Series.Add(bubble);
            return chart;
        }
    }
}