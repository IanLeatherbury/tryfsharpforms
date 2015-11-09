using System;

namespace tryfsharpforms
{
	public class DateTimeDouble
	{
		public DateTime Date { get; set; }
		public double Price { get; set; }

		public DateTimeDouble (DateTime date, double price)
		{
			this.Date = date;
			this.Price = price;
		}
		
	}
}

