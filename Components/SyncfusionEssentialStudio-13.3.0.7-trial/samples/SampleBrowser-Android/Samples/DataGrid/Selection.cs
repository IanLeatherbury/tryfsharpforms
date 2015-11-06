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
using Android.Widget;
using System.Collections.Generic;
using System.Globalization;

namespace SampleBrowser
{
	public class Selection:SamplePage
	{
		SfDataGrid sfGrid;
		SelectionViewModel viewModel;

		public override Android.Views.View GetSampleContent (Android.Content.Context context)
		{
			sfGrid = new SfDataGrid (context);
			viewModel = new SelectionViewModel ();
			sfGrid.ItemsSource = (viewModel.ProductDetails);
			sfGrid.AutoGeneratingColumn += OnAutoGenerateColumn;
			sfGrid.SelectedIndex = 1;
			sfGrid.SelectionMode = SelectionMode.Multiple;
			return sfGrid;
		}

		public override Android.Views.View GetPropertyWindowLayout (Android.Content.Context context)
		{
			View view = new View (context);
			Spinner spin = new Spinner (context);
			List<String> adapter = new List<String> (){"Single","Single/Deselect","Multiple","None" };
			ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
				(context, Android.Resource.Layout.SimpleSpinnerItem,adapter);
			spin.Adapter = dataAdapter;
			TextView txt = new TextView (context);
			txt.Text = "Set Selection Mode";
			txt.TextSize = 15f;
			txt.SetPadding (10, 10, 10, 10);
			spin.SetPadding (10, 10, 10, 10);
			LinearLayout linear = new LinearLayout (context);
			linear.Orientation = Orientation.Horizontal;
			linear.AddView (txt);
			linear.AddView (spin);
            spin.SetSelection(2);
			spin.ItemSelected += OnSelectionModeChanged;
			return linear;
		}

		void OnSelectionModeChanged (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			if (e.Position == 0)
				sfGrid.SelectionMode = SelectionMode.Single;
			if (e.Position == 1)
				sfGrid.SelectionMode = SelectionMode.SingleDeselect;
			if (e.Position == 2)
				sfGrid.SelectionMode = SelectionMode.Multiple;
			if (e.Position == 3)
				sfGrid.SelectionMode = SelectionMode.None;
		}

		void OnAutoGenerateColumn (object sender, AutoGeneratingColumnArgs e)
		{
			if (e.Column.MappingName == "ProductID") {
				e.Column.HeaderText = "Product ID";
			} else if (e.Column.MappingName == "Product") {
				e.Column.TextAlignment = GravityFlags.CenterVertical;
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

		public override void OnApplyChanges ()
		{
			base.OnApplyChanges ();
		}

		public override void Destroy ()
		{
			sfGrid.AutoGeneratingColumn -= OnAutoGenerateColumn;
			sfGrid.Dispose ();
			viewModel = null;
			sfGrid = null;
		}
	}
}

