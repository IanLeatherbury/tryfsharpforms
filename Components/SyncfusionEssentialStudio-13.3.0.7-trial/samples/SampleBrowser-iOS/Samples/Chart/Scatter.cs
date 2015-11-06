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
	public class Scatter : SampleView
	{
		
		public Scatter ()
		{
			SFChart chart 			        = new SFChart ();
			SFCategoryAxis primary 			= new SFCategoryAxis (){PlotOffset = 20};
			primary.ShowMajorGridLines 		= false;
			chart.PrimaryAxis 			    = primary;
			SFNumericalAxis secondary 		= new SFNumericalAxis (){PlotOffset = 20};
			secondary.ShowMajorGridLines    = false;
			chart.SecondaryAxis 			= secondary;
			ChartScatterSource dataModel 	= new ChartScatterSource ();
			chart.DataSource 		        = dataModel as SFChartDataSource;
			this.control 				    = chart;

		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) 
			{
				view.Frame = Frame;
			}
			base.LayoutSubviews ();
		}

	}

	public class ChartScatterSource : SFChartDataSource
	{
		NSMutableArray DataPoints;

		public ChartScatterSource ()
		{
			DataPoints = new NSMutableArray ();
			AddDataPointsForChart("2005", 54);
			AddDataPointsForChart("2006", 34);
			AddDataPointsForChart("2007", 53);
			AddDataPointsForChart("2007", 63);
			AddDataPointsForChart("2009", 35);
			AddDataPointsForChart("2010", 27);
			AddDataPointsForChart("2011", 13);
			AddDataPointsForChart("2012", 40);
			AddDataPointsForChart("2013", 25);
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
			SFScatterSeries series			= new SFScatterSeries ();
			series.ScatterWidth 			= 10;
			series.ScatterHeight 			= 10;
			series.DataMarker.ShowLabel     = true;
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



