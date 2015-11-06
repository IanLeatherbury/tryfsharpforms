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
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Parsing;
using System.Reflection;
using Xamarin.Forms;
using System.IO;

namespace SampleBrowser
{
    public partial class Stamping
    {
        public Stamping()
        {
            InitializeComponent();

            if (Device.Idiom != TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                this.SampleTitle.HorizontalOptions = LayoutOptions.Start;
                this.Description.HorizontalOptions = LayoutOptions.Start;
                this.btnGenerate.HorizontalOptions = LayoutOptions.Start;
          
            }
        }
        void OnButtonClicked(object sender, EventArgs e)
        {

            Stream docStream = typeof(App).GetTypeInfo().Assembly.GetManifestResourceStream("SampleBrowser.Samples.PDF.Assets.Syncfusion_Windows8_whitepaper.pdf");
            PdfLoadedDocument ldoc = new PdfLoadedDocument(docStream);

            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 100f, PdfFontStyle.Regular);

            foreach (PdfPageBase lPage in ldoc.Pages)
            {
                PdfGraphics g = lPage.Graphics;
                PdfGraphicsState state = g.Save();
                g.SetTransparency(0.25f);
                g.TranslateTransform(50, lPage.Size.Height / 2 );
                g.RotateTransform(-40);
                g.DrawString("Syncfusion", font, PdfPens.Red, PdfBrushes.Red, new PointF(0,0));
            }
            MemoryStream stream = new MemoryStream();
            ldoc.Save(stream);
            ldoc.Close(true);

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Stamping.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Stamping.pdf", "application/pdf", stream);
        }
    }
}
