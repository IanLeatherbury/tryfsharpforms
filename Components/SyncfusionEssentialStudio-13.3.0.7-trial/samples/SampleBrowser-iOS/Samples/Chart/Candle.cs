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
using nint = System.Int32;using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif
namespace SampleBrowser
{
	public class Candle : SampleView
	{
		public Candle ()
		{
			SFChart chart 			= new SFChart ();
			SFCategoryAxis primary 	= new SFCategoryAxis ();
			chart.PrimaryAxis 		= primary;
			chart.SecondaryAxis 	= new SFNumericalAxis ();

			ChartCandleDataSource dataModel = new ChartCandleDataSource ();
			chart.DataSource 				= dataModel as SFChartDataSource;
			this.control = chart;

		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
			}
			base.LayoutSubviews ();
		}

	}

	public class ChartCandleDataSource : SFChartDataSource
	{
		NSMutableArray DataPoints;

		public ChartCandleDataSource ()
		{
			DataPoints = new NSMutableArray ();
			AddDataPointsForChart("2010", 873.8, 878.85, 855.5, 860.5);
			AddDataPointsForChart("2011", 861, 868.4, 835.2, 843.45);
			AddDataPointsForChart("2012", 846.15, 853, 838.5, 847.5);
			AddDataPointsForChart("2013", 846, 860.75, 841, 855);
			AddDataPointsForChart("2014", 841, 845, 827.85, 838.65);
		}

		void AddDataPointsForChart (String xValue, Double open, Double high, Double low, Double close)
		{
			DataPoints.Add (new SFChartDataPoint (NSObject.FromObject (xValue), NSObject.FromObject(open),
				NSObject.FromObject(high), NSObject.FromObject(low),NSObject.FromObject(close)));
		}

		public override nint NumberOfSeriesInChart (SFChart chart)
		{
			return 1; 
		}

		public override SFSeries GetSeries (SFChart chart, nint index)
		{
			SFCandleSeries series		= new SFCandleSeries ();
			series.BorderWidth = 1;
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

