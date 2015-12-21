using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class CalcuateCallPutPayoffChartPage : ContentPage
	{
		public CalcuateCallPutPayoffChartPage (IEnumerable<Tuple<double, double>> call, IEnumerable<Tuple<double, double>> put)
		{
			InitializeComponent ();

			BackgroundColor = MyColors.MidnightBlue;

			callSeries.Color = MyColors.Turqoise;
			putSeries.Color = MyColors.BelizeHole;

			BindingContext = new PriceViewModel (call, put);
		}
	}
}

