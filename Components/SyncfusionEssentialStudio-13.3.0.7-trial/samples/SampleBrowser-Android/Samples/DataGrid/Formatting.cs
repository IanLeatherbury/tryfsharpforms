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
using System.Globalization;
using Android.Graphics;

namespace SampleBrowser
{
	public class Formatting:SamplePage
	{
		SfDataGrid sfGrid;
		FormattingViewModel viewmodel;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			GridTextColumn customerImageColumn = new GridTextColumn ();
			customerImageColumn.UserCellType = typeof(GridImageCell);
			customerImageColumn.MappingName = "CustomerImage";
			customerImageColumn.HeaderText = "Image";

			GridTextColumn isOpenColumn = new GridTextColumn ();
			isOpenColumn.UserCellType = typeof(BoolFormatCell);
			isOpenColumn.MappingName = "IsOpen";
			isOpenColumn.HeaderText = "Is Open";

			GridTextColumn customerIdColumn = new GridTextColumn ();
			customerIdColumn.MappingName = "CustomerID";
			customerIdColumn.HeaderText = "Customer ID";
			customerIdColumn.TextAlignment = GravityFlags.Center;

			GridTextColumn branchNoColumn = new GridTextColumn ();
			branchNoColumn.MappingName = "BranchNo";
			branchNoColumn.HeaderText = "Branch No";
			branchNoColumn.TextAlignment = GravityFlags.Center;

			GridTextColumn currentColumn = new GridTextColumn ();
			currentColumn.MappingName = "Current";
			currentColumn.Format = "C";
			currentColumn.CultureInfo = new CultureInfo ("en-US");
			currentColumn.TextAlignment = GravityFlags.Center;

			GridTextColumn customerNameColumn = new GridTextColumn ();
			customerNameColumn.MappingName = "CustomerName";
			customerNameColumn.HeaderText = "Customer Name";
			customerNameColumn.TextAlignment = GravityFlags.CenterVertical;

			GridTextColumn savingsColumn = new GridTextColumn ();
			savingsColumn.MappingName = "Savings";
			savingsColumn.Format = "C";
			savingsColumn.CultureInfo = new CultureInfo ("en-US");
			savingsColumn.TextAlignment = GravityFlags.Center;

			sfGrid = new SfDataGrid (context);
			sfGrid.AutoGenerateColumns = false;
			sfGrid.RowHeight = 80;
			sfGrid.Columns.Add (customerImageColumn);
			sfGrid.Columns.Add (customerIdColumn);
			sfGrid.Columns.Add (branchNoColumn);
			sfGrid.Columns.Add (currentColumn);
			sfGrid.Columns.Add (customerNameColumn);
			sfGrid.Columns.Add (savingsColumn);
			sfGrid.Columns.Add (isOpenColumn);
			viewmodel = new FormattingViewModel ();
			sfGrid.ItemsSource = viewmodel.BankInfo;
			sfGrid.AlternatingRowColor = Color.Rgb (206, 206, 206);

			return sfGrid;
		}

		public override void Destroy ()
		{
			sfGrid.Dispose ();
			sfGrid = null;
			this.viewmodel.Dispose ();
			this.viewmodel = null;
		}
	}
}

