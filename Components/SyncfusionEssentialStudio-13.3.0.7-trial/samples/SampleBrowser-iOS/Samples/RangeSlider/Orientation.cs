#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfRangeSlider.iOS;

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

namespace SampleBrowser
{
	public class Orientation : SampleView
	{
		SFRangeSlider rangeSlider1, rangeSlider2, rangeSlider3;
		UILabel label1,label2,label3,label4,label5,label6;

		public Orientation ()
		{
			rangeSlider1 = new SFRangeSlider ();
			rangeSlider2 = new SFRangeSlider ();
			rangeSlider3 = new SFRangeSlider ();
			label1 = new UILabel ();
			label2 = new UILabel ();
			label3 = new UILabel ();
			label4 = new UILabel ();
			label5 = new UILabel ();
			label6 = new UILabel ();
			rangeSlider1.Delegate = new RangeSliderDelegate ();
			rangeSlider2.Delegate = new RangeSliderDelegate ();
			rangeSlider3.Delegate = new RangeSliderDelegate ();
			rangeSlider1.Maximum=12;
			rangeSlider1.Minimum =-12;
			rangeSlider1.RangeStart =-12;
			rangeSlider1.RangeEnd =(nfloat)2.2;
			rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementNone;
			rangeSlider1.TickFrequency =12;
			rangeSlider1.Orientation = SFOrientation.SFOrientationVertical;
			rangeSlider1.ValuePlacement = SFValuePlacement.SFValuePlacementTopLeft;
			rangeSlider1.SnapsTo = SFSnapsTo.SFSnapsToNone;
			rangeSlider1.KnobColor = UIColor.White;
			rangeSlider1.TrackSelectionColor = UIColor.FromRGB (182, 182, 182);
			rangeSlider1.TrackColor = UIColor.FromRGB (182, 182, 182);
			rangeSlider1.ShowRange = false;

			rangeSlider2.Maximum=12;
			rangeSlider2.Minimum =-12;
			rangeSlider2.RangeStart =-12;
			rangeSlider2.RangeEnd =(nfloat)(-4.7);
			rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementNone;
			rangeSlider2.TickFrequency = 12;
			rangeSlider2.Orientation = SFOrientation.SFOrientationVertical;
			rangeSlider2.ValuePlacement = SFValuePlacement.SFValuePlacementTopLeft;
			rangeSlider2.SnapsTo = SFSnapsTo.SFSnapsToNone;
			rangeSlider2.KnobColor = UIColor.White;
			rangeSlider2.ShowRange = false;
			rangeSlider2.TrackSelectionColor = UIColor.FromRGB (182, 182, 182);
			rangeSlider2.TrackColor = UIColor.FromRGB (182, 182, 182);

			rangeSlider3.Maximum=12;
			rangeSlider3.Minimum =-12;
			rangeSlider3.RangeStart =-12;
			rangeSlider3.RangeEnd =(nfloat)6;
			rangeSlider3.TickPlacement = SFTickPlacement.SFTickPlacementNone;
			rangeSlider3.TickFrequency = 12;
			rangeSlider3.Orientation = SFOrientation.SFOrientationVertical;
			rangeSlider3.ValuePlacement = SFValuePlacement.SFValuePlacementTopLeft;
			rangeSlider3.SnapsTo = SFSnapsTo.SFSnapsToNone;
			rangeSlider3.KnobColor = UIColor.White;
			rangeSlider3.ShowRange = false;
			rangeSlider3.TrackSelectionColor = UIColor.FromRGB (182, 182, 182);
			rangeSlider3.TrackColor = UIColor.FromRGB (182, 182, 182);

			label1.TextColor = UIColor.FromRGB (109, 109, 114);
			label1.Text = "60Hz";
			label1.TextAlignment = UITextAlignment.Center;
			label1.Font=UIFont.FromName("Helvetica", 20f);

			label2.TextColor = UIColor.FromRGB (109, 109, 114);
			label2.Text = "170Hz";
			label2.TextAlignment = UITextAlignment.Center;
			label2.Font=UIFont.FromName("Helvetica", 20f);

			label3.TextColor = UIColor.FromRGB (109, 109, 114);
			label3.Text = "310Hz";
			label3.TextAlignment = UITextAlignment.Center;
			label3.Font=UIFont.FromName("Helvetica", 20f);

			label4.TextColor = UIColor.FromRGB (57, 181, 247);
			label4.Text = "2.2db";
			label4.TextAlignment = UITextAlignment.Center;
			label4.Font=UIFont.FromName("Helvetica", 14f);

			label5.TextColor = UIColor.FromRGB (57, 181, 247);
			label5.Text = "-4.7db";
			label5.TextAlignment = UITextAlignment.Center;
			label5.Font=UIFont.FromName("Helvetica", 14f);

			label6.TextColor = UIColor.FromRGB (57, 181, 247);
			label6.Text = "6.0db";
			label6.TextAlignment = UITextAlignment.Center;
			label6.Font=UIFont.FromName("Helvetica", 14f);
			this.AddSubview (rangeSlider3);
			this.AddSubview (rangeSlider1);
			this.AddSubview (rangeSlider2);
			this.AddSubview (label1);
			this.AddSubview (label2);
			this.AddSubview (label3);
			this.AddSubview (label4);
			this.AddSubview (label5);
			this.AddSubview (label6);
			this.control = this;
		}

		public void SetValue(SFRangeSlider r,nfloat value)
		{
			nfloat f = (nfloat)Math.Round (value,1);
			if(r==rangeSlider1)
				label4.Text = f.ToString()+"db";
			else if(r == rangeSlider2)
				label5.Text = f.ToString()+"db";
			else
				label6.Text = f.ToString()+"db";

		}
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
				label1.Frame=new CGRect(0, this.Frame.Size.Height/7, this.Frame.Size.Width/3, 30);
				label2.Frame=new CGRect(this.Frame.Size.Width/3, this.Frame.Size.Height/7, this.Frame.Size.Width/3, 30);
				label3.Frame=new CGRect((this.Frame.Size.Width/3)*2, this.Frame.Size.Height/7, this.Frame.Size.Width/3, 30);
				label4.Frame=new CGRect(0, this.Frame.Size.Height/5, this.Frame.Size.Width/3, 30);
				label5.Frame=new CGRect(this.Frame.Size.Width/3, this.Frame.Size.Height/5, this.Frame.Size.Width/3, 30);
				label6.Frame=new CGRect((this.Frame.Size.Width/3)*2, this.Frame.Size.Height/5, this.Frame.Size.Width/3, 30);
				rangeSlider1.Frame=new CGRect(0,this.Frame.Size.Height/4, this.Frame.Size.Width/4,this.Frame.Size.Height-this.Frame.Size.Height/4-50);
				rangeSlider2.Frame=new CGRect(this.Frame.Size.Width/3,this.Frame.Size.Height/4, this.Frame.Size.Width/3,this.Frame.Size.Height-this.Frame.Size.Height/4-50);
				rangeSlider3.Frame=new CGRect((this.Frame.Size.Width/3)*2,this.Frame.Size.Height/4, this.Frame.Size.Width/3,this.Frame.Size.Height-this.Frame.Size.Height/4-50);
			}
			base.LayoutSubviews ();
		}
		public class RangeSliderDelegate:SFRangeSliderDelegate
		{
			public override void ValueChange (SFRangeSlider SFRangeSlider, nfloat value)
			{
				(SFRangeSlider.Superview as Orientation).SetValue (SFRangeSlider,value);
			}
		}
	}
}

