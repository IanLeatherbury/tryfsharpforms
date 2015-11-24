using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;
using Syncfusion.SfBusyIndicator.XForms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class ExploringHistoricalStockPricesPage : ContentPage
	{
		Entry tickerEntry = new Entry{Placeholder = "MSFT", Text = "MSFT"};
		Entry startDateEntry = new Entry{Placeholder = "1/1/2014", Text = "1/1/2014"};
		Button getDataButton = new Button{Text = "Get Data!"};
		SfBusyIndicator busyIndicator = new SfBusyIndicator ();

		public ExploringHistoricalStockPricesPage ()
		{
			InitializeComponent ();

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
						Text = "Chart a stock price up until now",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold,
					},
					new Label { 
						Text = "Enter a stock ticker",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
					},
					tickerEntry,
					new Label { 
						Text = "Enter a start date",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
					},
					startDateEntry,
					getDataButton,
					busyIndicator
				}
			};

			getDataButton.Clicked += GetDataButton_Clicked;
		}

		void GetDataButton_Clicked (object sender, EventArgs e)
		{
			busyIndicator.IsBusy = true;
			busyIndicator.IsVisible = true;

			Task.Run (() => {	
				var stock = new ChartingAndComparingPrices.ComparingStocks (tickerEntry.Text, DateTime.Parse (startDateEntry.Text), DateTime.Now);
				Device.BeginInvokeOnMainThread (
					() => {
						Navigation.PushAsync (new ExploringHistoricalStockPricesChartPage (stock.Stocks));
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;
					});
			});
		}
	}
}

