using System;
using System.Collections.ObjectModel;

namespace tryfsharpforms
{
	public class KalmanRelationshipViewModel
	{
		public ObservableCollection<KalmanRelationshipModel>[] Lines { get; set; }

		public ObservableCollection<KalmanRelationshipModel>[] Points { get; set; }

		string[] markets = new string[6];

		public KalmanRelationshipViewModel (Tuple<double,double>[] indexPoints, Tuple<Tuple<double,double>, Tuple<double, double>>[] lines)
		{
			ObservableCollection<KalmanRelationshipModel>[] linesArray = new ObservableCollection<KalmanRelationshipModel>[10];
			ObservableCollection<KalmanRelationshipModel>[] pointsArray = new ObservableCollection<KalmanRelationshipModel>[9];
			markets [0] = "AORD";
			markets [1] = "FCHI";
			markets [2] = "FTSE";
			markets [3] = "MERV";
			markets [4] = "MXX";
			markets [5] = "NDX";

			int i = 0;
			foreach (var point in indexPoints) {
				if (i <= 5) {
					ObservableCollection<KalmanRelationshipModel> pointModel = new ObservableCollection<KalmanRelationshipModel> ();
					pointModel.Add (new KalmanRelationshipModel (point.Item1, point.Item2, markets [i]));

					pointsArray [i] = pointModel;
					i++;
				}
			}

			Points = pointsArray;

			int j = 0;
			foreach (var l in lines) {
				ObservableCollection<KalmanRelationshipModel> lineModel = new ObservableCollection<KalmanRelationshipModel> ();
				lineModel.Add (new KalmanRelationshipModel (l.Item1.Item1, l.Item1.Item2));
				lineModel.Add (new KalmanRelationshipModel (l.Item2.Item1, l.Item2.Item2));

				linesArray [j] = lineModel;
				j++;
			}

			Lines = linesArray;
		}
	}
}