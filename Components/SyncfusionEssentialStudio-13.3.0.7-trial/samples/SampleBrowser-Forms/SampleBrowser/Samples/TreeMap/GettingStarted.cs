#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfTreeMap.XForms;
using System;
using System.Collections.ObjectModel;
using Syncfusion.XlsIO.Parser.Biff_Records;
using Xamarin.Forms;

namespace SampleBrowser
{
	public class GettingStarted : SamplePage
	{
		SfTreeMap tree;
		public static bool IsDarkTheme = false;
		ToolbarItem baritem;
		LayoutTypes layoutType= LayoutTypes.Squarified;
		Label label3, label4, label5,label6,label9;
		RangeColorMapping rangeMapping;
		double groupPadding=2;
		DesaturationColorMapping desaturationMapping;
		UniColorMapping uniMapping;
		PaletteColorMapping paletteMapping;
		ColorMapping treeMapColorMapping;
		PickerExt picker1, picker2;

		Xamarin.Forms.Slider toggleButton,toggleButton2;
		public GettingStarted ()
		{
			baritem = new ToolbarItem();
			tree = new SfTreeMap();
			Title = "GettingStarted";
			this.BackgroundColor = Device.OnPlatform(iOS: Color.White, Android: Color.White, WinPhone: Color.Black);
			tree.WeightValuePath = "Population";
			tree.ColorValuePath = "Growth";
			tree.LeafItemSettings = new LeafItemSettings();
			tree.LeafItemSettings.BorderColor =  Device.OnPlatform(iOS: Color.Gray, Android: Color.White, WinPhone:IsDarkTheme ? Color.White : Color.Gray);
			tree.LeafItemSettings.BorderWidth = Device.OnPlatform(iOS: 1, Android:2, WinPhone:2);
			tree.LeafItemSettings.Gap = Device.OnPlatform(iOS:1 , Android: 5, WinPhone: 3);
			tree.LeafItemSettings.LabelStyle = new Syncfusion.SfTreeMap.XForms.Style() { Font = Font.SystemFontOfSize(18), Color = Color.White };
			tree.LeafItemSettings.LabelPath = "Country";
			ObservableCollection<Range> ranges = new ObservableCollection<Range>();
			ranges.Add(new Range() { LegendLabel = "1 % Growth", From = 0, To = 1, Color = Color.FromHex("#77D8D8") });
			ranges.Add(new Range() { LegendLabel = "2 % Growth", From = 0, To = 2, Color = Color.FromHex("#AED960") });
			ranges.Add(new Range() { LegendLabel = "3 % Growth", From = 0, To = 3, Color = Color.FromHex("#FFAF51") });
			ranges.Add(new Range() { LegendLabel = "4 % Growth", From = 0, To = 4, Color = Color.FromHex("#F3D240") });
			tree.LeafItemColorMapping = rangeMapping = new RangeColorMapping() { Ranges = ranges };
			Size legendSize = Device.OnPlatform(iOS: new Size(300, 60), Android: new Size(200, 60), WinPhone: new Size(420, 75));
			Size iconSize = Device.OnPlatform(iOS: new Size(17, 17), Android: new Size(25, 25), WinPhone: new Size(15, 15));

			
			treeMapColorMapping = rangeMapping;
			desaturationMapping = new DesaturationColorMapping (){ From = 1, To = 0.2, Color = Color.FromHex ("#02AEDC") };
			TreeMapFlatLevel level = new TreeMapFlatLevel() { HeaderStyle = new Syncfusion.SfTreeMap.XForms.Style() { Color= Device.OnPlatform(iOS: Color.Gray, Android: Color.Gray, WinPhone: Color.White) }, GroupPath = "Continent", HeaderHeight = 20, GroupGap = 5, ShowHeader = true };
			level.GroupBackground = Device.OnPlatform(iOS: Color.White, Android: Color.White, WinPhone: Color.Black);
			tree.Levels.Add (level);
			tree.DataSource = new PopulationViewModel ().PopulationDetails;
            if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                tree.LegendSettings = new LegendSettings() { Size = new Size(0, 0),ShowLegend = false };
            }
            else
            {

                tree.LegendSettings = new LegendSettings()
                {
                    LabelStyle = new Syncfusion.SfTreeMap.XForms.Style()
                    {
                        Font = Device.OnPlatform(iOS: Font.SystemFontOfSize(12), Android: Font.SystemFontOfSize(14), WinPhone: Font.SystemFontOfSize(12)),
                        Color = Color.Gray
                    },
                    IconSize = iconSize,
                    ShowLegend = true,
                    Size = legendSize
                };
                if (Device.Idiom == TargetIdiom.Tablet)
                {
                    tree.LegendSettings.Size = new Size(500, 30);
                }

            }
			uniMapping = new UniColorMapping (){ Color = Color.FromHex ("#D21243") };

