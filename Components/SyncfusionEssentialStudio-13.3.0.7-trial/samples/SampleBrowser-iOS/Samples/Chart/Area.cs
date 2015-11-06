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
	public class Area : SampleView
	{
		public Area ()
		{
			SFChart chart 					= new SFChart ();
			SFCategoryAxis primaryAxis 		= new SFCategoryAxis ();
			chart.PrimaryAxis 				= primaryAxis;
			chart.PrimaryAxis.PlotOffset    = 10;
			SFNumericalAxis secondaryAxis 	= new SFNumericalAxis ();
			chart.SecondaryAxis 			= secondaryAxis;
			ChartAreaDataSource dataModel 	= new ChartAreaDataSource ();
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

public class ChartAreaDataSource : SFChartDataSource
{
	NSMutableArray DataPoints;

	public ChartAreaDataSource ()
	{
		DataPoints = new NSMutableArray ();
		AddDataPointsForChart("2010", 45);
		AddDataPointsForChart("2011", 56);
		AddDataPointsForChart("2012", 23);
		AddDataPointsForChart("2013", 43);
		AddDataPointsForChart("2014", double.NaN);
		AddDataPointsForChart("2015", 54);
		AddDataPointsForChart("2016", 23);
		AddDataPointsForChart("2017", 43);
		AddDataPointsForChart("2018", 34);
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
		SFAreaSeries series		= new SFAreaSeries ();
		series.Alpha 			= 0.6f;
		series.BorderColor 		= UIColor.FromRGBA( 255.0f/255.0f ,191.0f/255.0f,0.0f/255.0f,1.0f);
		series.BorderWidth 		= 3;
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

