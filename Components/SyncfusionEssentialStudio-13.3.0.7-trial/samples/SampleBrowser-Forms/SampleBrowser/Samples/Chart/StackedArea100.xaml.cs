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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class StackedArea100
    {
        int index;

        ViewModel viewModel;

        public StackedArea100()
        {
            InitializeComponent();
            viewModel = Chart.BindingContext as ViewModel;
            UpdateData();
        }

        private async void UpdateData()
        {
            while (true)
            {
                await Task.Delay(300);
                Chart.Series[index].ItemsSource = Data(index);
                Chart.Series[index].XBindingPath = "Name";
                ((StackingArea100Series)Chart.Series[index]).YBindingPath = "Value";
                index++;
                if (index < 3)
                    continue;
                break;
            }
        }

        private IEnumerable<Model> Data(int index)
        {
            if (index == 0)
                return viewModel.Data1;
            return index == 1 ? viewModel.Data2 : viewModel.Data3;
        }
    }
}
