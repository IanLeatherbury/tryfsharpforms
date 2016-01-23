using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public class HomePage : ContentPage
	{
		ObservableCollection<Sections> sections = new ObservableCollection<Sections> ();

		public HomePage ()
		{
			Title = "Try F#!"; 

			sections.Add (new Sections{ SectionName = "Basic Financial Calculations" });
			sections.Add (new Sections{ SectionName = "Units of Measure" });
			sections.Add (new Sections{ SectionName = "Exploring Historical Stock Prices" });
			sections.Add (new Sections{ SectionName = "Analyzing Stock Prices" });
			sections.Add (new Sections{ SectionName = "Charting and Comparing Prices" });
			sections.Add (new Sections{ SectionName = "Understanding European Options" });
			sections.Add (new Sections{ SectionName = "Simulating and Analyzing Asset Prices" });
			sections.Add (new Sections{ SectionName = "Pricing European Options" });
			sections.Add (new Sections{ SectionName = "Analyzing Stock Markets" });
			sections.Add (new Sections{ SectionName = "Analyzing Market Interactions" });

			var listView = new ListView ();
			listView.ItemTemplate = new DataTemplate (typeof(CustomCell));
			listView.BackgroundColor = MyColors.WetAsphalt;
			listView.ItemsSource = sections;
			listView.ItemSelected += OnSelection;

			Content = listView;

		}

		public class CustomCell : ViewCell
		{
			public CustomCell ()
			{
				var label = new Label ();
				label.VerticalOptions = LayoutOptions.CenterAndExpand;
				var stackLayout = new StackLayout ();
				stackLayout.Padding = new Thickness (15);

				label.SetBinding (Label.TextProperty, "SectionName");
				label.TextColor = Color.White;

				stackLayout.Children.Add (label);

				View = stackLayout;
			}
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}

			Sections s = (Sections)e.SelectedItem;

			switch (s.SectionName) {
			case "Basic Financial Calculations":
				Navigation.PushAsync (new BasicCalcPage ());
				break;
			case "Units of Measure":
				Navigation.PushAsync (new UnitsOfMeasurePage ());
				break;
			case "Exploring Historical Stock Prices":
				Navigation.PushAsync (new ExploringHistoricalStockPricesPage ());
				break;
			case "Charting and Comparing Prices":
				Navigation.PushAsync (new ChartingAndComparingPricesPage ());
				break;
			case "Analyzing Stock Prices":
				Navigation.PushAsync (new AnalyzingStockPricesPage ());
				break;
			case "Understanding European Options":
				Navigation.PushAsync (new UnderstandingEuropeanOptionsPage ());
				break;
			case "Simulating and Analyzing Asset Prices":
				Navigation.PushAsync (new SimulatingAndAnalyzingAssetPricesPage ());
				break;
			case "Pricing European Options":
				Navigation.PushAsync (new PricingEuropeanOptionsPage ());
				break;
			case "Analyzing Stock Markets":
				Navigation.PushAsync (new AnalyzingStockMarketsPage ());
				break;
			case "Analyzing Market Interactions":
				Navigation.PushAsync (new AnalyzingMarketInteractionsPage ());
				break;
			};

			((ListView)sender).SelectedItem = null; 
		}
	}
}