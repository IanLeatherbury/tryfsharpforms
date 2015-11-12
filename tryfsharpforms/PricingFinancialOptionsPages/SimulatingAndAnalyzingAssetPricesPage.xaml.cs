using System;
using System.Collections.Generic;
using tryfsharplib;
using System.Linq;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace tryfsharpforms
{
	public partial class SimulatingAndAnalyzingAssetPricesPage : ContentPage
	{
		Button generateButton = new Button{ Text = "Generate!" };
		Button compareMsftButton = new Button { Text = "Compare" };
		Button compareMsftHistoricalGbmButton = new Button { Text = "Compare" };

		public ObservableCollection<DoubleDataPoint> RandomWalkCollection { get; set; }

		public SimulatingAndAnalyzingAssetPricesPage ()
		{
			InitializeComponent ();

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Generate Geometric Brownian Motion",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
					},
					generateButton,
					new Label { 
						Text = "Compare Msft against GBM",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
					},
					compareMsftButton,
					new Label { 
						Text = "Use historical data for better drift/volatility",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
					},
					compareMsftHistoricalGbmButton
				}
			};

			generateButton.Clicked += GenerateButton_Clicked;
			compareMsftButton.Clicked += CompareMsftButton_Clicked;
			compareMsftHistoricalGbmButton.Clicked += CompareMsftHistoricalGbmButton_Clicked;
		}

		void CompareMsftHistoricalGbmButton_Clicked (object sender, EventArgs e)
		{
			SimulatingAndAnalyzingAssetPrices.RandomWalk rw = new SimulatingAndAnalyzingAssetPrices.RandomWalk (10.0);

			Navigation.PushAsync (new CompareMsftHistoricalVolDriftChartPage (rw.MsftActual, rw.MsftHistoricalSimulated));
		}

		void CompareMsftButton_Clicked (object sender, EventArgs e)
		{
			SimulatingAndAnalyzingAssetPrices.RandomWalk rw = new SimulatingAndAnalyzingAssetPrices.RandomWalk (10.0);
			Navigation.PushAsync (new CompareMsftGbmChartPage (rw.MsftActual, rw.MsftSimulated));
		}

		void GenerateButton_Clicked (object sender, EventArgs e)
		{
			SimulatingAndAnalyzingAssetPrices.RandomWalk rw = new SimulatingAndAnalyzingAssetPrices.RandomWalk (10.0);

			Navigation.PushAsync (new BrownianMotionChartPage (rw.BrownianSeq, rw.BrownianSeq1, rw.BrownianSeq2));
		}
	}
}

