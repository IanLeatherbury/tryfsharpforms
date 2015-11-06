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
    public partial class StripLines
    {
        public StripLines()
        {
            InitializeComponent();
            (Chart.SecondaryAxis as NumericalAxis).Minimum = 28;
            (Chart.SecondaryAxis as NumericalAxis).Maximum = 52;
            (Chart.PrimaryAxis as CategoryAxis).LabelPlacement = LabelPlacement.BetweenTicks;
        }
    }
}
