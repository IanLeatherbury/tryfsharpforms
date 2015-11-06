#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfRangeSlider.iOS;
using System.Collections.Generic;


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
	public class RangeSliderGettingStarted : SampleView
	{
		SFRangeSlider rangeSlider1,rangeSlider2;
		UILabel label1,label2,label3,label4,label5,label6,label7,label8,label9,label10;
		UIButton textbutton = new UIButton ();
		UIButton textbutton1 = new UIButton ();
		UIButton doneButton=new UIButton();
		UIPickerView picker1, picker2;
		UISwitch labelswitch, labelswitch1;
		private string selectedType;
		private readonly IList<string> TAlignment = new List<string>
		{
			"BottomRight",
			"TopLeft",
			"Inline",
			"Outside",
			"None"
		};
		private readonly IList<string> LAlignment = new List<string>
		{
			"BottomRight",
			"TopLeft"
		};
		UIView view1 = new UIView ();
		public override UIView optionView()
		{
			base.optionView ();

			view1.AddSubview (label3);
			view1.AddSubview (textbutton);
			view1.AddSubview (label4);
			view1.AddSubview (textbutton1);
			view1.AddSubview (picker1);
			view1.AddSubview (picker2);
			view1.AddSubview (doneButton);
			view1.AddSubview (label7);
			view1.AddSubview (labelswitch);
			view1.AddSubview (label8);
			view1.AddSubview (labelswitch1);
			return view1;
		}
		public RangeSliderGettingStarted ()
		{
			picker1 = new UIPickerView ();
			picker2 = new UIPickerView ();
			labelswitch = new UISwitch ();
			labelswitch1 = new UISwitch ();
			PickerModel model = new PickerModel (TAlignment);
			picker1.Model = model;
			PickerModel model1 = new PickerModel (LAlignment);
			picker2.Model = model1;
			rangeSlider1 = new SFRangeSlider ();
			rangeSlider2 = new SFRangeSlider ();
			rangeSlider1.Delegate=new RangeSliderDelegate();
			rangeSlider2.Delegate = new RangeSliderDelegate ();
			label1 = new UILabel ();
			label2 = new UILabel ();
			label3 = new UILabel ();
			label4 = new UILabel ();
			label5 = new UILabel ();
			label6 = new UILabel ();
			label9 = new UILabel ();
			label10 = new UILabel ();
			textbutton = new UIButton ();
			textbutton1 = new UIButton ();
			label7 = new UILabel ();
			label8 = new UILabel ();
			rangeSlider1.Maximum = 12;
			rangeSlider1.Minimum = 0;
			rangeSlider1.RangeStart = 0;
			rangeSlider1.RangeEnd = 12;
			rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementBottomRight;
			rangeSlider1.TickFrequency = 2;
			rangeSlider1.ValuePlacement = SFValuePlacement.SFValuePlacementBottomRight;
			rangeSlider1.SnapsTo = SFSnapsTo.SFSnapsToNone;
			rangeSlider1.KnobColor = UIColor.White;
			rangeSlider1.TrackSelectionColor = UIColor.FromRGB (65, 115, 185);
			rangeSlider1.TrackColor = UIColor.FromRGB (182, 182, 182);

			label1.Text = "Departure";
			label1.TextColor = UIColor.Black;
			label1.TextAlignment = UITextAlignment.Left;
			label1.Font=UIFont.FromName("Helvetica", 18f);

			label3.Text = "Tick Placement";
			label3.TextColor = UIColor.Black;
			label3.TextAlignment = UITextAlignment.Left;

			label4.Text = "Label Placement";
			label4.TextColor = UIColor.Black;
			label4.TextAlignment = UITextAlignment.Left;

			label5.Text = "(in Hours)";
			label5.TextColor = UIColor.Gray;
			label5.TextAlignment = UITextAlignment.Left;
			label5.Font=UIFont.FromName("Helvetica", 14f);

			label6.Text = "(in Hours)";
			label6.TextColor = UIColor.Gray;
			label6.TextAlignment = UITextAlignment.Left;
			label6.Font=UIFont.FromName("Helvetica", 14f);

			label8.Text = "SnapToTick";
			label8.TextColor = UIColor.Black;
			label8.TextAlignment = UITextAlignment.Left;

			label9.Text = "Time: 12 AM - 12 PM";
			label9.TextColor = UIColor.Gray;
			label9.TextAlignment = UITextAlignment.Left;
			label9.Font=UIFont.FromName("Helvetica", 14f);

			label10.Text = "Time: 12 AM - 12 PM";
			label10.TextColor = UIColor.Gray;
			label10.TextAlignment = UITextAlignment.Left;
			label10.Font=UIFont.FromName("Helvetica", 14f);

			textbutton.SetTitle("BottomRight",UIControlState.Normal);
			textbutton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			textbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textbutton.Layer.CornerRadius = 8;
			textbutton.Layer.BorderWidth = 2;
			textbutton.TouchUpInside += ShowPicker1;
			textbutton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;


			textbutton1.SetTitle("BottomRight",UIControlState.Normal);
			textbutton1.SetTitleColor(UIColor.Black,UIControlState.Normal);
			textbutton1.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textbutton1.Layer.CornerRadius = 8;
			textbutton1.Layer.BorderWidth = 2;
			textbutton1.TouchUpInside += ShowPicker2;
			textbutton1.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			doneButton.SetTitle("Done\t",UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(246,246,246);

			label7.Text = "ShowLabel";
			label7.TextColor = UIColor.Black;
			label7.TextAlignment = UITextAlignment.Left;

			labelswitch.On = true;
			labelswitch1.On = false;

			rangeSlider2.Frame = new CGRect (10, 100, this.Frame.Size.Width, this.Frame.Size.Height);
			rangeSlider2.Maximum = 12;
			rangeSlider2.Minimum = 0;
			rangeSlider2.RangeStart = 0;
			rangeSlider2.RangeEnd = 12;
			rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementBottomRight;
			rangeSlider2.TickFrequency = 2;
			rangeSlider2.ValuePlacement = SFValuePlacement.SFValuePlacementBottomRight;
			rangeSlider2.SnapsTo = SFSnapsTo.SFSnapsToNone;
			rangeSlider2.KnobColor = UIColor.White;
			rangeSlider2.TrackSelectionColor = UIColor.FromRGB (65, 115, 185);
			rangeSlider2.TrackColor = UIColor.FromRGB (182, 182, 182);

			labelswitch.ValueChanged += toggleChanged;
			labelswitch1.ValueChanged += toggleChanged1;
			label2.Text = "Arrival";
			label2.TextColor = UIColor.Black;
			label2.TextAlignment = UITextAlignment.Left;
			label2.Font=UIFont.FromName("Helvetica", 18f);
			model.PickerChanged += SelectedIndexChanged;
			model1.PickerChanged += SelectedIndexChanged1;

			picker1.ShowSelectionIndicator = true;
			picker1.Hidden = true;

			picker2.ShowSelectionIndicator = true;
			picker2.Hidden = true;

			this.AddSubview (rangeSlider1);
			this.AddSubview (rangeSlider2);
			this.AddSubview (label1);
			this.AddSubview (label2);
			this.AddSubview (label5);
			this.AddSubview (label6);
			this.AddSubview (label9);
			this.AddSubview (label10);
			this.control = this;
		}

		public void SetValue(SFRangeSlider r,nfloat start, nfloat end)
		{
			if (r == rangeSlider1) {
				if (Math.Round (start) < 1) {
					if (Math.Round (end) == 12)
						label9.Text = "Time: 12 AM - " + Math.Round (end) + " PM";
					else
						label9.Text = "Time: 12 AM - " + Math.Round (end) + " AM";
				} else {
					if (Math.Round (end) == 12)
						label9.Text = "Time: " + Math.Round (start) + " AM - " + Math.Round (end) + " PM";
					else
						label9.Text = "Time: " + Math.Round (start) + " AM - " + Math.Round (end) + " AM";
				}
				if (Math.Round (start) == Math.Round (end)) {
					if (Math.Round (start) < 1)
						label9.Text = "Time: 12 AM";
					else if (Math.Round (start) == 12)
						label9.Text = "Time: 12 PM";
					else
						label9.Text = "Time: " + Math.Round (start) + " AM";
				}

			} 
			else if(r==rangeSlider2){
				if (Math.Round (start) < 1) {
					if (Math.Round (end) == 12)
						label10.Text = "Time: 12 AM - " + Math.Round (end) + " PM";
					else
						label10.Text = "Time: 12 AM - " + Math.Round (end) + " AM";
				} else {
					if (Math.Round (end) == 12)
						label10.Text = "Time: " + Math.Round (start) + " AM - " + Math.Round (end) + " PM";
					else
						label10.Text = "Time: " + Math.Round (start) + " AM - " + Math.Round (end) + " AM";
				}
				if (Math.Round (start) == Math.Round (end)) {
					if (Math.Round (start) < 1)
						label10.Text = "Time: 12 AM";
					else if (Math.Round (start) == 12)
						label10.Text = "Time: 12 PM";
					else
						label10.Text = "Time: " + Math.Round (start) + " AM";
				}

			}

		}

		public override void LayoutSubviews ()
		{
			
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
				label1.Frame = new CGRect (this.Frame.X + 10, this.Frame.Size.Height/6,85, 30);
				label2.Frame = new CGRect (this.Frame.X + 10,this.Frame.Size.Height -(this.Frame.Size.Height/2.5f), 80, 30);
				label5.Frame = new CGRect (this.Frame.X + 95, this.Frame.Size.Height / 6, this.Frame.Size.Width-20, 30);
				label6.Frame = new CGRect (this.Frame.X + 65, this.Frame.Size.Height -(this.Frame.Size.Height/2.5f), 85, 30);
				label9.Frame = new CGRect (this.Frame.X + 10, (this.Frame.Size.Height/6)+30,150, 30);
				label10.Frame = new CGRect (this.Frame.X + 10,(this.Frame.Size.Height -(this.Frame.Size.Height/2.5f))+30, 150, 30);
				rangeSlider1.Frame = new CGRect (2, (nfloat)(this.Frame.Size.Height/3.5), this.Frame.Size.Width - 4,  100);
				rangeSlider2.Frame = new CGRect (2, this.Frame.Size.Height -(nfloat)(this.Frame.Size.Height/3.5), this.Frame.Size.Width - 4, 100);


				label3.Frame = new CGRect (this.Frame.X +10, this.Frame.Y-20, this.Frame.Size.Width - 20, 30);
				textbutton.Frame=new CGRect(this.Frame.X +10, this.Frame.Y+20, this.Frame.Size.Width - 20, 30);	
				label4.Frame = new CGRect (this.Frame.X +10, this.Frame.Y+60, this.Frame.Size.Width - 20, 30);
				textbutton1.Frame=new CGRect(this.Frame.X +10, this.Frame.Y+100, this.Frame.Size.Width - 20, 30);	
				picker1.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width, this.Frame.Size.Height/3);
				picker2.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width , this.Frame.Size.Height/3);
				label7.Frame = new CGRect (this.Frame.X +10, this.Frame.Y+140, this.Frame.Size.Width - 20, 30);
				labelswitch.Frame = new CGRect (this.Frame.Size.Width-(labelswitch.Frame.Width)-20, this.Frame.Y+140, labelswitch.Frame.Width, 30);
				label8.Frame = new CGRect (this.Frame.X +10, this.Frame.Y+180, this.Frame.Size.Width - 20, 30);
				labelswitch1.Frame = new CGRect (this.Frame.Size.Width-(labelswitch.Frame.Width)-20, this.Frame.Y+180, labelswitch.Frame.Width, 30);
				doneButton.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width, 30);
			}
			base.LayoutSubviews ();
		}


		void ShowPicker1 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			picker1.Hidden = false;
			picker2.Hidden = true;
		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			picker2.Hidden = true;
			picker1.Hidden = true;
		}

		void ShowPicker2 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			picker1.Hidden = true;
			picker2.Hidden = false;
		}

		private void SelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			textbutton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "TopLeft") {
				rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementTopLeft;
				rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementTopLeft;
			} else if (selectedType == "BottomRight") {
				rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementBottomRight;
				rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementBottomRight;
			} else if (selectedType == "Inline") {
				rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementInline;
				rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementInline;
			} else if (selectedType == "Outside") {
				rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementOutSide;
				rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementOutSide;
			} else if (selectedType == "None") {
				rangeSlider1.TickPlacement = SFTickPlacement.SFTickPlacementNone;
				rangeSlider2.TickPlacement = SFTickPlacement.SFTickPlacementNone;
			} 
		}
		private void SelectedIndexChanged1(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			textbutton1.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "TopLeft") {
				rangeSlider1.ValuePlacement = SFValuePlacement.SFValuePlacementTopLeft;
				rangeSlider2.ValuePlacement = SFValuePlacement.SFValuePlacementTopLeft;
			} else if (selectedType == "BottomRight") {
				rangeSlider1.ValuePlacement = SFValuePlacement.SFValuePlacementBottomRight;
				rangeSlider2.ValuePlacement = SFValuePlacement.SFValuePlacementBottomRight;
			}
		}
		private void toggleChanged(object sender, EventArgs e)
		{
			if (((UISwitch)sender).On) {
				rangeSlider1.ShowValueLabel = true;
				rangeSlider2.ShowValueLabel = true;
			} else {
				rangeSlider1.ShowValueLabel = false;
				rangeSlider2.ShowValueLabel = false;
			}
		}
		private void toggleChanged1(object sender, EventArgs e)
		{
			if (((UISwitch)sender).On) {
				rangeSlider1.SnapsTo = SFSnapsTo.SFSnapsToTicks;
				rangeSlider2.SnapsTo = SFSnapsTo.SFSnapsToTicks;
			} else {
				rangeSlider1.SnapsTo = SFSnapsTo.SFSnapsToNone;
				rangeSlider2.SnapsTo = SFSnapsTo.SFSnapsToNone;
			}
		}

		public class RangeSliderDelegate:SFRangeSliderDelegate
		{
			public override void RangeValueChange (SFRangeSlider SFRangeSlider, nfloat start, nfloat end)
			{
				(SFRangeSlider.Superview as RangeSliderGettingStarted).SetValue (SFRangeSlider, start, end);
			}
		}
	}
}

