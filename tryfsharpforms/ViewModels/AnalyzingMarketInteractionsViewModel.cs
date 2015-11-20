using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace tryfsharpforms
{
	public class AnalyzingMarketInteractionsViewModel
	{
		public ObservableCollection<AnalyzingStockMarketsModel> Data { get; set;}
		public ObservableCollection<AnalyzingStockMarketsModel> Original { get; set;}
		public ObservableCollection<AnalyzingStockMarketsModel> Fitted { get; set;}


		public AnalyzingMarketInteractionsViewModel (IEnumerable<Tuple<int,double>> data )
		{
			var logliks = new ObservableCollection<AnalyzingStockMarketsModel> {};

			foreach(var tup in data)
			{
				logliks.Add (new AnalyzingStockMarketsModel (tup.Item1, tup.Item2));
			}

			Data = logliks;
		}

		public AnalyzingMarketInteractionsViewModel (IEnumerable<Tuple<int,double>> original,
			IEnumerable<Tuple<int,double>> fitted)
		{
			var originalData = new ObservableCollection<AnalyzingStockMarketsModel> {};
			var fittedData = new ObservableCollection<AnalyzingStockMarketsModel> {};

			foreach(var tup in original)
			{
				originalData.Add (new AnalyzingStockMarketsModel (tup.Item1, tup.Item2));
			}

			Original = originalData;

			foreach(var tup in fitted)
			{
				fittedData.Add (new AnalyzingStockMarketsModel (tup.Item1, tup.Item2));
			}

			Fitted = fittedData;
		}
	}
}