#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Syncfusion.SfDataGrid.XForms;

namespace SampleBrowser
{
    public partial class PullToRefresh : SamplePage
    {
        #region Constructor

        public PullToRefresh()
        {
            InitializeComponent();
            this.dataGrid.ItemsSource = viewModel.OrdersInfo;
            InitializeCommand();
        }

        #endregion

        #region Private Methods

        private void InitializeCommand()
        {
            this.dataGrid.PullToRefreshCommand = new Command(ExecuteCommand);
        }

        private async void ExecuteCommand()
        {
            this.dataGrid.IsBusy = true;
            await Task.Delay(new TimeSpan(0, 0, 5));
            this.viewModel.ItemsSourceRefresh();
            this.dataGrid.IsBusy = false;
        }

        #endregion

        #region Override Method

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (!IsPropertyViewVisible) {
                dataGrid.Dispose();
                dataGrid = null;
                viewModel = null;
            }
        }

        #endregion
    }
}
