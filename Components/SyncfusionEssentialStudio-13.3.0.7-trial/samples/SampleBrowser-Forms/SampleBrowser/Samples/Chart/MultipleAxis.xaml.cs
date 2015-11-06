#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class MultipleAxis
    {
        public MultipleAxis()
        {
            InitializeComponent();
            (Chart.SecondaryAxis as NumericalAxis).Maximum = 8800;
            (Chart.SecondaryAxis as NumericalAxis).Minimum = 6200;
            (Chart.SecondaryAxis as NumericalAxis).Interval = 200;

            ((Chart.Series[1] as FastLineSeries).YAxis as NumericalAxis).Maximum = 80;
            ((Chart.Series[1] as FastLineSeries).YAxis as NumericalAxis).Minimum = 0;
            ((Chart.Series[1] as FastLineSeries).YAxis as NumericalAxis).Interval = 5;
            ((Chart.Series[1] as FastLineSeries).YAxis as NumericalAxis).OpposedPosition = true;
        }
    }
}
