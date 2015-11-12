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

		Entry avgStock = new Entry { Placeholder = "FB", Text = "FB" };
		Button avgstockButton = new Button{ Text = "Compare!" };

		public ChartingAndComparingPricesPage ()
		{
			InitializeComponent ();

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Enter in 2 stock tickers to compare them",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold,
					},
					stock1,
					stock2,
					getDataButton,
					new Label { 
						Text = "Compare a stock vs its Average",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold,
					},
					avgStock,
					avgstockButton
				}
			};

			getDataButton.Clicked += OnGetDataButtonClicked;
			avgstockButton.Clicked += OnAvgStockButtonClicked;
		}

		void OnGetDataButtonClicked (object sender, EventArgs e)
		{
			var stockLookup1 = new ChartingAndComparingPrices.ComparingStocks (stock1.Text, new DateTime(2014,1,1), DateTime.Now);
			var stockList1 = stockLookup1.Stocks;

			var stockLookup2 = new ChartingAndComparingPrices.ComparingStocks (stock2.Text, new DateTime(2014,1,1), DateTime.Now);
			var stockList2 = stockLookup2.Stocks;

			Navigation.PushAsync (new CompareTwoStocksChartPage (stockList1, stockList2));
		}

		void OnAvgStockButtonClicked (object sender, EventArgs e)
		{
			var stockLookup = new ChartingAndComparingPrices.ComparingStocks (avgStock.Text, new DateTime(2014,1,1), DateTime.Now);
			var stock = stockLookup.Stocks;
			var average = stockLookup.Average;

			Navigation.PushAsync (new ComparePriceVsAvgPage(stock, average));
		}
	}
}

