using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;

using Syncfusion.SfBusyIndicator.XForms;

using tryfsharplib;

namespace tryfsharpforms
{
	public partial class SimulatingAndAnalyzingAssetPricesPage : BasePage
	{
		ObservableCollection<Sections> sections = new ObservableCollection<Sections> ();

		public SimulatingAndAnalyzingAssetPricesPage ()
		{
			Title = "Simulate Stock Prices"; 

			sections.Add (new Sections{ SectionName = "Geometric Brownian Motion" });
			sections.Add (new Sections{ SectionName = "MSFT Actual vs. GBM" });
			sections.Add (new Sections{ SectionName = "Msft vs. Improved GBM" });

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
				stackLayout.Orientation = StackOrientation.Horizontal;
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
			case "Geometric Brownian Motion":
				SimulatingAndAnalyzingAssetPrices.RandomWalk rw = new SimulatingAndAnalyzingAssetPrices.RandomWalk (10.0);
				Navigation.PushAsync (new BrownianMotionChartPage (rw.BrownianSeq, rw.BrownianSeq1, rw.BrownianSeq2));
				break;
			case "MSFT Actual vs. GBM":
				var item = e.SelectedItem;
				Navigation.PushAsync (new CompareMsftHistoricalVolDriftChartPage ());
				break;
			case "Msft vs. Improved GBM":
				//			this is not properly implemented. needs non optimized drift/vol  
				//			SimulatingAndAnalyzingAssetPrices.RandomWalk rw = new SimulatingAndAnalyzingAssetPrices.RandomWalk (10.0);
							Navigation.PushAsync (new CompareMsftGbmChartPage ());
				break;
			}
			;

			((ListView)sender).SelectedItem = null; 
		}
	}
}	