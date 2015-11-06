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
    
    public class Area : SamplePage
    {
       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.PrimaryAxis = new CategoryAxis {PlotOffset = 20};
            chart.SecondaryAxis = new NumericalAxis();

            var areaSeries = new AreaSeries
            {
                StrokeWidth = 5,
                Color = MainPage.ConvertHexaToColor(0x90FEBE17),
                Alpha = 0.5f,
                StrokeColor = MainPage.ConvertHexaToColor(0xFFFEBE17),
                DataSource = MainPage.GetAreaData(),
            };

            chart.Series.Add(areaSeries);
            return chart;
        }
    }
}