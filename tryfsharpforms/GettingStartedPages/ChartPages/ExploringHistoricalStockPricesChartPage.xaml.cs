using System;
using System.Collections.Generic;
using HelloFSharpXamarinFormsPortable.FSharp;


using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class ExploringHistoricalStockPricesChartPage : ContentPage
	{
		public ExploringHistoricalStockPricesChartPage (IEnumerable<Tuple<DateTime, decimal>> list)
		{
			InitializeComponent ();

			BindingContext = new StocksViewModel (list);
		}
	}
}

