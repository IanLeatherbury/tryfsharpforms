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

			var vm = new KalmanRelationshipViewModel (indexPoints, lines);

			BindingContext = vm;

			Market0.Label = vm.Points [0] [0].Name;
			Market1.Label = vm.Points [1] [0].Name;
			Market2.Label = vm.Points [2] [0].Name;
			Market3.Label = vm.Points [3] [0].Name;
			Market4.Label = vm.Points [4] [0].Name;
			Market5.Label = vm.Points [5] [0].Name;
		}
	}
}

