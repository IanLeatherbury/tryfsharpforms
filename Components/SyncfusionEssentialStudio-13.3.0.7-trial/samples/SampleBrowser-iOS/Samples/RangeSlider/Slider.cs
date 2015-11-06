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
	public class Slider : SampleView
	{
		UIImageView image;
		SFRangeSlider RangeSliderSample;
		UILabel label;

		public Slider ()
		{
			image = new UIImageView (); 
			RangeSliderSample = new SFRangeSlider ();
			label = new UILabel ();
			RangeSliderSample.Delegate = new RangeSliderDelegate ();
			image.Image = UIImage.FromBundle ("Images/mount.png");

			label.TextColor = UIColor.Black;
			label.Text = "Opacity";
			label.TextAlignment = UITextAlignment.Left;
			label.Font=UIFont.FromName("Helvetica", 20f);

			RangeSliderSample.Maximum=100;
			RangeSliderSample.Minimum=0;
			RangeSliderSample.RangeStart=0;
			RangeSliderSample.RangeEnd=100;
			RangeSliderSample.TickPlacement=SFTickPlacement.SFTickPlacementBottomRight;
			RangeSliderSample.ValuePlacement=SFValuePlacement.SFValuePlacementBottomRight;
			RangeSliderSample.TickFrequency=20;
			RangeSliderSample.SnapsTo=SFSnapsTo.SFSnapsToTicks;
			RangeSliderSample.ShowRange=false;
			RangeSliderSample.KnobColor=UIColor.White;
			RangeSliderSample.TrackSelectionColor=UIColor.FromRGB(66,115,185);
			RangeSliderSample.TrackColor=UIColor.FromRGB(182,182,182);

			//			RangeSliderDelegate slider= new SFRangeSliderDelegate (image);
			//			slider.valueChanged+= (sender, e) => {
			//				this.image.Alpha=e.imageval;
			//			};

			this.AddSubview (image);
			this.AddSubview (label);
			this.AddSubview (RangeSliderSample);
			this.control = this;
		}

		public void SetValue(nfloat value)
		{
			image.Alpha = value / 100;

		}
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
				image.Frame = new CGRect (this.Frame.X+20, this.Frame.Y, this.Frame.Size.Width - 40,this.Frame.Size.Height/2);
				label.Frame=new CGRect(this.Frame.X+20, this.Frame.Size.Height/2+90, this.Frame.Size.Width-40, 30);
				RangeSliderSample.Frame=new CGRect(this.Frame.X + 10, this.Frame.Y+ 100, this.Frame.Size.Width - 20, this.Frame.Size.Height-20);
			}
			base.LayoutSubviews ();
		}
	}

	public class RangeSliderDelegate:SFRangeSliderDelegate
	{
		public override void ValueChange (SFRangeSlider SFRangeSlider, nfloat value)
		{
			(SFRangeSlider.Superview as Slider).SetValue (value);
		}
	}

	public class RangeSliderValueChangedEventArgs : EventArgs
	{
		public nfloat imageval {get; set;}
	}
}

