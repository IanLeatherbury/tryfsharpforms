using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace tryfsharpforms
{
	public class BrownianMotionViewModel
	{
		public ObservableCollection<DoubleIntDataPoint> PriceData { get; set; }
		ObservableCollection<DoubleIntDataPoint> data = new ObservableCollection<DoubleIntDataPoint> {
		};
		public BrownianMotionViewModel (IEnumerable<double> list)
		{
			for (int i = 0; i < 100; i++) {
				
				foreach(var price in list)
				{
					data.Add (new DoubleIntDataPoint(price, i));
				}
			}

			PriceData = data;
		}
	}
}

