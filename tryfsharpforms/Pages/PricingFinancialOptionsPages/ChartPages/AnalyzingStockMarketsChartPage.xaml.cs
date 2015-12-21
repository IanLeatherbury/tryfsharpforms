using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections;

namespace tryfsharpforms
{
	public partial class AnalyzingStockMarketsChartPage : ContentPage
	{
		public AnalyzingStockMarketsChartPage (IEnumerable<Tuple<string, IEnumerable<Tuple<double, double>>>> data)
		{
			InitializeComponent ();

			BindingContext = new AnalyzingStockMarketsViewModel (data);

			var vm = new AnalyzingStockMarketsViewModel (data);
			first.Label = vm.DataArray [0] [0].Name;
			second.Label = vm.DataArray [1] [1].Name;
			third.Label = vm.DataArray [2] [2].Name;
			fourth.Label = vm.DataArray [3] [3].Name;
			fifth.Label = vm.DataArray [4] [4].Name;
			sixth.Label = vm.DataArray [5] [5].Name;

		}
	}
}

