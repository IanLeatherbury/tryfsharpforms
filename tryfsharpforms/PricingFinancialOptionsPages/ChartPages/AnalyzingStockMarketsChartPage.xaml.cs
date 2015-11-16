using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections;

namespace tryfsharpforms
{
	public partial class AnalyzingStockMarketsChartPage : ContentPage
	{
		public AnalyzingStockMarketsChartPage (IEnumerable<Tuple<string, IEnumerable<Tuple<int, decimal>>>> data)
		{
			InitializeComponent ();

			BindingContext = new AnalyzingStockMarketsViewModel (data);
		}
	}
}

