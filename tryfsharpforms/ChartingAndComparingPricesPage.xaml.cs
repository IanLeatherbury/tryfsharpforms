using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class ChartingAndComparingPricesPage : ContentPage
	{
		Entry stock1 = new Entry{ Placeholder = "MSFT", Text = "MSFT" };
		Entry stock2 = new Entry{ Placeholder = "TSLA", Text = "AAPL" };
		Button getDataButton = new Button{ Text = "Get Data!" };

		public ChartingAndComparingPricesPage ()
		{
			InitializeComponent ();

			Content = new StackLayout { 
				Padding = new Thickness(15),
				Children = {
					new Label { 
						Text = "Enter in 2 stock tickers to compare them",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold,
					},
					stock1,
					stock2,
					getDataButton
				}
			};

			getDataButton.Clicked += OnButtonClicked;
		}

		void OnButtonClicked (object sender, EventArgs e)
		{
			var stockLookup1 = new ChartingAndComparingPrices.ComparingStocks (stock1.Text);
			var stockList1 = stockLookup1.Stocks;

			var stockLookup2 = new ChartingAndComparingPrices.ComparingStocks (stock2.Text);
			var stockList2 = stockLookup2.Stocks;

			Navigation.PushAsync (new ChartPage (stockList1, stockList2));


		}
	}
}

