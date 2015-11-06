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
using Syncfusion.SfBusyIndicator.XForms;

namespace SampleBrowser
{
	public partial class BusyIndicator : SamplePage
	{
		PickerExt picker;
		SfBusyIndicator sfbusyindicator;
		public BusyIndicator ()
		{
			//InitializeComponent ();
			Label label;
			sfbusyindicator = new SfBusyIndicator();
			sfbusyindicator.ViewBoxWidth = 150;
			sfbusyindicator.ViewBoxHeight = 150;
			sfbusyindicator.BackgroundColor = Color.White;
			sfbusyindicator.VerticalOptions = LayoutOptions.FillAndExpand;
			picker = new PickerExt ();
			picker.BackgroundColor = Color.White;
		    if (Device.OS == TargetPlatform.WinPhone)
		        picker.BackgroundColor = Color.Gray;
			picker.Items.Add ("Ball");
			picker.Items.Add ("Battery");
			picker.Items.Add ("DoubleCircle");
			picker.Items.Add ("ECG");
			picker.Items.Add ("Globe");
			picker.Items.Add ("HorizontalPulsingBox");
			picker.Items.Add ("Print");
			picker.Items.Add ("Rectangle");
			picker.Items.Add ("SingleCircle");
			picker.Items.Add ("SlicedCircle");
			picker.HeightRequest = 40;
			picker.SelectedIndex = 0;
			picker.SelectedIndexChanged += picker_SelectedIndexChanged;
			if (Device.OS == TargetPlatform.iOS)
			{

				picker.BackgroundColor = Color.White;
				label = new Label () {
					Text = "\nAnimation Type",
					HeightRequest = 20,
					TextColor = Color.Black
				};
				label.FontAttributes = FontAttributes.Bold;
				label.FontSize = 25;
			}
			else if(Device.OS == TargetPlatform.WinPhone)
			{
				label = new Label() { Text = "Animation Type", HeightRequest = 35, TextColor = Color.Black };
				picker.HeightRequest = 60;
				label.FontAttributes = FontAttributes.Bold;
				label.FontSize = 25;
				sfbusyindicator.Title = " ";
			}
            
                
			else
			{
				label = new Label() { Text = "Animation Type", HeightRequest = 35,  TextColor = Color.Black };
				label.FontAttributes = FontAttributes.Bold;
				label.FontSize = 25;
			}
            if (Device.OS == TargetPlatform.Windows && Device.Idiom != TargetIdiom.Tablet)
            {
               
                    picker.BackgroundColor = Color.Gray;
                
            }
			var mainStack = new StackLayout
			{
				Spacing = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 30),
				Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 20),
				Children = {label,picker,sfbusyindicator }
			};
			this.ContentView = mainStack;
			this.BackgroundColor = Color.FromRgb(236,235,242);
		}

		void picker_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (picker.SelectedIndex)
			{
			case 0:
				sfbusyindicator.AnimationType = AnimationTypes.Ball;
				sfbusyindicator.TextColor = Color.FromHex("#243FD9");
				break;
			case 1:
				sfbusyindicator.AnimationType = AnimationTypes.Battery;
				sfbusyindicator.TextColor = Color.FromHex("#A70015");
				break;
			case 2:
				sfbusyindicator.AnimationType = AnimationTypes.DoubleCircle;
				sfbusyindicator.TextColor = Color.FromHex("#958C7B");
				break;
			case 3:
				sfbusyindicator.AnimationType = AnimationTypes.ECG;
				sfbusyindicator.TextColor = Color.FromHex("#DA901A");
				break;
			case 4:
				sfbusyindicator.AnimationType = AnimationTypes.Globe;
				sfbusyindicator.TextColor = Color.FromHex("#9EA8EE");
				break;
			case 5:
				sfbusyindicator.AnimationType = AnimationTypes.HorizontalPulsingBox;
				sfbusyindicator.TextColor = Color.FromHex("#E42E06");
				break;
			case 6:
				sfbusyindicator.AnimationType = AnimationTypes.Print;
				sfbusyindicator.TextColor = Color.FromHex("#5E6FF8");
				break;
			case 7:
				sfbusyindicator.AnimationType = AnimationTypes.Rectangle;
				sfbusyindicator.TextColor = Color.FromHex("#27AA9E");
				break;
			case 8:
				sfbusyindicator.AnimationType = AnimationTypes.SingleCircle;
				sfbusyindicator.TextColor = Color.FromHex("#AF2541");
				break;
			case 9:
				sfbusyindicator.AnimationType = AnimationTypes.SlicedCircle;
				sfbusyindicator.TextColor = Color.FromHex("#779772");
				break;
			}
		}


	}
}

