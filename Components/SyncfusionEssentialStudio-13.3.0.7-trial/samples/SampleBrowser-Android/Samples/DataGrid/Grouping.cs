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

namespace SampleBrowser
{
	public class Grouping:SamplePage
	{
		SfDataGrid sfGrid;
		GroupingViewModel viewModel;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
			viewModel = new GroupingViewModel ();
			sfGrid.ItemsSource = viewModel.ProductDetails;
			sfGrid.GroupColumnDescriptions.Add (new GroupColumnDescription (){ ColumnName = "Product" });
			sfGrid.AutoGeneratingColumn += OnAutoGenerateColumn;
			sfGrid.QueryRowHeight += SfGrid_QueryRowHeight;
			return sfGrid;
		}
		void SfGrid_QueryRowHeight (object sender, QueryRowHeightEventArgs e)
		{
			if (SfDataGridHelpers.IsCaptionSummaryRow (this.sfGrid, e.RowIndex)) {
				e.Height = 40;
				e.Handled = true;
			}
		}

		void OnAutoGenerateColumn (object sender, AutoGeneratingColumnArgs e)
		{
			if (e.Column.MappingName == "ProductID") {
				e.Column.HeaderText = "Product ID";
			} else if (e.Column.MappingName == "UserRating") {
				e.Column.HeaderText = "User Rating";
			} else if (e.Column.MappingName == "ProductModel") {
				e.Column.HeaderText = "Product Model";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Price") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "ShippingDays") {
				e.Column.HeaderText = "Shipping Days";
			} else if (e.Column.MappingName == "ProductType") {
				e.Column.HeaderText = "Product Type";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
				e.Column.TextMargin = 15;
			} else if (e.Column.MappingName == "Availability") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
				e.Column.TextMargin = 25;
			}
		}

		public override void Destroy ()
		{
			this.sfGrid.AutoGeneratingColumn -= OnAutoGenerateColumn;
			this.sfGrid.QueryRowHeight -= SfGrid_QueryRowHeight;
			this.sfGrid.Dispose ();
			this.sfGrid = null;
			this.viewModel = null;
		}
	}
}

