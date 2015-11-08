using System;
using tryfsharplib;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public class AnalyzingStockPricesPage : ContentPage
	{
		tryfsharplib.AnalyzingStockPrices.StandardDeviationWithoutUnits pricesNoUnits = new tryfsharplib.AnalyzingStockPrices.StandardDeviationWithoutUnits();
		tryfsharplib.AnalyzingStockPrices.StandardDeviationWithUnits pricesUnits = new tryfsharplib.AnalyzingStockPrices.StandardDeviationWithUnits();
		tryfsharplib.AnalyzingStockPrices.StandardDeviationMath stats = new tryfsharplib.AnalyzingStockPrices.StandardDeviationMath();

		public AnalyzingStockPricesPage ()
		{
			var pricesUnitsRounded = System.Math.Round (pricesUnits.StandardDev, 2);
			Content = new StackLayout { 
				Children = {
					new Label { 
						Text = "Standard Deviation of MSFT over the last 30 days",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold
					},
					new Label{
						Text = pricesNoUnits.StandardDev.ToString(),
						HorizontalOptions = LayoutOptions.CenterAndExpand
					},
					new Label { 
						Text = "Typed Standard Deviation of MSFT over the last 30 days",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold
					},
					new Label{
						Text = "$" + pricesUnitsRounded.ToString(),
						HorizontalOptions = LayoutOptions.CenterAndExpand
					},
					new Label { 
						Text = "Basic Statistics using Math.Net",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold
					},
					new Label{
						Text = "Mean: " + stats.Mean,
						HorizontalOptions = LayoutOptions.Start
					},
					new Label{
						Text = "Max: " + stats.Max,
						HorizontalOptions = LayoutOptions.Start
					},
					new Label{
						Text = "Min: " + stats.Min,
						HorizontalOptions = LayoutOptions.Start
					},
					new Label{
						Text = "StdDev: " + stats.StandardDev,
						HorizontalOptions = LayoutOptions.Start
					},
				}
			};
		}
	}
}


