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
using Syncfusion.SfGauge.XForms;

namespace SampleBrowser
{
	public partial class DigitalGauge : SamplePage
	{
		public static SfDigitalGauge digitalGauge1;
		public static SfDigitalGauge digitalGauge2;
		public static SfDigitalGauge digitalGauge3;
		public static SfDigitalGauge digitalGauge4;

		public void EnableTimer()
		{
			this.DateTime = DateTime.Now;

			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
				{
					this.DateTime = DateTime.Now;
					return true;
				}); 
		}
		DateTime dateTime = new DateTime();
		public DateTime DateTime
		{
			set
			{
				if (dateTime != value)
				{
					string timeString1 = DateTime.Now.ToString ("HH mm ss");
					digitalGauge1.Value = timeString1;
					digitalGauge2.Value = timeString1;
					digitalGauge3.Value = timeString1;
					digitalGauge4.Value = timeString1;
				}
			}
			get
			{
				return dateTime;
			}
		}

		public DigitalGauge ()
		{
			//InitializeComponent ();
			string timeString1 = DateTime.Now.ToString ("HH mm ss");

			Label label1;
			Label label2;
			Label label3;
			Label label4;

			label1 = new Label() { Text = "7 Segment", HeightRequest = 30, HorizontalOptions=LayoutOptions.Center, TextColor = Color.Gray };
			label1.FontAttributes = FontAttributes.Bold;
			label1.FontSize = 20;
			digitalGauge1 = new SfDigitalGauge();
			digitalGauge1.Value = timeString1;
			digitalGauge1.CharacterHeight = 50;
			digitalGauge1.CharacterWidth= 25;
			digitalGauge1.SegmentStrokeWidth = 3;
			digitalGauge1.CharacterType = CharacterType.SegmentSeven;
			digitalGauge1.Value = timeString1;
			digitalGauge1.DimmedSegmentAlpha = 30;
			digitalGauge1.BackgroundColor = Color.FromRgb (235, 235, 235);
			digitalGauge1.CharacterStrokeColor = Color.FromRgb (20,108,237);
			digitalGauge1.DimmedSegmentColor = Color.FromRgb (20,108,237);

			label2 = new Label() { Text = "14 Segment", HeightRequest = 30, HorizontalOptions=LayoutOptions.Center, TextColor = Color.Gray };
			label2.FontAttributes = FontAttributes.Bold;
			label2.FontSize = 20;
			digitalGauge2 = new SfDigitalGauge();
			digitalGauge2.CharacterHeight = 50;
			digitalGauge2.CharacterWidth = 25;
			digitalGauge2.SegmentStrokeWidth = 3;
			digitalGauge2.CharacterType = CharacterType.SegmentFourteen;
			digitalGauge2.Value = timeString1;
			digitalGauge2.DimmedSegmentAlpha = 30;
			digitalGauge2.BackgroundColor =  Color.FromRgb (235,235,235);
			digitalGauge2.CharacterStrokeColor = Color.FromRgb (2,186,94);
			digitalGauge2.DimmedSegmentColor = Color.FromRgb (2,186,94);

			label3 = new Label() { Text = "16 Segment", HeightRequest = 30, HorizontalOptions=LayoutOptions.Center, TextColor = Color.Gray };
			label3.FontAttributes = FontAttributes.Bold;
			label3.FontSize = 20;
			digitalGauge3 = new SfDigitalGauge();
			digitalGauge3.CharacterHeight = 50;
			digitalGauge3.CharacterWidth = 25;
			digitalGauge3.SegmentStrokeWidth = 3;
			digitalGauge3.CharacterType = CharacterType.SegmentSixteen;
			digitalGauge3.Value = timeString1;
			digitalGauge3.DimmedSegmentAlpha = 30;
			digitalGauge3.BackgroundColor = Color.FromRgb(235,235,235);
			digitalGauge3.CharacterStrokeColor	 =Color.FromRgb (219,153,7);
			digitalGauge3.DimmedSegmentColor = Color.FromRgb(219,153,7);
			digitalGauge1.HorizontalOptions = LayoutOptions.Center;

			label4 = new Label() { Text = "8x8 Matrix", HeightRequest = 30, HorizontalOptions=LayoutOptions.Center, TextColor = Color.Gray };
			label4.FontAttributes = FontAttributes.Bold;
			label4.FontSize = 20;
			digitalGauge4 = new SfDigitalGauge();
			digitalGauge4.CharacterHeight = 50;
			digitalGauge4.CharacterWidth = 25;
			digitalGauge4.SegmentStrokeWidth = 3;
			digitalGauge4.CharacterType = CharacterType.EightCrossEightDotMatrix;
			digitalGauge4.Value = timeString1;
			digitalGauge4.DimmedSegmentAlpha = 30;
			digitalGauge4.BackgroundColor = Color.FromRgb(235,235,235);
			digitalGauge4.CharacterStrokeColor = Color.FromRgb(249,66,53);
			digitalGauge4.DimmedSegmentColor = Color.FromRgb(249,66,53);

			digitalGauge1.HeightRequest = 50;
			digitalGauge2.HeightRequest = 50;
			digitalGauge3.HeightRequest = 50;
			digitalGauge4.HeightRequest = 50;
			if (Device.OS == TargetPlatform.iOS)
			{
				digitalGauge1.WidthRequest = (8 * digitalGauge1.CharacterWidth) + (8 * digitalGauge1.CharacterSpacing);
				digitalGauge2.WidthRequest = (8 * digitalGauge2.CharacterWidth) + (8 * digitalGauge2.CharacterSpacing);
				digitalGauge3.WidthRequest = (8 * digitalGauge3.CharacterWidth) + (8 * digitalGauge3.CharacterSpacing);
				digitalGauge4.WidthRequest = (9 * digitalGauge4.CharacterWidth) + (8 * digitalGauge4.CharacterSpacing);
				digitalGauge1.HorizontalOptions = LayoutOptions.Center;
				digitalGauge2.HorizontalOptions = LayoutOptions.Center;
				digitalGauge3.HorizontalOptions = LayoutOptions.Center;
				digitalGauge4.HorizontalOptions = LayoutOptions.Center;
			}

			EnableTimer ();
			if (Device.OS == TargetPlatform.Android) {
				digitalGauge1.HeightRequest = digitalGauge1.CharacterHeight + digitalGauge1.CharacterHeight / 6;
				digitalGauge2.HeightRequest = digitalGauge2.CharacterHeight + digitalGauge2.CharacterHeight / 6;
				digitalGauge3.HeightRequest = digitalGauge3.CharacterHeight + digitalGauge3.CharacterHeight / 6;
				digitalGauge4.HeightRequest = digitalGauge4.CharacterHeight + digitalGauge4.CharacterHeight / 6;
			}
			Label label;

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
			{
				digitalGauge1.HeightRequest = 65;
				digitalGauge2.HeightRequest = 65;
				digitalGauge3.HeightRequest = 65;
				digitalGauge4.HeightRequest = 65;

				digitalGauge1.CharacterHeight = 65;
				digitalGauge1.CharacterWidth = 20;
				digitalGauge1.SegmentStrokeWidth = 3;

				digitalGauge2.CharacterHeight = 65;
				digitalGauge2.CharacterWidth = 20;
				digitalGauge2.SegmentStrokeWidth = 3;

				digitalGauge3.CharacterHeight = 65;
				digitalGauge3.CharacterWidth = 20;
				digitalGauge3.SegmentStrokeWidth = 3;

				digitalGauge4.CharacterHeight = 65;
				digitalGauge4.CharacterWidth = 20;
				digitalGauge4.SegmentStrokeWidth = 3;

                digitalGauge1.WidthRequest = 350;
                digitalGauge2.WidthRequest = 350;
                digitalGauge3.WidthRequest = 350;
                digitalGauge4.WidthRequest = 350;
                digitalGauge1.HorizontalOptions = LayoutOptions.Center;
                digitalGauge2.HorizontalOptions = LayoutOptions.Center;
                digitalGauge3.HorizontalOptions = LayoutOptions.Center;
                digitalGauge4.HorizontalOptions = LayoutOptions.Center;
			}
			if (Device.OS == TargetPlatform.iOS)
			{
				label = new Label () {
					Text = "\nGauge Getting Started",
					HeightRequest = 20,
					TextColor = Color.White
				};
				label.FontAttributes = FontAttributes.Bold;
				label.FontSize = 25;
			}
			else
			{
				label = new Label() { Text = "Gauge Getting Started", HeightRequest = 25, TextColor = Color.White };
				label.FontAttributes = FontAttributes.Bold;
				label.FontSize = 25;
			}
			var mainStack = new StackLayout
			{
				Spacing = 10,
				Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
				Children = {label,label1,digitalGauge1,label2,digitalGauge2,label3,digitalGauge3,label4,digitalGauge4 }
			};
			this.ContentView = mainStack;
			this.BackgroundColor = Color.White;
		}
	}
}

