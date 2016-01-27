using System;
using tryfsharplib;

using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace tryfsharpforms
{
	public class AnalyzingStockMarketsPage : BasePage
	{
		GetDataButton obtainListOfIndicatorsButton = new GetDataButton(Borders.Thin,1){ Text = "Obtain Indicators" };

		public AnalyzingStockMarketsPage ()
		{
			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Obtain list of global market indicators",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold,
						TextColor = MyColors.Clouds
					},
					obtainListOfIndicatorsButton
				}
			};

			obtainListOfIndicatorsButton.Clicked += ObtainListOfIndicatorsButton_Clicked;
		}

		void ObtainListOfIndicatorsButton_Clicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new AnalyzingStockMarketsChartPage ());
		}
	}
}


