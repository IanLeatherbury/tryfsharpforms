using System;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Syncfusion.SfChart.XForms;

namespace tryfsharpforms
{
	public class BlackScholesViewModel
	{
		public ObservableCollection<DoubleDoubleDataPoint>[] DataArray { get; set;}

		public BlackScholesViewModel (IEnumerable<IEnumerable<Tuple<double, double>>> lines)
		{
			ObservableCollection<DoubleDoubleDataPoint>[] dataArray = new ObservableCollection<DoubleDoubleDataPoint>[21];

			int j = 0;

			foreach (var line in lines) {

				ObservableCollection<DoubleDoubleDataPoint> data = new ObservableCollection<DoubleDoubleDataPoint>();

				foreach (var l in line) {
					
					data.Add(new DoubleDoubleDataPoint (l.Item1, l.Item2));
				}

				dataArray [j] = data;
				j++;
			
			}

			DataArray = dataArray;
		}
	}
}