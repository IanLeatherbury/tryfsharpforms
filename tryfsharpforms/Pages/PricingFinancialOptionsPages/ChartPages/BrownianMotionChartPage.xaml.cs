using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace tryfsharpforms
{
	public partial class BrownianMotionChartPage : ContentPage
	{
		public BrownianMotionChartPage (IEnumerable<Tuple<double,double>> data, 
			IEnumerable<Tuple<double,double>> data1, IEnumerable<Tuple<double,double>> data2)
		{
			InitializeComponent ();

			BindingContext = new PriceViewModel (data, data1, data2);

			BackgroundColor = MyColors.MidnightBlue;
			series1.Color = MyColors.Turqoise;
			series2.Color = MyColors.Carrot;
			series3.Color = MyColors.Concrete;
		}
	}
}

