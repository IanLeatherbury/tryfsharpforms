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
			
		void PlotOberservedDataVersusFittedButton_Clicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new FittedVersusObservedChartPage ());
		}

		void PlotLogLikelihoodButton_Clicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new AnalyzingMarketInteractionsChartPage ());
		}

		void PlotKalmanRelationshipButton_Clicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new KalmanRelationshipChartPage ());
		}
	}
}

