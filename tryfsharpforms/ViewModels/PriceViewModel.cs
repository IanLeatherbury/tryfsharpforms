using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace tryfsharpforms
{
	public class PriceViewModel
	{
		public ObservableCollection<DoubleDataPoint> PriceData { get; set; }
		public ObservableCollection<DoubleDataPoint> PriceData1 { get; set; }
		public ObservableCollection<DoubleDataPoint> PriceData2 { get; set; }

		public PriceViewModel (IEnumerable<Tuple<double, double>> list)
		{
			var data = new ObservableCollection<DoubleDataPoint> {
			};

			foreach(var tup in list)
			{
				data.Add (new DoubleDataPoint(tup.Item2, tup.Item1));
			}

			PriceData = data;
		}

		public PriceViewModel (IEnumerable<Tuple<double, double>> list1, IEnumerable<Tuple<double, double>> list2)
		{
			var data1 = new ObservableCollection<DoubleDataPoint> {
			};


			foreach(var tup in list1)
			{
				data1.Add (new DoubleDataPoint(tup.Item2, tup.Item1));
			}

			PriceData1 = data1;

			var data2 = new ObservableCollection<DoubleDataPoint> {
			};

			foreach(var tup in list2)
			{
				data2.Add (new DoubleDataPoint(tup.Item2, tup.Item1));
			}

			PriceData2 = data2;
		}
	}
}

