using System;

namespace tryfsharpforms
{
	public class DecimalDataPoint
	{
		public decimal OptionPrice { get; set; }
		public decimal ActualPrice { get; set; }

		public DecimalDataPoint (decimal optionPrice, decimal actualPrice)
		{
			this.OptionPrice = optionPrice;
			this.ActualPrice = actualPrice;
		}
		
	}
}

