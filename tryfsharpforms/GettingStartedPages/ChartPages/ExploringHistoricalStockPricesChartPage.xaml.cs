using System;
using System.Collections.Generic;
using tryfsharplib;


using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class ExploringHistoricalStockPricesChartPage : ContentPage
	{
		public ExploringHistoricalStockPricesChartPage (IEnumerable<Tuple<DateTime, decimal>> list)
		{
			InitializeComponent ();

			BackgroundColor = MyColors.MidnightBlue;
			series1.Color = MyColors.Turqoise;

			BindingContext = new StocksViewModel (list);
		}
	}
}

