using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class AnalyzingMarketInteractionsPage : ContentPage
	{
		Button plotLogLikelihoodButton = new Button { Text = "Plot Log Likeliehood" };
		Button plotOberservedDataVersusFittedButton = new Button { Text = "Plot oberserved vs. fitted" };
		Button plotKalmanRelationshipButton = new Button{ Text = "Plot Kalman Relationship between tickers" };
		AnalyzingStockMarkets.GetStockMarketIndicators indicators = new AnalyzingStockMarkets.GetStockMarketIndicators ();

		public AnalyzingMarketInteractionsPage ()
		{
			InitializeComponent ();
			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Analyze Market Interactions",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold
					},
					plotLogLikelihoodButton,
					plotOberservedDataVersusFittedButton,
					plotKalmanRelationshipButton
				}
			};

			plotLogLikelihoodButton.Clicked += PlotLogLikelihoodButton_Clicked;
			plotOberservedDataVersusFittedButton.Clicked  += PlotOberservedDataVersusFittedButton_Clicked;
			plotKalmanRelationshipButton.Clicked += PlotKalmanRelationshipButton_Clicked;
		}

		void PlotKalmanRelationshipButton_Clicked (object sender, EventArgs e)
		{
			var indexPoints = indicators.IndexPoints;
			var lines = indicators.Lines;

			Navigation.PushAsync (new KalmanRelationshipChartPage(indexPoints, lines));
		}

		void PlotOberservedDataVersusFittedButton_Clicked (object sender, EventArgs e)
		{
			var original = indicators.OriginalObservedData;
			var fitted = indicators.FittedData;

			Navigation.PushAsync (new FittedVersusObservedChartPage (original, fitted));
		}

		void PlotLogLikelihoodButton_Clicked (object sender, EventArgs e)
		{
			var logliks = indicators.LogLikelihood;

			Navigation.PushAsync (new AnalyzingMarketInteractionsChartPage (logliks));
		}
			
	}
}

