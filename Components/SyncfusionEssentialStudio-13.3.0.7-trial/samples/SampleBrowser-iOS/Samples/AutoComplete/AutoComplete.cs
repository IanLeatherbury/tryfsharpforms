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
using Syncfusion.SfAutoComplete.iOS;


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
	public class AutoComplete : SampleView
	{
		UILabel label2,label3,label4,label5,label6;
		UIButton textbutton = new UIButton ();
		UIButton textbutton1 = new UIButton ();
		UIButton doneButton=new UIButton();
		UIPickerView picker1, picker2;
		UITextView text1,text2,text3;
		private string selectedType;
		private readonly IList<string> exp = new List<string> ();
		private string selectedTypes;
		UIPickerView pickers = new UIPickerView ();
		SFAutoComplete autocomplete1,autocomplete2;
		UILabel label1s,label2s,label3s,label4s;
		UIButton textbuttons = new UIButton ();
		UIButton textbutton1s = new UIButton ();
		UIButton buttons = new UIButton ();
		NSMutableArray title = new NSMutableArray ();
		private readonly IList<string> suggesionmode = new List<string>
		{
			"StartsWith",
			"StartsWithCaseSensitive",
			"Contains",
			"ContainsWithCaseSensitive",
			"EndsWith",
			"EndsWithCaseSensitive",
			"Equals",
			"EqualsWithCaseSensitive"
		};
		private readonly IList<string> autocompletemd = new List<string>
		{
			"Append",
			"Suggest",
			"SuggestAppend"
		};
		private readonly IList<string> experience = new List<string>
		{
			"1",
			"2"
		};

		UIView view1 = new UIView ();
		public override UIView optionView()
		{
			base.optionView ();
			view1.AddSubview (label5);
			view1.AddSubview (label6);
			view1.AddSubview (text1);
			view1.AddSubview (text2);
			view1.AddSubview (text3);
			view1.AddSubview (label2);
			view1.AddSubview (label3);
			view1.AddSubview (textbutton);
			view1.AddSubview (label4);
			view1.AddSubview (textbutton1);
			view1.AddSubview (picker1);
			view1.AddSubview (picker2);
			view1.AddSubview (doneButton);

			return view1;
		}
		public AutoComplete ()
		{
			picker1 = new UIPickerView ();
			picker2 = new UIPickerView ();
			PickerModel model = new PickerModel (suggesionmode);
			picker1.Model = model;
			PickerModel model1 = new PickerModel (autocompletemd);
			picker2.Model = model1;
			PickerModel model2 = new PickerModel (experience);
			label2 = new UILabel ();
			label3 = new UILabel ();
			label4 = new UILabel ();
			label5 = new UILabel ();
			label6 = new UILabel ();
			textbutton = new UIButton ();
			textbutton1 = new UIButton ();
			this.title.Add ((NSString)"Banking");
			this.title.Add ((NSString)"Software");
			this.title.Add ((NSString)"Media");
			this.title.Add ((NSString)"Medical");
			this.exp.Add ((NSString)"1");
			this.exp.Add ((NSString)"2");
			label1s = new UILabel ();
			label2s = new UILabel ();
			label3s = new UILabel ();
			label4s = new UILabel ();
			textbuttons = new UIButton ();
			autocomplete1 = new SFAutoComplete ();
			autocomplete2 = new SFAutoComplete ();
			autocomplete1.AutoCompleteSource = new Countrylist().Country;
			autocomplete1.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
			autocomplete1.Watermark= (NSString)"Enter a country name";
			autocomplete1.MaxDropDownHeight=90;
			autocomplete1.AutoCompleteMode= SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggest;
			autocomplete2.AutoCompleteSource = title;
			autocomplete2.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
			autocomplete2.Watermark=(NSString)"Starts with ’S’, ‘M’ or ‘B’";
			autocomplete2.MaxDropDownHeight=90;
			autocomplete2.AutoCompleteMode= SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggest;

			label1s.Text = "Job  Search";
			label1s.TextColor = UIColor.Black;
			label1s.TextAlignment = UITextAlignment.Left;
			label1s.Font=UIFont.FromName("Helvetica-Bold", 20f);

			label2s.Text = "Country";
			label2s.TextColor = UIColor.Black;
			label2s.TextAlignment = UITextAlignment.Left;
			label2s.Font=UIFont.FromName("Helvetica", 16f);

			label3s.Text = "Job Title";
			label3s.TextColor = UIColor.Black;
			label3s.TextAlignment = UITextAlignment.Left;
			label3s.Font=UIFont.FromName("Helvetica", 16f);

			label4s.Text = "Experience";
			label4s.TextColor = UIColor.Black;
			label4s.TextAlignment = UITextAlignment.Left;
			label4s.Font=UIFont.FromName("Helvetica", 16f);

			textbuttons.SetTitle("Search",UIControlState.Normal);
			textbuttons.SetTitleColor(UIColor.Black,UIControlState.Normal);
			textbuttons.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textbuttons.Layer.CornerRadius = 8;
			textbuttons.Layer.BorderWidth = 2;
			textbuttons.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;
			textbuttons.TouchUpInside += SelectResults;

			textbutton1s.SetTitle("1", UIControlState.Normal);
			textbutton1s.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textbutton1s.BackgroundColor = UIColor.Clear;
			textbutton1s.SetTitleColor(UIColor.Black, UIControlState.Normal);
			textbutton1s.Layer.BorderColor = UIColor.FromRGB(246,246,246).CGColor;
			textbutton1s.Layer.BorderWidth = 4;
			textbutton1s.Layer.CornerRadius = 8;
			textbutton1s.TouchUpInside += ShowPickers;
			this.AddSubview (textbutton1s);

			PickerModel models = new PickerModel(this.exp);
			models.PickerChanged += (sender, e) => {
				this.selectedTypes = e.SelectedValue;
				textbutton1s.SetTitle(selectedTypes, UIControlState.Normal);
			};

			pickers.ShowSelectionIndicator = true;
			pickers.Hidden = true;
			pickers.Model = model2;
			pickers.BackgroundColor = UIColor.White;
			buttons.SetTitle("Done\t", UIControlState.Normal);
			buttons.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			buttons.BackgroundColor = UIColor.FromRGB(240,240,240);
			buttons.SetTitleColor(UIColor.Black, UIControlState.Normal);
			buttons.Hidden = true;
			buttons.TouchUpInside += HidePickers;

			this.AddSubview (pickers);
			this.AddSubview (buttons);
			this.AddSubview (autocomplete1);
			this.AddSubview (autocomplete2);
			this.AddSubview (label1s);
			this.AddSubview (label2s);
			this.AddSubview (label3s);
			this.AddSubview (label4s);
			this.AddSubview (textbuttons);
			this.control = this;

			label2.Text = "SuggestionMode";
			label2.TextColor = UIColor.Black;
			label2.TextAlignment = UITextAlignment.Left;
			label3.Text = "AutoCompleteMode";
			label3.TextColor = UIColor.Black;
			label3.TextAlignment = UITextAlignment.Left;

			label4.Text = "Min Prefix Character";
			label4.TextColor = UIColor.Black;
			label4.TextAlignment = UITextAlignment.Left;
			label4.Font=UIFont.FromName("Helvetica", 14f);

			label5.Text = "Max DropDownHeight";
			label5.TextColor = UIColor.Black;
			label5.TextAlignment = UITextAlignment.Left;
			label5.Font=UIFont.FromName("Helvetica", 14f);

			label6.Text = "Popup Delay";
			label6.TextColor = UIColor.Black;
			label6.TextAlignment = UITextAlignment.Left;
			label6.Font=UIFont.FromName("Helvetica", 14f);
			textbutton.SetTitle("StartsWith",UIControlState.Normal);
			textbutton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			textbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textbutton.Layer.CornerRadius = 8;
			textbutton.Layer.BorderWidth = 2;
			textbutton.TouchUpInside += ShowPicker1;
			textbutton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			text1 = new UITextView ();
			text2 = new UITextView ();
			text3 = new UITextView ();
			text1.Layer.BorderColor = UIColor.Black.CGColor;
			text2.Layer.BorderColor = UIColor.Black.CGColor;
			text3.Layer.BorderColor = UIColor.Black.CGColor;
			text1.BackgroundColor = UIColor.FromRGB(246,246,246);
			text2.BackgroundColor = UIColor.FromRGB(246,246,246);
			text3.BackgroundColor = UIColor.FromRGB(246,246,246);
			text1.KeyboardType = UIKeyboardType.NumberPad;
			text2.KeyboardType = UIKeyboardType.NumberPad;
			text3.KeyboardType = UIKeyboardType.NumberPad;
			text1.Text = "1";
			text2.Text = "400";
			text3.Text = "100";
			text2.Changed+= (object sender, EventArgs e) => 
			{
				if(text2.Text.Length>0){
					autocomplete1.MaxDropDownHeight = double.Parse(text2.Text);
					autocomplete2.MaxDropDownHeight = double.Parse(text2.Text);
				}
				else{
					autocomplete1.MaxDropDownHeight = 200;
					autocomplete2.MaxDropDownHeight = 200;
				}
			};
			text1.Changed+= (object sender, EventArgs e) => 
			{
				if(text1.Text.Length>0){
					autocomplete1.MinimumPrefixCharacters = int.Parse(text1.Text);
					autocomplete2.MinimumPrefixCharacters = int.Parse(text1.Text);
				}
				else{
					autocomplete1.MinimumPrefixCharacters = 1;
					autocomplete2.MinimumPrefixCharacters = 1;
				}
			};
			text3.Changed+= (object sender, EventArgs e) => 
			{
				if(text3.Text.Length>0)
				{
					autocomplete1.PopUpDelay = double.Parse(text3.Text);
					autocomplete2.PopUpDelay = double.Parse(text3.Text);
				}
				else
				{
					autocomplete1.PopUpDelay = 100;
					autocomplete2.PopUpDelay = 100;
				}
			};
			textbutton1.SetTitle("Suggest",UIControlState.Normal);
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
			model.PickerChanged += SelectedIndexChanged;
			model1.PickerChanged += SelectedIndexChanged1;
			model2.PickerChanged += SelectedIndexChanged2;
			picker1.ShowSelectionIndicator = true;
			picker1.Hidden = true;
			picker1.BackgroundColor = UIColor.Gray;
			picker2.BackgroundColor = UIColor.Gray;
			picker2.ShowSelectionIndicator = true;
			picker2.Hidden = true;
		}
		void ShowPickers (object sender, EventArgs e) {
			textbuttons.Hidden = true;
			buttons.Hidden = false;
			pickers.Hidden = false;
			this.BecomeFirstResponder ();
		}
		public override void TouchesBegan (NSSet touches, UIEvent evt){
			this.EndEditing (true);
		}
		void SelectResults (object sender, EventArgs e) {

			if (autocomplete1.TextField.Text != "" && autocomplete2.TextField.Text != "") {
				NSString s1 = (NSString)autocomplete1.Text;
				NSString s2 = (NSString)autocomplete2.Text;
				nint s4 = 0;
				if (s1 != null && s2 != null) {
					Random r = new Random();
					s4 = r.Next (5,60);
				}
				UIAlertView v = new UIAlertView ();
				v.Title = "Results";
				if (s4 > 0)
					v.Message = s4 + " Jobs found";
				else
					v.Message = "0 Jobs found";
				v.AddButton ("OK");
				v.Show ();
			} else {
				UIAlertView v1 = new UIAlertView ();
				v1.Title = "Results";
				v1.AddButton ("OK");
				v1.Message = "0 Jobs found";
				v1.Show ();
			}
			this.BecomeFirstResponder ();
		}
		void HidePickers (object sender, EventArgs e) {
			textbuttons.Hidden = false;
			buttons.Hidden = true;
			pickers.Hidden = true;
			this.BecomeFirstResponder ();
		}
		public override void LayoutSubviews ()
		{
			
			foreach (var view in this.Subviews) {
				view.Frame = Frame;
				label2.Frame = new CGRect ( 10,10, this.Frame.Size.Width-10, 30);
				label3.Frame = new CGRect ( 10, 100, this.Frame.Size.Width-20, 30);
				label4.Frame = new CGRect ( 10, 200,this.Frame.Size.Width-10 , 30);
				label5.Frame = new CGRect (10, 250, this.Frame.Size.Width - 10, 30);
				textbutton.Frame=new CGRect(10, 50, this.Frame.Size.Width - 20, 30);	
				label6.Frame = new CGRect (10, 300, this.Frame.Size.Width - 10, 30);
				textbutton1.Frame=new CGRect(10, 140, this.Frame.Size.Width - 20, 30);	
				text1.Frame = new CGRect (230, 200, this.Frame.Size.Width - 250, 30);
				text2.Frame = new CGRect (230, 250, this.Frame.Size.Width - 250, 30);
				text3.Frame = new CGRect (230, 300, this.Frame.Size.Width - 250, 30);
				picker1.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width, this.Frame.Size.Height/3);
				picker2.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width , this.Frame.Size.Height/3);
				doneButton.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width, 30);
				label1s.Frame = new CGRect ( 10, 10, view.Frame.Width, 30);
				label2s.Frame = new CGRect ( 10, 50, view.Frame.Width, 30);
				label3s.Frame = new CGRect ( 10,130 ,view.Frame.Width, 30);
				label4s.Frame = new CGRect ( 10,210, view.Frame.Width, 30);
				autocomplete1.Frame = new CGRect ( 10, 80, this.Frame.Size.Width -20, 40);
				autocomplete2.Frame = new CGRect ( 10, 160, this.Frame.Size.Width - 20, 40);
				textbutton1s.Frame = new CGRect ( 10, 250, this.Frame.Size.Width - 20, 40);
				pickers.Frame=new CGRect(0,this.Frame.Size.Height-( this.Frame.Size.Height/3), this.Frame.Size.Width,this.Frame.Size.Height/3);
				buttons.Frame=new CGRect(0, this.Frame.Size.Height-( this.Frame.Size.Height/3), this.Frame.Size.Width, 40);
				textbuttons.Frame = new CGRect ( 10,310, this.Frame.Size.Width -20, 30);	
			}
			base.LayoutSubviews ();
		}


		void ShowPicker1 (object sender, EventArgs e) {
			text1.EndEditing(true);
			text2.EndEditing(true);
			text3.EndEditing(true);
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
			text1.EndEditing(true);
			text2.EndEditing(true);
			text3.EndEditing(true);
			doneButton.Hidden = false;
			picker1.Hidden = true;
			picker2.Hidden = false;
		}

		private void SelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			textbutton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "StartsWith") {
				autocomplete1.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
				autocomplete2.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
			} else if (selectedType == "StartsWithCaseSensitive") {
				autocomplete1.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWithCaseSensitive;
				autocomplete2.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWithCaseSensitive;
			} else if (selectedType == "Contains") {
				autocomplete1.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeContains;
				autocomplete2.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeContains;
			} else if (selectedType == "ContainsWithCaseSensitive") {
				autocomplete1.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeContainsCaseSensitive;
				autocomplete2.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeContainsCaseSensitive;

			} else if (selectedType == "EndsWith") {
				autocomplete1.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEndsWith;
				autocomplete2.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEndsWith;
			} else if (selectedType == "EndsWithCaseSensitive") {
				autocomplete1.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEndsWithCaseSensitive;
				autocomplete2.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEndsWithCaseSensitive;
			} else if (selectedType == "Equals") {
				autocomplete1.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEquals;
				autocomplete2.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEquals;

			}
			else if (selectedType == "EqualsWithCaseSenstive"){
				autocomplete1.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEqualsCaseSensitive;
				autocomplete2.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEqualsCaseSensitive;
			}
		}
		private void SelectedIndexChanged1(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			textbutton1.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "Append") {
				autocomplete1.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeAppend;
				autocomplete2.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeAppend;
			}
			else if (selectedType == "Suggest") {
				autocomplete1.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggest;
				autocomplete2.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggest;
			}
			else if (selectedType == "SuggestAppend")
			{
				autocomplete1.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggestAppend;
				autocomplete2.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggestAppend;
			}
		}
		private void SelectedIndexChanged2(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			textbutton1s.SetTitle (selectedType, UIControlState.Normal);
		}
	}
}

