#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Reflection.Emit;
using Android.App;
using Android.Graphics;
using Android.OS;
using Com.Syncfusion.Charts;
using Android.Views;
using Android.Content;
using Android.Widget;
using System.Collections.Generic;
using System;


namespace SampleBrowser
{
    public class Line : SamplePage
    {
        SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);

            chart.PrimaryAxis = new CategoryAxis { PlotOffset = 20 };
            chart.SecondaryAxis = new NumericalAxis();
            var lineSeries = new LineSeries { DataSource = MainPage.GetLineData() };

            lineSeries.DataMarker.ShowLabel = true;
            lineSeries.StrokeWidth = 3;
            lineSeries.DataMarker.LabelStyle.Angle = -45;

            chart.Series.Add(lineSeries);
            return chart;
        }
    }
}