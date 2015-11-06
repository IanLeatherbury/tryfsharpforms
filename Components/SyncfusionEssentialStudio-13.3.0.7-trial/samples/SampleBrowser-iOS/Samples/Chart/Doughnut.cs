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
	public class Doughnut : SampleView
	{
		public Doughnut ()
		{
			SFChart chart 						= new SFChart ();
			chart.Legend.Visible 				= true;
			ChartDoughnutDataSource dataModel 	= new ChartDoughnutDataSource ();
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

public class ChartDoughnutDataSource : SFChartDataSource
{
	NSMutableArray DataPoints;

	public ChartDoughnutDataSource ()
	{
		DataPoints = new NSMutableArray ();
		AddDataPointsForChart("2010", 8000);
		AddDataPointsForChart("2011", 8100);
		AddDataPointsForChart("2012", 8250);
		AddDataPointsForChart("2013", 8600);
		AddDataPointsForChart("2014", 8700);
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
		SFDoughnutSeries series		= new SFDoughnutSeries ();
		series.ExplodeIndex 		= 3;
		series.DataMarker.ShowLabel	= true;
		series.DataMarkerPosition 	= SFChartCircularSeriesLabelPosition.OutsideExtended;
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

