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

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.SfDataGrid;
using System.Globalization;
using Syncfusion.SfDataGrid.Exporting;
using System.Reflection;
using System.IO;
using Java.IO;
using Android.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;

namespace SampleBrowser
{
    public class Exporting : SamplePage
    {

        #region Field
        SfDataGrid sfGrid;
        ExportingViewModel viewModel;
        ImageButton exportPdf;
        ImageButton exportExcel;
        private List<String> item = null;
        private List<String> path = null;
        private String root;
        private TextView myPath;
        #endregion

        public override Android.Views.View GetSampleContent(Context context)
        {
            sfGrid = new SfDataGrid(context);
            viewModel = new ExportingViewModel();
            sfGrid.AutoGeneratingColumn += GridGenerateColumns;
            sfGrid.ItemsSource = (viewModel.OrdersInfo);
            exportPdf = new ImageButton(context);
            exportPdf.SetMaxHeight(30);
            exportPdf.SetMaxWidth(30);
            exportPdf.SetBackgroundColor(Android.Graphics.Color.Transparent); 
            exportPdf.SetImageResource(Resource.Drawable.pdfexport);
            exportPdf.SetScaleType(ImageView.ScaleType.FitXy);
            exportPdf.LayoutParameters = new ViewGroup.LayoutParams( 120,120);
            exportPdf.Click += ExportToPdf;
            exportExcel = new ImageButton(context);
            exportExcel.SetMaxHeight(30);
            exportExcel.SetMaxWidth(30);
            exportExcel.SetBackgroundColor(Android.Graphics.Color.Transparent);
            exportExcel.SetImageResource(Resource.Drawable.excelexport);
            exportExcel.SetScaleType(ImageView.ScaleType.FitXy);
            exportExcel.LayoutParameters = new ViewGroup.LayoutParams(120, 120);
            exportExcel.Click += ExportToExcel;

            LinearLayout option = new LinearLayout(context);
            option.SetGravity(GravityFlags.Center);
            option.Orientation = Android.Widget.Orientation.Horizontal;
            var pdftext = new TextView(context) { Text = "Export to Pdf" };
            pdftext.SetTypeface(null, TypefaceStyle.Bold);
            var exceltext = new TextView(context) { Text = "Export to Excel" };
            exceltext.SetTypeface(null, TypefaceStyle.Bold);
            option.AddView(exportPdf);         
            option.AddView(pdftext);
            option.AddView(exportExcel);
            option.AddView(exceltext);
            
            LinearLayout mainView = new LinearLayout(context);
            mainView.Orientation = Android.Widget.Orientation.Vertical;
            mainView.AddView(option);
            mainView.AddView(sfGrid);
            return mainView;
        }

        private void ExportToExcel(object sender, EventArgs e)
        {
            DataGridExcelExportingController excelExport = new DataGridExcelExportingController();
            var excelEngine = excelExport.ExportToExcel(this.sfGrid, new DataGridExcelExportingOption() { ExportRowHeight = false, ExportColumnWidth = false, DefaultColumnWidth = 100, DefaultRowHeight = 60 });
            var workbook = excelEngine.Excel.Workbooks[0];
            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();
            Save("DataGrid.xlsx", "application/msexcel", stream , sfGrid.Context);
        }

        private void ExportToPdf(object sender, EventArgs e)
        {
            DataGridPdfExportingController pdfExport = new DataGridPdfExportingController();
            pdfExport.HeaderAndFooterExporting += pdfExport_HeaderAndFooterExporting;
            MemoryStream stream = new MemoryStream();
            var doc = pdfExport.ExportToPdf(this.sfGrid);
            doc.Save(stream);
            doc.Close(true);
            Save("DataGrid.pdf", "application/pdf", stream, sfGrid.Context);
        }

