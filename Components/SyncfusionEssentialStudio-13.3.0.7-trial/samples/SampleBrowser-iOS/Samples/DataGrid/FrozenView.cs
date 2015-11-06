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

using Foundation;
using UIKit;
using Syncfusion.SfDataGrid;
using System.Globalization;
using CoreGraphics;

namespace SampleBrowser
{
    public class FrozenView : SampleView
    {
        #region Fields

        SfDataGrid sfGrid;
        FrozenViewViewModel viewModel;

        #endregion

        #region Static Methods

        static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

        #endregion

        #region Constructor

        public FrozenView ()
        {
            sfGrid = new SfDataGrid ();
            viewModel = new FrozenViewViewModel ();
            sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            sfGrid.ItemsSource = viewModel.Products;
            sfGrid.FrozenRowsCount = 2;
            sfGrid.FrozenColumnsCount = 1;
            this.control = this;
            this.AddSubview (sfGrid);
        }

        #endregion

        #region Override Methods

        public override void LayoutSubviews()
        {
            this.sfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews ();
        }

        #endregion

        #region CallBacks

        private void GridAutoGenerateColumns(object sender, AutoGeneratingColumnArgs e)
        {
            if (e.Column.MappingName == "SupplierID") {
				e.Column.HeaderText = "Supplier ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "ProductID") {
				e.Column.HeaderText = "Product ID";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "ProductName") {
				e.Column.HeaderText = "Product Name";
				e.Column.TextMargin = 15;
				e.Column.TextAlignment = UITextAlignment.Left;
			} else if (e.Column.MappingName == "QuantityPerUnit") {
				e.Column.HeaderText = "Quantity Per Unit";
				e.Column.TextAlignment = UITextAlignment.Center;
			} else if (e.Column.MappingName == "UnitPrice") {
				e.Column.TextAlignment = UITextAlignment.Center;
				e.Column.Format = "C";
				e.Column.CultureInfo = new CultureInfo ("en-US");
				e.Column.HeaderText = "Unit Price";
			} else if (e.Column.MappingName == "UnitsInStock") {
				e.Column.TextAlignment = UITextAlignment.Center;
				e.Column.HeaderText = "Units In Stock";
				if (!UserInterfaceIdiomIsPhone) {
					e.Column.Width = (double)(this.Frame.Width - ((this.sfGrid.View.GetItemProperties().Count -1) * this.sfGrid.DefaultColumnWidth));
				}
			}
        }

        #endregion

    }

}