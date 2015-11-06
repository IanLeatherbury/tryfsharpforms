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
	public partial class RangeSlider : SamplePage
	{
		
		SfRangeSlider sfRangeSlider1;
		SfRangeSlider sfRangeSlider2;
		Label label, label1, label2, label3, label4, label5,label6,label7,label8,label9,label10,label11;
		Label time,time1;
		PickerExt picker1, picker2;
		Switch toggleButton,toggleButton2;
		public RangeSlider ()
		{
			//InitializeComponent ();
			
			sfRangeSlider1 = new SfRangeSlider();
			sfRangeSlider2 = new SfRangeSlider();

			sfRangeSlider1.HeightRequest = 90;
			sfRangeSlider1.WidthRequest = 200;
			sfRangeSlider1.Minimum = 0;
			sfRangeSlider1.Maximum = 12;
			sfRangeSlider1.RangeStart = 0;
			sfRangeSlider1.RangeEnd = 12;
			sfRangeSlider1.TickFrequency = 2;
			sfRangeSlider1.SnapsTo = SnapsTo.None;
			sfRangeSlider1.Orientation = Syncfusion.SfRangeSlider.XForms.Orientation.Horizontal;
			sfRangeSlider1.TickPlacement = TickPlacement.BottomRight;


			sfRangeSlider2.HeightRequest = 90;
			sfRangeSlider2.WidthRequest = 200;
			sfRangeSlider2.Minimum = 0;
			sfRangeSlider2.Maximum = 12;
			sfRangeSlider2.RangeStart = 0;
			sfRangeSlider2.RangeEnd = 12;
			sfRangeSlider2.TickFrequency = 2;
			sfRangeSlider2.SnapsTo = SnapsTo.None;
			sfRangeSlider2.Orientation = Syncfusion.SfRangeSlider.XForms.Orientation.Horizontal;
			sfRangeSlider2.TickPlacement = TickPlacement.BottomRight;
			
			Title = "Getting Started";
			toggleButton = new Switch();
			toggleButton2 = new Switch();
			picker1 = new PickerExt();
			picker2 = new PickerExt();
			sfRangeSlider1.RangeChanging += (object sender, RangeEventArgs e) => {
				if (Math.Round (e.Start) < 1) {
					if (Math.Round (e.End) == 12)
						label10.Text = "12 AM - " + Math.Round (e.End) + " PM";
					else
						label10.Text = "12 AM - " + Math.Round (e.End) + " AM";
				} else {
					if (Math.Round (e.End) == 12)
						label10.Text = Math.Round (e.Start) + " AM - " + Math.Round (e.End) + " PM";
					else
						label10.Text = Math.Round (e.Start) + " AM - " + Math.Round (e.End) + " AM";
				}
				if (Math.Round (e.Start) == Math.Round (e.End)) {
					if (Math.Round (e.Start) < 1) 
						label10.Text = "12 AM";
					else if(Math.Round (e.Start) == 12)
						label10.Text = "12 PM";
					else
						label10.Text = Math.Round (e.Start) + " AM";
				}
			};
			sfRangeSlider2.RangeChanging+= (object sender, RangeEventArgs e) => 
			{
				if (Math.Round (e.Start) < 1) {
					if (Math.Round (e.End) == 12)
						label11.Text = "12 AM - " + Math.Round (e.End) + " PM";
					else
						label11.Text = "12 AM - " + Math.Round (e.End) + " AM";
				} else {
					if (Math.Round (e.End) == 12)
						label11.Text = Math.Round (e.Start) + " AM - " + Math.Round (e.End) + " PM";
					else
						label11.Text = Math.Round (e.Start) + " AM - " + Math.Round (e.End) + " AM";
				}
				if (Math.Round (e.Start) == Math.Round (e.End)) {
					if (Math.Round (e.Start) < 1) 
						label11.Text = "12 AM";
					else if(Math.Round (e.Start) == 12)
						label11.Text = "12 PM";
					else
						label11.Text = Math.Round (e.Start) + " AM";
				}
			};
			toggleButton.Toggled += toggleStateChanged;
			toggleButton2.Toggled += toggleStateChanged1;
			toggleButton.IsToggled = true;
			picker1.Items.Add("TopLeft");
			picker1.Items.Add("BottomRight");
			picker1.Items.Add("Inline");
			picker1.Items.Add("Outside");
			picker1.Items.Add("None");
			picker1.HeightRequest = 40;
			picker1.SelectedIndex = 1;
			picker1.SelectedIndexChanged += picker1_SelectedIndexChanged;
			picker2.Items.Add("TopLeft");
			picker2.Items.Add("BottomRight");
			picker2.HeightRequest = 40;
			picker2.SelectedIndex = 1;
			picker2.SelectedIndexChanged += picker2_SelectedIndexChanged;
			picker1.BackgroundColor = Color.White;
			picker2.BackgroundColor = Color.White;
			label6 = new Label()
			{
				Text = " " + "Settings",
				FontSize = 60,
				HeightRequest = 60,
				YAlign = TextAlignment.End,
				TextColor = Color.White
			};
			label3 = new Label()
			{
				Text = "Tick Placement",
				HeightRequest = 20,
				YAlign = TextAlignment.End,
				TextColor = Color.Black
			};
			label4 = new Label()
			{
				Text = "Label Placement",
				HeightRequest = 20,
				YAlign = TextAlignment.End,
				TextColor = Color.Black
			};
			label5 = new Label()
			{
				Text = "Label",
				HeightRequest = 20,
				YAlign = TextAlignment.Center,
				TextColor = Color.Black,
			};
			label9 = new Label()
			{
				Text = "SnapsToTick",
				HeightRequest = 20,
				YAlign = TextAlignment.Center,
				TextColor = Color.Black
			};
		    if (Device.OS == TargetPlatform.Windows && Device.Idiom != TargetIdiom.Tablet)
		    {
		        label9.TextColor = Color.White;
		    }
		    label10 = new Label()
			{
				FontSize = 12,
				Text = "12 AM - 12 PM",
				HeightRequest = 20,
				YAlign = TextAlignment.Center,
				TextColor = Color.FromHex("#939394"),
				XAlign = TextAlignment.Start
			};
			label11 = new Label()
			{
				FontSize = 12,
				Text = "12 AM - 12 PM",
				HeightRequest = 20,
				YAlign = TextAlignment.Center,
				TextColor = Color.FromHex("#939394"),
				XAlign = TextAlignment.Start
			};
			if (Device.OS == TargetPlatform.Android) {
				time = new Label()
				{
					FontSize = 12,
					Text = "   Time: ",
					HeightRequest = 20,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromHex("#939394"),
					XAlign = TextAlignment.Start
				};
				time1 = new Label()
				{
					FontSize = 12,
					Text = "   Time: ",
					HeightRequest = 20,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromHex("#939394"),
					XAlign = TextAlignment.Start
				};
				label = new Label()
				{
					XAlign = TextAlignment.Start,
					Text = "  Departure",
					HeightRequest = 20,
					YAlign = TextAlignment.End,
					TextColor = Color.Black
				};
				label1 = new Label()
				{
					XAlign = TextAlignment.Start,
					Text = "  Arrival",
					HeightRequest = 20,
					YAlign = TextAlignment.End,
					TextColor = Color.Black
				};
			} else if (Device.OS == TargetPlatform.iOS) {
				time = new Label()
				{
					FontSize = 12,
					Text = "   Time: ",
					HeightRequest = 20,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromHex("#939394"),
					XAlign = TextAlignment.Start
				};
				time1 = new Label()
				{
					FontSize = 12,
					Text = "   Time: ",
					HeightRequest = 20,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromHex("#939394"),
					XAlign = TextAlignment.Start
				};
				label = new Label()
				{
					XAlign = TextAlignment.Start,
					Text = "  Departure",
					HeightRequest = 20,
					YAlign = TextAlignment.End,
					TextColor = Color.Black
				};
				label1 = new Label()
				{
					XAlign = TextAlignment.Start,
					Text = "  Arrival",
					HeightRequest = 20,
					YAlign = TextAlignment.End,
					TextColor = Color.Black
				};
			} else {
				time1 = new Label()
				{
					FontSize = 12,
					Text = "Time: ",
					HeightRequest = 20,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromHex("#939394"),
					XAlign = TextAlignment.Start
				};
				time = new Label()
				{
					FontSize = 12,
					Text = "Time: ",
					HeightRequest = 20,
					YAlign = TextAlignment.Center,
					TextColor = Color.FromHex("#939394"),
					XAlign = TextAlignment.Start
				};
				label = new Label()
				{
					XAlign = TextAlignment.Start,
					Text = "Departure",
					HeightRequest = 20,
					YAlign = TextAlignment.End,
					TextColor = Color.Black
				};
				label1 = new Label()
				{
					XAlign = TextAlignment.Start,
					Text = "Arrival",
					HeightRequest = 20,
					YAlign = TextAlignment.End,
					TextColor = Color.Black
				};
                if (Device.OS == TargetPlatform.Windows && Device.Idiom != TargetIdiom.Tablet)
                {
                    label.TextColor = Color.White;
                    label1.TextColor = Color.White;
                }
			}

			if (Device.OS == TargetPlatform.Android)
			{
				picker1.BackgroundColor = Color.FromRgb(239, 239, 239);
				picker2.BackgroundColor = Color.FromRgb(239, 239, 239);
				label3.FontSize = 20;
				label4.FontSize = 20;
				label5.FontSize = 20;
				label9.FontSize = 20;
			}
			label10.WidthRequest = sfRangeSlider1.Width;
			label11.WidthRequest = sfRangeSlider1.Width;
			label5.WidthRequest = label9.Width;
			ContentView = GetRangeSlider();
			PropertyView = GetOptionPage ();
		}

		private StackLayout GetRangeSlider()
		{

			this.BackgroundColor = Color.White;
			picker1.SelectedIndex = 0;
			picker2.SelectedIndex = 0;

			label7 = new Label()
			{
				FontSize = 12,
				//WidthRequest = sfRangeSlider1.Width,
				Text = " (in Hours)",
				HeightRequest = 20,
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Start,
				TextColor = Color.FromHex("#939394")
			};
			label8 = new Label()
			{
				FontSize = 12,
				//WidthRequest = sfRangeSlider1.Width,
				Text = " (in Hours)",
				HeightRequest = 20,
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Start,
				TextColor = Color.FromHex("#939394")
			};
			label2 = new Label()
			{

				HeightRequest = 20,
			};
			label10.WidthRequest = sfRangeSlider1.Width;
			label11.WidthRequest = sfRangeSlider1.Width;
			label5.WidthRequest = 150;
			label9.WidthRequest = 150;
			if (Device.OS == TargetPlatform.WinPhone)
			{
                picker1.BackgroundColor = Color.Black;
                picker2.BackgroundColor = Color.Black;
				sfRangeSlider1.HeightRequest = 110;
				sfRangeSlider2.HeightRequest = 110;
				label5.WidthRequest = 150;
				label9.WidthRequest = 150;
				sfRangeSlider1.BackgroundColor = Color.Gray;
				sfRangeSlider2.BackgroundColor = Color.Gray;
				picker1.HeightRequest = 60;
				picker2.HeightRequest = 60;
                
				label2.TextColor = Color.White;
				label3.TextColor = Color.White;
				label4.TextColor = Color.White;
				label5.TextColor = Color.White;
				this.BackgroundColor = Color.Black;
				label1.TextColor = Color.White;
				label.TextColor = Color.White;
				sfRangeSlider1.KnobColor = Color.White;
				sfRangeSlider2.KnobColor = Color.White;

			
				label3.Text = "  " + "Tick Placement";
				label3.HeightRequest = 22;
				label4.Text = "  " + "Label Placement";
				label4.HeightRequest = 22;
				label5.Text = "  " + "Label";
				label5.HeightRequest = 22;
				label7.FontSize = 20;
				label8.FontSize = 20;
				label10.FontSize = 20;
				label11.FontSize = 20;
				label9.TextColor = Color.White;
				time.FontSize = 20;
				time1.FontSize = 20;
			}
            if (Device.OS == TargetPlatform.Windows && Device.Idiom != TargetIdiom.Tablet)
		    {
                picker1.BackgroundColor = Color.Black;
                picker2.BackgroundColor = Color.Black;
                sfRangeSlider1.TrackColor = Color.Gray;
                sfRangeSlider2.TrackColor = Color.Gray;
		        this.BackgroundColor = Color.Black;
                label2.TextColor = Color.White;
                label3.TextColor = Color.White;
                label4.TextColor = Color.White;
                label5.TextColor = Color.White;

		    }
			var depart = new StackLayout
			{
				Spacing = 0,Orientation = StackOrientation.Horizontal,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50),
				Children = { label,label7}
			};
			var apart = new StackLayout
			{
				Spacing = 0,Orientation = StackOrientation.Horizontal,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50),
				Children = { label1,label8}
			};
			var mainStack1 = new StackLayout
			{
				Spacing = 0,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50),
				Children = { sfRangeSlider1}
			};
			var mainStack2 = new StackLayout
			{
				Spacing = 0,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50),
				Children = {sfRangeSlider2}
			};

			var timestack = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				//Spacing = 10,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50),
				Children = { time,label10}
			};
			var timestack1 = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				//Spacing = 10,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50),
				Children = { time1,label11}
			};
			var main1 = new StackLayout
			{
				Spacing = 10,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50),
				Children = { depart,timestack, mainStack1}
			};
			var main2 = new StackLayout
			{
				Spacing = 10,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50),
				Children = {apart,timestack1, mainStack2}
			};
			var mainStack = new StackLayout
			{
				Spacing = 20,
				Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 50),
				Children = { main1, main2}
			};
			if (Device.OS == TargetPlatform.WinPhone)
				mainStack.Spacing = 60;
			return mainStack;
		}

		private StackLayout GetOptionPage()
		{


			//			toggleButton.WidthRequest = picker1.Width - label5.Width;
			//			toggleButton2.WidthRequest = picker1.Width - label9.Width;
			toggleButton.HorizontalOptions = LayoutOptions.End;
			toggleButton2.HorizontalOptions = LayoutOptions.End;
			var layoutpage = new StackLayout
			{
				Spacing = 10,
				Orientation = StackOrientation.Horizontal,
				//Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
				Children = { label5, toggleButton }
			};
			var togglepage = new StackLayout
			{
				Spacing = 10,
				Orientation = StackOrientation.Horizontal,
				//Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
				Children = { label9, toggleButton2 }
			};
			var page1 = new StackLayout
			{
				Spacing = 10,
				Orientation = StackOrientation.Vertical,
				//Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
				Children = { label3, picker1 }
			};
			var page2 = new StackLayout
			{
				Spacing = 10,
				Orientation = StackOrientation.Vertical,
				//Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
				Children = { label4, picker2 }
			};
			var page3 = new StackLayout
			{
				Spacing = 40,
				Orientation = StackOrientation.Vertical,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
				Children = { page1, page2 }
			};

			var page = new StackLayout
			{
				Spacing = 40,
				Orientation = StackOrientation.Vertical,
				Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
				Children = { page3, layoutpage , togglepage }
			};
			var page4 = new StackLayout
			{
				Spacing = 40,
				Orientation = StackOrientation.Vertical,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
				Children = { label6, page }
			};

			if (Device.OS == TargetPlatform.WinPhone)
			{
				page.Spacing = 25;
				
				return page4;
			}
			//label5.WidthRequest = label9.Width;
			//this.InvalidateMeasure ();
			return page;
		}

		void picker1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (picker1.SelectedIndex)
			{
			case 0:
				{
					sfRangeSlider1.TickPlacement = TickPlacement.TopLeft;
					sfRangeSlider2.TickPlacement = TickPlacement.TopLeft;

					break;
				}
			case 1:
				{
					sfRangeSlider1.TickPlacement = TickPlacement.BottomRight;
					sfRangeSlider2.TickPlacement = TickPlacement.BottomRight;
					break;
				}
			case 2:
				{
					sfRangeSlider1.TickPlacement = TickPlacement.Inline;
					sfRangeSlider2.TickPlacement = TickPlacement.Inline;
					break;
				}
			case 3:
				{
					sfRangeSlider1.TickPlacement = TickPlacement.Outside;
					sfRangeSlider2.TickPlacement = TickPlacement.Outside;
					break;
				}
			case 4:
				{
					sfRangeSlider1.TickPlacement = TickPlacement.None;
					sfRangeSlider2.TickPlacement = TickPlacement.None;
					break;
				}
			}
		}
		void picker2_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (picker2.SelectedIndex)
			{
			case 0:
				{
					sfRangeSlider1.ValuePlacement = ValuePlacement.TopLeft;
					sfRangeSlider2.ValuePlacement = ValuePlacement.TopLeft;
					break;
				}
			case 1:
				{
					sfRangeSlider1.ValuePlacement = ValuePlacement.BottomRight;
					sfRangeSlider2.ValuePlacement = ValuePlacement.BottomRight;
					break;
				}
			}
		}
		void toggleStateChanged(object sender, ToggledEventArgs e)
		{
			sfRangeSlider1.ShowValueLabel = e.Value;
			sfRangeSlider2.ShowValueLabel = e.Value;
		}
		void toggleStateChanged1(object sender, ToggledEventArgs e)
		{
			if (e.Value) {
				sfRangeSlider1.SnapsTo = SnapsTo.Ticks;
				sfRangeSlider2.SnapsTo = SnapsTo.Ticks;
			} else {
				sfRangeSlider1.SnapsTo = SnapsTo.None;
				sfRangeSlider2.SnapsTo = SnapsTo.None;
			}
		}
	}
}

