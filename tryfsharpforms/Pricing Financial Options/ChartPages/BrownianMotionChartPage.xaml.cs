﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace tryfsharpforms
{
	public partial class BrownianMotionChartPage : ContentPage
	{
		public BrownianMotionChartPage (IEnumerable<Tuple<double,double>> data)
		{
			InitializeComponent ();

			BindingContext = new PriceViewModel (data);
		}
	}
}

