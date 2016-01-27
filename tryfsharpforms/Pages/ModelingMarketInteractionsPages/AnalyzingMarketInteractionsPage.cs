using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class AnalyzingMarketInteractionsPage : BasePage
	{
		GetDataButton plotLogLikelihoodButton = new GetDataButton(Borders.Thin,1) { Text = "Plot Log Likeliehood" };
		GetDataButton plotOberservedDataVersusFittedButton = new GetDataButton(Borders.Thin,1) { Text = "Plot oberserved vs. fitted" };
		GetDataButton plotKalmanRelationshipButton = new GetDataButton(Borders.Thin,1){ Text = "Plot Kalman Relationship between tickers" };

		AnalyzingStockMarkets.GetStockMarketIndicators indicators = new AnalyzingStockMarkets.GetStockMarketIndicators ();

		public AnalyzingMarketInteractionsPage ()
		{
			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Analyze Market Interactions",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold,
						TextColor = MyColors.Clouds
					},
					new BoxView(){Opacity = 0, HeightRequest=15},
					plotLogLikelihoodButton,
					new BoxView(){Opacity = 0, HeightRequest=15},
					plotOberservedDataVersusFittedButton,
					new BoxView(){Opacity = 0, HeightRequest=15},
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

