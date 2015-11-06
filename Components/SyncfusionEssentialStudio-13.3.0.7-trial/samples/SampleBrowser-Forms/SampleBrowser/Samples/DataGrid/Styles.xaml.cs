#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfDataGrid.XForms;
using System.Globalization;

namespace SampleBrowser
{
	public partial class Styles : SamplePage
	{
		#region  Constructor

		public Styles ()
		{
			InitializeComponent ();
            this.dataGrid.ItemsSource = viewModel.OrdersInfo;
            StylePicker.SelectedIndex = 0;
		}

		#endregion

		#region CallBacks

		void OnStyleChanged (object sender, EventArgs e)
		{
			if (StylePicker.SelectedIndex == 0) {
				this.dataGrid.GridStyle = new Dark ();
			} else if (StylePicker.SelectedIndex == 1) {
				this.dataGrid.GridStyle = new Blue ();
			} else if (StylePicker.SelectedIndex == 2) {
				this.dataGrid.GridStyle = new Red ();
			} else if (StylePicker.SelectedIndex == 3) {
				this.dataGrid.GridStyle = new Green ();
			}
		}

		void GridViewCreated (object sender, GridViewCreatedEvent e)
		{
			this.dataGrid.SelectedItem = viewModel.OrdersInfo[1];
			this.dataGrid.GridStyle = new Dark();
		}

		#endregion

		#region override

		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
            if (!IsPropertyViewVisible) {
                dataGrid.Dispose();
                dataGrid = null;
                viewModel = null;
            }
		}

		#endregion
	}
}

