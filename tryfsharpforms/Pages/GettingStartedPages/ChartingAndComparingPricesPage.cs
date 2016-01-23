using System;
using System.Collections.Generic;
using tryfsharplib;
using Syncfusion.SfBusyIndicator.XForms;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class ChartingAndComparingPricesPage : BasePage
	{
		DataEntry stock1 = new DataEntry{ Placeholder = "MSFT", Text = "MSFT" };
		DataEntry stock2 = new DataEntry{ Placeholder = "TSLA", Text = "AAPL" };
		GetDataButton getDataButton = new GetDataButton (Borders.Thin, 1){ Text = "Get Data!", TextColor = MyColors.Clouds };

		DataEntry avgStock = new DataEntry { Placeholder = "FB", Text = "FB" };
		GetDataButton avgstockButton = new GetDataButton (Borders.Thin, 1){ Text = "Compare!", TextColor = MyColors.Clouds };
		SfBusyIndicator busyIndicator = new SfBusyIndicator ();

		public ChartingAndComparingPricesPage ()
		{
			busyIndicator.ViewBoxWidth = 150;
			busyIndicator.ViewBoxHeight = 150;
			busyIndicator.HeightRequest = 50;
			busyIndicator.WidthRequest = 50;
			busyIndicator.BackgroundColor = MyColors.MidnightBlue;
			busyIndicator.AnimationType = AnimationTypes.DoubleCircle;
			busyIndicator.TextColor = MyColors.Turqoise;
			busyIndicator.IsVisible = false;
			busyIndicator.IsBusy = false;

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Enter in 2 stock tickers to compare them",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
						TextColor = MyColors.Clouds
					},
					stock1,
					stock2,
					new BoxView{ HeightRequest = 10, Opacity = 0 },
					getDataButton,
					new BoxView{ HeightRequest = 20, Opacity = 0 },
					new Label { 
						Text = "Compare a stock vs its Average",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
						TextColor = MyColors.Clouds
					},
					avgStock,
					new BoxView{ HeightRequest = 10, Opacity = 0 },
					avgstockButton,
					new BoxView{ HeightRequest = 10, Opacity = 0 },
					busyIndicator
				}
			};

			getDataButton.Clicked += OnGetDataButtonClicked;
			avgstockButton.Clicked += OnAvgStockButtonClicked;
		}

		void OnGetDataButtonClicked (object sender, EventArgs e)
		{
			busyIndicator.IsBusy = true;
			busyIndicator.IsVisible = true;

			Task.Run (() => {
				var stockLookup1 = new ChartingAndComparingPrices.ComparingStocks (stock1.Text, new DateTime (2014, 1, 1), DateTime.Now);
				var stockList1 = stockLookup1.Stocks;

				var stockLookup2 = new ChartingAndComparingPrices.ComparingStocks (stock2.Text, new DateTime (2014, 1, 1), DateTime.Now);
				var stockList2 = stockLookup2.Stocks;	

				Device.BeginInvokeOnMainThread (
					() => {
						Navigation.PushAsync (new CompareTwoStocksChartPage (stockList1, stockList2, stock1.Text, stock2.Text));
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;
					});
			});
		}

		void OnAvgStockButtonClicked (object sender, EventArgs e)
		{
			busyIndicator.IsBusy = true;
			busyIndicator.IsVisible = true;

			Task.Run (() => {
				var stockLookup = new ChartingAndComparingPrices.ComparingStocks (avgStock.Text, new DateTime (2014, 1, 1), DateTime.Now);
				var stock = stockLookup.Stocks;
				var average = stockLookup.Average;

				Device.BeginInvokeOnMainThread (
					() => {
						Navigation.PushAsync (new ComparePriceVsAvgPage (stock, average, avgStock.Text));
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;
					});
			});
		}
	}
}

