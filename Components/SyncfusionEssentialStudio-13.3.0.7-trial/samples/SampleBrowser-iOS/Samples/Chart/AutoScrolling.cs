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
using CoreGraphics;
using Foundation;
using UIKit;

#else
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;
using nint	 = System.Int32;
using nuint	 = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif

using System.Threading.Tasks;

namespace SampleBrowser
{
	public class AutoScrolling : SampleView
	{
		SFChart chart;
		UILabel label;
		int wave1 	= 30;

		Random random;

		AutoScrollingDataSource dataModel;
		public AutoScrolling ()
		{

			chart 							= new SFChart ();
			SFNumericalAxis primaryAxis 	= new SFNumericalAxis ();
			primaryAxis.AutoScrollingDelta 	= 10;
			chart.PrimaryAxis				= primaryAxis;
			SFNumericalAxis secondaryAxis 	= new SFNumericalAxis ();
			secondaryAxis.Minimum 			= NSObject.FromObject(0);
			secondaryAxis.Maximum 			= NSObject.FromObject(9);
			chart.SecondaryAxis				= secondaryAxis;
			dataModel 						= new AutoScrollingDataSource ();
			chart.DataSource 				= dataModel as SFChartDataSource;

			label 							= new UILabel ();
			label.Text 						= "In this demo, a data point is being added for every 500 milliseconds. The Chart is then automatically scrolled to display the fixed range of data points at the end. You can also pan to view previous data points. In this sample the delta value is 10";
			label.Font						= UIFont.FromName("Helvetica", 12f);
			label.TextAlignment 			= UITextAlignment.Center;
			label.LineBreakMode 			= UILineBreakMode.WordWrap;
			label.Lines 					= 6; 
			label.BackgroundColor   		= UIColor.Black.ColorWithAlpha (0.7f);
			label.TextColor 				= UIColor.White;

			chart.AddChartBehavior (new SFChartZoomPanBehavior());

			this.AddSubview (chart);
			this.AddSubview (label);
			this.control = this;
			random = new Random ();
			UpdateData ();
		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				if (view == chart)
					chart.Frame = new CGRect (0, 0, Frame.Width, Frame.Height-68);
				else if (view == label)
					label.Frame = new CGRect (0, Frame.Height-62, Frame.Width, 70);
				else
					view.Frame = Frame;

			}
			base.LayoutSubviews ();
		}

		async void UpdateData()
		{
			await Task.Delay(500);
			NSNumber value = new NSNumber(random.Next(0,9)) ;
			dataModel.DataPoints.Add(new SFChartDataPoint(NSObject.FromObject(wave1),value));
			chart.InsertDataPointAtIndex ((int)dataModel.DataPoints.Count-1, 0);
			wave1++;

			UpdateData();
		}

	}

	public class AutoScrollingDataSource : SFChartDataSource
	{
		public NSMutableArray DataPoints { get; set;}
		int wave1 	= 0;

		public AutoScrollingDataSource ()
		{
			DataPoints 		= new NSMutableArray ();
			Random random 	= new Random ();

			for (int i = 1; i <= 30; i++) 
			{
				NSNumber value = new NSNumber(random.Next(0,9)) ;
				DataPoints.Add (new SFChartDataPoint (NSObject.FromObject (i), value));
				wave1++;
			}
		}
			
		public override nint NumberOfSeriesInChart (SFChart chart)
		{
			return 1; 
		}
			
		public override SFSeries GetSeries (SFChart chart, nint index)
		{
			SFColumnSeries series			= new SFColumnSeries ();
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

