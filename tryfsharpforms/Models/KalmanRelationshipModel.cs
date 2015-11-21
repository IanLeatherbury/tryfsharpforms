using System;

namespace tryfsharpforms
{
	public class KalmanRelationshipModel
	{
		public double Xpoint { get; set; }

		public double Ypoint { get; set; }

		public string Name { get; set; }

		public KalmanRelationshipModel (double xpoint, double ypoint)
		{
			this.Xpoint = xpoint;
			this.Ypoint = ypoint;
		}

		public KalmanRelationshipModel (double xpoint, double ypoint, string name)
		{
			this.Xpoint = xpoint;
			this.Ypoint = ypoint;
			this.Name = name;
		}
	}
}