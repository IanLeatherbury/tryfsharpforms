using System;

namespace tryfsharpforms
{
	public class DoubleDoubleDataPoint
	{
		public double Price1 { get; set; }
		public double Price2 { get; set; }

		public DoubleDoubleDataPoint (double price1, double price2)
		{
			this.Price1 = price1;
			this.Price2 = price2;
		}
		
	}
}

