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
    public partial class DataPointSelection
    {
        public DataPointSelection()
        {
            InitializeComponent();
            Grid.SetRow(Chart, 0);
            Grid.SetRow(label, 1);
        }

        private void chart_SelectionChanged(object sender, ChartSelectionEventArgs e)
        {
            var selectedindex = e.SelectedDataPointIndex;
            if (selectedindex < 0)
            {
                label.Text = "Tap on a bar segment to select a data point";
                label.FontSize = 15;
                return;
            }
            label.FontSize = 20;
            var series = e.SelectedSeries;
            if (series == null) return;
            var datapoints = (series.ItemsSource as IList<Model>);
            
            if (datapoints == null) return;
            var x = datapoints[selectedindex].Name.ToString();
            var y = datapoints[selectedindex].Value.ToString();
            label.Text = "Month : " + x + ",  Sales : $" + y;
        }
    }
}