			paletteMapping = new PaletteColorMapping ();
			paletteMapping.Colors.Add (Color.FromHex ("#BD8EC2"));
			paletteMapping.Colors.Add (Color.FromHex ("#FFD34E"));
			paletteMapping.Colors.Add (Color.FromHex ("#55B949"));
			paletteMapping.Colors.Add (Color.FromHex ("#00B2DA"));
			paletteMapping.Colors.Add (Color.FromHex ("#744A94"));
			paletteMapping.Colors.Add (Color.FromHex ("#A1A616"));
			paletteMapping.Colors.Add (Color.FromHex ("#0753A1"));
			DrawOptionsPage ();

			this.PropertyView = GetOptionPage ();
            this.ContentView = tree;
            this.ContentView.BackgroundColor = Color.White;
		}

		private void DrawOptionsPage()
		{
			toggleButton = new Xamarin.Forms.Slider ();
			toggleButton.Value = 4;
			toggleButton2 = new Xamarin.Forms.Slider ();
			toggleButton2.Value = 2;
			toggleButton.Maximum = 20;
			toggleButton2.Maximum = 20;
			toggleButton2.ValueChanged+= (object sender, ValueChangedEventArgs e) => 
			{
				//groupGap = e.NewValue;
			};
			toggleButton.ValueChanged+= (object sender, ValueChangedEventArgs e) => {
				groupPadding = e.NewValue;
				(tree.Levels [0] as TreeMapFlatLevel).GroupPadding = groupPadding;
				tree.Refresh ();
			};
			picker1 = new PickerExt();
			picker2 = new PickerExt();
			picker1.Items.Add("Squarified");
			picker1.Items.Add("Slice And Dice Horizontal");
			picker1.Items.Add("Slice And Dice Vertical");
			picker1.Items.Add("Slice And Dice Auto");
			picker1.HeightRequest = 40;
			picker1.SelectedIndex = 0;
			picker1.SelectedIndexChanged += picker1_SelectedIndexChanged;


			picker2.Items.Add("RangeColorMapping");
			picker2.Items.Add("DesaturationColorMapping");
			picker2.Items.Add("UniColorMapping");
			picker2.Items.Add("PaletteColorMapping");
			picker2.HeightRequest = 40;
			picker2.SelectedIndex = 0;

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
				Text = "Layout Type",
				HeightRequest = 20,
				YAlign = TextAlignment.End,
				TextColor = Color.Black
			};
			label4 = new Label()
			{
				Text = "Color Mapping",
				HeightRequest = 20,
				YAlign = TextAlignment.End,
				TextColor = Color.Black
			};
			label5 = new Label()
			{
				Text = "Group Padding",
				HeightRequest = 30,
				YAlign = TextAlignment.Center,
				TextColor = Color.Black,
			};
			label9 = new Label()
			{
				Text = "Group Gap",
				HeightRequest = 20,
				YAlign = TextAlignment.Center,
				TextColor = Color.Black
			};


