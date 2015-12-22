using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class BottomStraddleChartPage : ContentPage
	{
		public BottomStraddleChartPage (IEnumerable<Tuple<double, double>> bsList)
		{
			InitializeComponent ();

			BackgroundColor = MyColors.MidnightBlue;
			bottomStraddle.Color = MyColors.Turqoise;

			BindingContext = new PriceViewModel (bsList);
		}
	}
}

