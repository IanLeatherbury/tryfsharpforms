#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class WordToHTML : SamplePage
    {
        public WordToHTML()
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
            Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            // Creating a new document.
            WordDocument document = new WordDocument();
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.WordtoHTML.doc");
            //Open the Word document to convert
            document.Open(inputStream, FormatType.Doc);
            //Export the Word document to HTML file
            MemoryStream stream = new MemoryStream();
            HTMLExport htmlExport = new HTMLExport();
            htmlExport.SaveAsXhtml(document, stream);
            document.Close();

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("WordtoHTML.html", "application/html", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("WordtoHTML.html", "application/html", stream);
            if (!(Device.Idiom != TargetIdiom.Phone && Device.OS == TargetPlatform.Windows))
            {
                //Set the stream to start position to read the content as string
                stream.Position = 0;
                StreamReader reader = new StreamReader(stream);
                string htmlString = reader.ReadToEnd();

                //Set the HtmlWebViewSource to the html string
                HtmlWebViewSource html = new HtmlWebViewSource();
                html.Html = htmlString;

                //Create the web view control to view the web page
                WebView view = new WebView();
                view.Source = html;
                ContentPage webpage = new ContentPage();
                webpage.Content = view;
                this.ContentView.Navigation.PushAsync(webpage);
            }
        }
    }
}
