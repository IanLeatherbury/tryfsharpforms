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
    public partial class BuiltInStyle : SamplePage
    {
        public BuiltInStyle()
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


            WSection section = document.AddSection() as WSection;
            //Set Margin of the section
            section.PageSetup.Margins.All = 72;
            WParagraph para = section.AddParagraph() as WParagraph;
            section.AddColumn(100, 100);
            section.AddColumn(100, 100);
            section.MakeColumnsEqual();

            #region Built-in styles
            # region List Style

            //List
            //para = section.AddParagraph() as WParagraph;
            para.AppendText("This para is written with style List").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.List);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            //List5 style
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style List5").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.List5);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            # region ListNumber Style

            //List Number style
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListNumber").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListNumber);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            //List Number5 style
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListNumber5").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListNumber5);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            # region TOA Heading Style

            //TOA Heading
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style TOA Heading").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ToaHeading);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            para = section.AddParagraph() as WParagraph;
            section.BreakCode = SectionBreakCode.NewColumn;

            # region ListBullet Style
            //ListBullet
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListBullet").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListBullet);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            //ListBullet5
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListBullet5").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListBullet5);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            # region List Continue Style

            //ListContinue
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListContinue").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListContinue);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            //ListContinue5
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style ListContinue5").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.ListContinue5);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            # region HTMLSample Style

            //HtmlSample
            para = section.AddParagraph() as WParagraph;
            para.AppendText("\nThis para is written with style HtmlSample").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.HtmlSample);
            para.AppendText("Google Chrome\n");
            para.AppendText("Mozilla Firefox\n");
            para.AppendText("Internet Explorer");

            # endregion

            section = document.AddSection() as WSection;
            section.BreakCode = SectionBreakCode.NoBreak;

            # region Document Map Style

            //Docuemnt Map
            para = section.AddParagraph() as WParagraph;
            para.AppendText("This para is written with style DocumentMap\n").CharacterFormat.UnderlineStyle = Syncfusion.Drawing.UnderlineStyle.Double;
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.DocumentMap);
            IWTextRange textrange = para.AppendText("Google Chrome\n");
            textrange.CharacterFormat.TextBackgroundColor = Syncfusion.Drawing.Color.Red;
            textrange = para.AppendText("Mozilla Firefox\n");
            textrange.CharacterFormat.TextBackgroundColor = Syncfusion.Drawing.Color.Red;
            textrange = para.AppendText("Internet Explorer");
            textrange.CharacterFormat.TextBackgroundColor = Syncfusion.Drawing.Color.Red;

            #endregion

            # region Heading Styles
            //Heading Styles
            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading1);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading2);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading3);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading4);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading5);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading6);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading7);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading8);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            para = section.AddParagraph() as WParagraph;
            para.ApplyStyle(BuiltinStyle.Heading9);
            para.AppendText("Hello World. This para is written with style " + para.StyleName.ToString());

            # endregion

            #endregion Built-in styles

            #region Saving Document
            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();
            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("WordDocument_BuiltInStyles.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("WordDocument_BuiltInStyles.docx", "application/msword", stream);
            #endregion
        }
    }
}
