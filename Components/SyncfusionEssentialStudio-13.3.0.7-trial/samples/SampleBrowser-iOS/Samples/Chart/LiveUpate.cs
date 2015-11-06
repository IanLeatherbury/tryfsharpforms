#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfChart.iOS;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

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
	public class LiveUpdate : SampleView
	{
		SFChart chart;
		int wave1 	= 180;
		int wave2	= 360;
		LiveUpdateDataSource dataModel;

		public LiveUpdate ()
		{

			chart 							= new SFChart ();
			SFNumericalAxis primaryAxis 	= new SFNumericalAxis ();
			chart.PrimaryAxis 				= primaryAxis;
			SFNumericalAxis secondaryAxis 	= new SFNumericalAxis ();
			secondaryAxis.Minimum 			= NSObject.FromObject( -1.5);
			secondaryAxis.Maximum 			= NSObject.FromObject(1.5);
			secondaryAxis.Interval 			= NSObject.FromObject( 0.5);
			chart.SecondaryAxis 			= secondaryAxis;
			dataModel 						= new LiveUpdateDataSource ();
			chart.DataSource 				= dataModel as SFChartDataSource;
			this.control = chart;
			UpdateData ();

		}

		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
			}
			base.LayoutSubviews ();
		}

		async void UpdateData()
		{
			
			await Task.Delay(10);
			dataModel.DataPoints.RemoveObject (0);
			chart.RemoveDataPointAtIndex (0, 0);
		

			dataModel.DataPoints.Add(new SFChartDataPoint(NSObject.FromObject(wave1), NSObject.FromObject(Math.Sin(wave1 * (Math.PI / 180.0)))));
			chart.InsertDataPointAtIndex ((int)dataModel.DataPoints.Count-1, 0);
			wave1++;

			dataModel.DataPoints1.RemoveObject (0);
			chart.RemoveDataPointAtIndex (0, 1);

			dataModel.DataPoints1.Add(new SFChartDataPoint(NSObject.FromObject(wave1), NSObject.FromObject(Math.Sin(wave2 * (Math.PI / 180.0)))));
			chart.InsertDataPointAtIndex ((int)dataModel.DataPoints1.Count-1, 1);
			wave2++;
			UpdateData();
		}

	}

	public class LiveUpdateDataSource : SFChartDataSource
	{
		public NSMutableArray DataPoints { get; set;}
		public NSMutableArray DataPoints1 { get; set;}
		int wave1 	= 0;
		int wave2 	= 180;
		public LiveUpdateDataSource ()
		{
			DataPoints 	= new NSMutableArray ();
			DataPoints1 = new NSMutableArray ();

			for (int i = 1; i <= 180; i++) 
			{
				double value = Math.Sin(wave1 * (Math.PI / 180.0));
				DataPoints.Add (new SFChartDataPoint (NSObject.FromObject (i), NSObject.FromObject(value)));
				wave1++;
			}
			for (int i = 1; i <= 180; i++) 
			{
				double value = Math.Sin(wave2 * (Math.PI / 180.0));
				DataPoints1.Add (new SFChartDataPoint (NSObject.FromObject (i), NSObject.FromObject(value)));
				wave2++;
			}
		}

		public override nint NumberOfSeriesInChart (SFChart chart)
		{
			return 2; 
		}

		public override SFSeries GetSeries (SFChart chart, nint index)
		{
			SFFastLineSeries series			= new SFFastLineSeries ();
			return series;
		}

		public override SFChartDataPoint GetDataPoint (SFChart chart, nint index, nint seriesIndex)
		{
			if (seriesIndex == 0)
				return DataPoints.GetItem<SFChartDataPoint> ((nuint)index);
			else
				return DataPoints1.GetItem<SFChartDataPoint> ((nuint)index);
		}

		public override nint GetNumberOfDataPoints (SFChart chart, nint index)
		{
			if(index ==0)
				return (int)DataPoints.Count;
			else 
				return (int)DataPoints1.Count;
		}
	}
}




