using System;
using tryfsharplib;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public class AnalyzingStockPrices : ContentPage
	{
		tryfsharplib.AnalyzingStockPrices.StandardDeviation prices = new tryfsharplib.AnalyzingStockPrices.StandardDeviation();

		public AnalyzingStockPrices ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { 
						Text = "Standard Deviation of MSFT over the last 30 days",
						HorizontalOptions = LayoutOptions.CenterAndExpand
					},
					new Label{
						Text = prices.StandardDev.ToString(),
						HorizontalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}


