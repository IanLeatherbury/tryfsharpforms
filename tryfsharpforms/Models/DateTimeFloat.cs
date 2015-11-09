using System;

namespace tryfsharpforms
{
	public class DateTimeFloat
	{
		public DateTime Date { get; set; }
		public float Price { get; set; }

		public DateTimeFloat (DateTime date, float price)
		{
			this.Date = date;
			this.Price = price;
		}
		
	}
}

