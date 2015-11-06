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
using System;
using System.Threading.Tasks;


namespace SampleBrowser
{
    public class LiveUpdate : SamplePage
    {
        private readonly ObservableArrayList data = new ObservableArrayList();
        private readonly ObservableArrayList data2 = new ObservableArrayList();

        private int wave1;
        private int wave2 = 180;

        private SfChart chart;

        public override View GetSampleContent(Context context)
        {
            LoadData();

            chart = new SfChart(context);;
            chart.SetBackgroundColor(Color.White);
            chart.PrimaryAxis = new NumericalAxis();

            var axis = new NumericalAxis {Minimum = -1.5, Maximum = 1.5};
            chart.SecondaryAxis = axis;
            axis.LabelStyle.LabelsPosition = AxisElementPosition.Outside;
            axis.TickPosition = AxisElementPosition.Outside;

            var lineSeries = new FastLineSeries {DataSource = data};

            chart.Series.Add(lineSeries);

            UpdateData();

            AddSeries();

            return chart;
        }

        private void LoadData()
        {
            for (var i = 0; i < 180; i++)
            {
                data.Add(new ChartDataPoint(i, Math.Sin(wave1*(Math.PI/180.0))));
                wave1++;
            }

            for (var i = 0; i < 180; i++)
            {
                data2.Add(new ChartDataPoint(i, Math.Sin(wave2*(Math.PI/180.0))));
                wave2++;
            }

            wave1 = data.Size();
        }

        private async void AddSeries()
        {
            await Task.Delay(400);
            var fastLine = new FastLineSeries();
            chart.Series.Add(fastLine);
            fastLine.DataSource = data2;
        }

        private async void UpdateData()
        {
            while (true)
            {
                await Task.Delay(10);
                data.Remove(0);
                data.Add(data.Size(), new ChartDataPoint(wave1, Math.Sin(wave1*(Math.PI/180.0))));
                wave1++;

                data2.Remove(0);
                data2.Add(data2.Size(), new ChartDataPoint(wave1, Math.Sin(wave2*(Math.PI/180.0))));
                wave2++;
            }
        }
    }
}