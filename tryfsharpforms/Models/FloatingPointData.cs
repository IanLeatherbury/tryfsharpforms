using System;

namespace tryfsharpforms
{
	public class FloatingPointData
	{
		public float OptionPrice { get; set; }
		public float ActualPrice { get; set; }

		public FloatingPointData (float optionPrice, float actualPrice)
		{
			this.OptionPrice = optionPrice;
			this.ActualPrice = actualPrice;
		}
		
	}
}

