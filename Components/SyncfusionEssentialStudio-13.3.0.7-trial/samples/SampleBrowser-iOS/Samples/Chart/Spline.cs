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
using nint	 = System.Int32;
using nuint	 = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class Spline : SampleView
	{
		public Spline ()
		{
			SFChart chart 					= new SFChart ();
			SFCategoryAxis primaryAxis 		= new SFCategoryAxis ();
			chart.PrimaryAxis 				= primaryAxis;
			chart.PrimaryAxis.PlotOffset	= 10;
			chart.SecondaryAxis 			= new SFNumericalAxis ();
			ChartSplineDataSource dataModel = new ChartSplineDataSource ();
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

}

public class ChartSplineDataSource : SFChartDataSource
{
	NSMutableArray DataPoints;

	public ChartSplineDataSource ()
	{
		DataPoints = new NSMutableArray ();
		AddDataPointsForChart("2010", 45);
		AddDataPointsForChart("2011", 89);
		AddDataPointsForChart("2012", 23);
		AddDataPointsForChart("2013", 43);
		AddDataPointsForChart("2014", 54);
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
		SFSplineSeries series		= new SFSplineSeries ();
		series.LineWidth 			= 3;
		series.DataMarker.ShowLabel	= true;
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

