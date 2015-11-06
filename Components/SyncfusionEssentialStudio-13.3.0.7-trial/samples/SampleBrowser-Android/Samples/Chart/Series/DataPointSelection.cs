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
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Charts;
using Com.Syncfusion.Charts.Enums;
using Android.Graphics;

namespace SampleBrowser
{
    public class DataPointSelection : SamplePage
    {
        private TextView label;

       public override View GetSampleContent(Context context)
        {
            var chart = new SfChart(context);
            chart.SetBackgroundColor(Color.White);

            var primaryAxis = new CategoryAxis { LabelPlacement = LabelPlacement.BetweenTicks };
            primaryAxis.Title.Text = "Month";
            chart.PrimaryAxis = primaryAxis;

            var secondaryAxis = new NumericalAxis();
            secondaryAxis.Title.Text = "Sales";
            secondaryAxis.LabelStyle.LabelFormat = "$##.##";
            chart.SecondaryAxis = secondaryAxis;

            var columnSeries = new ColumnSeries
            {
                DataSource = MainPage.GetSelectionData(),
                DataMarkerPosition = DataMarkerPosition.Center,
                SelectedDataPointIndex = 2,
                DataPointSelectionEnabled = true,
            };

            columnSeries.DataMarker.ShowLabel = true;
            chart.Series.Add(columnSeries);
            
            chart.Behaviors.Add(new ChartSelectionBehavior());
            chart.SelectionChanged += chart_SelectionChanged;

            label = new TextView(context){ TextSize = 20 };
            label.SetPadding(5, 5, 5, 5);

            var layout = new LinearLayout(context){ Orientation = Android.Widget.Orientation.Vertical };

            var layoutLabel = new LinearLayout(context)
            {
                Orientation = Android.Widget.Orientation.Horizontal,
                LayoutParameters =
                    new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent)
            };

            layoutLabel.SetHorizontalGravity(GravityFlags.CenterHorizontal);
            layoutLabel.AddView(label);
            layout.AddView(layoutLabel);
            layout.AddView(chart);

            return layout;
        }

        private void chart_SelectionChanged(object sender, SfChart.SelectionChangedEventArgs e)
        {
            var selectedindex = e.P1.SelectedDataPointIndex;
            if (selectedindex < 0)
            {
                label.Text = "Tap on a bar segment to select a data point.";
                return;
            }
            var series = e.P1.SelectedSeries;
            if (series == null) return;
            var dataPoints = series.DataSource as ObservableArrayList;

            var x = (dataPoints.Get(selectedindex) as ChartDataPoint).GetX().ToString();
            var y = ((ChartDataPoint) dataPoints.Get(selectedindex)).GetY().ToString();
            label.Text = "Month : " + x + ",  Sales : $" + y;
        }

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
        }
    }
}