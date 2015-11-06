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
    public class StackingArea100 : SamplePage
    {
        private int index = 1;

        private SfChart chart;

        public override View GetSampleContent(Context context)
        {
            chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);

            chart.PrimaryAxis = new CategoryAxis() {EdgeLabelsDrawingMode = EdgeLabelsDrawingMode.Shift };
            chart.SecondaryAxis = new NumericalAxis();

            chart.Series.Add(new StackingArea100Series
            {
                Alpha = 0.5f,
                StrokeWidth = 5,
                Color = MainPage.ConvertHexaToColor(0x99FEBE17),
                StrokeColor = MainPage.ConvertHexaToColor(0xFFFEBE17),
            });

            chart.Series.Add(new StackingArea100Series
            {
                Alpha = 0.5f,
                StrokeWidth = 5,
                Color = MainPage.ConvertHexaToColor(0x994F4838),
                StrokeColor = MainPage.ConvertHexaToColor(0xFF4F4838),
            });

            chart.Series.Add(new StackingArea100Series
            {
                StrokeWidth = 5,
                Alpha = 0.5f,
                Color = MainPage.ConvertHexaToColor(0x99C15146),
                StrokeColor = MainPage.ConvertHexaToColor(0xFFC15146),
                DataSource = GetData(2)
            });

            UpdateData();
            return chart;
        }

        private void UpdateData()
        {
            while (true)
            {
                ((ChartSeries) chart.Series.Get(index)).DataSource = GetData(index);
                index--;
                if (index >= 0)
                    continue;
                break;
            }
        }

        private static ObservableArrayList GetData(int index)
        {
            if (index == 0)
                return MainPage.GetData1();
            return index == 1 ? MainPage.GetData2() : MainPage.GetData3();
        }
    }
}