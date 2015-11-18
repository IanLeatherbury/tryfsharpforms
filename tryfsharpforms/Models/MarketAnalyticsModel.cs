using System;

namespace tryfsharpforms
{
	public class MarketAnalyticsModel
	{
		public string Name { get; set; }

		public double Day { get; set; }

		public double Price { get; set; }

		public MarketAnalyticsModel (string name, double day, double price)
		{
			this.Name = name;
			this.Day = day;
			this.Price = price;
		}
	}
}

