using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class FittedVersusObservedChartPage : ContentPage
	{
		public FittedVersusObservedChartPage (IEnumerable<Tuple<int,double>> original, 
			IEnumerable<Tuple<int,double>> fitted)
		{
			InitializeComponent ();

			BindingContext = new AnalyzingMarketInteractionsViewModel (original, fitted);
		}
	}
}

