#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfRangeSlider.XForms;

namespace SampleBrowser
{
	public partial class Orientation : SamplePage
	{
		public Orientation ()
		{
			//InitializeComponent ();
			ContentView = GetRangeSlider ();
		}

		private StackLayout GetRangeSlider()
		{
			SfRangeSlider sfRangeSlider1;
			SfRangeSlider sfRangeSlider2;
			SfRangeSlider sfRangeSlider3;
			Label label, label1, label2, label3, label4, label5, label6;
			sfRangeSlider1 = new SfRangeSlider ();

			sfRangeSlider1.HeightRequest = 400;
			sfRangeSlider1.WidthRequest = 85;
			sfRangeSlider1.Minimum = -12;
			sfRangeSlider1.Maximum = 12;
			sfRangeSlider1.RangeStart = -12;
			sfRangeSlider1.RangeEnd = 2.2;
			sfRangeSlider1.Value = 2.2;
			sfRangeSlider1.TickFrequency = 12;
			sfRangeSlider1.SnapsTo = SnapsTo.None;
			sfRangeSlider1.Orientation = Syncfusion.SfRangeSlider.XForms.Orientation.Vertical;
			sfRangeSlider1.ValuePlacement = ValuePlacement.TopLeft;
			sfRangeSlider1.TickPlacement = TickPlacement.None;
			sfRangeSlider1.ShowRange = false;
			sfRangeSlider1.TrackSelectionColor = Color.Gray;
			//sfRangeSlider1.SetValue (0);
			sfRangeSlider2 = new SfRangeSlider ();

			sfRangeSlider2.HeightRequest = 400;
			sfRangeSlider2.WidthRequest = 85;
			sfRangeSlider2.Minimum = -12;
			sfRangeSlider2.Maximum = 12;
			sfRangeSlider2.RangeStart = -12;
			sfRangeSlider2.RangeEnd = -4.7;
			sfRangeSlider2.Value = -4.7;
			sfRangeSlider2.TickFrequency = 12;
			sfRangeSlider2.SnapsTo = SnapsTo.None;
			sfRangeSlider2.Orientation = Syncfusion.SfRangeSlider.XForms.Orientation.Vertical;
			sfRangeSlider2.TickPlacement = TickPlacement.None;
			sfRangeSlider2.ValuePlacement = ValuePlacement.TopLeft;
			sfRangeSlider2.ShowRange = false;
			sfRangeSlider2.TrackSelectionColor = Color.Gray;
			//sfRangeSlider2.SetValue (12);
			sfRangeSlider3 = new SfRangeSlider ();

			sfRangeSlider3.HeightRequest = 400;
			sfRangeSlider3.WidthRequest = 85;
			sfRangeSlider3.Minimum = -12;
			sfRangeSlider3.Maximum = 12;
			sfRangeSlider3.RangeStart = -12;
			sfRangeSlider3.Value = 6;
			sfRangeSlider3.RangeEnd = 6;
			sfRangeSlider3.TickFrequency = 12;
			sfRangeSlider3.SnapsTo = SnapsTo.None;
			sfRangeSlider3.Orientation = Syncfusion.SfRangeSlider.XForms.Orientation.Vertical;
			sfRangeSlider3.TickPlacement = TickPlacement.None;
			sfRangeSlider3.ValuePlacement = ValuePlacement.TopLeft;
			sfRangeSlider3.ShowRange = false;
			sfRangeSlider3.TrackSelectionColor = Color.Gray;
			//sfRangeSlider3.SetValue (-12);
			this.BackgroundColor = Color.White;
			if (Device.OS == TargetPlatform.WinPhone)
			{
				label = new Label()
				{
					FontSize = 20,
					Text = "\t\t" + "60Hz",
					HeightRequest = 24,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromRgb(109, 109, 114),
					XAlign = TextAlignment.Center
				};
				label1 = new Label()
				{
					FontSize = 20,
					Text = "\t\t" + "170Hz",
					HeightRequest = 24,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromRgb(109, 109, 114),
					XAlign = TextAlignment.Center
				};
				label2 = new Label()
				{
					FontSize = 20,
					Text = "\t\t" + "310Hz",
					HeightRequest = 24,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromRgb(109, 109, 114),
					XAlign = TextAlignment.Center
				};
				label3 = new Label()
				{
					FontSize = 12,
					Text = "\t\t\t" + "2.2db",
					HeightRequest = 30,
					YAlign = TextAlignment.Start,
					TextColor = Color.FromRgb(57, 181, 247),
					XAlign = TextAlignment.Center
				};
				label4 = new Label()
				{
					FontSize = 12,
					Text = "\t\t\t" + "-4.7db",
					HeightRequest = 30,
					YAlign = TextAlignment.Start,
					TextColor = Color.FromRgb(57, 181, 247),
					XAlign = TextAlignment.Center
				};
				label5 = new Label()
				{
					FontSize = 12,
					Text = "\t\t\t" + "6db",
					HeightRequest = 30,
					YAlign = TextAlignment.Start,
					TextColor = Color.FromRgb(57, 181, 247),
					XAlign = TextAlignment.Center
				};
			}
			else
			{
				label = new Label()
				{
					FontSize = 20,
					Text ="60Hz",
					HeightRequest = 24,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromRgb(109, 109, 114),
					XAlign = TextAlignment.Center
				};
				label1 = new Label()
				{
					FontSize = 20,
					Text ="170Hz",
					HeightRequest = 24,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromRgb(109, 109, 114),
					XAlign = TextAlignment.Center
				};
				label2 = new Label()
				{
					FontSize = 20,
					Text ="310Hz",
					HeightRequest = 24,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromRgb(109, 109, 114),
					XAlign = TextAlignment.Center
				};
				label3 = new Label()
				{
					FontSize = 12,
					Text ="2.2db",
					HeightRequest = 30,
					YAlign = TextAlignment.Start,
					TextColor = Color.FromRgb(57, 181, 247),
					XAlign = TextAlignment.Center
				};
				label4 = new Label()
				{
					FontSize = 12,
					Text ="-4.7db",
					HeightRequest = 30,
					YAlign = TextAlignment.Start,
					TextColor = Color.FromRgb(57, 181, 247),
					XAlign = TextAlignment.Center
				};
				label5 = new Label()
				{
					FontSize = 12,
					Text ="6db",
					HeightRequest = 30,
					YAlign = TextAlignment.Start,
					TextColor = Color.FromRgb(57, 181, 247),
					XAlign = TextAlignment.Center
				};
			}
			label6 = new Label () {
				FontSize = 20,
				Text = "",
				HeightRequest = 1,
				YAlign = TextAlignment.End,
				TextColor = Color.FromRgb(109,109,114),
				XAlign = TextAlignment.Center
			};
			if (Device.OS == TargetPlatform.WinPhone) {
				sfRangeSlider1.BackgroundColor = Color.Gray;
				sfRangeSlider2.BackgroundColor = Color.Gray;
				sfRangeSlider3.BackgroundColor = Color.Gray;
				this.BackgroundColor = Color.Black;
			}
			if (Device.OS == TargetPlatform.iOS) {
				sfRangeSlider1.WidthRequest = 90;
				sfRangeSlider2.WidthRequest = 90;
				sfRangeSlider3.WidthRequest = 90;
				sfRangeSlider1.HeightRequest = 300;
				sfRangeSlider2.HeightRequest = 300;
				sfRangeSlider3.HeightRequest = 300;
			}
			else if(Device.OS == TargetPlatform.WinPhone)
			{
				sfRangeSlider1.WidthRequest = 120;
				sfRangeSlider2.WidthRequest = 120;
				sfRangeSlider3.WidthRequest = 120;
				sfRangeSlider1.HeightRequest = 600;
				sfRangeSlider2.HeightRequest = 600;
				sfRangeSlider3.HeightRequest = 600;
				sfRangeSlider1.KnobColor = Color.White;
				sfRangeSlider2.KnobColor = Color.White;
				sfRangeSlider3.KnobColor = Color.White;
				sfRangeSlider1.TrackSelectionColor = Color.Gray;
				sfRangeSlider2.TrackSelectionColor = Color.Gray;
				sfRangeSlider3.TrackSelectionColor = Color.Gray;
			}
            else if (Device.OS == TargetPlatform.Windows && Device.Idiom != TargetIdiom.Tablet)
            {
                this.BackgroundColor = Color.Black;
                label.TextColor =
                    label1.TextColor =
                        label2.TextColor =
                            label3.TextColor = label4.TextColor = label5.TextColor = label6.TextColor = Color.White;
                sfRangeSlider1.TrackSelectionColor = sfRangeSlider2.TrackSelectionColor = sfRangeSlider3.TrackSelectionColor = Color.Gray;
                sfRangeSlider1.TrackColor = sfRangeSlider2.TrackColor = sfRangeSlider3.TrackColor = Color.Gray;
            }
			sfRangeSlider1.ValueChanging += (object sender, ValueEventArgs e) => {
				double f = Math.Round(e.Value,1);
				if(Device.OS == TargetPlatform.WinPhone)
					label3.Text = "\t\t\t" + f + "db";
				else
					label3.Text = f + "db";
			};
			sfRangeSlider2.ValueChanging+= (object sender, ValueEventArgs e) => {
				double f = Math.Round(e.Value,1);
				if (Device.OS == TargetPlatform.WinPhone)
					label4.Text = "\t\t\t" + f + "db";
				else
					label4.Text = f + "db";
			};
			sfRangeSlider3.ValueChanging+= (object sender, ValueEventArgs e) => {
				double f = Math.Round(e.Value,1);
				if(Device.OS == TargetPlatform.WinPhone)
					label5.Text = "\t\t\t" + f + "db";
				else
					label5.Text = f + "db";
			};
			var mainStack1 = new StackLayout {
				Spacing = 1, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.Center,
				Padding = Device.OnPlatform (iOS: 10, Android : 10, WinPhone : 10),
				Children = { label, label3, sfRangeSlider1 }
			};
			var mainStack2 = new StackLayout {
				Spacing = 1, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.Center,
				Padding = Device.OnPlatform (iOS: 10, Android : 10, WinPhone : 10),
				Children = { label1, label4, sfRangeSlider2 }
			};
			var mainStack3 = new StackLayout {
				Spacing = 1, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.Center,
				Padding = Device.OnPlatform (iOS: 10, Android : 10, WinPhone : 10),
				Children = { label2, label5, sfRangeSlider3 }
			};
			var mainStack = new StackLayout {
				Spacing = 1, Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Center,
				Padding = Device.OnPlatform(iOS: 0, Android : 0, WinPhone : 0),
				Children = { mainStack1, mainStack2, mainStack3 }
			};
			var mainStack4 = new StackLayout {
				Spacing = 1, Orientation = StackOrientation.Vertical, VerticalOptions = LayoutOptions.FillAndExpand,
				Padding = Device.OnPlatform (iOS: 10, Android : 10, WinPhone : 1),
				Children = { label6, mainStack }
			};

			return mainStack4;
		}
	
	}
}

