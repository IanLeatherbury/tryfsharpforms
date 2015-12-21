using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class AnalyzingMarketInteractionsChartPage : ContentPage
	{
		public AnalyzingMarketInteractionsChartPage (IEnumerable<Tuple<int, double>> data)
		{
			InitializeComponent ();

			BindingContext = new AnalyzingMarketInteractionsViewModel (data);
		}
	}
}

