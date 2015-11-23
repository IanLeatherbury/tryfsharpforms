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
		public CompareTwoStocksChartPage (IEnumerable<Tuple<DateTime, decimal>> priceList1, IEnumerable<Tuple<DateTime, decimal>> priceList2)
		{
			InitializeComponent ();

			var svm = new StocksViewModel (priceList1, priceList2);
			BindingContext = svm;
		}
	}
}
