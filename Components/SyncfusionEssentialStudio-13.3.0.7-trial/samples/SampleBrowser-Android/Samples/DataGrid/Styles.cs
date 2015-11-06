#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfDataGrid;
using Android.Graphics;
using Android.Views;
using System.Globalization;
using Android.Widget;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class Styles:SamplePage
	{
		SfDataGrid sfGrid;
		StylesViewModel viewModel;
		DataGridStyle defaultStyle;
		Dark darkStyle;
		Red redStyle;
		Green greenStyle;
		Blue blueStyle;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
			viewModel = new StylesViewModel ();
			sfGrid.ItemsSource = (viewModel.OrdersInfo);
			sfGrid.AutoGeneratingColumn += GridGenerateColumns;
			sfGrid.AlternatingRowColor = Color.Rgb (206, 206, 206);
			sfGrid.SelectionMode = SelectionMode.Single;
			sfGrid.GroupColumnDescriptions.Add (new GroupColumnDescription (){ ColumnName = "CustomerID" });
			sfGrid.GridViewCreated += SfGrid_GridViewCreated;
			sfGrid.QueryRowHeight += SfGrid_QueryRowHeight;
			defaultStyle = new DataGridStyle ();
			darkStyle = new Dark ();
			blueStyle = new Blue ();
			redStyle = new Red ();
			greenStyle = new Green ();
			return sfGrid;
		}

		public override View GetPropertyWindowLayout (Android.Content.Context context)
		{
			LinearLayout linear = new LinearLayout (context);
			linear.Orientation = Orientation.Horizontal;
			TextView txt = new TextView (context);
			txt.Text = "Select Theme";
			txt.SetPadding (10, 10, 10, 10);
			txt.TextSize = 15f;
			Spinner themeDropDown = new Spinner (context);
			List<String> adapter = new List<String> (){"Default","Dark","Blue","Red","Green" };
			ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
				(context, Android.Resource.Layout.SimpleSpinnerItem,adapter);
			themeDropDown.Adapter = dataAdapter; 
			themeDropDown.SetPadding (10, 10, 10, 10);
            themeDropDown.SetSelection(1);
			themeDropDown.ItemSelected += OnGridThemeChanged;
			themeDropDown.SetMinimumHeight (70);
			linear.AddView (txt);
			linear.AddView (themeDropDown);
			return linear;
		}

		void OnGridThemeChanged (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			if (e.Position == 0) 
			{
				sfGrid.GridStyle = defaultStyle;
				sfGrid.AlternatingRowColor = Color.Rgb (206, 206, 206);
			}
			if (e.Position == 1) 
			{
				sfGrid.GridStyle = darkStyle;
				sfGrid.AlternatingRowColor = Color.Rgb (25, 25, 25);
			}
			if (e.Position == 2) 
			{
				sfGrid.GridStyle = blueStyle;
				sfGrid.AlternatingRowColor = Color.Rgb (230, 239, 237);
			}
			if (e.Position == 3) 
			{
				sfGrid.GridStyle = redStyle;
				sfGrid.AlternatingRowColor = Color.Rgb (252, 242, 240);
			}
			if (e.Position == 4) 
			{
				sfGrid.GridStyle = greenStyle;
				sfGrid.AlternatingRowColor = Color.Rgb (248, 249, 229);
			}
		}

		void SfGrid_GridViewCreated (object sender, GridViewCreatedEvent e)
		{
			SfDataGrid grid = sender as SfDataGrid;
			grid.GridStyle = darkStyle;
			sfGrid.AlternatingRowColor = Color.Rgb (25, 25, 25);
		}

		void SfGrid_QueryRowHeight (object sender, QueryRowHeightEventArgs e)
		{
			if (SfDataGridHelpers.IsCaptionSummaryRow (this.sfGrid, e.RowIndex)) {
				e.Height = 50;
				e.Handled = true;
			}
		}

		void GridGenerateColumns (object sender, AutoGeneratingColumnArgs e)
		{
			if (e.Column.MappingName == "OrderID") {
				e.Column.HeaderText = "Order ID";
			} else if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Freight") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "ShipCity") {
				e.Column.HeaderText = "Ship City";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "ShipCountry") {
				e.Column.HeaderText = "Ship Country";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
				e.Column.TextAlignment = GravityFlags.Center;
			} else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "Gender") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} else if (e.Column.MappingName == "ShippingDate") {
				e.Column.HeaderText = "Shipping Date";
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "IsClosed") {
				e.Column.HeaderText = "Is Closed";
				e.Column.TextAlignment = GravityFlags.CenterVertical;
			} 
		}

		public override void Destroy ()
		{
			sfGrid.AutoGeneratingColumn -= GridGenerateColumns;
			sfGrid.Dispose ();
			sfGrid = null;
			viewModel = null;
			defaultStyle = null;
			darkStyle = null;
			blueStyle = null;
			redStyle = null;
			greenStyle = null;
		}
	}
}