			if (Device.OS == TargetPlatform.Android)
			{
				picker1.BackgroundColor = Color.FromRgb(239, 239, 239);
				picker2.BackgroundColor = Color.FromRgb(239, 239, 239);
				label3.FontSize = 20;
				label4.FontSize = 20;
				label5.FontSize = 20;
			}
			//label10.WidthRequest = tree.Width;
			//label11.WidthRequest = tree.Width;
			label5.WidthRequest = label9.Width;
			if (Device.OS == TargetPlatform.WinPhone)
			{

				label5.WidthRequest = 150;
				label9.WidthRequest = 150;

				picker1.HeightRequest = 60;
				picker2.HeightRequest = 60;

				label3.TextColor = Color.White;
				label4.TextColor = Color.White;
				label5.TextColor = Color.White;
				this.BackgroundColor = Color.Black;


				FileImageSource images = new FileImageSource();
				images.File = "options.png";
				baritem.Icon = images;
				label3.Text = "  " + "Layout Type";
				label3.HeightRequest = 22;
				label4.Text = "  " + "Color Mapping";
				label4.HeightRequest = 22;
				label5.Text = "  " + "Group Padding";
				label5.HeightRequest = 22;

				label9.TextColor = Color.White;

			}
            if (Device.OS == TargetPlatform.Windows && Device.Idiom != TargetIdiom.Tablet)
		    {
                picker1.BackgroundColor = Color.Gray;
                picker2.BackgroundColor = Color.Gray;
		    }
		}

		private StackLayout GetOptionPage()
		{

			//	toggleButton.WidthRequest = picker1.Width - label5.Width;
			//	toggleButton2.WidthRequest = picker1.Width - label9.Width;
			toggleButton.HorizontalOptions = LayoutOptions.Fill;
			toggleButton2.HorizontalOptions = LayoutOptions.Fill;
			var layoutpage = new StackLayout
			{
				Spacing = 10,
				Orientation = StackOrientation.Vertical,
				//Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
				Children = { label5, toggleButton }
			};
//			var togglepage = new StackLayout
//			{
//				Spacing = 10,
//				Orientation = StackOrientation.Vertical,
//				//Padding = Device.OnPlatform(iOS: 10, Android : 10, WinPhone : 50),
//				Children = { label9, toggleButton2 }
//			};
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
				Children = { label4 ,picker2}
			};
			var page3 = new StackLayout
			{
				Spacing = 40,
				Orientation = StackOrientation.Vertical,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
				Children = { page1, page2 }
			};
		    var page = new StackLayout();
		    if (Device.Idiom != TargetIdiom.Tablet)
		    {
		        page = new StackLayout
		        {
		            Spacing = 40,
		            Orientation = StackOrientation.Vertical,
		            Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
		            Children = {page3, layoutpage}
		        };
		    }
		    else
		    {
                page = new StackLayout
                {
                    Spacing = 40,
                    Orientation = StackOrientation.Vertical,
                    Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
                    Children = { page3 }
                };
		    }

		    var page4 = new StackLayout
			{
				Spacing = 40,
				Orientation = StackOrientation.Vertical,
				//Padding = Device.OnPlatform(iOS: 10, Android: 10, WinPhone: 10),
				Children = { label6, page }
			};

			if (Device.OS == TargetPlatform.WinPhone)
			{

                picker1.BackgroundColor = Color.Black;
                picker2.BackgroundColor = Color.Black;
				page.Spacing = 25;
				FileImageSource images = new FileImageSource();
				images.File = "Check.png";
				baritem.Icon = images;
				return page4;
			}
            if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                page.BackgroundColor = Color.Black;
                this.BackgroundColor = Color.Black;
                picker1.BackgroundColor = Color.Black;
                picker2.BackgroundColor = Color.Black;
                label3.TextColor = label4.TextColor = label5.TextColor = Color.White;
                label3.FontSize = label4.FontSize = label5.FontSize = 17;
                label3.HeightRequest = label4.HeightRequest = label5.HeightRequest = 25;
            }
			return page;
		}


		void picker1_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (picker1.SelectedIndex)
			{
			case 0:
				{
					layoutType = LayoutTypes.Squarified;

					break;
				}
			case 1:
				{
					layoutType = LayoutTypes.SliceAndDiceHorizontal;
					break;
				}
			case 2:
				{
					layoutType = LayoutTypes.SliceAndDiceVertical;
					break;
				}
			case 3:
				{
					layoutType = LayoutTypes.SliceAndDiceAuto;
					break;
				}

			}
			tree.LayoutType = layoutType;
			tree.Refresh ();
		}
		void picker2_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (picker2.SelectedIndex)
			{
			case 0:
				{
					treeMapColorMapping = rangeMapping;
					break;
				}
			case 1:
				{
					treeMapColorMapping = desaturationMapping;
					break;
				}
			case 2:
				{
					treeMapColorMapping = uniMapping;
					break;
				}
			case 3:
				{
					treeMapColorMapping = paletteMapping;
					break;
				}
			}
			if (!(treeMapColorMapping is RangeColorMapping)) {
				tree.LegendSettings.ShowLegend = false;
			} else {
				tree.LegendSettings.ShowLegend = true;;
			}
			tree.LeafItemColorMapping = treeMapColorMapping;
			tree.Refresh ();
		}
		protected override bool OnBackButtonPressed()
		{
			Content = tree;
			return base.OnBackButtonPressed();
		}

	}


	public class PopulationViewModel
	{
		public PopulationViewModel()
		{
			this.PopulationDetails = new ObservableCollection<PopulationDetail>();
			PopulationDetails.Add(new PopulationDetail() { Continent = "Asia", Country = "Indonesia", Growth = 3, Population = 237641326 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "Asia", Country = "Russia", Growth = 2, Population = 152518015 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "Asia", Country = "Malaysia", Growth = 1, Population = 29672000 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "North America", Country = "United States", Growth = 4, Population = 315645000 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "North America", Country = "Mexico", Growth = 2, Population = 112336538 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "North America", Country = "Canada", Growth = 1, Population = 35056064 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "South America", Country = "Colombia", Growth = 1, Population = 47000000 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "South America", Country = "Brazil", Growth = 3, Population = 193946886 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "Africa", Country = "Nigeria", Growth = 2, Population = 170901000 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "Africa", Country = "Egypt", Growth = 1, Population = 83661000 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "Europe", Country = "Germany", Growth = 1, Population = 81993000 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "Europe", Country = "France", Growth = 1, Population = 65605000 });
			PopulationDetails.Add(new PopulationDetail() { Continent = "Europe", Country = "UK", Growth = 1, Population = 63181775 });
		}

		public ObservableCollection<PopulationDetail> PopulationDetails
		{
			get;
			set;
		}

		public class PopulationDetail
		{
			public string Continent { get; set; }
			public string Country { get; set; }
			public double Growth { get; set; }
			public double Population { get; set; }
		}
	}
}

