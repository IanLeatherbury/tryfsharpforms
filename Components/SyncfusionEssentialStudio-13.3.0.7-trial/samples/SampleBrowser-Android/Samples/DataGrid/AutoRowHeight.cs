#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Views;

namespace SampleBrowser
{
	public class AutoRowHeight:SamplePage
	{
		SfDataGrid sfGrid;
		AutoRowHeightViewModel viewModel;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
			sfGrid.QueryRowHeight += HandleQueryRowHeightEventHandler;
			viewModel = new AutoRowHeightViewModel ();
			sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			sfGrid.ItemsSource = (viewModel.EmployeeInformation);
			return sfGrid;
		}

		void HandleQueryRowHeightEventHandler (object sender, QueryRowHeightEventArgs e)
		{
			double height = SfDataGridHelpers.GetRowHeight (sfGrid, e.RowIndex);
			if (height > 35) {
				e.Height = height;
				e.Handled = true;
			}
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnArgs e)
		{
			e.Column.LoadUIView = true;
			if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
				e.Column.TextAlignment = GravityFlags.CenterHorizontal;
			} else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
				e.Column.TextAlignment = GravityFlags.Left;
			} else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
				e.Column.TextAlignment = GravityFlags.Left;
			} else if (e.Column.MappingName == "Designation") {
				e.Column.TextAlignment = GravityFlags.Left;
			} else if (e.Column.MappingName == "DateOfBirth") {
				e.Column.HeaderText = "Date Of Birth";
				e.Column.Format = "d";
				e.Column.TextAlignment = GravityFlags.CenterHorizontal;
			} else if (e.Column.MappingName == "DateOfJoining") {
				e.Column.HeaderText = "Date Of Joining";
				e.Column.Format = "d";
				e.Column.TextAlignment = GravityFlags.CenterHorizontal;
			} else if (e.Column.MappingName == "Address") {
				e.Column.TextAlignment = GravityFlags.Left;
			} else if (e.Column.MappingName == "City") {
				e.Column.TextAlignment = GravityFlags.Left;
			} else if (e.Column.MappingName == "PostalCode") {
				e.Column.TextAlignment = GravityFlags.Left;
			} else if (e.Column.MappingName == "Country") {
				e.Column.TextAlignment = GravityFlags.CenterHorizontal;
			} else if (e.Column.MappingName == "Telephone") {
				e.Column.TextAlignment = GravityFlags.Left;
			} else if (e.Column.MappingName == "Qualification") {
				e.Column.TextAlignment = GravityFlags.Left;
			}
		}

		public override void Destroy ()
		{
			this.sfGrid.QueryRowHeight -= HandleQueryRowHeightEventHandler;
			sfGrid.Dispose ();
			sfGrid = null;
			viewModel = null;
		}

	}
}

