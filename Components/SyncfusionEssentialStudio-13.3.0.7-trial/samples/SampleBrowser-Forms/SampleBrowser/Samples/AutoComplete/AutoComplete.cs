#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using Syncfusion.SfAutoComplete.XForms;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class AutoComplete : SamplePage
	{
		Label label,label1,label2,label3,label4,label5;
		PickerExt picker1,picker2;
		Entry text1,text2,text3;
		List<String> ss = new List<String>(); 
		Label label1s,label2s,label3s,label4s,label5s;
		Button buttons;
		SfAutoComplete autocomplete1,autocomplete2;
		List<String> title = new List<String>(); 
		List<String> exp = new List<String>(); 
		PickerExt pp;
		string s1,s2;
		public AutoComplete ()
		{
			label = new Label ();
			label.Text = "Type a country name to display the suggested list in the dropdown";
			label1 = new Label() { Text = "SuggestionMode", HeightRequest = 50, HorizontalOptions=LayoutOptions.Start, TextColor = Color.Gray };
			label2 = new Label() { Text = "AutoCompleteMode", HeightRequest = 50, HorizontalOptions=LayoutOptions.Start, TextColor = Color.Gray };
			label3 = new Label() { Text = "Max DropDown Height", HeightRequest = 40, HorizontalOptions=LayoutOptions.Start, TextColor = Color.Gray };
			label4 = new Label() { Text = "Min Prefix Character", HeightRequest = 40, HorizontalOptions=LayoutOptions.Start, TextColor = Color.Gray };
			label5 = new Label() { Text = "Popup Delay", HeightRequest = 40, HorizontalOptions=LayoutOptions.Start, TextColor = Color.Gray };
			label1.FontAttributes = FontAttributes.None;
			label1.FontSize = 20;
			label2.FontAttributes = FontAttributes.None;
			label2.FontSize = 20;
			label3.FontAttributes = FontAttributes.None;
			label3.FontSize = 20;
			label4.FontAttributes = FontAttributes.None;
			label4.FontSize = 20;
			label5.FontAttributes = FontAttributes.None;
			label5.FontSize = 20;
			text1 = new Entry ();
			text2 = new Entry ();
			text3 = new Entry ();
			label1.YAlign = TextAlignment.End;
			label2.YAlign = TextAlignment.End;
			label3.YAlign = TextAlignment.Center;
			label4.YAlign = TextAlignment.Center;
			label5.YAlign = TextAlignment.Center;
			text1.WidthRequest = 80;
			text2.WidthRequest = 80;
			text3.WidthRequest = 80;
			text1.HeightRequest = 40;
			text2.HeightRequest = 40;
			text3.HeightRequest = 40;
			picker1 = new PickerExt ();
			picker2 = new PickerExt ();
			label3.WidthRequest = 300;
			label4.WidthRequest = 300;
			label5.WidthRequest = 300;
			picker1.Items.Add ("StartsWith");
			picker1.Items.Add ("StartsWithCaseSensitive");
			picker1.Items.Add ("Contains");
			picker1.Items.Add ("ContainsWithCaseSensitive");
			picker1.Items.Add ("EndsWith");
			picker1.Items.Add ("EndsWithCaseSensitive");
			picker1.Items.Add ("Equals");
			picker1.Items.Add ("EqualsWithCaseSensitive");

			picker2.Items.Add ("Append");
			picker2.Items.Add ("Suggest");
			picker2.Items.Add ("SuggestAppend");
			picker1.SelectedIndex = 0;
			picker2.SelectedIndex = 1;
			text1.Text = "300";
			text2.Text = "2";
			text3.Text = "100";
			text1.TextChanged+= (object sender, TextChangedEventArgs e) => 
			{
				if(e.NewTextValue.Length >0){
					autocomplete1.MaximumDropDownHeight = int.Parse(e.NewTextValue);
					autocomplete2.MaximumDropDownHeight = int.Parse(e.NewTextValue);
				}
				else{
					autocomplete1.MaximumDropDownHeight = 100;
					autocomplete2.MaximumDropDownHeight = 100;
				}
			};
			text2.TextChanged+= (object sender, TextChangedEventArgs e) => 
			{
				if(e.NewTextValue.Length > 0){
                    autocomplete1.MinimumPrefixCharacters = int.Parse(e.NewTextValue);
                    autocomplete2.MinimumPrefixCharacters = int.Parse(e.NewTextValue);
				}
				else{
					autocomplete1.MinimumPrefixCharacters = 1;
					autocomplete2.MinimumPrefixCharacters = 1;
				}
			};
			text3.TextChanged+= (object sender, TextChangedEventArgs e) => 
			{
				if(e.NewTextValue.Length > 0){
					autocomplete1.PopupDelay = int.Parse(e.NewTextValue);
					autocomplete2.PopupDelay = int.Parse(e.NewTextValue);
				}
				else{
					autocomplete1.PopupDelay = 100;
					autocomplete2.PopupDelay = 100;
				}
			};
			picker1.SelectedIndexChanged += (object sender, EventArgs e) => {
				switch (picker1.SelectedIndex) {
				case 0:
					{
						autocomplete1.SuggestionMode = SuggestionMode.StartsWith;
						autocomplete2.SuggestionMode = SuggestionMode.StartsWith;
					}
					break;
				case 1:
					{
						autocomplete1.SuggestionMode = SuggestionMode.StartsWithCaseSensitive;
						autocomplete2.SuggestionMode = SuggestionMode.StartsWithCaseSensitive;
					}
					break;
				case 2:
					{
						autocomplete1.SuggestionMode = SuggestionMode.Contains;
						autocomplete2.SuggestionMode = SuggestionMode.Contains;
					}
					break;
				case 3:
					{
						autocomplete1.SuggestionMode = SuggestionMode.ContainsWithCaseSensitive;
						autocomplete2.SuggestionMode = SuggestionMode.ContainsWithCaseSensitive;
					}
					break;
				case 4:
					{
						autocomplete1.SuggestionMode = SuggestionMode.EndsWith;
						autocomplete2.SuggestionMode = SuggestionMode.EndsWith;
					}
					break;
				case 5:
					{
						autocomplete1.SuggestionMode = SuggestionMode.EndsWithCaseSensitive;
						autocomplete2.SuggestionMode = SuggestionMode.EndsWithCaseSensitive;
					}
					break;
				case 6:
					{
						autocomplete1.SuggestionMode = SuggestionMode.Equals;
						autocomplete2.SuggestionMode = SuggestionMode.Equals;
					}
					break;
				case 7:
					{
						autocomplete1.SuggestionMode = SuggestionMode.EqualsWithCaseSensitive;
						autocomplete2.SuggestionMode = SuggestionMode.EqualsWithCaseSensitive;
					}
					break;
				}
			};
			picker2.SelectedIndexChanged += (object sender, EventArgs e) => {
				switch (picker2.SelectedIndex) {
				case 0:
					{
						autocomplete1.AutoCompleteMode = AutoCompleteMode.Append;
						autocomplete2.AutoCompleteMode = AutoCompleteMode.Append;
					}
					break;
				case 1:
					{
						autocomplete1.AutoCompleteMode = AutoCompleteMode.Suggest;
						autocomplete2.AutoCompleteMode = AutoCompleteMode.Suggest;
					}
					break;
				case 2:
					{
						autocomplete1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
						autocomplete2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
					}
					break;
				}
			};
			s1 = string.Empty;
			s2 = string.Empty;
			pp = new PickerExt ();
			title.Add ("Software");
			title.Add ("Banking");
			title.Add ("Media");
			title.Add ("Medical");

			exp.Add ("1");
			exp.Add ("2");
			label5s = new Label ();
			label1s = new Label() { Text = "Job Search", HeightRequest = 40,VerticalOptions=LayoutOptions.Center, HorizontalOptions=LayoutOptions.Start, TextColor = Color.Gray };
			label2s = new Label() { Text = "Country", HeightRequest = 30, HorizontalOptions=LayoutOptions.Start, TextColor = Color.Gray };
			label3s = new Label() { Text = "Job Field", HeightRequest = 30, HorizontalOptions=LayoutOptions.Start, TextColor = Color.Gray };
			label4s = new Label() { Text = "Experience", HeightRequest = 30, HorizontalOptions=LayoutOptions.Start, TextColor = Color.Gray };
			label1s.FontAttributes = FontAttributes.Bold;
			label1s.FontSize = 24;
			label2s.FontAttributes = FontAttributes.None;
			label2s.FontSize = 18;
			label3s.FontAttributes = FontAttributes.None;
			label3s.FontSize = 18;
			label4s.FontAttributes = FontAttributes.None;
			label4s.FontSize = 18;
			label5s.HeightRequest = 10;
			label1s.TextColor = Color.Black;
			label2s.TextColor = Color.Black;
			label3s.TextColor = Color.Black;
			label4s.TextColor = Color.Black;
			label5s.TextColor = Color.Black;
			buttons = new Button ();
			buttons.Text = "Search";
			buttons.Clicked += (object sender, EventArgs e) => {
				if (s1 != "" && s2 != "") {
					Random r = new Random ();
					DisplayAlert ("Results", r.Next (9, 50) + " Jobs found", "OK");
				} else
					DisplayAlert ("Results", "0 Jobs found", "OK");
			};

			autocomplete1 = new SfAutoComplete ();
            autocomplete1.SuggestionMode = SuggestionMode.StartsWith;
            autocomplete1.AutoCompleteMode = AutoCompleteMode.Suggest;
            autocomplete1.MaximumDropDownHeight = 300;
            autocomplete1.AutoCompleteSource = new Countrylist().Country;
			autocomplete1.HeightRequest = 40;
            autocomplete1.Watermark = "Enter a country name";
            autocomplete1.ValueChanged += (object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e) =>
            {
                s1 = e.Value;
            };
			autocomplete2 = new SfAutoComplete ();
			autocomplete2.SuggestionMode = SuggestionMode.StartsWith;
			autocomplete2.AutoCompleteMode = AutoCompleteMode.Suggest;
			autocomplete2.MaximumDropDownHeight = 300;
            autocomplete2.AutoCompleteSource = title;
			autocomplete2.HeightRequest = 40;
            autocomplete2.Watermark = "Enter 'B' , 'S' , 'M' to start";
            autocomplete2.ValueChanged += (object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e) =>
            {
                s2 = e.Value;
            };
			pp.Items.Add ("1");
			pp.Items.Add ("2");
			pp.SelectedIndex = 0;
			pp.BackgroundColor = Color.White;
			

			
			//this.BackgroundColor = Color.FromRgb(236, 235, 242);
			if (Device.OS == TargetPlatform.WinPhone)
			{
                autocomplete1.HeightRequest = 80;
                autocomplete2.HeightRequest = 80;
				this.BackgroundColor = Color.Black;
				label1s.TextColor = Color.White;
				label2s.TextColor = Color.White;
				label3s.TextColor = Color.White;
				label4s.TextColor = Color.White;
				label5s.TextColor = Color.White;
                autocomplete2.BackgroundColor = Color.White;
                autocomplete1.BackgroundColor = Color.White;
				pp.BackgroundColor = Color.Black;
                text2.WidthRequest = 120;
                text3.WidthRequest = 120;
                text2.HeightRequest = 80;
                text3.HeightRequest = 80;
			}
            if ( Device.OS == TargetPlatform.Windows)
            {
                
                this.BackgroundColor = Color.Black;
                label1s.TextColor = Color.Black;
                label2s.TextColor = Color.Black;
                label3s.TextColor = Color.Black;
                label4s.TextColor = Color.Black;
                label5s.TextColor = Color.Black;
                autocomplete2.BackgroundColor = Color.White;
                autocomplete1.BackgroundColor = Color.White;
                //pp.BackgroundColor = Color.Gray;
                text2.WidthRequest = 120;
                text3.WidthRequest = 120;
                if (Device.Idiom != TargetIdiom.Tablet)
                {
                    this.BackgroundColor = Color.Black;
                    label1s.TextColor = Color.White;
                    label2s.TextColor = Color.White;
                    label3s.TextColor = Color.White;
                    label4s.TextColor = Color.White;
                    label5s.TextColor = Color.White;
                    pp.BackgroundColor = Color.Black;
                }

            }

           
            this.ContentView = GetAutoComplete();
			PropertyView = GetOptionPage ();
		}

	    private StackLayout GetAutoComplete()
	    {
            var mainStack = new StackLayout
            {
                Spacing = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 30),
                Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 20),
                Children = { label1s, label2s, autocomplete1, label3s, autocomplete2, label4s, pp, label5s, buttons }
            };
	        return mainStack;
	    }

	    private StackLayout GetOptionPage()
		{
//			var row1 = new StackLayout
//			{
//				Orientation = StackOrientation.Horizontal,
//				Children = { label3,text1 }
//			};
			var row2 = new StackLayout
			{
                

				Children = { label4,text2 }
			};
	        if (Device.OS == TargetPlatform.Windows)
	            row2.Orientation = StackOrientation.Vertical;
	        else
	            row2.Orientation = StackOrientation.Horizontal;
			var row3 = new StackLayout
			{
				Children = { label5,text3 }
			};
            if (Device.OS == TargetPlatform.Windows)
                row3.Orientation = StackOrientation.Vertical;
            else
                row3.Orientation = StackOrientation.Horizontal;
			var mainStack1 = new StackLayout
			{
				Children = { label1,picker1 }
			};
			var mainStack2 = new StackLayout
			{
				Children = { label2,picker2}
			};
			var mainStack = new StackLayout
			{
				Spacing = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 30),
				Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 20),
				Children = { mainStack1,mainStack2,row2,row3 }
			};
			return mainStack;
		}
	}
}

