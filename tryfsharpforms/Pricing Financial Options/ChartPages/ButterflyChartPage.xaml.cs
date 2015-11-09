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

			BindingContext = new PriceViewModel (bfList);
		}
	}
}

