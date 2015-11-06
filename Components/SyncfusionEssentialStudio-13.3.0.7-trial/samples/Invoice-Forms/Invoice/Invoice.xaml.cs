#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using XamarinIOInvoice;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.XlsIO;

namespace XamarinIOInvoice
{
    public partial class Invoice
    {
        List<string> namelist, numberlist, ratelist, taxlist, amountlist;
        
        public Invoice()
        {
            InitializeComponent();
            InitializeComponent();
            namelist = new List<string>();
            numberlist = new List<string>();
            ratelist = new List<string>();
            taxlist = new List<string>();
            amountlist = new List<string>();
            var listValue = GetDataSource();

            for (int i = 0; i < 5; i++)
            {
                 namelist.Add(listValue[i].ItemName);
                 numberlist.Add(listValue[i].Quantity.ToString());
                 ratelist.Add("$" + listValue[i].Rate.ToString());
                 taxlist.Add(listValue[i].Taxes.ToString()+"%");
                 amountlist.Add("$"+listValue[i].TotalAmount.ToString());

            }

          
            listView.ItemsSource = namelist;           
            numbersView.ItemsSource = numberlist;            
            RateView.ItemsSource = ratelist;         
            TaxView.ItemsSource = taxlist;          
            AmountView.ItemsSource = amountlist;

            listView.ItemSelected += listView_ItemSelected;
            numbersView.ItemSelected += numbersView_ItemSelected;
            RateView.ItemSelected += RateView_ItemSelected;
            TaxView.ItemSelected += TaxView_ItemSelected;
            AmountView.ItemSelected += AmountView_ItemSelected;

            
        }


