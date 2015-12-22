using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class ButterflyChartPage : ContentPage
	{
		public ButterflyChartPage (IEnumerable<Tuple<double, double>> bfList)
		{
			InitializeComponent ();

			BackgroundColor = MyColors.MidnightBlue;
			butterflySeries.Color = MyColors.Turqoise;

			BindingContext = new PriceViewModel (bfList);
		}
	}
}

