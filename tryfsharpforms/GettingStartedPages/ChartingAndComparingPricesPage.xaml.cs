using System;
using System.Collections.Generic;
using tryfsharplib;
using Syncfusion.SfBusyIndicator.XForms;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class ChartingAndComparingPricesPage : ContentPage
	{
		Entry stock1 = new Entry{ Placeholder = "MSFT", Text = "MSFT" };
		Entry stock2 = new Entry{ Placeholder = "TSLA", Text = "AAPL" };
		Button getDataButton = new Button{ Text = "Get Data!", TextColor = MyColors.Clouds };

		Entry avgStock = new Entry { Placeholder = "FB", Text = "FB" };
		Button avgstockButton = new Button{ Text = "Compare!", TextColor = MyColors.Clouds };
		SfBusyIndicator busyIndicator = new SfBusyIndicator ();

		public ChartingAndComparingPricesPage ()
		{
			InitializeComponent ();

			BackgroundColor = MyColors.MidnightBlue;

			busyIndicator.ViewBoxWidth = 150;
			busyIndicator.ViewBoxHeight = 150;
			busyIndicator.HeightRequest = 50;
			busyIndicator.WidthRequest = 50;
			busyIndicator.BackgroundColor = Color.White;
			busyIndicator.AnimationType = AnimationTypes.DoubleCircle;
			busyIndicator.TextColor = Color.FromHex ("#958C7B");
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
					getDataButton,
					new Label { 
						Text = "Compare a stock vs its Average",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
						TextColor = MyColors.Clouds
					},
					avgStock,
					avgstockButton,
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
						Navigation.PushAsync (new CompareTwoStocksChartPage (stockList1, stockList2));
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
						Navigation.PushAsync (new ComparePriceVsAvgPage (stock, average));
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;
					});
			});
		}
	}
}