        void AmountView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem.ToString() == "$904")
            {
                listView.SelectedItem = namelist[0];
                numbersView.SelectedItem = numberlist[0];
                TaxView.SelectedItem = taxlist[0];
                RateView.SelectedItem = ratelist[0];
            }
            if (e.SelectedItem.ToString() == "$1810")
            {
                listView.SelectedItem = namelist[1];
                numbersView.SelectedItem = numberlist[1];
                TaxView.SelectedItem = taxlist[1];
                RateView.SelectedItem = ratelist[1];
            }
            if (e.SelectedItem.ToString() == "$2718")
            {
                listView.SelectedItem = namelist[2];
                numbersView.SelectedItem = numberlist[2];
                TaxView.SelectedItem = taxlist[2];
                RateView.SelectedItem = ratelist[2];
            }
            if (e.SelectedItem.ToString() == "$3628")
            {
                listView.SelectedItem = namelist[3];
                numbersView.SelectedItem = numberlist[3];
                TaxView.SelectedItem = taxlist[3];
                RateView.SelectedItem = ratelist[3];
            }
            if (e.SelectedItem.ToString() == "$4540")
            {
                listView.SelectedItem = namelist[4];
                numbersView.SelectedItem = numberlist[4];
                TaxView.SelectedItem = taxlist[4];
                RateView.SelectedItem = ratelist[4];
            }
        }

        void TaxView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem.ToString() == "10%")
            {
                listView.SelectedItem = namelist[0];
                numbersView.SelectedItem = numberlist[0];
                RateView.SelectedItem = ratelist[0];
                AmountView.SelectedItem = amountlist[0];
            }
            if (e.SelectedItem.ToString() == "20%")
            {
                listView.SelectedItem = namelist[1];
                numbersView.SelectedItem = numberlist[1];
                RateView.SelectedItem = ratelist[1];
                AmountView.SelectedItem = amountlist[1];
            }
            if (e.SelectedItem.ToString() == "30%")
            {
                listView.SelectedItem = namelist[2];
                numbersView.SelectedItem = numberlist[2];
                RateView.SelectedItem = ratelist[2];
                AmountView.SelectedItem = amountlist[2];
            }
            if (e.SelectedItem.ToString() == "40%")
            {
                listView.SelectedItem = namelist[3];
                numbersView.SelectedItem = numberlist[3];
                RateView.SelectedItem = ratelist[3];
                AmountView.SelectedItem = amountlist[3];
            }
            if (e.SelectedItem.ToString() == "50%")
            {
                listView.SelectedItem = namelist[4];
                numbersView.SelectedItem = numberlist[4];
                RateView.SelectedItem = ratelist[4];
                AmountView.SelectedItem = amountlist[4];
            }
        }

        void RateView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem.ToString() == "$895")
            {
                listView.SelectedItem = namelist[0];
                numbersView.SelectedItem = numberlist[0];
                TaxView.SelectedItem = taxlist[0];
                AmountView.SelectedItem = amountlist[0];
            }
            if (e.SelectedItem.ToString() == "$896")
            {
                listView.SelectedItem = namelist[1];
                numbersView.SelectedItem = numberlist[1];
                TaxView.SelectedItem = taxlist[1];
                AmountView.SelectedItem = amountlist[1];
            }
            if (e.SelectedItem.ToString() == "$897")
            {
                listView.SelectedItem = namelist[2];
                numbersView.SelectedItem = numberlist[2];
                TaxView.SelectedItem = taxlist[2];
                AmountView.SelectedItem = amountlist[2];
            }
            if (e.SelectedItem.ToString() == "$898")
            {
                listView.SelectedItem = namelist[3];
                numbersView.SelectedItem = numberlist[3];
                TaxView.SelectedItem = taxlist[3];
                AmountView.SelectedItem = amountlist[3];
            }
            if (e.SelectedItem.ToString() == "$899")
            {
                listView.SelectedItem = namelist[4];
                numbersView.SelectedItem = numberlist[4];
                TaxView.SelectedItem = taxlist[4];
                AmountView.SelectedItem = amountlist[4];
            }
        }

        void numbersView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem.ToString() == "1")
            {
                listView.SelectedItem = namelist[0];
                RateView.SelectedItem = ratelist[0];
                TaxView.SelectedItem = taxlist[0];
                AmountView.SelectedItem = amountlist[0];
            }
            if (e.SelectedItem.ToString() == "2")
            {
                listView.SelectedItem = namelist[1];
                RateView.SelectedItem = ratelist[1];
                TaxView.SelectedItem = taxlist[1];
                AmountView.SelectedItem = amountlist[1];
            }
            if (e.SelectedItem.ToString() == "3")
            {
                listView.SelectedItem = namelist[2];
                RateView.SelectedItem = ratelist[2];
                TaxView.SelectedItem = taxlist[2];
                AmountView.SelectedItem = amountlist[2];
            }
            if (e.SelectedItem.ToString() == "4")
            {
                listView.SelectedItem = namelist[3];
                RateView.SelectedItem = ratelist[3];
                TaxView.SelectedItem = taxlist[3];
                AmountView.SelectedItem = amountlist[3];
            }
            if (e.SelectedItem.ToString() == "5")
            {
                listView.SelectedItem = namelist[4];
                RateView.SelectedItem = ratelist[4];
                TaxView.SelectedItem = taxlist[4];
                AmountView.SelectedItem = amountlist[4];
            }
        }

        void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == "Grid")
            {
                numbersView.SelectedItem = numberlist[0];
                RateView.SelectedItem = ratelist[0];
                TaxView.SelectedItem = taxlist[0];
                AmountView.SelectedItem = amountlist[0];
            }
            if (e.SelectedItem == "Maps")
            {
                numbersView.SelectedItem = numberlist[1];
                RateView.SelectedItem = ratelist[1];
                TaxView.SelectedItem = taxlist[1];
                AmountView.SelectedItem = amountlist[1];
            }
            if (e.SelectedItem == "PDF")
            {
                numbersView.SelectedItem = numberlist[2];
                RateView.SelectedItem = ratelist[2];
                TaxView.SelectedItem = taxlist[2];
                AmountView.SelectedItem = amountlist[2];
            }
            if (e.SelectedItem == "Edit")
            {
                numbersView.SelectedItem = numberlist[3];
                RateView.SelectedItem = ratelist[3];
                TaxView.SelectedItem = taxlist[3];
                AmountView.SelectedItem = amountlist[3];
            }
            if (e.SelectedItem == "Chart")
            {
                numbersView.SelectedItem = numberlist[4];
                RateView.SelectedItem = ratelist[4];
                TaxView.SelectedItem = taxlist[4];
                AmountView.SelectedItem = amountlist[4];
            }

        }

        void Pdf_Clicked(object sender, EventArgs args)
        {
            PdfDocument document = new PdfDocument();
            document.PageSettings.Orientation = PdfPageOrientation.Landscape;
            document.PageSettings.Margins.All = 50;
            PdfPage page = document.Pages.Add();
            PdfGraphics g = page.Graphics;
            PdfTextElement element = new PdfTextElement(@"Syncfusion Software 
2501 Aerial Center Parkway 
Suite 200 Morrisville, NC 27560 USA 
Tel +1 888.936.8638 Fax +1 919.573.0306");
            element.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12);
            element.Brush = new PdfSolidBrush(new PdfColor(89, 89, 93));
            PdfLayoutResult result = element.Draw(page, new RectangleF(0, 0, page.Graphics.ClientSize.Width / 2, 200));
            Stream imgStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("XamarinIOInvoice.SyncfusionLogo.jpg");
            PdfImage img = PdfImage.FromStream(imgStream);
            page.Graphics.DrawImage(img, new RectangleF(g.ClientSize.Width - 200, result.Bounds.Y, 190, 45));
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            g.DrawRectangle(new PdfSolidBrush(new PdfColor(126, 151, 173)), new RectangleF(0, result.Bounds.Bottom + 40, g.ClientSize.Width, 20));


            PdfGrid grid = new PdfGrid();
            grid.DataSource = GetDataSource();
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            PdfGridRow header = grid.Headers[0];

            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular);

            for (int i = 0; i < header.Cells.Count; i++)
            {
                if (i == 0)
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                else
                    header.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            }

            header.ApplyStyle(headerStyle);
            cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f);
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));
            foreach (PdfGridRow row in grid.Rows)
            {
                row.ApplyStyle(cellStyle);
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    PdfGridCell cell = row.Cells[i];
                    if (i == 0)
                        cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Left, PdfVerticalAlignment.Middle);
                    else
                        cell.StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

                    if (i > 1)
                    {
                        float val = float.MinValue;
                        float.TryParse(cell.Value.ToString(), out val);
                        cell.Value = "$" + val.ToString();
                    }
                }
            }

            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;

            PdfGridLayoutResult gridResult = grid.Draw(page, new RectangleF(new Syncfusion.Drawing.PointF(0, result.Bounds.Bottom + 40), new Syncfusion.Drawing.SizeF(g.ClientSize.Width, g.ClientSize.Height - 100)), layoutFormat);
            float pos = 0.0f;
            for (int i = 0; i < grid.Columns.Count - 1; i++)
                pos += grid.Columns[i].Width;

            PdfFont font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f);

            gridResult.Page.Graphics.DrawString("Total Due", font, new PdfSolidBrush(new PdfColor(126, 151, 173)), new RectangleF(new Syncfusion.Drawing.PointF(pos, gridResult.Bounds.Bottom + 20), new Syncfusion.Drawing.SizeF(grid.Columns[3].Width - pos, 20)), new PdfStringFormat(PdfTextAlignment.Right));
            gridResult.Page.Graphics.DrawString("Thank you for your business!", new PdfStandardFont(PdfFontFamily.TimesRoman, 12), new PdfSolidBrush(new PdfColor(89, 89, 93)), new Syncfusion.Drawing.PointF(pos - 55, gridResult.Bounds.Bottom + 60));
            pos += grid.Columns[4].Width;
            gridResult.Page.Graphics.DrawString("$13600", font, new PdfSolidBrush(new PdfColor(131, 130, 136)), new RectangleF(new Syncfusion.Drawing.PointF(pos, gridResult.Bounds.Bottom + 20), new Syncfusion.Drawing.SizeF(grid.Columns[4].Width - pos, 20)), new PdfStringFormat(PdfTextAlignment.Right));


            MemoryStream data = new MemoryStream();

            document.Save(data);

            document.Close();

            DependencyService.Get<ISave>().SaveTextAsync("Invoice.pdf", "application/pdf", data);
          

        }
        void Word_Clicked(object sender, EventArgs args)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream inputStream = assembly.GetManifestResourceStream("XamarinIOInvoice.Template.docx");
            //Load Template document stream
            // Stream inputStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Showcase.InvoiceGenerater.Assets.Template.docx");
            //Create instance
            WordDocument document = new WordDocument();
            //Open Template document
            document.Open(inputStream, FormatType.Doc);
            //Dispose input stream
            inputStream.Dispose();

            //Set Clear Fields to false
            document.MailMerge.ClearFields = false;
            //Create Mail Merge Data Table
            MailMergeDataTable mailMergeDataTable = new MailMergeDataTable("Invoice", GetDataSource());
            //Executes mail merge using the data generated in the app.
            document.MailMerge.ExecuteGroup(mailMergeDataTable);

            //Mail Merge Billing information
            string[] fieldNames = { "Name", "Address", "Date", "InvoiceNumber", "DueDate", "TotalDue" };
            string[] fieldValues = { Customer.CustomerName, Customer.Address, Customer.Date, Customer.Number, DateTime.Now.ToString("d"), "13600" };
            document.MailMerge.Execute(fieldNames, fieldValues);

            MemoryStream data = new MemoryStream();

            document.Save(data, FormatType.Docx);

            document.Close();
            DependencyService.Get<ISave>().SaveTextAsync("Invoice.docx", "application/msword", data);
          
        }
        void Excel_Clicked(object sender, EventArgs args)
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream inputStream = executingAssembly.GetManifestResourceStream("XamarinIOInvoice.InvoiceTemplate.xlsx");
            IWorkbook book = null;

            ExcelEngine excelEngine = new ExcelEngine();
            book = excelEngine.Excel.Workbooks.Open(inputStream);
            inputStream.Dispose();
            IWorksheet sheet = book.Worksheets[0];

            //Create Template Marker Processor
            ITemplateMarkersProcessor marker = book.CreateTemplateMarkersProcessor();
            //Binding the business object with the marker.
            marker.AddVariable("InvoiceItem", GetDataSource());
            //Applies the marker.
            marker.ApplyMarkers(UnknownVariableAction.Skip);
           
			sheet ["I18"].Number = 13600;
            
            MemoryStream data = new MemoryStream();

            book.SaveAs(data);

            book.Close();
            DependencyService.Get<ISave>().SaveTextAsync("Invoice.xlsx", "application/msexcel", data);
        }

        public IList<InvoiceItem> GetDataSource()
        {
            List<InvoiceItem> items = new List<InvoiceItem>();
           
            //    InvoiceItem item = new InvoiceItem();
            //    item.ItemName="Grid";
            //    item.Quantity = "1";
            //    item.Rate = "895";
            //    item.Taxes = "10";
            //    item.TotalAmount = "904";
            //    items.Add(item);

            //     item = new InvoiceItem();
            //    item.ItemName = "Maps";
            //    item.Quantity = "2";
            //    item.Rate = "896";
            //    item.Taxes = "20";
            //    item.TotalAmount = "1810";
            //    items.Add(item);

            //     item = new InvoiceItem();
            //    item.ItemName = "PDF";
            //    item.Quantity = "3";
            //    item.Rate = "897";
            //    item.Taxes = "30";
            //    item.TotalAmount = "2718";
            //    items.Add(item);

            //     item = new InvoiceItem();
            //    item.ItemName = "Edit";
            //    item.Quantity = 4;
            //    item.Rate =898;
            //    item.Taxes = 40;
            //    item.TotalAmount = 3628;
            //    items.Add(item);

            //     item = new InvoiceItem();
            //    item.ItemName = "Chart";
            //    item.Quantity = 5;
            //    item.Rate = 899;
            //    item.Taxes = 50;
            //    item.TotalAmount = 4540;
            //    items.Add(item);

   
          
            return items;
        }
    }
}
