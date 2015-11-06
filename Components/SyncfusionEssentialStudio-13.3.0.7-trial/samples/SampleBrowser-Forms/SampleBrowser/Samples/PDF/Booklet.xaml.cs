#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Reflection;

namespace SampleBrowser
{
    public partial class Booklet
    {
        public Booklet()
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
            float width = 1224;
            float height = 792;

            PdfDocument document = PdfBookletCreator.CreateBooklet(ldoc, new SizeF(width, height), true);
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("Booklet.pdf", "application/pdf", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("Booklet.pdf", "application/pdf", stream);

        }
    }
}
