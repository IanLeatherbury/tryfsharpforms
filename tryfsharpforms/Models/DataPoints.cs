using System;

namespace tryfsharpforms
{
	public class DataPoints
	{
		public decimal Close { get; set; }
		public DateTime Date { get; set; }

		public DataPoints (decimal close, DateTime date)
		{
			this.Close = close;
			this.Date = date;
		}
		
	}
}

