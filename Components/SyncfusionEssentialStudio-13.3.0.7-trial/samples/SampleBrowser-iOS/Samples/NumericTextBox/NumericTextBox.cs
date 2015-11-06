#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfNumericTextBox.iOS;
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
	public class NumericTextBox : SampleView
	{
		UIPickerView picker;
		UILabel titleText, description, formulaLabel, principal, interestrate, term, interest, culLabel,allow;
		UISwitch allowSwitch;
		UIButton button,culture;
		private string selectedType;
		SFNumericTextBox numericTextBox1;
		SFNumericTextBox numericTextBox2;
		SFNumericTextBox numericTextBox3;
		SFNumericTextBox numericTextBox4;
		UIView options = new UIView();
		private readonly IList<string> cultureTypes = new List<string> ();
		public override UIView optionView()
		{
			base.optionView ();

			return options;
		}
		public override void LayoutSubviews ()
		{
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
				numericTextBox1.Frame = new CGRect(200, 120, view.Frame.Width-220, 40);
				numericTextBox2.Frame = new CGRect(200, 180, view.Frame.Width-220, 40);
				numericTextBox3.Frame = new CGRect(200, 240, view.Frame.Width-220, 40);
				numericTextBox4.Frame = new CGRect(200, 300, view.Frame.Width-220, 40);
				titleText.Frame =new CGRect(15, 0, this.Frame.Size.Width-20, 50);
				description.Frame = new CGRect(15, 35, this.Frame.Size.Width-20, 50);
				formulaLabel.Frame = new CGRect(15, 60, this.Frame.Size.Width-20, 50);
				principal.Frame = new CGRect(15, 120, this.Frame.Size.Width-20, 50);
				interestrate.Frame = new CGRect(15, 180, this.Frame.Size.Width-20, 50);
				term.Frame = new CGRect(15, 240, this.Frame.Size.Width-20, 50);
				interest.Frame = new CGRect(15, 300, this.Frame.Size.Width-20, 50);
				culLabel.Frame=new CGRect(15, 40, this.Frame.Size.Width-20, 40);
				culture.Frame=new CGRect(10,80,  this.Frame.Size.Width-20, 40);
				allow.Frame=new CGRect(15, 140, this.Frame.Size.Width-20, 40);
				allowSwitch.Frame=new CGRect(250,140,  this.Frame.Size.Width-20, 40);
				picker.Frame=new CGRect(0,this.Frame.Size.Height-( this.Frame.Size.Height/3), this.Frame.Size.Width,this.Frame.Size.Height/3);
				button.Frame=new CGRect(0, this.Frame.Size.Height-( this.Frame.Size.Height/3), this.Frame.Size.Width, 40);
			}
			base.LayoutSubviews ();
		}
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}
		public NumericTextBox ()
		{
			this.cultureTypes.Add ((NSString)"United States");
			this.cultureTypes.Add ((NSString)"United Kingdom");
			this.cultureTypes.Add ((NSString)"Japan");
			this.cultureTypes.Add ((NSString)"France");
			this.cultureTypes.Add ((NSString)"Italy");

			numericTextBox1= new SFNumericTextBox();
			numericTextBox1.Watermark = "Enter Principal";
			numericTextBox1.AllowNull = true;
			numericTextBox1.MaximumNumberDecimalDigits = 2;
			numericTextBox1.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			numericTextBox1.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			numericTextBox1.FormatString = "c";
			numericTextBox1.Value = 1000;
			numericTextBox1.CultureInfo = new NSLocale ("en_US");
			numericTextBox1.NumericTextBoxDelegate = new NumericTextBoxDelegate();
			this.AddSubview(numericTextBox1);

			numericTextBox2= new SFNumericTextBox();
			numericTextBox2.Watermark = "Enter RI";
			numericTextBox2.AllowNull = true;
			numericTextBox2.MaximumNumberDecimalDigits = 0;
			numericTextBox2.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			numericTextBox2.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			numericTextBox2.FormatString = @"p";
			numericTextBox2.Value = 0.1f;
			numericTextBox2.CultureInfo = new NSLocale ("en_US");
			numericTextBox2.NumericTextBoxDelegate = new NumericTextBoxDelegate();
			this.AddSubview(numericTextBox2);

			numericTextBox3= new SFNumericTextBox();
			numericTextBox3.Watermark = @"Enter Years";
			numericTextBox3.AllowNull = true;
			numericTextBox3.MaximumNumberDecimalDigits = 0;
			numericTextBox3.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			numericTextBox3.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			numericTextBox3.FormatString = @"years";
			numericTextBox3.Value = 20;
			numericTextBox3.CultureInfo = new NSLocale ("en_US");
			numericTextBox3.NumericTextBoxDelegate = new NumericTextBoxDelegate();
			this.AddSubview(numericTextBox3);

			numericTextBox4= new SFNumericTextBox();
			numericTextBox4.Watermark = @"Enter a number";
			numericTextBox4.AllowNull = true;
			numericTextBox4.MaximumNumberDecimalDigits = 0;
			numericTextBox4.PercentDisplayMode = SFNumericTextBoxPercentDisplayMode.Compute;
			numericTextBox4.ValueChangeMode = SFNumericTextBoxValueChangeMode.OnLostFocus;
			numericTextBox4.FormatString = @"c";
			numericTextBox4.Value = 2000;
			numericTextBox4.Enabled = false;
			numericTextBox4.TextColor = UIColor.Gray;
			numericTextBox4.CultureInfo = new NSLocale ("en_US");
			numericTextBox4.NumericTextBoxDelegate = new NumericTextBoxDelegate();
			this.AddSubview(numericTextBox4);

			titleText = new UILabel();
			titleText.TextColor = UIColor.Black;
			titleText.BackgroundColor= UIColor.Clear;
			titleText.Text=@"Simple Interest Calculator";
			titleText.TextAlignment = UITextAlignment.Left;
			titleText.Font = UIFont.FromName("Helvetica", 20f);
			this.AddSubview(titleText);

			description = new UILabel();
			description.TextColor = UIColor.Black;
			description.BackgroundColor= UIColor.Clear;
			description.Text=@"The formula for finding simple interest is:";
			description.TextAlignment = UITextAlignment.Left;
			description.Font = UIFont.FromName("Helvetica", 16f);
			this.AddSubview(description);

			formulaLabel = new UILabel();
			formulaLabel.TextColor = UIColor.Black;
			formulaLabel.BackgroundColor= UIColor.Clear;
			formulaLabel.Text=@"Interest = Principal * Rate * Time";
			formulaLabel.TextAlignment = UITextAlignment.Left;
			formulaLabel.Font = UIFont.FromName("Helvetica", 16f);
			this.AddSubview(formulaLabel);

			principal = new UILabel();
			principal.TextColor = UIColor.Black;
			principal.BackgroundColor= UIColor.Clear;
			principal.Text=@"Principal";
			principal.TextAlignment= UITextAlignment.Left;
			principal.Font=UIFont.FromName("Helvetica", 13f);
			this.AddSubview(principal);

			interestrate = new UILabel();
			interestrate.TextColor = UIColor.Black;
			interestrate.BackgroundColor= UIColor.Clear;
			interestrate.Text=@"Interest Rate";
			interestrate.TextAlignment= UITextAlignment.Left;
			interestrate.Font=UIFont.FromName("Helvetica", 13f);
			this.AddSubview(interestrate);

			term = new UILabel();
			term.TextColor = UIColor.Black;
			term.BackgroundColor= UIColor.Clear;
			term.Text=@"Term";
			term.TextAlignment= UITextAlignment.Left;
			term.Font=UIFont.FromName("Helvetica", 13f);
			this.AddSubview(term);

			interest = new UILabel();
			interest.TextColor = UIColor.Black;
			interest.BackgroundColor= UIColor.Clear;
			interest.Text=@"Interest";
			interest.TextAlignment= UITextAlignment.Left;
			interest.Font=UIFont.FromName("Helvetica", 13f);
			this.AddSubview(interest);

			allow = new UILabel();
			allow.TextColor = UIColor.Black;
			allow.BackgroundColor= UIColor.Clear;
			allow.Text=@"Allow Null";
			allow.TextAlignment= UITextAlignment.Left;
			allow.Font=UIFont.FromName("Helvetica", 16f);
			options.AddSubview(allow);

			allowSwitch = new UISwitch();
			allowSwitch.ValueChanged += toggleChanged;
			allowSwitch.On=true;
			options.AddSubview(allowSwitch);

			culLabel = new UILabel();
			culLabel.TextColor = UIColor.Black;
			culLabel.BackgroundColor= UIColor.Clear;
			culLabel.Text=@"Culture";
			culLabel.TextAlignment= UITextAlignment.Left;
			culLabel.Font=UIFont.FromName("Helvetica", 16f);
			options.AddSubview(culLabel);

			culture = new UIButton ();
			culture.SetTitle("United States", UIControlState.Normal);
			culture.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			culture.BackgroundColor = UIColor.Clear;
			culture.SetTitleColor(UIColor.Black, UIControlState.Normal);
			culture.Hidden = false;
			culture.Layer.BorderColor = UIColor.FromRGB(246,246,246).CGColor;
			culture.Layer.BorderWidth = 4;
			culture.Layer.CornerRadius = 8;
			culture.TouchUpInside += ShowPicker;
			options.AddSubview (culture);

			PickerModel model1 = new PickerModel(this.cultureTypes);
			model1.PickerChanged += (sender, e) => {
				this.selectedType = e.SelectedValue;
				culture.SetTitle(selectedType, UIControlState.Normal);
				if(selectedType=="United States"){
					numericTextBox1.CultureInfo = new NSLocale ("en_US");
					numericTextBox2.CultureInfo = new NSLocale ("en_US");
					numericTextBox3.CultureInfo = new NSLocale ("en_US");
					numericTextBox4.CultureInfo = new NSLocale ("en_US");}
				else if(selectedType=="United Kingdom"){
					numericTextBox1.CultureInfo = new NSLocale ("en_UK");
					numericTextBox2.CultureInfo = new NSLocale ("en_UK");
					numericTextBox3.CultureInfo = new NSLocale ("en_UK");
					numericTextBox4.CultureInfo = new NSLocale ("en_UK");}
				else if(selectedType=="Japan"){
					numericTextBox1.CultureInfo = new NSLocale ("jp_JP");
					numericTextBox2.CultureInfo = new NSLocale ("jp_JP");
					numericTextBox3.CultureInfo = new NSLocale ("jp_JP");
					numericTextBox4.CultureInfo = new NSLocale ("jp_JP");}
				else if(selectedType=="France"){
					numericTextBox1.CultureInfo = new NSLocale ("fr_FR");
					numericTextBox2.CultureInfo = new NSLocale ("fr_FR");
					numericTextBox3.CultureInfo = new NSLocale ("fr_FR");
					numericTextBox4.CultureInfo = new NSLocale ("fr_FR");}
				else if(selectedType=="Italy"){
					numericTextBox1.CultureInfo = new NSLocale ("it_IT");
					numericTextBox2.CultureInfo = new NSLocale ("it_IT");
					numericTextBox3.CultureInfo = new NSLocale ("it_IT");
					numericTextBox4.CultureInfo = new NSLocale ("it_IT");}
			};
			picker = new UIPickerView();
			picker.ShowSelectionIndicator = true;
			picker.Hidden = false;
			picker.Model = model1;
			picker.BackgroundColor = UIColor.White;
			options.AddSubview(picker);
			button = new UIButton ();
			button.SetTitle("Done\t", UIControlState.Normal);
			button.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			button.BackgroundColor = UIColor.FromRGB(240,240,240);
			button.SetTitleColor(UIColor.Black, UIControlState.Normal);
			button.Hidden = false;
			button.TouchUpInside += HidePicker;
			options.AddSubview (button);

			this.BackgroundColor = UIColor.White;
			this.control = this;


		}
		public void SetValue()
		{
			numericTextBox4.Value = numericTextBox1.Value * numericTextBox2.Value * numericTextBox3.Value;

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
		private void toggleChanged(object sender, EventArgs e)
		{
			if (((UISwitch)sender).On) {
				numericTextBox1.AllowNull = true;
				numericTextBox2.AllowNull = true;
				numericTextBox3.AllowNull = true;
				numericTextBox4.AllowNull = true;
			} else {
				numericTextBox1.AllowNull = false;
				numericTextBox2.AllowNull = false;
				numericTextBox3.AllowNull = false;
				numericTextBox4.AllowNull = false;
			}
		}

		public override void TouchesBegan (NSSet touches, UIEvent evt){
			this.EndEditing (true);
		}
	}
	public class NumericTextBoxDelegate:SFNumericTextBoxDelegate
	{
		public override void ValueChange (SFNumericTextBox SFNumericTextBox, float value)
		{
			(SFNumericTextBox.Superview as NumericTextBox).SetValue ();
		}
	}
}

