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
	public class DateTimeAxis : SampleView
	{
		public DateTimeAxis ()
		{
			SFChart chart 					= new SFChart ();
			SFDateTimeAxis dateTimeAxis 	= new SFDateTimeAxis ();
			dateTimeAxis.EdgeLabelsDrawingMode = SFChartAxisEdgeLabelsDrawingMode.Shift;
			chart.PrimaryAxis 				= dateTimeAxis;
			chart.PrimaryAxis.Title.Text    = new NSString ("DateTime Axis");
			chart.SecondaryAxis 			= new SFNumericalAxis ();
			chart.SecondaryAxis.Title.Text  = new NSString ("Numerical Axis");
			DateTimeDataSource dataModel 	= new DateTimeDataSource ();
			chart.DataSource 				= dataModel as SFChartDataSource;
			chart.Legend.Visible            = true;
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

	public class DateTimeDataSource : SFChartDataSource
	{
		NSMutableArray DataPoints;

		public DateTimeDataSource ()
		{
			DataPoints = new NSMutableArray ();
			DateTime date = new DateTime (2014, 3, 17, 14, 20, 0);

			AddDataPointsForChart(date, 800);
			AddDataPointsForChart(date.AddDays(1), 810);
			AddDataPointsForChart(date.AddDays(2), 825);
			AddDataPointsForChart(date.AddDays(3), 860);
			AddDataPointsForChart(date.AddDays(4), 870);
		}

		void AddDataPointsForChart (DateTime XValue, Double YValue)
		{
			NSCalendar cal 			= new NSCalendar (NSCalendarType.Gregorian);
			NSDateComponents comp 	= new NSDateComponents ();
			comp.Day 				= XValue.Day;
			comp.Month 				= XValue.Month;
			comp.Year 				= XValue.Year;
			comp.Hour 				= XValue.Hour;
			comp.Minute 			= XValue.Minute;
			comp.Second 			= XValue.Second;
			DataPoints.Add (new SFChartDataPoint ( cal.DateFromComponents(comp), NSObject.FromObject(YValue)));
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

