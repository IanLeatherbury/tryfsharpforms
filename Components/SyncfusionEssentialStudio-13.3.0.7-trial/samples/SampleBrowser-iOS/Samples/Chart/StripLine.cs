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
using nfloat = System.Single;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

namespace SampleBrowser
{
	public class StripLines : SampleView
	{
		public StripLines ()
		{
			SFChart chart 						= new SFChart ();
			chart.Title.Text 			        = new NSString ("Average temperature for the year 2014");
			chart.Title.Font				    = UIFont.FromName ("Helvetica neue",14);
			SFCategoryAxis primaryAxis 			= new SFCategoryAxis ();
			primaryAxis.LabelPlacement			= SFChartLabelPlacement.BetweenTicks;
			chart.PrimaryAxis 					= primaryAxis;
			chart.PrimaryAxis.Title.Text        = new NSString ("Months");
			SFNumericalAxis numeric				= new SFNumericalAxis ();
			numeric.Minimum 					= NSObject.FromObject(28);
			numeric.Maximum 					= NSObject.FromObject(52);
			numeric.Interval 					= NSObject.FromObject(2);
			numeric.Title.Text  				= new NSString ("Temperature in Celsius");
			SFChartNumericalStripLine strip1 	= new SFChartNumericalStripLine ();
			strip1.Start                        = 28;
			strip1.Width                        = 8;
			strip1.Text                         = new NSString("Low Temperature");
			strip1.BackgroundColor              = UIColor.FromRGBA((nfloat)0.7843,(nfloat)0.8196,(nfloat)0.4275,(nfloat)1.0);

			numeric.AddStripLine (strip1);

			SFChartNumericalStripLine strip2 	= new SFChartNumericalStripLine ();
			strip2.Start                        = 36;
			strip2.Width                        = 8;
			strip2.Text                         = new NSString("Average Temperature");
			strip2.BackgroundColor              = UIColor.FromRGBA((nfloat)0.9569,(nfloat)0.7804,(nfloat)0.3843,(nfloat)1.0);

			numeric.AddStripLine (strip2);

			SFChartNumericalStripLine strip3 	= new SFChartNumericalStripLine ();
			strip3.Start                        = 44;
			strip3.Width                        = 8;
			strip3.Text                         = new NSString("High Temperature");
			strip3.BackgroundColor              = UIColor.FromRGBA((nfloat)0.9373,(nfloat)0.4706,(nfloat)0.4706,(nfloat)1.0);

			numeric.AddStripLine (strip3);

			chart.SecondaryAxis 		        = numeric;
			ChartStripLineDataSource dataModel  = new ChartStripLineDataSource ();
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

public class ChartStripLineDataSource : SFChartDataSource
{
	NSMutableArray DataPoints;

	public ChartStripLineDataSource ()
	{
		DataPoints = new NSMutableArray ();
		AddDataPointsForChart("Jan", 33);
		AddDataPointsForChart("Feb", 37);
		AddDataPointsForChart("Mar", 39);
		AddDataPointsForChart("Apr", 43);
		AddDataPointsForChart("May", 45);
		AddDataPointsForChart("Jun", 43);
		AddDataPointsForChart("Jul", 41);
		AddDataPointsForChart("Aug", 40);
		AddDataPointsForChart("Sep", 39);
		AddDataPointsForChart("Oct", 39);
		AddDataPointsForChart("Nov", 34);
		AddDataPointsForChart("Dec", 33);

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
		SFSplineSeries series	= new SFSplineSeries ();
		series.Color			= UIColor.FromRGBA((nfloat)0.08235,(nfloat)0.2863,(nfloat)0.3098,(nfloat)1.0);
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


