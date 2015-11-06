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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinIOInvoice.Views
{
    public partial class InfoView
    {
        public InfoView()
        {
            InitializeComponent();
            this.InfolistView.ItemsSource = GetDataSource();

			this.InfoLayout.Padding = Device.OnPlatform(iOS: new Thickness(0, 25, 0, 0), Android: new Thickness(0, 0, 0, 0), WinPhone: new Thickness(0, 0, 0, 0));

			this.InfolistView.IsVisible = Device.OnPlatform (iOS: false, Android: true, WinPhone: true);
			this.Info.IsVisible = Device.OnPlatform (iOS: true, Android: false, WinPhone: false);
        }

        # region Methods / Events

        public IList<ProductInfo> GetDataSource()
        {
            List<ProductInfo> items = new List<ProductInfo>();

            ProductInfo item = new ProductInfo();
            item.ProductName = "INVOICE";
            item.Description = @"This application provides a simple invoice generation which has export functionality to different file formats such as PDF, Excel and Word.  The following assemblies are referred to generate the invoice.

    * Syncfusion.Compression.Portable
	* Syncfusion.Pdf.Portable
	* Syncfusion.XlsIO.Portable
	* Syncfusion.DocIO.Portable

Essential PDF makes it possible to easily create richly formatted PDF documents as well as modify existing ones. Essential XlsIO creates and manipulates Microsoft Excel files, which can be used on systems that do not have Microsoft Excel installed, making it an excellent report engine for tabular data. Essential DocIO allows creation and manipulation of Microsoft Word files without any dependencies of Microsoft Word. It enables users to create richly formatted Microsoft Word reports.";
            items.Add(item);

            return items;
        }

        #endregion
    }
}
