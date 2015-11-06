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
	public class Trackball : SampleView
	{
		UILabel label;
		SFChart chart; 
		public Trackball ()
		{
			chart 					        = new SFChart ();
			SFNumericalAxis primaryAxis     = new SFNumericalAxis ();
			chart.PrimaryAxis 				= primaryAxis;
			SFNumericalAxis secondaryAxis 	= new SFNumericalAxis ();
			chart.SecondaryAxis 			= secondaryAxis;
			ChartTrackballDataSource dataModel 	= new ChartTrackballDataSource ();
			chart.DataSource 				= dataModel as SFChartDataSource;

			label 					= new UILabel ();
			label.Text 				= "Press and hold to enable trackball";
			label.Font				= UIFont.FromName("Helvetica", 12f);
			label.TextAlignment 	= UITextAlignment.Center;
			label.LineBreakMode 	= UILineBreakMode.WordWrap;
			label.Lines 			= 2; 
			label.BackgroundColor   = UIColor.Black.ColorWithAlpha (0.7f);
			label.TextColor 		= UIColor.White;


			chart.AddChartBehavior (new SFChartTrackballBehavior());
			this.AddSubview (chart);
			this.AddSubview (label);
			this.control = this;
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				if (view == chart)
					chart.Frame = new CGRect (0, 0, Frame.Width, Frame.Height-48);
				else if (view == label)
					label.Frame = new CGRect (0, Frame.Height-32, Frame.Width, 40);
				else
					view.Frame = Frame;

			}
			base.LayoutSubviews ();
		}
	}
}

public class ChartTrackballDataSource : SFChartDataSource
{
	NSMutableArray DataPoints1;
	NSMutableArray DataPoints2;
	NSMutableArray DataPoints3;

	public ChartTrackballDataSource ()
	{
		DataPoints1 = new NSMutableArray ();
		DataPoints1.Add (new SFChartDataPoint (NSObject.FromObject (1), NSObject.FromObject(54)));
		DataPoints1.Add (new SFChartDataPoint (NSObject.FromObject (2), NSObject.FromObject(24)));
		DataPoints1.Add (new SFChartDataPoint (NSObject.FromObject (3), NSObject.FromObject(53)));
		DataPoints1.Add (new SFChartDataPoint (NSObject.FromObject (4), NSObject.FromObject(63)));
		DataPoints1.Add (new SFChartDataPoint (NSObject.FromObject (5), NSObject.FromObject(35)));

		DataPoints2 = new NSMutableArray ();
		DataPoints2.Add (new SFChartDataPoint (NSObject.FromObject (1), NSObject.FromObject(34)));
		DataPoints2.Add (new SFChartDataPoint (NSObject.FromObject (2), NSObject.FromObject(20)));
		DataPoints2.Add (new SFChartDataPoint (NSObject.FromObject (3), NSObject.FromObject(43)));
		DataPoints2.Add (new SFChartDataPoint (NSObject.FromObject (4), NSObject.FromObject(53)));
		DataPoints2.Add (new SFChartDataPoint (NSObject.FromObject (5), NSObject.FromObject(25)));

		DataPoints3 = new NSMutableArray ();
		DataPoints3.Add (new SFChartDataPoint (NSObject.FromObject (1), NSObject.FromObject(24)));
		DataPoints3.Add (new SFChartDataPoint (NSObject.FromObject (2), NSObject.FromObject(14)));
		DataPoints3.Add (new SFChartDataPoint (NSObject.FromObject (3), NSObject.FromObject(33)));
		DataPoints3.Add (new SFChartDataPoint (NSObject.FromObject (4), NSObject.FromObject(43)));
		DataPoints3.Add (new SFChartDataPoint (NSObject.FromObject (5), NSObject.FromObject(15)));

	}

	public override nint NumberOfSeriesInChart (SFChart chart)
	{
		return 3; 
	}

	public override SFSeries GetSeries (SFChart chart, nint index)
	{
		SFLineSeries series			= new SFLineSeries ();
		series.LineWidth 			= 3;
		return series;
	}

	public override SFChartDataPoint GetDataPoint (SFChart chart, nint index, nint seriesIndex)
	{
		if(seriesIndex ==0)
			return DataPoints1.GetItem<SFChartDataPoint> ((nuint)index);//returns the datapoint for each series.
		else if (seriesIndex ==1)
			return DataPoints2.GetItem<SFChartDataPoint> ((nuint)index);
		else
			return DataPoints3.GetItem<SFChartDataPoint> ((nuint)index);
	}

	public override nint GetNumberOfDataPoints (SFChart chart, nint index)
	{
		if(index == 0)
			return (int)DataPoints1.Count;//No of datapoints needed for each series.
		else if(index ==1)
			return (int)DataPoints2.Count;
		else
			return (int)DataPoints3.Count;
	}
}

