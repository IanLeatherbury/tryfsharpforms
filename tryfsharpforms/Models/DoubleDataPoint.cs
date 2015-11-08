using System;

namespace tryfsharpforms
{
	public class DoubleDataPoint
	{
		public double OptionPrice { get; set; }
		public double ActualPrice { get; set; }

		public DoubleDataPoint (double optionPrice, double actualPrice)
		{
			this.OptionPrice = optionPrice;
			this.ActualPrice = actualPrice;
		}
		
	}
}

