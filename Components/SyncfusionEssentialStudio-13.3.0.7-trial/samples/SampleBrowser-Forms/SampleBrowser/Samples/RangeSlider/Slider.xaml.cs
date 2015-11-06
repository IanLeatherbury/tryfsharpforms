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
	public partial class Slider : SamplePage
	{
		public Slider ()
		{
			//InitializeComponent ();
			ContentView = GetRangeSlider ();
		}
		private StackLayout GetRangeSlider()
		{
			SfRangeSlider sfRangeSlider1;
			Label label,label1,label3;

			Image image = new Image ();
			image.WidthRequest = 280;
			image.HeightRequest = 280;
			image.Source = ImageSource.FromFile ("mount.jpg");

			sfRangeSlider1 = new SfRangeSlider();
			sfRangeSlider1.ShowRange = false;

			sfRangeSlider1.HeightRequest = 80;
			sfRangeSlider1.WidthRequest = 200;
			sfRangeSlider1.Minimum = 0;
			sfRangeSlider1.Maximum = 100;
			sfRangeSlider1.TickFrequency = 20;
			sfRangeSlider1.ShowValueLabel = true;
			sfRangeSlider1.Value = 100;
			sfRangeSlider1.SnapsTo = SnapsTo.None;
			sfRangeSlider1.Orientation = Syncfusion.SfRangeSlider.XForms.Orientation.Horizontal;
			sfRangeSlider1.TickPlacement = TickPlacement.BottomRight;
			sfRangeSlider1.ValueChanging+= (object sender, ValueEventArgs e) => 
			{
				image.Opacity = (double)(e.Value/100);
			};
			this.BackgroundColor = Color.White;

			label = new Label () {
				Text = "",
				HeightRequest = 20,
				YAlign = TextAlignment.End,
				TextColor = Color.Black
			};
			label1 = new Label () {
				Text = "  Opacity",
				HeightRequest = 20,
				YAlign = TextAlignment.End,
				TextColor = Color.Black
			};
			if (Device.OS == TargetPlatform.iOS) {
				label3 = new Label () {
					Text = "\n Slider",
					HeightRequest = 20,
					YAlign = TextAlignment.Start,
					TextColor = Color.Black,
					XAlign = TextAlignment.Start
				};
			} else {
				label3 = new Label () {
					Text = "Slider",
					HeightRequest = 30,
					YAlign = TextAlignment.Start,
					TextColor = Color.Black,
					XAlign = TextAlignment.Center
				};
			}
			label3.FontAttributes = FontAttributes.Bold;
			if(Device.OS == TargetPlatform.WinPhone)
			{
				sfRangeSlider1.BackgroundColor = Color.Gray;
				sfRangeSlider1.HeightRequest = 130;
				this.BackgroundColor = Color.Black;
				sfRangeSlider1.KnobColor = Color.White;
				label1.TextColor = Color.White;
				label.TextColor = Color.White;
				image.WidthRequest = 400;
				image.HeightRequest = 400;
				image.Aspect = Aspect.AspectFit;
				image.Source = ImageSource.FromFile("mount.jpg");
			}
		    if (Device.OS == TargetPlatform.Windows)
		    {
                //sfRangeSlider1.BackgroundColor = Color.Gray;
                sfRangeSlider1.HeightRequest = 150;
                this.BackgroundColor = Color.Black;
                sfRangeSlider1.KnobColor = Color.Gray;
                label1.TextColor = Color.Black;
                label.TextColor = Color.Black;
                image.WidthRequest = 400;
                image.HeightRequest = 400;
                image.Aspect = Aspect.AspectFit;
                image.Source = ImageSource.FromFile("mount.jpg");
		        if (Device.Idiom != TargetIdiom.Tablet)
		        {
		            sfRangeSlider1.TrackColor = Color.Gray;
		            this.BackgroundColor = Color.Black;
                    label1.TextColor = Color.White;
                    label.TextColor = Color.White;
		        }
		    }

		    var mainStack1 = new StackLayout
			{
				Spacing = 0,
				VerticalOptions = LayoutOptions.Center,
				Padding = Device.OnPlatform(iOS: 0, Android: 0, WinPhone: 30),
				Children = { label1, sfRangeSlider1 }
			};
			var mainStack = new StackLayout();
			if (Device.OS == TargetPlatform.WinPhone)
			{
				mainStack = new StackLayout
				{
					Spacing = 20,
					VerticalOptions = LayoutOptions.Center,
					Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
					Children = {label3, image, mainStack1 }
				};
			}
			else
			{
				mainStack = new StackLayout
				{
					Spacing = 20,
					VerticalOptions = LayoutOptions.Center,
					Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
					Children = {image, mainStack1 }
				};
			}
			return mainStack;
		}
	}

}

