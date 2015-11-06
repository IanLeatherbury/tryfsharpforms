#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.SfDataGrid.XForms.Exporting;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.Drawing;

namespace SampleBrowser
{
    public partial class Exporting : SamplePage
    {
        #region Field

        private bool isExporting = false;

        #endregion 

        #region Constructor

        public Exporting()
        {
            InitializeComponent();
            this.dataGrid.ItemsSource = viewModel.OrdersInfo;
            excelImage.GestureRecognizers.Add(new TapGestureRecognizer(sender => { ExportToExcel(); }));
            pdfImage.GestureRecognizers.Add (new TapGestureRecognizer (sender => { ExportToPdf();}));
            excelImage.Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.ExportExcel.png");
            pdfImage.Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.ExportPdf.png");
        }

        #endregion 

        #region Exporting 

        private void ExportToExcel()
        {
            isExporting = true;
            DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
            DataGridExcelExportingOption exportOption = new DataGridExcelExportingOption();
            if(Device.OS == TargetPlatform.iOS)
            {
                exportOption.ExportColumnWidth = false;
                exportOption.DefaultColumnWidth = 150;
            }
            var excelEngine = excelExport.ExportToExcel(this.dataGrid,exportOption);
            var workbook = excelEngine.Excel.Workbooks[0];
            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("DataGrid.xlsx", "application/msexcel", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("DataGrid.xlsx", "application/msexcel", stream);
        }

        private void ExportToPdf()
        {
            isExporting = true;
            DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
            pdfExport.HeaderAndFooterExporting += pdfExport_HeaderAndFooterExporting;
            MemoryStream stream = new MemoryStream();
            var doc = pdfExport.ExportToPdf(this.dataGrid, new DataGridPdfExportOption() { FitAllColumnsInOnePage = true});
            doc.Save(stream);
            doc.Close(true);

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("DataGrid.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("DataGrid.pdf", "application/pdf", stream);
        }

        private void pdfExport_HeaderAndFooterExporting(object sender, PdfHeaderFooterEventArgs e)
        {
            var width = e.PdfPage.GetClientSize().Width;

            PdfPageTemplateElement header = new PdfPageTemplateElement(width, 60);
            var assmbely = this.GetType().GetTypeInfo().Assembly;
            var imagestream = assmbely.GetManifestResourceStream("SampleBrowser.Icons.DataGrid.SyncfusionLogo.jpg");
            PdfImage pdfImage = PdfImage.FromStream(imagestream);
            header.Graphics.DrawImage(pdfImage,new RectangleF(0,0,width,50));
            e.PdfDocumentTemplate.Top = header;
        }

        #endregion

        #region override

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (!IsPropertyViewVisible && !isExporting )
            {
                dataGrid.Dispose();
                dataGrid = null;
                viewModel = null;
            }
        }

        #endregion

    }

   
}
