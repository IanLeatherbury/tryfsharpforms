using System;

namespace tryfsharpforms
{
	public class AnalyzingStockMarketsModel
	{
		public int Day { get; set; }

		public double Price { get; set; }

		public AnalyzingStockMarketsModel (int day, double price)
		{
			this.Day = day;
			this.Price = price;
		}
		
	}
}

