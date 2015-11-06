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
	public class DataVirtualization:SampleView
	{
		#region Fields

		SfDataGrid SfGrid;

		#endregion

		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public DataVirtualization()
		{
			this.SfGrid = new SfDataGrid ();
			this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
			this.SfGrid.ItemsSource = new DataVirtualizationViewModel ().ViewSource;
			this.SfGrid.ShowRowHeader = false;
			this.SfGrid.HeaderRowHeight = 45;
			this.SfGrid.RowHeight = 45;
			this.SfGrid.AlternatingRowColor = UIColor.FromRGB (219, 219, 219);
			this.control = this;
			this.AddSubview (SfGrid);
		}

		void GridAutoGenerateColumns (object sender, AutoGeneratingColumnArgs e)
		{
			if (e.Column.MappingName == "EmployeeID") {
				e.Column.HeaderText = "Employee ID";
			} else if (e.Column.MappingName == "Name") {
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 10;
			} else if (e.Column.MappingName == "ContactID") {
				e.Column.HeaderText = "Contact ID";
			} else if (e.Column.MappingName == "Gender") {
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 30;
			} else if (e.Column.MappingName == "Title") {
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.TextMargin = 10;
			} else if (e.Column.MappingName == "SickLeaveHours") {
				e.Column.HeaderText = "Sick Leave Hours";
			} else if (e.Column.MappingName == "Salary") {
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
			} else if (e.Column.MappingName == "BirthDate") {
				e.Column.HeaderText = "Birth Date";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
				e.Column.Format = "d";	
			}
		}

		public override void LayoutSubviews ()
		{
			this.SfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
			base.LayoutSubviews ();
		}

	}
}

