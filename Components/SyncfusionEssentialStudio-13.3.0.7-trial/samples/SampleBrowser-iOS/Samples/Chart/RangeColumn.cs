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
#endif

namespace SampleBrowser
{
	public class RangeColumn : SampleView
	{
		public RangeColumn ()
		{
			SFChart chart 			  = new SFChart ();
			SFCategoryAxis primary 	  = new SFCategoryAxis ();
			primary.LabelPlacement	  = SFChartLabelPlacement.BetweenTicks;
			chart.PrimaryAxis 		  = primary;
			chart.SecondaryAxis 	  = new SFNumericalAxis (){ ShowMajorGridLines = false };

			ChartRangeColumnDataSource dataModel = new ChartRangeColumnDataSource ();
			chart.DataSource 					 = dataModel as SFChartDataSource;
			this.control 						 = chart;

		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
			}
			base.LayoutSubviews ();
		}

	}

	public class ChartRangeColumnDataSource : SFChartDataSource
	{
		NSMutableArray DataPoints;

		public ChartRangeColumnDataSource ()
		{
			DataPoints = new NSMutableArray ();
			AddDataPointsForChart("Jan", 35, 17);
			AddDataPointsForChart("Feb", 42,-11);
			AddDataPointsForChart("Mar", 25,  5);
			AddDataPointsForChart("Apr", 32, 10);
			AddDataPointsForChart("May", 20,  3);
			AddDataPointsForChart("Jun", 41, 30);
		}

		void AddDataPointsForChart (String XValue, Double high, Double low)
		{
			DataPoints.Add (new SFChartDataPoint (NSObject.FromObject (XValue),new NSNumber(high), new NSNumber(low)));
		}

		public override nint NumberOfSeriesInChart (SFChart chart)
		{
			return 1; 
		}

		public override SFSeries GetSeries (SFChart chart, nint index)
		{
			SFRangeColumnSeries series					= new SFRangeColumnSeries ();
			series.DataMarker.ShowLabel					= true;
			series.DataMarker.LabelStyle.Margin 	    = new UIEdgeInsets (3, 3, 3, 3);
			return series;
		}

		public override SFChartDataPoint GetDataPoint (SFChart chart, nint index, nint seriesIndex)
		{
			return DataPoints.GetItem<SFChartDataPoint> ((nuint)index);
		}

		public override nint GetNumberOfDataPoints (SFChart chart, nint index)
		{
			return (int)DataPoints.Count;
		}
	} 
}


