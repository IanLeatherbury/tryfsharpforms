using System;

using Xamarin.Forms;
using tryfsharplib;

namespace tryfsharpforms
{
	public class StockStatsPage : ContentPage
	{

		public StockStatsPage (string stockTicker)
		{
			var stock = new ChartingAndComparingPrices.ComparingStocks (stockTicker, new DateTime (2014, 1, 1), DateTime.Now);

			Content = new StackLayout { 
				Padding = new Thickness(15),
				Children = {
					new Label { Text = stockTicker.ToUpper(), FontSize = 30, FontAttributes = FontAttributes.Bold, HorizontalOptions = LayoutOptions.CenterAndExpand, },
					new Label { 
						Text = "Standard Deviation over the last 30 days",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold
					},
					new Label{
						Text = System.Math.Round(stock.StandardDev, 2).ToString(),
						HorizontalOptions = LayoutOptions.CenterAndExpand
					},
					new Label { 
						Text = "Typed Standard Deviation over the last 30 days",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold
					},
					new Label{
						Text = "$" +  System.Math.Round(stock.StandardDev,2).ToString(),
						HorizontalOptions = LayoutOptions.CenterAndExpand
					},
					new Label { 
						Text = "Basic Statistics using Math.Net",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold
					},
					new Label{
						Text = "Mean: " +  System.Math.Round(stock.Mean, 2).ToString(),
						HorizontalOptions = LayoutOptions.Start
					},
					new Label{
						Text = "Max: " + System.Math.Round(stock.Max, 2),
						HorizontalOptions = LayoutOptions.Start
					},
					new Label{
						Text = "Min: " + System.Math.Round(stock.Min,2),
						HorizontalOptions = LayoutOptions.Start
					},
					new Label{
						Text = "StdDev: " +  System.Math.Round(stock.StandardDev, 2).ToString(),
						HorizontalOptions = LayoutOptions.Start
					},
				}
			};
		}
	}
}


