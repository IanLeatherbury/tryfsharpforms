using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class AnalyzingMarketInteractionsPage : ContentPage
	{
		Button plotLogLikelihoodButton = new Button { Text = "Plot Log Likeliehood" };

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
					plotLogLikelihoodButton
				}
			};

			plotLogLikelihoodButton.Clicked += PlotLogLikelihoodButton_Clicked;
		}

		void PlotLogLikelihoodButton_Clicked (object sender, EventArgs e)
		{
			AnalyzingStockMarkets.GetStockMarketIndicators logliks = new AnalyzingStockMarkets.GetStockMarketIndicators ();

			var data = logliks.LogLikelihood;

			Navigation.PushAsync (new AnalyzingMarketInteractionsChartPage (data));
		}
	}
}

