#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class FormulasPage : SamplePage
    {
        public FormulasPage()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                this.SampleTitle.HorizontalOptions = LayoutOptions.Start;
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.Content_1.HorizontalOptions = LayoutOptions.Start;
                this.Content_2.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;

                this.SampleTitle.VerticalOptions = LayoutOptions.Center;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.Content_2.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
            else if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                this.Description.FontSize = 18.5;
                this.Content_1.FontSize = 18.5;
                this.Content_2.FontSize = 18.5;
                this.SampleTitle.VerticalOptions = LayoutOptions.Center;
                this.Description.VerticalOptions = LayoutOptions.Center;
                this.Content_1.VerticalOptions = LayoutOptions.Center;
                this.Content_2.VerticalOptions = LayoutOptions.Center;
                this.btnGenerate.VerticalOptions = LayoutOptions.Center;
            }
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            ExcelEngine excelEngine = new ExcelEngine();
            IApplication application = excelEngine.Excel;
            application.DefaultVersion = ExcelVersion.Excel2013;

            #region Initializing Workbook
            //A new workbook is created.[Equivalent to creating a new workbook in MS Excel]
            //The new workbook will have 1 worksheet
            IWorkbook workbook = application.Workbooks.Create(1);

            //The first worksheet object in the worksheets collection is accessed.
            IWorksheet sheet = workbook.Worksheets[0];
            #endregion

            #region Generate Excel
            #region Insert Array Formula

            sheet.EnableSheetCalculations();

            sheet.Range["A2"].Text = "Array formulas";
            sheet.Range["B2:E2"].Number = 3;
            sheet.Names.Add("ArrayRange", sheet.Range["B2:E2"]);
            sheet.Range["B3:E3"].Number = 5;
            sheet.Range["A2"].CellStyle.Font.Bold = true;
            sheet.Range["A2"].CellStyle.Font.Size = 14;
            #endregion

            #region Excel functions
            sheet.Range["A5"].Text = "Formulas";
            sheet.Range["B5"].Text = "Results";
            sheet.Range["B5:C5"].Merge();
            sheet.Range["B5:C5"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;

            sheet.Range["A7"].Text = "ABS(ABS(-B3))";
            sheet.Range["B7"].Formula = "ABS(ABS(-B3))";

            sheet.Range["A9"].Text = "SUM(B3,C3)";
            sheet.Range["B9"].Formula = "SUM(B3,C3)";

            sheet.Range["A11"].Text = "MIN(10,20,30,5,15,35,6,16,36)";
            sheet.Range["B11"].Formula = "MIN(10,20,30,5,15,35,6,16,36)";

            sheet.Range["A13"].Text = "MAX(10,20,30,5,15,35,6,16,36)";
            sheet.Range["B13"].Formula = "MAX(10,20,30,5,15,35,6,16,36)";

            sheet.Range["A5:B5"].CellStyle.Font.Bold = true;
            sheet.Range["A5:B5"].CellStyle.Font.Size = 14;
            #endregion

            #region Simple formulas
            sheet.Range["C7"].Number = 10;
            sheet.Range["C9"].Number = 10;
            sheet.Range["A15"].Text = "C7+C9";
            sheet.Range["C15"].Formula = "C7+C9";
            #endregion


            sheet.Range["A1"].Text = "Excel formula support";
            sheet.Range["A1"].CellStyle.Font.Bold = true;
            sheet.Range["A1"].CellStyle.Font.Size = 14;
            sheet.Range["A1"].CellStyle.HorizontalAlignment = ExcelHAlign.HAlignCenter;
            sheet.Range["A1"].CellStyle.VerticalAlignment = ExcelVAlign.VAlignCenter;
            sheet.Range["A1:C1"].Merge();

            sheet.Columns[0].ColumnWidth = 23;
            sheet.Columns[1].ColumnWidth = 10;
            sheet.Columns[2].ColumnWidth = 10;
            sheet.Columns[3].ColumnWidth = 10;
            sheet.Columns[4].ColumnWidth = 10;
            #endregion

            workbook.Version = ExcelVersion.Excel2013;

            MemoryStream stream = new MemoryStream();
            workbook.SaveAs(stream);
            workbook.Close();
            excelEngine.Dispose();

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Formulas.xlsx", "application/msexcel", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Formulas.xlsx", "application/msexcel", stream);
        }
    }



}
