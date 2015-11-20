using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace tryfsharpforms
{
	public class AnalyzingMarketInteractionsViewModel
	{
		public ObservableCollection<AnalyzingStockMarketsModel> Data { get; set;}


		public AnalyzingMarketInteractionsViewModel (IEnumerable<Tuple<int,double>> data )
		{
			var logliks = new ObservableCollection<AnalyzingStockMarketsModel> {};

			foreach(var tup in data)
			{
				logliks.Add (new AnalyzingStockMarketsModel (tup.Item1, tup.Item2));
			}

			Data = logliks;
		}
	}
}