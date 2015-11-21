using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class KalmanRelationshipChartPage : ContentPage
	{
		public KalmanRelationshipChartPage (Tuple<double,double>[] indexPoints, Tuple<Tuple<double,double>, Tuple<double, double>>[] lines)
		{
			InitializeComponent ();

			BindingContext = new KalmanRelationshipViewModel (indexPoints, lines);
		}
	}
}

