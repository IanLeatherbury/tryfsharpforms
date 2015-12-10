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
		Entry tickerEntry = new Entry {
			Placeholder = "MSFT",
			TextColor = MyColors.Clouds,
			BackgroundColor = MyColors.WetAsphalt
		};
		Entry startDateEntry = new Entry {
			Placeholder = "1/1/2014",
			Keyboard = Keyboard.Numeric,
			TextColor = MyColors.Clouds,
			BackgroundColor = MyColors.WetAsphalt
		};
		Button getDataButton = new Button{ Text = "Get Data!", TextColor = MyColors.Clouds };
		SfBusyIndicator busyIndicator = new SfBusyIndicator ();

		public ExploringHistoricalStockPricesPage ()
		{
			InitializeComponent ();

			BackgroundColor = MyColors.MidnightBlue;

			busyIndicator.ViewBoxWidth = 150;
			busyIndicator.ViewBoxHeight = 150;
			busyIndicator.HeightRequest = 50;
			busyIndicator.WidthRequest = 50;
			busyIndicator.AnimationType = AnimationTypes.DoubleCircle;
			busyIndicator.TextColor = MyColors.Turqoise;
			busyIndicator.IsVisible = false;
			busyIndicator.IsBusy = false;
			busyIndicator.BackgroundColor = MyColors.MidnightBlue;

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Chart a stock price up until now",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, TextColor = MyColors.Clouds
					},
					new Label { 
						Text = "Enter a stock ticker",
						HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = MyColors.Clouds
					},
					tickerEntry,
					new Label { 
						Text = "Enter a start date",
						HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = MyColors.Clouds
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
						Navigation.PushAsync (new ExploringHistoricalStockPricesChartPage (stock.Stocks, tickerEntry.Text));
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;
					});
			});
		}
	}
}

