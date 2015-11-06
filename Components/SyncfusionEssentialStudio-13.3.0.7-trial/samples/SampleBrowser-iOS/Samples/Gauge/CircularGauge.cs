#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfGauge.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
using System.Drawing;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using CGRect = System.Drawing.RectangleF;
using CGPoint = System.Drawing.PointF;
using CGSize = System.Drawing.SizeF;
using nfloat = System.Single;
using System.Drawing;
#endif

namespace SampleBrowser
{
	public class CircularGauge : SampleView
	{

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}
			

		#region View lifecycle
		SFCircularGauge gauge;
		SFCircularScale scale;
		SFNeedlePointer needlePointer;
		SFRangePointer rangePointer;

		public CircularGauge ()
		{

			gauge = new SFCircularGauge ();
			gauge.Scales.Add (new SFCircularScale ());
			NSMutableArray scales = new NSMutableArray();

			scale = new SFCircularScale();
			scale.StartValue = 0;
			scale.EndValue = 100;
			scale.Interval = 10;
			scale.StartAngle = 35;
			scale.SweepAngle = 320;
			scale.RimWidth = 5;
			//	scale.LabelPostfix = (NSString)"%";
			scale.ShowTicks = true;
			scale.ShowLabels = true;
			scale.RimColor = UIColor.FromRGB((byte)209,(byte)70,(byte)70);

			scale.LabelColor = UIColor.Gray;
			scale.LabelOffset = 0.3f;
			scale.MinorTicksPerInterval = 0;

			NSMutableArray pointers = new NSMutableArray();

		    needlePointer = new SFNeedlePointer();
			needlePointer.Value = 60;
			needlePointer.Color = UIColor.Gray;
			needlePointer.KnobRadius = 12;
			needlePointer.KnobColor = UIColor.FromRGB(43, 191, 184);
			needlePointer.Width = 3;
			needlePointer.LengthFactor =nfloat.Parse("0.8");
			//	needlePointer.PointerType = SFCiruclarGaugePointerType.SFCiruclarGaugePointerTypeBar;
            
			rangePointer = new SFRangePointer();
			rangePointer.Value = 60;
			rangePointer.Color = UIColor.FromRGB(43, 191, 184);
			rangePointer.Width = 5;
			pointers.Add(needlePointer);
			pointers.Add(rangePointer);

			SFTickSettings minor = new SFTickSettings();
			minor.Size = 4;
			minor.Color = UIColor.FromRGB(68, 68, 68);
			minor.Width = 3;
			scale.MinorTickSettings = minor;

			SFTickSettings major = new SFTickSettings();
			major.Size = 12;
			major.Offset = 0.2f;
			major.Color = UIColor.FromRGB(68,68,68);
			major.Width = 2;
			scale.MajorTickSettings = major;
			scale.Pointers = pointers;
			scales.Add(scale);
			gauge.Scales = scales;

			SFGaugeHeader header = new SFGaugeHeader();
			header.Text = (NSString)"Speedometer";
			header.Position = new CGPoint (0.4f, 0.7f);
			header.TextColor = UIColor.Gray;
			gauge.Headers.Add(header);

		 
			this.AddSubview (gauge);
			this.control = gauge;
		}

		UIView view1 = new UIView ();
		public override UIView optionView()
		{
			base.optionView ();
			UISlider slider = new UISlider(new RectangleF(5,  50, 300, 60));
			this.Add(slider);
			slider.MinValue = 0f;
			slider.MaxValue = 100f;
			slider.Value = 60f;
			slider.ValueChanged+= (object sender, EventArgs e) => 
			{
				needlePointer.Value=slider.Value;
				rangePointer.Value= slider.Value;
			};

			UISlider slider2 = new UISlider(new RectangleF(5, 155, 300, 60));
			this.Add (slider2);
			slider2.MinValue = 0f;
			slider2.MaxValue = 0.8f;
			slider2.Value = 0.2f;
			slider2.ValueChanged+= (object sender, EventArgs e) => 
			{
				scale.MajorTickSettings.Offset=slider2.Value;
			};

			UISlider slider3 = new UISlider(new RectangleF(5, 260, 300, 60));
			this.Add (slider3);
			slider3.MinValue = 0f;
			slider3.MaxValue = 0.8f;
			slider3.Value = 0.3f;
			slider3.ValueChanged+= (object sender, EventArgs e) => 
			{
				scale.LabelOffset=slider3.Value;
			};

			UILabel text1 = new UILabel ();
			text1.Text = "POINTER VALUE";
			text1.TextAlignment = UITextAlignment.Left;
			text1.BackgroundColor = UIColor.FromRGB(240,240,240);
			text1.Frame = new CGRect (10,25, 300,40);
			text1.Font=UIFont.FromName("Helvetica", 14f);

			UILabel text2 = new UILabel ();
			text2.Text = "TICK OFFSET";
			text2.TextAlignment = UITextAlignment.Left;
			text2.BackgroundColor = UIColor.FromRGB(240,240,240);
			text2.Frame = new CGRect (10,130, 300,40);
			text2.Font=UIFont.FromName("Helvetica", 14f);

			UILabel text3 = new UILabel ();
			text3.BackgroundColor = UIColor.FromRGB(255,255,255);
			//text3.Frame = new CGRect (0,55, 300,50);

			UILabel text4 = new UILabel ();
			text4.BackgroundColor = UIColor.FromRGB(255,255,255);
			///text4.Frame = new CGRect (0,160, 300,50);


			UILabel text5 = new UILabel ();
			text5.Text = "LABEL OFFSET";
			text5.TextAlignment = UITextAlignment.Left;
			text5.BackgroundColor = UIColor.FromRGB(240,240,240);
			text5.Frame = new CGRect (10,230, 300,40);
			text5.Font=UIFont.FromName("Helvetica", 14f);

			UILabel text6 = new UILabel ();
			text6.BackgroundColor = UIColor.FromRGB(255,255,255);
			//text6.Frame = new CGRect (0,260, 300,50);

			view1.AddSubview (text1);
			view1.AddSubview (text2);
			view1.AddSubview (text3);
			view1.AddSubview (text4);
			view1.AddSubview (text5);
			view1.AddSubview (text6);
			view1.AddSubview (slider);
			view1.AddSubview (slider2);
			view1.AddSubview (slider3);
			return view1;
		}

		#endregion
	}
	}


