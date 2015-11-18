using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace tryfsharpforms
{
	public class AnalyzingStockMarketsViewModel
	{
		public ObservableCollection<MarketAnalyticsModel>[] DataArray { get; set;}

		public AnalyzingStockMarketsViewModel (IEnumerable<Tuple<string, IEnumerable<Tuple<double, double>>>> data)
		{
			ObservableCollection<MarketAnalyticsModel>[] dataArray = new ObservableCollection<MarketAnalyticsModel>[21];

			int j = 0;

			foreach (var n in data) {
				ObservableCollection<MarketAnalyticsModel> myData = new ObservableCollection<MarketAnalyticsModel>();

				foreach (var l in n.Item2) {
					myData.Add (new MarketAnalyticsModel (n.Item1, l.Item1, l.Item2));
				}

				dataArray [j] = myData;
				j++;
			}

			DataArray = dataArray;
		}
	}
}