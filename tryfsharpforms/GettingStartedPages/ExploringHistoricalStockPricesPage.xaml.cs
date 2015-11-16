using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class ExploringHistoricalStockPricesPage : ContentPage
	{
		Entry tickerEntry = new Entry{Placeholder = "MSFT", Text = "MSFT"};
		Entry startDateEntry = new Entry{Placeholder = "1/1/2014", Text = "1/1/2014"};
		Button getDataButton = new Button{Text = "Get Data!"};

		public ExploringHistoricalStockPricesPage ()
		{
			InitializeComponent ();

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
					getDataButton
				}
			};

			getDataButton.Clicked += GetDataButton_Clicked;
		}

		void GetDataButton_Clicked (object sender, EventArgs e)
		{
			var stock = new ChartingAndComparingPrices.ComparingStocks (tickerEntry.Text, DateTime.Parse (startDateEntry.Text), DateTime.Now);

			Navigation.PushAsync (new ExploringHistoricalStockPricesChartPage (stock.Stocks));
		}
	}
}

