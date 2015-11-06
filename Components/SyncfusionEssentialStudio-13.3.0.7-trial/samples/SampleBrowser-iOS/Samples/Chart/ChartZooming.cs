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
	public class ZoomingandPanning: SampleView
	{
		SFChart chart;
		UILabel label;
		public ZoomingandPanning ()
		{
			chart 					= new SFChart ();
			SFCategoryAxis primary 	= new SFCategoryAxis ();
			primary.LabelPlacement	= SFChartLabelPlacement.BetweenTicks;
			chart.PrimaryAxis 		= primary;
			chart.PrimaryAxis.Title.Text    = new NSString ("Company");
			chart.SecondaryAxis 			= new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text  = new NSString ("Sales");

			ChartZoomPanDataSource dataModel 	= new ChartZoomPanDataSource ();
			chart.DataSource 					= dataModel as SFChartDataSource;

			label 					= new UILabel ();
			label.Text 				= "Pinch to zoom or double tap and drag to select a region to zoom in";
			label.Font				= UIFont.FromName("Helvetica", 12f);
			label.TextAlignment 	= UITextAlignment.Center;
			label.LineBreakMode 	= UILineBreakMode.WordWrap;
			label.Lines 			= 2; 
			label.BackgroundColor   = UIColor.Black.ColorWithAlpha (0.7f);
			label.TextColor 		= UIColor.White;

			chart.AddChartBehavior (new SFChartZoomPanBehavior() {EnableSelectionZooming = true});
			this.AddSubview (chart);
			this.AddSubview (label);
			this.control = this;

		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				if (view == chart)
					chart.Frame = new CGRect (0, 0, Frame.Width, Frame.Height-48);
				else if (view == label)
					label.Frame = new CGRect (0, Frame.Height-32, Frame.Width, 40);
				else
					view.Frame = Frame;

			}
			base.LayoutSubviews ();
		}

	}
	public class ChartZoomPanDataSource : SFChartDataSource
	{
		NSMutableArray DataPoints;

		public ChartZoomPanDataSource ()
		{
			DataPoints = new NSMutableArray ();
			AddDataPointsForChart("Bentley"	, 	54);
			AddDataPointsForChart("Audi", 		24);
			AddDataPointsForChart("BMW", 		53);
			AddDataPointsForChart("Jaguar", 	63);
			AddDataPointsForChart("Skoda", 		35);
		}

		void AddDataPointsForChart (String month, Double value)
		{
			DataPoints.Add (new SFChartDataPoint (NSObject.FromObject (month), NSObject.FromObject(value)));
		}

		public override nint NumberOfSeriesInChart (SFChart chart)
		{
			return 1; 
		}

		public override SFSeries GetSeries (SFChart chart, nint index)
		{
			SFColumnSeries series 						= new SFColumnSeries ();
			return series;
		}

		public override SFChartDataPoint GetDataPoint (SFChart chart, nint index, nint seriesIndex)
		{
			return DataPoints.GetItem<SFChartDataPoint> ((nuint)index);//returns the datapoint for each series.
		}

		public override nint GetNumberOfDataPoints (SFChart chart, nint index)
		{
			return (int)DataPoints.Count;//No of datapoints needed for each series.
		}
	}
}

