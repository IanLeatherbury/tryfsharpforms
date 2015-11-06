#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using CoreGraphics;
using Foundation;
using QuickLook;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.SfDataGrid;
using Syncfusion.SfDataGrid.Exporting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Reflection;
using UIKit;

namespace SampleBrowser
{
    public class Exporting : SampleView
    {
        #region Fields

        SfDataGrid SfGrid;
        UIButton exportPdf;
        UIButton exportExcel;
        UILabel excelText;
        UILabel pdfText;
        #endregion

        static bool UserInterfaceIdiomIsPhone
        {
            get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
        }

        public Exporting()
        {
            this.SfGrid = new SfDataGrid();
            this.SfGrid.AutoGeneratingColumn += GridAutoGenerateColumns;
            this.SfGrid.ItemsSource = new ExportingViewModel().OrdersInfo;
            this.SfGrid.ShowRowHeader = false;
            this.SfGrid.HeaderRowHeight = 45;
            this.SfGrid.RowHeight = 45;
            this.SfGrid.AlternatingRowColor = UIColor.FromRGB(219, 219, 219);
            exportPdf = new UIButton(UIButtonType.RoundedRect);
            exportPdf.SetBackgroundImage(UIImage.FromFile("Images/pdfexport.png"), UIControlState.Normal);
            exportExcel = new UIButton(UIButtonType.RoundedRect);
            exportExcel.SetBackgroundImage(UIImage.FromFile("Images/excelexport.png"), UIControlState.Normal);
            exportPdf.TouchDown += ExportToPdf;
            exportExcel.TouchDown += ExportToExcel;
            excelText = new UILabel() { Text = "Export To Excel",TextAlignment = UITextAlignment.Left, TextColor = UIColor.Black, Font = UIFont.FromName("Helvetica-Bold", 12f) };
            pdfText = new UILabel() { Text = "Export To Pdf", TextAlignment = UITextAlignment.Left,TextColor = UIColor.Black, Font = UIFont.FromName("Helvetica-Bold", 12f) };
            this.control = this;
            this.AddSubview(exportExcel);
            this.AddSubview(excelText);
            this.AddSubview(exportPdf);
            this.AddSubview(pdfText);
            this.AddSubview(this.SfGrid);
        }

        private void ExportToExcel(object sender, EventArgs e)
        {
            DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
            var excelEngine = excelExport.ExportToExcel(this.SfGrid , new DataGridExcelExportingOption() {ExportRowHeight = false,ExportColumnWidth = false , DefaultColumnWidth = 100, DefaultRowHeight =  60});
            var workbook = excelEngine.Excel.Workbooks[0];
            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();
            Save("DataGrid.xlsx", "application/msexcel", stream);
        }

        private void ExportToPdf(object sender, EventArgs e)
        {
            DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
            MemoryStream stream = new MemoryStream();
            pdfExport.HeaderAndFooterExporting += pdfExport_HeaderAndFooterExporting;
            var doc = pdfExport.ExportToPdf(this.SfGrid);
            doc.Save(stream);
            doc.Close(true);
            Save("DataGrid.pdf", "application/pdf", stream);
        }

        private void pdfExport_HeaderAndFooterExporting(object sender, PdfHeaderFooterEventArgs e)
        {
            var width = e.PdfPage.GetClientSize().Width;

            PdfPageTemplateElement header = new PdfPageTemplateElement(width, 60);
            var assmbely = Assembly.GetExecutingAssembly();
            var imagestream = assmbely.GetManifestResourceStream("SampleBrowser.Resources.Images.SyncfusionLogo.jpg");
            PdfImage pdfImage = PdfImage.FromStream(imagestream);
            header.Graphics.DrawImage(pdfImage, new RectangleF(0, 0, width, 50));
            e.PdfDocumentTemplate.Top = header;
        }


        private void Save(string filename, string contentType, MemoryStream stream)
        {
            string exception = string.Empty;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, filename);
            try
            {
                FileStream fileStream = File.Open(filePath, FileMode.Create);
                stream.Position = 0;
                stream.CopyTo(fileStream);
                fileStream.Flush();
                fileStream.Close();
            }
            catch (Exception e)
            {
                exception = e.ToString();
            }
            if (contentType == "application/html" || exception != string.Empty)
                return;
            UIViewController currentController = UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (currentController.PresentedViewController != null)
                currentController = currentController.PresentedViewController;
            UIView currentView = currentController.View;

