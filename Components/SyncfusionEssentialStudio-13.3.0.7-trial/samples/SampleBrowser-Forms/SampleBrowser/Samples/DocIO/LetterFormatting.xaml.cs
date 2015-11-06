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
    public partial class LetterFormatting : SamplePage
    {
        public LetterFormatting()
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
            Stream inputStream = assembly.GetManifestResourceStream("SampleBrowser.Samples.DocIO.Templates.Letter Formatting.docx");
            //Open Template document
            document.Open(inputStream, FormatType.Word2013);
            inputStream.Dispose();
            List<Customer> source = new List<Customer>();
            source.Add(new Customer("ALFKI", "Alfreds Futterkiste", "Maria Anders", "Sales Representative", "Obere Str. 57", "Berlin", "12209", "Germany", "030-0074321", "030-0076545"));
            //source.Add(new Customer("ANATR", "Ana Trujillo Emparedados y helados", "Ana Trujillo", "Owner", "Avda. de la Constitución 2222", "México D.F.", "05021", "Mexico", "(5) 555-4729", "(5) 555-3745"));
            document.MailMerge.Execute(source);

            MemoryStream stream = new MemoryStream();
            document.Save(stream, FormatType.Word2013);
            document.Close();

            if (Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows)
                Xamarin.Forms.DependencyService.Get<ISaveWindowsPhone>().Save("LetterFormatting.docx", "application/msword", stream);
            else
                Xamarin.Forms.DependencyService.Get<ISave>().Save("LetterFormatting.docx", "application/msword", stream);
        }
    }
    public class Customer
    {
        #region fields
        string m_customerID;
        string m_companyName;
        string m_contactName;
        string m_contactTitle;
        string m_address;
        string m_city;
        string m_postalCode;
        string m_country;
        string m_phone;
        string m_fax;
        #endregion

        #region properties
        public string CustomerID
        {
            get
            {
                return m_customerID;
            }
            set
            {
                m_customerID = value;
            }
        }
        public string CompanyName
        {
            get
            {
                return m_companyName;
            }
            set
            {
                m_companyName = value;
            }
        }
        public string ContactName
        {
            get
            {
                return m_contactName;
            }
            set
            {
                m_contactName = value;
            }
        }
        public string ContactTitle
        {
            get
            {
                return m_contactTitle;
            }
            set
            {
                m_contactTitle = value;
            }
        }
        public string Address
        {
            get
            {
                return m_address;
            }
            set
            {
                m_address = value;
            }
        }
        public string City
        {
            get
            {
                return m_city;
            }
            set
            {
                m_city = value;
            }
        }
        public string PostalCode
        {
            get
            {
                return m_postalCode;
            }
            set
            {
                m_postalCode = value;
            }
        }
        public string Country
        {
            get
            {
                return m_country;
            }
            set
            {
                m_country = value;
            }
        }
        public string Phone
        {
            get
            {
                return m_phone;
            }
            set
            {
                m_phone = value;
            }
        }
        public string Fax
        {
            get
            {
                return m_fax;
            }
            set
            {
                m_fax = value;
            }
        }
        #endregion

        #region constructor
        public Customer()
        { }

        public Customer(string customerID, string companyName, string contactName, string contactTitle, string address, string city, string postalCode, string country, string phone, string fax)
        {
            m_customerID = customerID;
            m_companyName = companyName;
            m_contactName = contactName;
            m_contactTitle = contactTitle;
            m_address = address;
            m_city = city;
            m_postalCode = postalCode;
            m_country = country;
            m_phone = phone;
            m_fax = fax;
        }
        #endregion
    }
}