        private void pdfExport_HeaderAndFooterExporting(object sender, PdfHeaderFooterEventArgs e)
        {
            var width = e.PdfPage.GetClientSize().Width;

            PdfPageTemplateElement header = new PdfPageTemplateElement(width, 60);
            var assmbely = Assembly.GetExecutingAssembly();
            var imagestream = assmbely.GetManifestResourceStream("SampleBrowser.Resources.drawable.SyncfusionLogo.jpg");
            if (imagestream != null)
            {
                PdfImage pdfImage = PdfImage.FromStream(imagestream);
                header.Graphics.DrawImage(pdfImage, new RectangleF(0, 0, width, 50));
                e.PdfDocumentTemplate.Top = header;
            }
        }

        public void Save(string fileName, String contentType, MemoryStream stream , Context context)
        {
            string exception = string.Empty;
            string root = null;
            if (Android.OS.Environment.IsExternalStorageEmulated)
            {
                root = Android.OS.Environment.ExternalStorageDirectory.ToString();
            }
            else
                root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            Java.IO.File myDir = new Java.IO.File(root + "/Syncfusion");
            myDir.Mkdir();

            Java.IO.File file = new Java.IO.File(myDir, fileName);

            if (file.Exists())
            {
                file.Delete();
                file.CreateNewFile();
            }
            try
            {
                FileOutputStream outs = new FileOutputStream(file, false);
                outs.Write(stream.ToArray());

                outs.Flush();
                outs.Close();
            }
            catch (Exception e)
            {
                exception = e.ToString();
            }
            if (file.Exists() && contentType != "application/html")
            {
                Android.Net.Uri path = Android.Net.Uri.FromFile(file);
                string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
                string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(path, mimeType);
                context.StartActivity(Intent.CreateChooser(intent, "Choose App"));

            }
        }

        private void getDir(String dirPath, Context context)
        {
            myPath.Text = "Location: " + dirPath;
            item = new List<String>();
            path = new List<String>();
            Java.IO.File f = new Java.IO.File(dirPath);
            Java.IO.File[] files = f.ListFiles();

            if (!dirPath.Equals(root))
            {
                item.Add(root);
                path.Add(root);
                item.Add("../");
                path.Add(f.Parent);
            }

            for (int i = 0; i < files.Length; i++)
            {
                Java.IO.File file = files[i];

                if (!file.IsHidden && file.CanRead())
                {
                    path.Add(file.Path);
                    if (file.IsDirectory)
                    {
                        item.Add(file.Name + "/");
                    }
                    else
                    {
                        item.Add(file.Name);
                    }
                }
            }

            ArrayAdapter<String> fileList =
              new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleListItem1, item);
        }

        void GridGenerateColumns(object sender, AutoGeneratingColumnArgs e)
        {
            if (e.Column.MappingName == "OrderID")
            {
                e.Column.HeaderText = "Order ID";
            }
            else if (e.Column.MappingName == "CustomerID")
            {
                e.Column.HeaderText = "Customer ID";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "Freight")
            {
                e.Column.Format = "C";
                e.Column.CultureInfo = new CultureInfo("en-US");
                e.Column.TextAlignment = GravityFlags.Center;
            }
            else if (e.Column.MappingName == "ShipCity")
            {
                e.Column.HeaderText = "Ship City";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "ShipCountry")
            {
                e.Column.HeaderText = "Ship Country";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "EmployeeID")
            {
                e.Column.HeaderText = "Employee ID";
                e.Column.TextAlignment = GravityFlags.Center;
            }
            else if (e.Column.MappingName == "FirstName")
            {
                e.Column.HeaderText = "First Name";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "LastName")
            {
                e.Column.HeaderText = "Last Name";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "Gender")
            {
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
            else if (e.Column.MappingName == "ShippingDate")
            {
                e.Column.HeaderText = "Shipping Date";
                e.Column.Format = "d";
            }
            else if (e.Column.MappingName == "IsClosed")
            {
                e.Column.HeaderText = "Is Closed";
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            }
        }

        public override void Destroy()
        {
            sfGrid.AutoGeneratingColumn -= GridGenerateColumns;
            sfGrid.Dispose();
            sfGrid = null;
            viewModel = null;
        }

    }
}