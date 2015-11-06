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
	public class StackedArea : SampleView
	{
		public StackedArea ()
		{
			SFChart chart 						= new SFChart ();
			SFCategoryAxis primaryAxis 			= new SFCategoryAxis ();
			primaryAxis.EdgeLabelsDrawingMode   = SFChartAxisEdgeLabelsDrawingMode.Shift;
			chart.PrimaryAxis 					= primaryAxis;
			chart.SecondaryAxis 				= new SFNumericalAxis ();
			StackingAreaDataSource dataModel 	= new StackingAreaDataSource ();
			chart.DataSource 					= dataModel as SFChartDataSource;
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

public class StackingAreaDataSource : SFChartDataSource
{
	NSMutableArray DataPoints;
	NSMutableArray DataPoints1;
	NSMutableArray DataPoints2;

	public StackingAreaDataSource ()
	{
		DataPoints  = new NSMutableArray ();
		DataPoints1 = new NSMutableArray ();
		DataPoints2 = new NSMutableArray ();
		AddDataPointsForChart("2010", 45,54,14);
		AddDataPointsForChart("2011", 89,24,54);
		AddDataPointsForChart("2012", 23,53,23);
		AddDataPointsForChart("2013", 43,63,53);
		AddDataPointsForChart("2014", 54,35,25);
	}

	void AddDataPointsForChart (String XValue, Double YValue, Double YValue1, Double YValue2)
	{
		DataPoints.Add (new SFChartDataPoint (NSObject.FromObject (XValue), NSObject.FromObject(YValue)));
		DataPoints1.Add (new SFChartDataPoint (NSObject.FromObject (XValue), NSObject.FromObject(YValue1)));
		DataPoints2.Add (new SFChartDataPoint (NSObject.FromObject (XValue), NSObject.FromObject(YValue2)));
	}

	[Export ("numberOfSeriesInChart:")]
	public override nint NumberOfSeriesInChart (SFChart chart)
	{
		return 3; 
	}

	[Export ("chart:seriesAtIndex:")]
	public override SFSeries GetSeries (SFChart chart, nint index)
	{
		SFStackingAreaSeries series = new SFStackingAreaSeries ();
		series.Alpha 				= 0.6f;
		series.BorderWidth 			= 3;

		if(index == 0)
			series.BorderColor 		= UIColor.FromRGBA( 255.0f/255.0f ,191.0f/255.0f,0.0f/255.0f,1.0f);
		else if(index ==1)
			series.BorderColor 		= UIColor.FromRGBA( 81.0f/255.0f ,72.0f/255.0f,57.0f/255.0f,1.0f);
		else 
			series.BorderColor 		= UIColor.FromRGBA( 195.0f/255.0f ,81.0f/255.0f,64.0f/255.0f,1.0f);
		
		return series;
	}

	[Export ("chart:dataPointAtIndex:forSeriesAtIndex:")]
	public override SFChartDataPoint GetDataPoint (SFChart chart, nint index, nint seriesIndex)
	{
		if (seriesIndex == 0)
			return DataPoints.GetItem<SFChartDataPoint> ((nuint)index);
		else if (seriesIndex == 1)
			return DataPoints1.GetItem<SFChartDataPoint> ((nuint)index);
		else
			return DataPoints2.GetItem<SFChartDataPoint> ((nuint)index);
	}

	[Export ("chart:numberOfDataPointsForSeriesAtIndex:")]
	public override nint GetNumberOfDataPoints (SFChart chart, nint index)
	{
		if(index == 0)
			return (int)DataPoints.Count;
		else if(index ==1)
			return (int)DataPoints1.Count;
		else 
			return (int)DataPoints2.Count;
	}
}

