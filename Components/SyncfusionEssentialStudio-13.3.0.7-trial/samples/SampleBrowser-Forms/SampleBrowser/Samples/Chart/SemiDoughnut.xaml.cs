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
    public partial class SemiDoughnut
    {
        public SemiDoughnut()
        {
            InitializeComponent();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (height > width)
            {
                double padding = (layout.Height - layout.Width) / 2;
                layout.Padding = new Thickness(0, padding / 2, 0, padding);
                Chart.Legend.DockPosition = LegendPlacement.Bottom;
                Chart.Legend.ItemMargin = new Thickness(2, 2, 2, 2);
            }
            else
            {
                double padding = (layout.Width - layout.Height) / 2;
                layout.Padding = new Thickness(padding/2, 0, padding/2, 0);
                Chart.Legend.ItemMargin = new Thickness(0, 0, padding / 5, 0);
                Chart.Legend.DockPosition = LegendPlacement.Right;
            }
        }
    }
}
