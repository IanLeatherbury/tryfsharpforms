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
	public class SplineArea : SampleView
	{
		public SplineArea ()
		{
			SFChart chart 						= new SFChart ();
			SFCategoryAxis primaryAxis 			= new SFCategoryAxis ();
			primaryAxis.EdgeLabelsDrawingMode   = SFChartAxisEdgeLabelsDrawingMode.Shift;
			chart.PrimaryAxis 					= primaryAxis;
			SFNumericalAxis secondaryAxis 		= new SFNumericalAxis ();
			secondaryAxis.Interval 				= NSObject.FromObject(5);
			chart.SecondaryAxis 				= secondaryAxis;
			ChartSplineAreaDataSource dataModel = new ChartSplineAreaDataSource ();
			chart.DataSource 					= dataModel as SFChartDataSource;
			this.control 						= chart;
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

public class ChartSplineAreaDataSource : SFChartDataSource
{
	NSMutableArray DataPoints;

	public ChartSplineAreaDataSource ()
	{
		DataPoints = new NSMutableArray ();
		AddDataPointsForChart("2010", 54);
		AddDataPointsForChart("2011", 34);
		AddDataPointsForChart("2012", 53);
		AddDataPointsForChart("2013", 63);
		AddDataPointsForChart("2014", 35);
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
		SFSplineAreaSeries series		= new SFSplineAreaSeries ();
		series.Alpha 					= 0.6f;
		series.BorderColor 				= UIColor.FromRGBA( 255.0f/255.0f ,191.0f/255.0f,0.0f/255.0f,1.0f);
		series.BorderWidth 				= 3;
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




