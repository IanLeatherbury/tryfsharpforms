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

			BindingContext = new PriceViewModel (call, put);
		}
	}
}

