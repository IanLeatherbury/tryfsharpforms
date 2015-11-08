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

			BindingContext = new PriceViewModel (bsList);
		}
	}
}

