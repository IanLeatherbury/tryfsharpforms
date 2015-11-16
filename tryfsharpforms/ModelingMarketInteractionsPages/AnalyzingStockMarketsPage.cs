using System;
using tryfsharplib;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace tryfsharpforms
{
	public class AnalyzingStockMarketsPage : ContentPage
	{
		Button obtainListOfIndicatorsButton = new Button{Text = "Obtain Indicators" };

		public AnalyzingStockMarketsPage()
		{
			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Obtain list of global market indicators",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold
					},
					obtainListOfIndicatorsButton
				}
			};

			obtainListOfIndicatorsButton.Clicked += ObtainListOfIndicatorsButton_Clicked;
		}

		void ObtainListOfIndicatorsButton_Clicked (object sender, EventArgs e)
		{
			var indicators = new AnalyzingStockMarkets.GetStockMarketIndicators ();

			var cd = indicators.ChartData;

			Navigation.PushAsync (new AnalyzingStockMarketsChartPage (cd));
		}
	}
}


