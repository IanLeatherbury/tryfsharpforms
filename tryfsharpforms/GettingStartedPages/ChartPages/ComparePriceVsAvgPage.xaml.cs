using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class ComparePriceVsAvgPage : ContentPage
	{
		Entry stock1 = new Entry{ Placeholder = "MSFT", Text = "MSFT" };
		Button compareStats = new Button{ Text = "Compare Stats!" };

		public ComparePriceVsAvgPage (IEnumerable<Tuple<DateTime, decimal>> stocks, IEnumerable<Tuple<DateTime, decimal>> avg)
		{
			InitializeComponent ();

			BindingContext = new StocksViewModel (stocks, avg);
		}
	}
}

