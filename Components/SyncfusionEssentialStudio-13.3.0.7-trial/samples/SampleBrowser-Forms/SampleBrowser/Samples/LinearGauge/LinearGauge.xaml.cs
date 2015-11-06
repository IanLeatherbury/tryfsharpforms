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
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public partial class LinearGauge : SamplePage
	{
		public static SfLinearGauge linearGauge;
		public LinearGauge ()
		{
			//InitializeComponent ();
			linearGauge = new SfLinearGauge ();
			linearGauge.BackgroundColor = Color.White;
			linearGauge.Orientation = Syncfusion.SfGauge.XForms.Orientation.OrientationVertical;
			//Scale
			ObservableCollection<LinearScale> scales = new ObservableCollection<LinearScale> ();
			LinearScale scale = new LinearScale ();
			scale.MinimumValue = 0;
			scale.MaximumValue = 100;
			scale.Interval = 20;
			scale.ScaleBarLength = 100;
			//			scale.LabelPostfix = "%";
			scale.ScaleBarColor = Color.FromRgb (250, 236, 236);
			scale.LabelColor = Color.FromRgb (84, 84, 84); 
			scale.MinorTicksPerInterval = 1;
			scale.ScaleBarSize = 13;
			scale.ScalePosition = ScalePosition.BackWard;
			List<LinearPointer> pointers = new List<LinearPointer> ();
			//SymbolPointer
			SymbolPointer symbolPointer = new SymbolPointer ();
			symbolPointer.Value = 50;
			symbolPointer.Offset = 0.0;
			symbolPointer.Thickness = 3;
			symbolPointer.Color = Color.FromRgb (65, 77, 79);

			//BarPointer
			BarPointer rangePointer = new BarPointer ();
			rangePointer.Value = 50;
			rangePointer.Color = Color.FromRgb (206, 69, 69);
			rangePointer.Thickness = 10;
			pointers.Add (symbolPointer);
			pointers.Add (rangePointer);

			//Range
			LinearRange range = new LinearRange ();
			range.StartValue = 0;
			range.EndValue = 50;
			range.Color = Color.FromRgb (234, 248, 249);
			range.StartWidth = 10;
			range.EndWidth = 10;
            if (Device.OS == TargetPlatform.Windows)
            {
                range.Offset = -0.07;
            }
            else
            range.Offset = -0.17;
			scale.Ranges.Add (range);


			//Range
			LinearRange range2 = new LinearRange ();
			range2.StartValue = 50;
			range2.EndValue = 100;
			range2.Color = Color.FromRgb (50, 184, 198);
			range2.StartWidth = 10;
            range2.EndWidth = 10; 
            if (Device.OS == TargetPlatform.Windows)
            {
                range2.Offset = -0.07;
            }
            else
			range2.Offset = -0.17;
			scale.Ranges.Add (range2);

			//Minor Ticks setting
			LinearTickSettings minor = new LinearTickSettings ();
			minor.Length = 10;
			minor.Color = Color.FromRgb (175, 175, 175);
			minor.Thickness = 1;
			scale.MinorTickSettings = minor;

			//Major Ticks setting
			LinearTickSettings major = new LinearTickSettings ();
			major.Length = 10;
			major.Color = Color.FromRgb (175, 175, 175);
			major.Thickness = 1;
			scale.MajorTickSettings = major;

			scale.Pointers = pointers;
			scales.Add (scale);
			linearGauge.Scales = scales;



			Label label;
			if (Device.OS == TargetPlatform.iOS) {
				label = new Label () {
					Text = "Memory Usage",HorizontalOptions = LayoutOptions.Center,
					HeightRequest = 50,
					TextColor = Color.Black
				};
				label.FontAttributes = FontAttributes.Bold;
				label.FontSize = 25;
			} else {
				label = new Label () {
					Text = "Memory Usage",HorizontalOptions = LayoutOptions.Center,
					HeightRequest = 50,
					TextColor = Color.Black
				};
				label.FontAttributes = FontAttributes.Bold;
				label.FontSize = 25;
			}

			var mainStack = new StackLayout {
				BackgroundColor = Color.White,
				Spacing = 10,
				Padding = Device.OnPlatform (iOS: 10, Android : 10, WinPhone : 50),
				Children = { label, linearGauge }
			};
			mainStack.SizeChanged += (object sender, EventArgs e) => {
				linearGauge.HeightRequest = mainStack.Height - 150;
				linearGauge.WidthRequest = mainStack.Width - 50;

			};
			this.ContentView = mainStack;
			//this.BackgroundColor = Color.Black;
		}
	}
}

