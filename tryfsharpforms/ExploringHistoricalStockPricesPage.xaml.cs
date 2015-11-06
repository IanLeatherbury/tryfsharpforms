using System;
using System.Collections.Generic;
using tryfsharplib;


using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class ExploringHistoricalStockPricesPage : ContentPage
	{
		public ExploringHistoricalStockPricesPage ()
		{
			InitializeComponent ();

			ExploringHistoricalStockPrices.Charting stocks = new ExploringHistoricalStockPrices.Charting ();

			var list = stocks.RecentPricesWithDates;

			BindingContext = new StocksViewModel ();
		}
	}
}

