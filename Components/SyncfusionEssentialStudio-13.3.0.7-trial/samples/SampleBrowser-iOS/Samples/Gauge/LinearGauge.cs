#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

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
using nfloat  = System.Single;
#endif
using Syncfusion.SfGauge.iOS;
namespace SampleBrowser
{
	public class LinearGauge : SampleView
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}
		#region View lifecycle
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
				label.Frame = new CGRect (Frame.Width/2-60, 320, 150, 50);
				linearGauge.Frame=  new CGRect (Frame.Width/2-140, 30, 300, 300);
			}
			base.LayoutSubviews ();
		}
		UILabel label;
		SFLinearGauge linearGauge;
		public LinearGauge ()
		{
			linearGauge = new SFLinearGauge ();
			label = new UILabel ();
			label.Text = "Memory Usage";

			linearGauge.BackgroundColor = UIColor.White;
			linearGauge.Orientation = SFLinearGaugeOrientation.SFLinearGaugeOrientationVertical;
			//Scale

			SFLinearScale scale = new SFLinearScale ();
			scale.Minimum = 0;
			scale.Maximum = 100;
			scale.Interval = 20;
			scale.ScaleBarLength = 100;
			//			scale.LabelPostfix = "%";
			scale.ScaleBarColor =UIColor.FromRGB (250, 236, 236);
			scale.LabelColor = UIColor.FromRGB (84, 84, 84); 
			scale.MinorTicksPerInterval = 1;
			scale.ScaleBarSize = 13;
			scale.ScalePosition = SFLinearGaugeScalePosition.SFLinearGaugeScalePositionForward;
			//SymbolPointer
			SFSymbolPointer symbolPointer = new SFSymbolPointer ();
			symbolPointer.Value = 50;
			symbolPointer.Offset = 0;
			symbolPointer.Thickness = 3;
			symbolPointer.Color = UIColor.FromRGB (65, 77, 79);

			//BarPointer
			SFBarPointer rangePointer = new SFBarPointer ();
			rangePointer.Value = 50;
			rangePointer.Color = UIColor.FromRGB (206, 69, 69);
			rangePointer.Thickness = 10;


			//Range
			SFLinearRange range = new SFLinearRange ();
			range.StartValue = 0;
			range.EndValue = 50;
			range.Color = UIColor.FromRGB (234, 248, 249);
			range.StartWidth = 10;
			range.EndWidth = 10;
			range.Offset = nfloat.Parse("-0.17");
			scale.Ranges.Add (range);


			//Range
			SFLinearRange range2 = new SFLinearRange ();
			range2.StartValue = 50;
			range2.EndValue = 100;
			range2.Color = UIColor.FromRGB (50, 184, 198);
			range2.StartWidth = 10;
			range2.EndWidth = 10;
			range2.Offset = nfloat.Parse("-0.17");
			scale.Ranges.Add (range2);

			//Minor Ticks setting
			SFLinearTickSettings minor = new SFLinearTickSettings ();
			minor.Length = 10;
			minor.Color = UIColor.FromRGB (175, 175, 175);
			minor.Thickness = 1;
			scale.MinorTickSettings = minor;

			//Major Ticks setting
			SFLinearTickSettings major = new SFLinearTickSettings ();
			major.Length = 10;
			major.Color = UIColor.FromRGB (175, 175, 175);
			major.Thickness = 1;
			scale.MajorTickSettings = major;
			scale.Pointers.Add (symbolPointer);
			scale.Pointers.Add (rangePointer);

			linearGauge.Scales.Add (scale);


			this.AddSubview (linearGauge);
			this.AddSubview (label);
			this.control = this;
			// Perform any additional setup after loading the view, typically from a nib.
		}
		#endregion
	}
}

