using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class CompareMsftHistoricalVolDriftChartPage : ContentPage
	{
		public CompareMsftHistoricalVolDriftChartPage (IEnumerable<Tuple<DateTime,double>> data, IEnumerable<Tuple<DateTime,double>> data1)
		{
			InitializeComponent ();

			BindingContext = new DateTimeDoubleViewModel (data, data1);
		}
	}
}

