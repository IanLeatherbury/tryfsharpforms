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
using System.Globalization;
using CoreGraphics;

namespace SampleBrowser
{
	public class GridGettingStarted :SampleView
	{
		#region Fields

		SfDataGrid SfGrid;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public GridGettingStarted ()
		{
			this.SfGrid = new SfDataGrid ();
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			this.SfGrid.ItemsSource = new GridGettingStartedViewModel().OrdersInfo;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
			this.SfGrid.AlternatingRowColor = UIColor.FromRGB (219, 219, 219);
			this.control = this;
			this.AddSubview (this.SfGrid);
		}


		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnArgs e)
		{
			if (e.Column.MappingName == "OrderID") {
				e.Column.HeaderText = "Order ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "CustomerID") {
				e.Column.HeaderText = "Customer ID";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Freight") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "ShipCity") {
				e.Column.HeaderText = "Ship City";
				e.Column.TextMargin = 10;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "ShipCountry") {
				e.Column.HeaderText = "Ship Country";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Index") {
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "FirstName") {
				e.Column.HeaderText = "First Name";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "LastName") {
				e.Column.HeaderText = "Last Name";
				e.Column.TextMargin = 20;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "Gender") {
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 20;
			} else if (e.Column.MappingName == "ShippingDate") {
				e.Column.HeaderText = "Shipping Date";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.Format = "d";
			} else if (e.Column.MappingName == "IsClosed") {
				e.Column.HeaderText = "Is Closed";
				e.Column.TextMargin = 30;
				e.Column.TextAlignment = UITextAlignment.Left;
			}				
		}

		public override void LayoutSubviews ()
		{
			this.SfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
			base.LayoutSubviews ();
		}
	}
}

