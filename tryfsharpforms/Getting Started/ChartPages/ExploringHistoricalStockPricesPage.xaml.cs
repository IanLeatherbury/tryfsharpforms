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

			ExploringHistoricalStockPrices.Charting stocks = new ExploringHistoricalStockPrices.Charting (30.0);

			var list = stocks.RecentDatePrice;

			BindingContext = new StocksViewModel (list);
		}
	}
}

