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

using System.Drawing;

namespace SampleBrowser
{
	public class CategoryAxis : SampleView
	{
		public CategoryAxis ()
		{
			SFChart chart 					= new SFChart ();
			SFCategoryAxis categoryAxis 	= new SFCategoryAxis ();
			categoryAxis.LabelPlacement 	= SFChartLabelPlacement.BetweenTicks;
			chart.PrimaryAxis				= categoryAxis;
			chart.PrimaryAxis.Title.Text    = new NSString ("Category Axis");
			chart.SecondaryAxis 			= new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text  = new NSString ("Numerical Axis");
			ChartCagetorySource dataModel 	= new ChartCagetorySource ();
			chart.DataSource 				= dataModel as SFChartDataSource;
			chart.Legend.Visible 			= true;
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

	public class ChartCagetorySource : SFChartDataSource
	{
		NSMutableArray DataPoints;

		public ChartCagetorySource ()
		{
			DataPoints = new NSMutableArray ();
			AddDataPointsForChart("Bentley"	, 	54);
			AddDataPointsForChart("Audi", 		24);
			AddDataPointsForChart("BMW", 		53);
			AddDataPointsForChart("Jaguar", 	63);
			AddDataPointsForChart("Skoda", 		35);
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
			SFColumnSeries series			= new SFColumnSeries ();
			series.Label					= new NSString("Column Series");
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



