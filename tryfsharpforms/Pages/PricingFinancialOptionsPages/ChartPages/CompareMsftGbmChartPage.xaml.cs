using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class CompareMsftGbmChartPage : ContentPage
	{
		public CompareMsftGbmChartPage (IEnumerable<Tuple<DateTime,double>> data, 
			IEnumerable<Tuple<DateTime,double>> data1)
		{
			InitializeComponent ();

			BindingContext = new DateTimeDoubleViewModel (data, data1);
		}
	}
}

