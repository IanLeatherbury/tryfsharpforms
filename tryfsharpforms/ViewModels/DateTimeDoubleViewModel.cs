using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace tryfsharpforms
{
	public class DateTimeDoubleViewModel
	{
		public ObservableCollection<DateTimeDouble> MyData1 { get; set; }
		public ObservableCollection<DateTimeDouble> MyData2 { get; set; }

		public DateTimeDoubleViewModel (IEnumerable<Tuple<DateTime, double>> list1, IEnumerable<Tuple<DateTime, double>> list2)
		{
			var data1 = new ObservableCollection<DateTimeDouble> {
			};

			foreach(var tup in list1)
			{
				data1.Add (new DateTimeDouble(tup.Item1, tup.Item2));
			}

			MyData1 = data1;

			var data2 = new ObservableCollection<DateTimeDouble> {
			};

			foreach(var tup in list2)
			{
				data2.Add (new DateTimeDouble(tup.Item1, tup.Item2));
			}

			MyData2 = data2;
		}
	}
}