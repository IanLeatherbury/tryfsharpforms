using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfChart.XForms;

namespace tryfsharpforms
{
	public partial class BlackScholesChartPage : ContentPage
	{
		SfChart chart = new SfChart();

		public BlackScholesChartPage (IEnumerable<Tuple<double,double>[]> list)
		{
			InitializeComponent ();

			BindingContext = new BlackScholesViewModel (list);
		}
	}
}

