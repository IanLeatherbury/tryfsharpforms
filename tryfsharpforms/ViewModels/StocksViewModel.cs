using System;
using tryfsharplib;
using System.Collections.ObjectModel;

namespace tryfsharpforms
{
	public class StocksViewModel
	{
		ExploringHistoricalStockPrices.Charting stocks = new ExploringHistoricalStockPrices.Charting ();

		public ObservableCollection<DataPoints> StockData { get; set; }

		public StocksViewModel ()
		{
			var list = stocks.RecentPricesWithDates;

			var data = new ObservableCollection<DataPoints> {
			};

			foreach(var tup in list)
			{
				data.Add (new DataPoints(tup.Item2, tup.Item1));
			}

			StockData = data;
		}


//		LineData1 = new ObservableCollection<Model>
//		{
//			new Model("2010", 45.68),
//			new Model("2011", 89.25),
//			new Model("2012", 23.73),
//			new Model("2013", 43.5),
//			new Model("2014", 54.92)
//		};
	}
}

