#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using UIKit;
using CoreGraphics;

namespace SampleBrowser
{
	public class AutoRowHeight:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public AutoRowHeight ()
		{
			this.SfGrid = new SfDataGrid ();
			this.SfGrid.AllowSorting = false;
			this.SfGrid.AllowTriStateSorting = false;
			this.SfGrid.AlternationCount = 2;
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			this.SfGrid.ItemsSource = new AutoRowHeightViewModel ().EmployeeInformation;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.QueryRowHeight += GridQueryRowHeight;
			this.control = this;
			this.AddSubview (SfGrid);
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnArgs e)
		{
			if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Designation") {
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "DateOfBirth") {
				e.Column.HeaderText = "Date Of Birth";
				e.Column.TextMargin = 15;
				e.Column.Format = "d";
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "DateOfJoining") {
				e.Column.HeaderText = "Date Of Joining";
				e.Column.TextMargin = 15;
				e.Column.Format = "d";
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Address") {
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "City") {
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 20;
			} else if (e.Column.MappingName == "PostalCode") {
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Country") {
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "Telephone") {
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Qualification") {
				e.Column.TextAlignment = UITextAlignment.Left;
			}
		}

		void GridQueryRowHeight (object sender, QueryRowHeightEventArgs e)
		{
			double height = SfDataGridHelpers.GetRowHeight (SfGrid, e.RowIndex);
			if (height > 35) {
				e.Height = height;
				e.Handled = true;
			} else if (e.RowIndex == 0) {

				e.Height = 45;
				e.Handled = true;
			}
		}

		public override void LayoutSubviews ()
		{
			this.SfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
			base.LayoutSubviews ();
		}
	}
}

