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
		StackLayout sl = new StackLayout ();

		ActivityIndicator ai = new ActivityIndicator ();

		public ObservableCollection<DoubleDataPoint> RandomWalkCollection { get; set; }

		public SimulatingAndAnalyzingAssetPricesPage ()
		{
			InitializeComponent ();

			ai.IsVisible = true;
			ai.IsEnabled = true;
			ai.IsRunning = false;
			ai.HorizontalOptions = LayoutOptions.CenterAndExpand;
			ai.Color = Color.Black;

			Content = sl;
			sl.Padding = new Thickness (15);
			sl.Children.Add (new Label { 
				Text = "Generate Geometric Brownian Motion",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontAttributes = FontAttributes.Bold, 
			});
			sl.Children.Add (generateButton);
			sl.Children.Add (ai);
			sl.Children.Add (
				new Label { 
					Text = "Compare Msft against GBM",
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					FontAttributes = FontAttributes.Bold, 
				});
			sl.Children.Add (compareMsftButton);
			sl.Children.Add (
				new Label { 
					Text = "Use historical data for better drift/volatility",
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					FontAttributes = FontAttributes.Bold, 
				});
			sl.Children.Add (compareMsftHistoricalGbmButton);

			generateButton.Clicked += GenerateButton_Clicked;
			compareMsftButton.Clicked += CompareMsftButton_Clicked;
			compareMsftHistoricalGbmButton.Clicked += CompareMsftHistoricalGbmButton_Clicked;
		}

		void GenerateButton_Clicked (object sender, EventArgs e)
		{
			SimulatingAndAnalyzingAssetPrices.RandomWalk rw = new SimulatingAndAnalyzingAssetPrices.RandomWalk (10.0);

			Navigation.PushAsync (new BrownianMotionChartPage (rw.BrownianSeq, rw.BrownianSeq1, rw.BrownianSeq2));
		}

		void CompareMsftButton_Clicked (object sender, EventArgs e)
		{
			ai.IsRunning = true;

//			SimulatingAndAnalyzingAssetPrices.RandomWalk rw = new SimulatingAndAnalyzingAssetPrices.RandomWalk (10.0);
			SimulatingAndAnalyzingAssetPrices.GetMsftCsvData msftData = new SimulatingAndAnalyzingAssetPrices.GetMsftCsvData ();

			ai.IsRunning = false; 

			Navigation.PushAsync (new CompareMsftGbmChartPage (msftData.MsftActual, msftData.MsftSimulated));
		}

		void CompareMsftHistoricalGbmButton_Clicked (object sender, EventArgs e)
		{
			ai.IsRunning = true;
			ai.IsVisible = true;

			SimulatingAndAnalyzingAssetPrices.GetMsftCsvData rw = new SimulatingAndAnalyzingAssetPrices.GetMsftCsvData ();
			var actual = rw.MsftActual;
			var sim = rw.MsftSimulated;

			ai.IsRunning = false;
			ai.IsVisible = false;

			Navigation.PushAsync (new CompareMsftHistoricalVolDriftChartPage (actual, sim));
		}
	}
}	