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
	public class DigitalGauge :SampleView
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		#region View lifecycle
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
				CGSize sz = this.Frame.Size;
				nfloat x = sz.Width / 2;
				digitalGauge1.Frame = new CGRect (x-132,  60, 265, 60);
				digitalGauge2.Frame = new CGRect (x-132,  160, 265, 60);
				digitalGauge3.Frame = new CGRect (x-132, 260, 265, 60);
				digitalGauge4.Frame = new CGRect (x-132,  360, 265, 60);
				label.Frame = new CGRect (x-50, 30, 100, 20);
				label2.Frame = new CGRect (x-50, 130, 100, 20);
				label3.Frame = new CGRect (x-50, 230, 100, 20);
				label4.Frame = new CGRect (x-60, 330, 120, 20);
			}
			base.LayoutSubviews ();
		}
		SFDigitalGauge digitalGauge4;
		SFDigitalGauge digitalGauge1;
		SFDigitalGauge digitalGauge2;
		SFDigitalGauge digitalGauge3;
		UILabel label,label2,label3,label4;
		public DigitalGauge ()
		{


			NSDate date = new NSDate ();
			NSString currentDateandTime = (NSString)date.ToString ();

			//			CGRect rect1 = CGRectMake(x, 27, 230, 60);
			digitalGauge1 = new SFDigitalGauge ();

			digitalGauge1.CharacterHeight = 36;
			digitalGauge1.CharacterWidth = 18;
			digitalGauge1.SegmentWidth = 3;
			//    digitalGauge1.horizontalPadding = 50;
			digitalGauge1.VerticalPadding = 10;
			digitalGauge1.CharacterType = SFDigitalGaugeCharacterType.SFDigitalGaugeCharacterTypeSegmentSeven;
			digitalGauge1.StrokeType = SFDigitalGaugeStrokeType.SFDigitalGaugeStrokeTypeTriangleEdge;
			digitalGauge1.Value = currentDateandTime;
			digitalGauge1.DimmedSegmentAlpha = nfloat.Parse("0.11");
			digitalGauge1.BackgroundColor = UIColor.FromRGB(248,248,248);
			digitalGauge1.CharacterColor = UIColor.FromRGB(20,108,237);
			digitalGauge1.DimmedSegmentColor = UIColor.FromRGB(20,108,237);

			//			CGRect rect2 = CGRectMake(x, 115, 230, 60);
			digitalGauge2 = new SFDigitalGauge ();


			digitalGauge2.CharacterHeight = 36;
			digitalGauge2.CharacterWidth = 18;
			digitalGauge2.SegmentWidth = 3;
			//    digitalGauge2.horizontalPadding = 50;
			digitalGauge2.VerticalPadding = 10;
			//    digitalGuge2.margin  = 8;
			digitalGauge2.CharacterType = SFDigitalGaugeCharacterType.SFDigitalGaugeCharacterTypeSegmentFourteen;
			digitalGauge2.StrokeType = SFDigitalGaugeStrokeType.SFDigitalGaugeStrokeTypeTriangleEdge;
			digitalGauge2.Value =currentDateandTime;
			digitalGauge2.DimmedSegmentAlpha =nfloat.Parse("0.11");
			//    digitalGauge2.backgroundColor = UIColor.FromRGB(:235/255.0f green:235/255.0f blue:235/255.0f alpha:1.0f];
			digitalGauge2.BackgroundColor = UIColor.FromRGB(248,248,248);
			digitalGauge2.CharacterColor = UIColor.FromRGB(2,186,94);
			digitalGauge2.DimmedSegmentColor = UIColor.FromRGB(2,186,94);


			//			CGRect rect3 = CGRectMake(x, 205, 230, 60);
			digitalGauge3 = new SFDigitalGauge ();

			digitalGauge3.CharacterHeight = 36;
			digitalGauge3.CharacterWidth = 18;
			digitalGauge3.SegmentWidth = 3;
			//    digitalGauge3.horizontalPadding = 50;
			digitalGauge3.VerticalPadding = 10;
			digitalGauge3.CharacterType = SFDigitalGaugeCharacterType.SFDigitalGaugeCharacterTypeSegmentSixteen;
			digitalGauge3.StrokeType = SFDigitalGaugeStrokeType.SFDigitalGaugeStrokeTypeTriangleEdge;
			digitalGauge3.Value = currentDateandTime;
			digitalGauge3.DimmedSegmentAlpha =nfloat.Parse("0.11");
			digitalGauge3.BackgroundColor = UIColor.FromRGB (248, 248, 248);
			digitalGauge3.CharacterColor = UIColor.FromRGB(219,153,7);
			digitalGauge3.DimmedSegmentColor = UIColor.FromRGB(219,153,7);

			//			CGRect rect4 = CGRectMake(x, 295, 230, 60);
			digitalGauge4 = new SFDigitalGauge ();

			digitalGauge4.CharacterHeight = 36;
			digitalGauge4.CharacterWidth = 17;
			digitalGauge4.SegmentWidth = 3;
			//    digitalGauge4.horizontalPadding = 50;
			digitalGauge4.VerticalPadding = 10;
			digitalGauge4.CharacterType = SFDigitalGaugeCharacterType.SFDigitalGaugeCharacterTypeEightCrossEightDotMatrix;
			digitalGauge4.StrokeType = SFDigitalGaugeStrokeType.SFDigitalGaugeStrokeTypeTriangleEdge;
			digitalGauge4.Value = currentDateandTime;
			digitalGauge4.DimmedSegmentAlpha = nfloat.Parse("0.11");
			digitalGauge4.BackgroundColor = UIColor.FromRGB (248, 248, 248);
			digitalGauge4.CharacterColor = UIColor.FromRGB(249,66,53);
			digitalGauge4.DimmedSegmentColor = UIColor.FromRGB (249, 66, 53);

			label = new UILabel ();
			label.Text = "7 Segment";


			label2 = new UILabel ();
			label2.Text = "14 Segment";

			label3 = new UILabel ();
			label3.Text = "16 Segment";

			label4 = new UILabel ();
			label4.Text = "8 X 8 DotMatrix";


			this.AddSubview (digitalGauge1);
			this.AddSubview (digitalGauge2);
			this.AddSubview (digitalGauge3);
			this.AddSubview (digitalGauge4);
			this.AddSubview (label);
			this.AddSubview (label2);
			this.AddSubview (label3);
			this.AddSubview (label4);
			this.control = this;
		}
		#endregion

	}
}
