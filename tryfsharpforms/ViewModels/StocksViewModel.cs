using System;
using tryfsharplib;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace tryfsharpforms
{
	public class StocksViewModel
	{
		ExploringHistoricalStockPrices.Charting stocks = new ExploringHistoricalStockPrices.Charting ();
//		ChartingAndComparingPrices.UrlConstructor(

		public ObservableCollection<DataPoints> StockData { get; set; }

		public ObservableCollection<DataPoints> StockData1 { get; set; }

		public ObservableCollection<DataPoints> StockData2 { get; set; }

		public StocksViewModel (IEnumerable<Tuple<DateTime, decimal>> list)
		{
//			var list = stocks.RecentDatePrice;

			var data = new ObservableCollection<DataPoints> {
			};

			foreach(var tup in list)
			{
				data.Add (new DataPoints(tup.Item2, tup.Item1));
			}

			StockData = data;
		}

		public StocksViewModel (IEnumerable<Tuple<DateTime, decimal>> list1, IEnumerable<Tuple<DateTime, decimal>> list2)
		{
			//			var list = stocks.RecentDatePrice;

			var data1 = new ObservableCollection<DataPoints> {
			};

			foreach(var tup in list1)
			{
				data1.Add (new DataPoints(tup.Item2, tup.Item1));
			}

			StockData1 = data1;

			var data2 = new ObservableCollection<DataPoints> {
			};

			foreach(var tup in list2)
			{
				data2.Add (new DataPoints(tup.Item2, tup.Item1));
			}

			StockData2 = data2;
		}
	}
}

