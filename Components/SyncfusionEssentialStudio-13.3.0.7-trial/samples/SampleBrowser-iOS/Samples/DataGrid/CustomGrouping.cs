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

using CoreGraphics;
using Foundation;
using UIKit;
using Syncfusion.Linq;
using Syncfusion.SfDataGrid;

namespace SampleBrowser
{
    public class CustomGrouping : SampleView
    {
        #region Fields

        SfDataGrid sfGrid;
        SalesInfoViewModel viewModel;

        #endregion

        #region Static Methods

        static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

        #endregion

        #region Constructor

        public CustomGrouping ()
        {
            sfGrid = new SfDataGrid ();
            viewModel = new SalesInfoViewModel ();
            sfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            sfGrid.ItemsSource = viewModel.DailySalesDetails;
            sfGrid.AllowSorting = true;
            this.sfGrid.HeaderRowHeight = 45;
            this.sfGrid.RowHeight = 45;
            sfGrid.SortComparers.Add (new SortComparer() { Comparer = new CustomSortComparer (), PropertyName = "Total" });
            sfGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "Total", Converter = new GroupDataTimeConverter() });
            this.control = this;
            this.AddSubview (sfGrid);
        }

        #endregion

        #region Override Methods

        public override void LayoutSubviews ()
        {
            this.sfGrid.Frame = new CGRect (0, 0, this.Frame.Width, this.Frame.Height);
            base.LayoutSubviews ();
        }

        #endregion

        #region CallBacks

        private void GridAutoGenerateColumns(object sender, AutoGeneratingColumnArgs e)
        {
            if (e.Column.MappingName == "Name") {
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.TextMargin = 15;
            } else if (e.Column.MappingName == "QS1") {
                e.Column.HeaderText = "Sales in Quarter1";
            } else if (e.Column.MappingName == "QS2") {
                e.Column.HeaderText = "Sales in Quarter2";
            } else if (e.Column.MappingName == "QS3") {
                e.Column.HeaderText = "Sales in Quarter3";
            } else if (e.Column.MappingName == "QS4") {
                e.Column.HeaderText = "Sales in Quarter4";
            } else if (e.Column.MappingName == "Total") {
                e.Column.HeaderText = "Total Sales in Year";
            }
        }

        #endregion
    }
}