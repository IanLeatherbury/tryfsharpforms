#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class DataPointSelection : SampleView
	{
		SFChart chart;
		UILabel label;
		ChartSelectionDataSource dataModel;
		public DataPointSelection ()
		{
			chart 					= new SFChart ();
			SFCategoryAxis primary 	= new SFCategoryAxis ();
			primary.LabelPlacement	= SFChartLabelPlacement.BetweenTicks;
			primary.Title.Text 		= new NSString ("Month");
			chart.PrimaryAxis 		= primary;
			chart.SecondaryAxis 		 	= new SFNumericalAxis (){ ShowMajorGridLines = false };
			chart.SecondaryAxis.Title.Text 	= new NSString ("Sales");

			dataModel 				= new ChartSelectionDataSource ();
			chart.DataSource 		= dataModel as SFChartDataSource;
			chart.Delegate 			= new ChartSelectionDelegate ();
			chart.AddChartBehavior (new SFChartSelectionBehavior());
			label 					= new UILabel ();
			label.Text 				= "Month :  Mar, Sales : $ 53";
			label.Font				= UIFont.FromName("Helvetica", 13f);
			label.TextAlignment 	= UITextAlignment.Center;
			this.control = this;
			this.AddSubview (chart);
			this.AddSubview (label);
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				if (view == chart)
					chart.Frame = new CGRect (0, 0, Frame.Width, Frame.Height-28);
				else if (view == label)
					label.Frame = new CGRect (0, Frame.Height-20, Frame.Width, 20);
				else
					view.Frame = Frame;

			}
			base.LayoutSubviews ();
		}

		public void SetLabelContent(string xValue, string yValue)
		{
			if (xValue != null  && yValue != null) {
				label.Text = "Month : " + xValue + ", Sales : $" + yValue;
			}
			else {
				label.Text = "Tap a bar segment to select a data point";
			}

		}

	}

	public class ChartSelectionDelegate : SFChartDelegate
	{
		public override void DidDataPointSelect (SFChart chart, SFChartSelectionInfo info)
		{
			int selectedindex = info.SelectedDataPointIndex;
			if (selectedindex >= 0) {
				SFSeries series = info.SelectedSeries;
				if (series != null) {
					SFChartDataPoint dataPoint = (chart.DataSource as ChartSelectionDataSource).GetDataPoint (chart, selectedindex, 0);
					if (dataPoint == null)
						(chart.Superview as DataPointSelection).SetLabelContent (null, null);
					else {
						String x = dataPoint.XValue.ToString ();
						String y = dataPoint.YValue.ToString ();
						(chart.Superview as DataPointSelection).SetLabelContent (x, y);
					}
				}
			} 
			else 
			{
				(chart.Superview as DataPointSelection).SetLabelContent (null, null);
			}
		}
	}


	public class ChartSelectionDataSource : SFChartDataSource
	{
		public NSMutableArray DataPoints { get; set;}

		public ChartSelectionDataSource ()
		{
			DataPoints = new NSMutableArray ();

			AddDataPointsForChart("Jan", 42);
			AddDataPointsForChart("Feb", 44);
			AddDataPointsForChart("Mar", 53);
			AddDataPointsForChart("Apr", 64);
			AddDataPointsForChart("May", 75);
			AddDataPointsForChart("Jun", 83);
		}

		void AddDataPointsForChart (String XValue, Double YValue)
		{
			DataPoints.Add (new SFChartDataPoint (NSObject.FromObject (XValue), NSObject.FromObject(YValue)));
		}

		public override nint NumberOfSeriesInChart (SFChart chart)
		{
			return 1; 
		}

		public override SFSeries GetSeries (SFChart chart, nint index)
		{
			SFColumnSeries series		= new SFColumnSeries ();
			series.EnableDataPointSelection = true;
			series.SelectedDataPointIndex = 2;
			series.DataMarkerPosition	= SFChartDataMarkerPosition.Center;
			series.DataMarker.ShowLabel	= true;
			series.DataMarker.LabelStyle.LabelPosition = SFChartDataMarkerLabelPosition.Center;
			return series;
		}

		public override SFChartDataPoint GetDataPoint (SFChart chart, nint index, nint seriesIndex)
		{
			if (DataPoints.Count <= ((nuint)index))
				return null;
			return DataPoints.GetItem<SFChartDataPoint> ((nuint)index);//returns the datapoint for each series.
		}

		public override nint GetNumberOfDataPoints (SFChart chart, nint index)
		{
			return (int)DataPoints.Count;//No of datapoints needed for each series.
		}
	} 
}

