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
	public class SemiPie : SampleView
	{
		public SemiPie ()
		{
			SFChart chart 						= new SFChart ();
			chart.Legend.Visible 				= true;
			ChartSemiPieDataSource dataModel 	= new ChartSemiPieDataSource ();
			chart.DataSource 					= dataModel as SFChartDataSource;
			chart.Legend.DockPosition 			= SFChartLegendPosition.Bottom;
			chart.Title.Text 					= new NSString ("Products Growth - 2015");
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

public class ChartSemiPieDataSource : SFChartDataSource
{
	NSMutableArray DataPoints;

	public ChartSemiPieDataSource ()
	{
		DataPoints = new NSMutableArray ();
		AddDataPointsForChart("Product A", 14);
		AddDataPointsForChart("Product B", 54);
		AddDataPointsForChart("Product C", 23);
		AddDataPointsForChart("Product D", 53);
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
		SFPieSeries series			= new SFPieSeries ();
		series.StartAngle 			= 180;
		series.EndAngle 			= 360;
		series.DataMarker.ShowLabel	= true;
		series.DataMarker.LabelContent	= SFChartLabelContent.Percentage;
		series.DataMarkerPosition 		= SFChartCircularSeriesLabelPosition.Outside;
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

