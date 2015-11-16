using System;

namespace tryfsharpforms
{
	public class MarketAnalyticsModel
	{
		public string Name { get; set; }

		public int Day { get; set; }

		public decimal Price { get; set; }

		public MarketAnalyticsModel (string name, int day, decimal price)
		{
			this.Name = name;
			this.Day = day;
			this.Price = price;
		}
	}
}

