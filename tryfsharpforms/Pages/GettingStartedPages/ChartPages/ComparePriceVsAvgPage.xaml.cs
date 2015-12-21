using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class ComparePriceVsAvgPage : ContentPage
	{
		public ComparePriceVsAvgPage (IEnumerable<Tuple<DateTime, decimal>> stocks, IEnumerable<Tuple<DateTime, decimal>> avg, string ticker)
		{
			InitializeComponent ();

			BackgroundColor = MyColors.MidnightBlue;

			Title = ticker.ToUpper ();

			series1.Color = MyColors.Turqoise;
			series2.Color = MyColors.GreenSea;

			series1.Label = ticker.ToUpper ();
			series2.Label = ticker.ToUpper () + "Average";

			BindingContext = new StocksViewModel (stocks, avg);
		}
	}
}

