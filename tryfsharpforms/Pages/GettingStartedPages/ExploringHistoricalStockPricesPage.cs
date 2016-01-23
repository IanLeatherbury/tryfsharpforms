using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;
using Syncfusion.SfBusyIndicator.XForms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class ExploringHistoricalStockPricesPage : BasePage
	{
		DataEntry tickerEntry = new DataEntry {
			Placeholder = "MSFT",
			TextColor = MyColors.Clouds,
		};
		DataEntry startDateEntry = new DataEntry {
			Placeholder = "1/1/2014",
			Keyboard = Keyboard.Numeric,
			TextColor = MyColors.Clouds,
		};
		GetDataButton getDataButton = new GetDataButton (Borders.Thin, 1) {
			Text = "Get The Data!",
			TextColor = MyColors.Clouds
		};
		Label nullLabel = new Label {HorizontalOptions = LayoutOptions.CenterAndExpand,
			FontAttributes = FontAttributes.Bold, TextColor = MyColors.Clouds,
		};
		SfBusyIndicator busyIndicator = new SfBusyIndicator ();

		public ExploringHistoricalStockPricesPage ()
		{

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
						FontAttributes = FontAttributes.Bold, TextColor = MyColors.Clouds,
					},
					new BoxView { HeightRequest = 10, Opacity = 0 },
					new Label { 
						Text = "Enter a stock ticker",
						HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = MyColors.Clouds
					},
					tickerEntry,
					new Label { 
						Text = "And a start date",
						HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = MyColors.Clouds
					},
					startDateEntry,
					new BoxView { HeightRequest = 10, Opacity = 0 },
					getDataButton,
					new BoxView { HeightRequest = 10, Opacity = 0 },
					busyIndicator,
					nullLabel
				}
			};

			getDataButton.Clicked += GetDataButton_Clicked;
		}

		void GetDataButton_Clicked (object sender, EventArgs e)
		{
			nullLabel.Text = "";

			if ((tickerEntry.Text == null) || (startDateEntry.Text == null)) {
				nullLabel.Text = "Don't forget to enter a stock ticker and a start date!";
			} else {
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
}