            QLPreviewController qlPreview = new QLPreviewController();
            QLPreviewItem item = new QLPreviewItemBundle(filename, filePath);
            qlPreview.DataSource = new PreviewControllerDS(item);

            currentController.PresentViewController((UIViewController)qlPreview, true, (Action)null);
        }

        void GridAutoGenerateColumns(object sender, AutoGeneratingColumnArgs e)
        {
            if (e.Column.MappingName == "OrderID")
            {
                e.Column.HeaderText = "Order ID";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "CustomerID")
            {
                e.Column.HeaderText = "Customer ID";
                e.Column.TextMargin = 20;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "Freight")
            {
                e.Column.Format = "C";
                e.Column.CultureInfo = new CultureInfo("en-US");
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "ShipCity")
            {
                e.Column.HeaderText = "Ship City";
                e.Column.TextMargin = 10;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "ShipCountry")
            {
                e.Column.HeaderText = "Ship Country";
                e.Column.TextMargin = 20;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "Index")
            {
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "EmployeeID")
            {
                e.Column.HeaderText = "Employee ID";
                e.Column.TextAlignment = UITextAlignment.Center;
            }
            else if (e.Column.MappingName == "FirstName")
            {
                e.Column.HeaderText = "First Name";
                e.Column.TextMargin = 20;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "LastName")
            {
                e.Column.HeaderText = "Last Name";
                e.Column.TextMargin = 20;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
            else if (e.Column.MappingName == "Gender")
            {
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.TextMargin = 20;
            }
            else if (e.Column.MappingName == "ShippingDate")
            {
                e.Column.HeaderText = "Shipping Date";
                e.Column.TextMargin = 15;
                e.Column.TextAlignment = UITextAlignment.Left;
                e.Column.Format = "d";
            }
            else if (e.Column.MappingName == "IsClosed")
            {
                e.Column.HeaderText = "Is Closed";
                e.Column.TextMargin = 30;
                e.Column.TextAlignment = UITextAlignment.Left;
            }
        }

        public override void LayoutSubviews()
        {
            this.exportPdf.Frame = new CGRect(0, 0, 50, 50);
            this.pdfText.Frame = new CGRect(55, 0,(this.Frame.Width/2)-10, 50);
            this.exportExcel.Frame = new CGRect(this.Frame.Width / 2, 0, 50, 50);
            this.excelText.Frame = new CGRect(this.Frame.Width / 2 + 55, 0, (this.Frame.Width / 2) - 10, 50);
            this.SfGrid.Frame = new CGRect(0, 55, this.Frame.Width, this.Frame.Height - 55);
            base.LayoutSubviews();
        }
    }

    public class PreviewControllerDS : QLPreviewControllerDataSource
    {
        private QLPreviewItem _item;

        public PreviewControllerDS(QLPreviewItem item)
        {
            _item = item;
        }

        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return (nint)1;
        }

        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return _item;
        }
    }

    public class QLPreviewItemFileSystem : QLPreviewItem
    {
        string _fileName, _filePath;

        public QLPreviewItemFileSystem(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public override string ItemTitle
        {
            get
            {
                return _fileName;
            }
        }
        public override NSUrl ItemUrl
        {
            get
            {
                return NSUrl.FromFilename(_filePath);
            }
        }
    }

    public class QLPreviewItemBundle : QLPreviewItem
    {
        string _fileName, _filePath;
        public QLPreviewItemBundle(string fileName, string filePath)
        {
            _fileName = fileName;
            _filePath = filePath;
        }

        public override string ItemTitle
        {
            get
            {
                return _fileName;
            }
        }
        public override NSUrl ItemUrl
        {
            get
            {
                var documents = NSBundle.MainBundle.BundlePath;
                var lib = Path.Combine(documents, _filePath);
                var url = NSUrl.FromFilename(lib);
                return url;
            }
        }
    }
}
