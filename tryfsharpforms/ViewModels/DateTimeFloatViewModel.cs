using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace tryfsharpforms
{
	public class DateTimeFloatViewModel
	{
		public ObservableCollection<DateTimeFloat> MyData1 { get; set; }
		public ObservableCollection<DateTimeFloat> MyData2 { get; set; }

		public ObservableCollection<DataPoints> StockData2 { get; set; }
		public DateTimeFloatViewModel (IEnumerable<Tuple<DateTime, float>> list1, IEnumerable<Tuple<DateTime, float>> list2)
		{
			var data1 = new ObservableCollection<DateTimeFloat> {
			};

			foreach(var tup in list1)
			{
				data1.Add (new DateTimeFloat(tup.Item1, tup.Item2));
			}

			MyData1 = data1;

			var data2 = new ObservableCollection<DateTimeFloat> {
			};

			foreach(var tup in list2)
			{
				data2.Add (new DateTimeFloat(tup.Item1, tup.Item2));
			}

			MyData2 = data2;
		}
	}
}

