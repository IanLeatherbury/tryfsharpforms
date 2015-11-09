using System;

namespace tryfsharpforms
{
	public class DoubleIntDataPoint
	{
		public double Dist { get; set; }
		public int Int { get; set; }

		public DoubleIntDataPoint (double dist, int @int)
		{
			this.Dist = dist;
			this.Int = @int;
		}
		
	}
}

