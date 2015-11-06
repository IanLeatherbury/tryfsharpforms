#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using Syncfusion.SfNumericTextBox.XForms;

namespace SampleBrowser
{
	public class NumericTextBox :SamplePage
	{
		Label label1,label2,label3,label4,label5,label6,label7;
		Label label11,label12;
		PickerExt picker;
		Switch toggle1;
		SfNumericTextBox numericTextBox1,numericTextBox2,numericTextBox3,numericTextBox4;
		public NumericTextBox ()
		{
            double height = Bounds.Height;
            double width = App.ScreenWidth;
		    if (Device.Idiom == TargetIdiom.Tablet)
		    {
		        width /= 2;
		    }
            
			label1 = new Label() { Text = "Simple Interest Calculator", HeightRequest = 40, HorizontalOptions = LayoutOptions.Center, TextColor = Color.Black };
			label2 = new Label() { Text = "The formula for finding simple interest is :", HeightRequest = 45, HorizontalOptions = LayoutOptions.Center, TextColor = Color.Black };
			label3 = new Label() { Text = "Interest = Principal * Rate * Time", HeightRequest = 40, HorizontalOptions = LayoutOptions.Center, TextColor = Color.Black };
			label4 = new Label() { Text = "Principal", HeightRequest = 40, WidthRequest = width / 2, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black };
			label5 = new Label() { Text = "Interest Rate", HeightRequest = 40, WidthRequest = width / 2, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black };
			label6 = new Label() { Text = "Term", HeightRequest = 40, WidthRequest = width / 2, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black };
			label7 = new Label() { Text = "Interest", HeightRequest = 40, WidthRequest = width / 2, VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Start, TextColor = Color.Black };
            label11 = new Label() { Text = "  " + "Culture", HeightRequest = 40, WidthRequest = width / 2, HorizontalOptions = LayoutOptions.Start, TextColor = Color.Gray };
			label12 = new Label() { Text = "  " + "AllowNull", HeightRequest = 40, WidthRequest = width / 2, HorizontalOptions = LayoutOptions.Start, VerticalOptions = LayoutOptions.Center, TextColor = Color.Gray };
			label1.FontAttributes = FontAttributes.None;
			label1.FontSize = 22;
			label2.FontAttributes = FontAttributes.None;
			label2.FontSize = 20;
			label3.FontAttributes = FontAttributes.None;
			label3.FontSize = 20;
			label4.FontAttributes = FontAttributes.None;
			label4.FontSize = 18;
			label5.FontAttributes = FontAttributes.None;
			label5.FontSize = 18;
			label6.FontAttributes = FontAttributes.None;
			label6.FontSize = 18;
			label7.FontAttributes = FontAttributes.None;
			label7.FontSize = 18;
			label11.FontAttributes = FontAttributes.None;
			label11.FontSize = 20;
			label12.FontAttributes = FontAttributes.None;
			label12.FontSize = 20;
			label12.YAlign = TextAlignment.Center;
            toggle1 = new Switch();
            toggle1.IsToggled = true;
            toggle1.HorizontalOptions = LayoutOptions.Start;
            toggle1.VerticalOptions = LayoutOptions.Center;
            toggle1.Toggled += (object sender, ToggledEventArgs e) =>
            {
                numericTextBox1.AllowNull = e.Value;
                numericTextBox2.AllowNull = e.Value;
                numericTextBox3.AllowNull = e.Value;
                numericTextBox4.AllowNull = e.Value;
            };
            picker = new PickerExt();
            picker.VerticalOptions = LayoutOptions.Start;
            picker.Items.Add("United States");
            picker.Items.Add("United Kingdom");
            picker.Items.Add("Japan");
            picker.Items.Add("France");
            picker.Items.Add("Italy");
			picker.SelectedIndexChanged+= (object sender, EventArgs e) =>
            {
                switch (picker.SelectedIndex)
                {
                    case 0:
                        {
                            numericTextBox1.Culture = new System.Globalization.CultureInfo("en-US");
                            numericTextBox2.Culture = new System.Globalization.CultureInfo("en-US");
                            numericTextBox4.Culture = new System.Globalization.CultureInfo("en-US");
                            numericTextBox3.Culture = new System.Globalization.CultureInfo("en-US");
                        }
                        break;
                    case 1:
                        {
                            numericTextBox1.Culture = new System.Globalization.CultureInfo("en-GB");
                            numericTextBox2.Culture = new System.Globalization.CultureInfo("en-GB");
                            numericTextBox3.Culture = new System.Globalization.CultureInfo("en-GB");
                            numericTextBox4.Culture = new System.Globalization.CultureInfo("en-GB");
                        }
                        break;
                    case 2:
                        {
                            numericTextBox1.Culture = new System.Globalization.CultureInfo("ja-JP");
                            numericTextBox2.Culture = new System.Globalization.CultureInfo("ja-JP");
                            numericTextBox3.Culture = new System.Globalization.CultureInfo("ja-JP");
                            numericTextBox4.Culture = new System.Globalization.CultureInfo("ja-JP");
                        }
                        break;
                    case 3:
                        {
                            numericTextBox1.Culture = new System.Globalization.CultureInfo("fr-FR");
                            numericTextBox2.Culture = new System.Globalization.CultureInfo("fr-FR");
                            numericTextBox3.Culture = new System.Globalization.CultureInfo("fr-FR");
                            numericTextBox4.Culture = new System.Globalization.CultureInfo("fr-FR");
                        }
                        break;
                    case 4:
                        {
                            numericTextBox1.Culture = new System.Globalization.CultureInfo("it-IT");
                            numericTextBox2.Culture = new System.Globalization.CultureInfo("it-IT");
                            numericTextBox3.Culture = new System.Globalization.CultureInfo("it-IT");
                            numericTextBox4.Culture = new System.Globalization.CultureInfo("it-IT");
                        }
                        break;
                }
            };
            numericTextBox1 = new SfNumericTextBox();
            numericTextBox1.Watermark = "Enter Principal";
            numericTextBox1.AllowNull = true;
            numericTextBox1.MaximumNumberDecimalDigits = 2;
			numericTextBox1.ValueChangeMode = ValueChangeMode.OnKeyFocus;
            numericTextBox1.FormatString = "c";
            numericTextBox1.Value = 1000;
            numericTextBox1.HorizontalOptions = LayoutOptions.End;
            numericTextBox1.VerticalOptions = LayoutOptions.Center;
			numericTextBox1.ValueChanged+= (object sender, ValueEventArgs e) => 
			{
				numericTextBox4.Value = numericTextBox2.Value*e.Value*numericTextBox3.Value;
			};



			numericTextBox1.Culture = new System.Globalization.CultureInfo("en-US");
		
            numericTextBox2 = new SfNumericTextBox();
            numericTextBox2.Watermark = "Enter RI";
            numericTextBox2.AllowNull = true;
            numericTextBox2.MaximumNumberDecimalDigits = 0;
			numericTextBox2.PercentDisplayMode = PercentDisplayMode.Compute;
			numericTextBox2.ValueChangeMode = ValueChangeMode.OnKeyFocus;
            numericTextBox2.FormatString = "p";
            numericTextBox2.Value = 0.1f;
            numericTextBox2.HorizontalOptions = LayoutOptions.End;
            numericTextBox2.VerticalOptions = LayoutOptions.Center;
			numericTextBox2.Culture = new System.Globalization.CultureInfo("en-US");
			numericTextBox2.ValueChanged+= (object sender, ValueEventArgs e) => 
			{
				numericTextBox4.Value = numericTextBox1.Value*e.Value*numericTextBox3.Value;
			};
            numericTextBox3 = new SfNumericTextBox();
            numericTextBox3.Watermark = "Enter Years";
            numericTextBox3.AllowNull = true;
            numericTextBox3.MaximumNumberDecimalDigits = 0;
			numericTextBox3.ValueChangeMode = ValueChangeMode.OnKeyFocus;
            numericTextBox3.FormatString = "years";
            numericTextBox3.Value = 20;
            numericTextBox3.HorizontalOptions = LayoutOptions.End;
            numericTextBox3.VerticalOptions = LayoutOptions.Center;
			numericTextBox3.ValueChanged+= (object sender, ValueEventArgs e) => 
			{
				numericTextBox4.Value = numericTextBox1.Value*numericTextBox2.Value*e.Value;
			};
			numericTextBox3.Culture = new System.Globalization.CultureInfo("en-US");

            numericTextBox4 = new SfNumericTextBox();
            numericTextBox4.Watermark = "Enter a number";
            numericTextBox4.AllowNull = true;
            numericTextBox4.MaximumNumberDecimalDigits = 0;
            numericTextBox4.ValueChangeMode = ValueChangeMode.OnKeyFocus;
            numericTextBox4.HorizontalOptions = LayoutOptions.End;
            numericTextBox4.FormatString = "c";
			numericTextBox4.Value = (float)1000*0.1*20;
            numericTextBox4.VerticalOptions = LayoutOptions.Center;
			numericTextBox4.Culture = new System.Globalization.CultureInfo("en-US");
			numericTextBox4.IsEnabled = false;
			this.BackgroundColor = Color.White;

            if (Device.OS == TargetPlatform.iOS)
            {
				numericTextBox1.WidthRequest = width / 2;
                numericTextBox2.WidthRequest = width / 2;
                numericTextBox3.WidthRequest = width / 2;
                numericTextBox4.WidthRequest = width / 2;
                toggle1.WidthRequest = width / 2;
            }
            else if (Device.OS == TargetPlatform.WinPhone)
            {
                numericTextBox1.WidthRequest = width / 2;
                numericTextBox2.WidthRequest = width / 2;
                numericTextBox3.WidthRequest = width / 2;
                numericTextBox4.WidthRequest = width / 2;
                toggle1.WidthRequest = width / 2;
                toggle1.HorizontalOptions = LayoutOptions.End;
                label1.TextColor = Color.White;
                label2.TextColor = Color.White;
                label3.TextColor = Color.White;
                label4.TextColor = Color.White;
                label5.TextColor = Color.White;
                label6.TextColor = Color.White;
                label7.TextColor = Color.White;
                numericTextBox1.BackgroundColor = Color.White;
                numericTextBox2.BackgroundColor = Color.White;
                numericTextBox3.BackgroundColor = Color.White;
                numericTextBox4.BackgroundColor = Color.White;
                numericTextBox2.FormatString = "0 %";
                numericTextBox3.FormatString = "0 years";
                this.BackgroundColor = Color.Black;
            }
            else
            {
                
                numericTextBox1.WidthRequest = width / 3;
                numericTextBox2.WidthRequest = width / 3;
                numericTextBox3.WidthRequest = width / 3;
                numericTextBox4.WidthRequest = width / 3;
            }
		    if (Device.OS == TargetPlatform.Windows)
		    {
                label1.TextColor = Color.Gray;
                label2.TextColor = Color.Gray;
                label3.TextColor = Color.Gray;
                label4.TextColor = Color.Gray;
                label5.TextColor = Color.Gray;
                label6.TextColor = Color.Gray;
                label7.TextColor = Color.Gray;
                numericTextBox1.BackgroundColor = Color.White;
                numericTextBox2.BackgroundColor = Color.White;
                numericTextBox3.BackgroundColor = Color.White;
                numericTextBox4.BackgroundColor = Color.White;
                this.BackgroundColor = Color.Black;
                numericTextBox2.FormatString = "0 %";
                numericTextBox3.FormatString = "0 years";
		        if (Device.Idiom != TargetIdiom.Tablet)
		        {
		            numericTextBox4.IsEnabled = true;
		        }
		    }
		    this.ContentView = GetNumeric();
            PropertyView = GetOptionPage();
        }

       
        private StackLayout GetNumeric()
        {
            picker.SelectedIndex = 0;
            var row1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { label4, numericTextBox1 }
            };
            var row2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { label5, numericTextBox2 }
            };

            var row3 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { label6, numericTextBox3 }
            };
            var row4 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { label7, numericTextBox4 }
            };
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                row1.HorizontalOptions =
                    row2.HorizontalOptions = row3.HorizontalOptions = row4.HorizontalOptions = LayoutOptions.Center;
            }
            var mainStack = new StackLayout
            {
                Spacing = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 30),
                Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 20),
				Children = { label1, label2, label3, row1, row2, row3, row4 }
            };




            return mainStack;

        }

        private StackLayout GetOptionPage()
        {
            var row1 = new StackLayout
            {
                Children = { label12, toggle1 }
            };
            if (Device.OS == TargetPlatform.Windows)
                row1.Orientation = StackOrientation.Vertical;
            else
                row1.Orientation = StackOrientation.Horizontal;
            var row2 = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { label11, picker }
            };
            var mainStack = new StackLayout
            {
                Spacing = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50),
                Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
                Children = { row2, row1 }
            };
            return mainStack;
        }
	}
}

