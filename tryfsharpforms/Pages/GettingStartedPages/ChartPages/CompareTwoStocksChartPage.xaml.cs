using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System.Collections.ObjectModel;
using Syncfusion.SfBusyIndicator.XForms;

namespace tryfsharpforms
{
	public partial class CompareTwoStocksChartPage : ContentPage
	{
		public CompareTwoStocksChartPage (IEnumerable<Tuple<DateTime, decimal>> priceList1, IEnumerable<Tuple<DateTime, decimal>> priceList2, string ticker1, string ticker2)
		{
			InitializeComponent ();

			Title = ticker1.ToUpper() + " vs " + ticker2.ToUpper();

			BackgroundColor = MyColors.MidnightBlue;
			series1.Color = MyColors.Turqoise;
			series2.Color = MyColors.Carrot;

			series1.Label = ticker1.ToUpper ();

			series2.Label = ticker2.ToUpper ();


			var svm = new StocksViewModel (priceList1, priceList2);
			BindingContext = svm;
		}
	}
}
