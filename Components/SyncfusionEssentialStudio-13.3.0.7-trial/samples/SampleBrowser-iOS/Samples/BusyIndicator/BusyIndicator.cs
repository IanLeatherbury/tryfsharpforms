#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfBusyIndicator.iOS;

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
	public class BusyIndicator : SampleView
	{
		private readonly IList<string> animationTypes = new List<string> ();

		private string selectedType;

		UIPickerView picker = new UIPickerView ();
		UIButton textbutton = new UIButton ();
		UILabel label = new UILabel ();
		UIButton button = new UIButton ();
		SFBusyIndicator busyIndicator;
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
				busyIndicator.Frame=new CGRect(0,0, this.Frame.Size.Width,this.Frame.Size.Height);
				label.Frame=new CGRect(15, 40, this.Frame.Size.Width-20, 40);
				textbutton.Frame=new CGRect(10,80,  this.Frame.Size.Width-20, 40);
				picker.Frame=new CGRect(0,this.Frame.Size.Height-( this.Frame.Size.Height/3), this.Frame.Size.Width,this.Frame.Size.Height/3);
				button.Frame=new CGRect(0, this.Frame.Size.Height-( this.Frame.Size.Height/3), this.Frame.Size.Width, 40);
			}
			base.LayoutSubviews ();
		}
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		#region View lifecycle
		//NSArray animationTypes = new NSArray ();

		public BusyIndicator()
		{

			busyIndicator = new SFBusyIndicator ();
			this.animationTypes.Add ((NSString)"Ball");
			this.animationTypes.Add ((NSString)"Battery");
			this.animationTypes.Add ((NSString)"DoubleCircle");
			this.animationTypes.Add ((NSString)"ECG");
			this.animationTypes.Add ((NSString)"Globe");
			this.animationTypes.Add ((NSString)"HorizontalPulsingBox");
			this.animationTypes.Add ((NSString)"MovieTimer");
			this.animationTypes.Add ((NSString)"Print");
			this.animationTypes.Add ((NSString)"Rectangle");
			this.animationTypes.Add ((NSString)"RollingBall");
			this.animationTypes.Add ((NSString)"SingleCircle");
			this.animationTypes.Add ((NSString)"SlicedCircle");
			this.animationTypes.Add ((NSString)"ZoomingTarget");


			busyIndicator.Foreground = UIColor.FromRGB (36,63,217);
			busyIndicator.ViewBoxWidth = 100;
			busyIndicator.ViewBoxHeight = 100;
			busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeBall;
			this.AddSubview (busyIndicator);


			label.Text="AnimationTypes";
			label.TextColor = UIColor.Black;
			this.AddSubview (label);



			textbutton.SetTitle("Ball", UIControlState.Normal);
			textbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textbutton.BackgroundColor = UIColor.Clear;
			textbutton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			textbutton.Hidden = false;
			textbutton.Layer.BorderColor = UIColor.FromRGB(246,246,246).CGColor;
			textbutton.Layer.BorderWidth = 4;
			textbutton.Layer.CornerRadius = 8;
			textbutton.TouchUpInside += ShowPicker;
			this.AddSubview (textbutton);

			PickerModel model = new PickerModel(this.animationTypes);
			model.PickerChanged += (sender, e) => {
				this.selectedType = e.SelectedValue;
				textbutton.SetTitle(selectedType, UIControlState.Normal);
				if(selectedType=="Ball"){
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB (36,63,217);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeBall;}
				else if(selectedType=="Battery"){
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(167,0,21);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeBattery;}
				else if(selectedType=="DoubleCircle"){
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(149,140,123);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeDoubleCircle;}
				else if(selectedType=="ECG"){
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(218,144,26);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeECG;}
				else if(selectedType=="Globe"){
					busyIndicator.ViewBoxWidth=100;
					busyIndicator.ViewBoxHeight=100;
					busyIndicator.Foreground = UIColor.FromRGB(158,168,238);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeGlobe;}
				else if(selectedType=="HorizontalPulsingBox"){
					busyIndicator.ViewBoxWidth=100;
					busyIndicator.ViewBoxHeight=100;
					busyIndicator.Foreground = UIColor.FromRGB(228,46,6);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeHorizontalPulsingBox;}
				else if(selectedType=="MovieTimer"){
					busyIndicator.ViewBoxWidth=100;
					busyIndicator.ViewBoxHeight=100;
					busyIndicator.Foreground = UIColor.FromRGB(45,45,45);
					busyIndicator.SecondaryColor=UIColor.FromRGB(155,155,155);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeMovieTimer;}
				else if(selectedType=="Print"){
					busyIndicator.ViewBoxWidth=70;
					busyIndicator.ViewBoxHeight=70;
					busyIndicator.Foreground = UIColor.FromRGB(94,111,248);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypePrint;}
				else if(selectedType=="Rectangle"){
					busyIndicator.ViewBoxWidth=100;
					busyIndicator.ViewBoxHeight=100;
					busyIndicator.Foreground = UIColor.FromRGB(39,170,158);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeRectangle;}
				else if(selectedType=="RollingBall"){
					busyIndicator.ViewBoxWidth=70;
					busyIndicator.ViewBoxHeight=70;
					busyIndicator.Foreground = UIColor.FromRGB(45,45,45);
					busyIndicator.SecondaryColor=UIColor.White;
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeRollingBall;}
				else if(selectedType=="SingleCircle"){
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(175,37,65);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSingleCircle;}
				else if(selectedType=="SlicedCircle"){
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(119,151,114);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeSlicedCircle;}
				else if(selectedType=="ZoomingTarget"){
					busyIndicator.ViewBoxWidth = 70;
					busyIndicator.ViewBoxHeight = 70;
					busyIndicator.Foreground = UIColor.FromRGB(237,143,60);
					busyIndicator.AnimationType = SFBusyIndicatorAnimationType.SFBusyIndicatorAnimationTypeZoomingTarget;}
			};



			picker.ShowSelectionIndicator = true;
			picker.Hidden = false;
			picker.Model = model;
			picker.BackgroundColor = UIColor.White;

			this.AddSubview (picker);



			button.SetTitle("Done\t", UIControlState.Normal);
			button.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			button.BackgroundColor = UIColor.FromRGB(240,240,240);
			button.SetTitleColor(UIColor.Black, UIControlState.Normal);
			button.Hidden = false;
			button.TouchUpInside += HidePicker;
			this.AddSubview (button);



			this.BackgroundColor = UIColor.White;
			this.control = this;
			// Perform any additional setup after loading the view, typically from a nib.
		}


		void ShowPicker (object sender, EventArgs e) {

			button.Hidden = false;
			picker.Hidden = false;
			this.BecomeFirstResponder ();
		}

		void HidePicker (object sender, EventArgs e) {

			button.Hidden = true;
			picker.Hidden = true;
			this.BecomeFirstResponder ();
		}
		#endregion
	}
}

