#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using Xamarin.Forms;

namespace SampleBrowser
{
    public class ControlListViewModel : BindableObject
    {
        public List<MasterSample> MasterSampleLists { get; set; }

        public ControlListViewModel()
        {
            MasterSampleLists = new List<MasterSample>();
            PopulateSamplesList();
        }

        private void PopulateSamplesList()
        {
            var assembly = typeof (App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("SampleBrowser.SampleList.SampleList.xml");

            using (var reader = new StreamReader(stream))
            {
                var xmlReader = XmlReader.Create(reader);
                xmlReader.Read();

                while (!xmlReader.EOF)
                {
                    if (xmlReader.Name == "Group" && xmlReader.IsStartElement())
                    {
                        var masterSampleList = new MasterSample
                        {
                            Title = GetDataFromXmlReader(xmlReader, "Title"),
                            ImageID = GetDataFromXmlReader(xmlReader, "ImageId"),
                        };

                        bool isPreview;
                        bool.TryParse(GetDataFromXmlReader(xmlReader, "IsPreview"), out isPreview);
                        if (isPreview)
                            masterSampleList.Type = "Preview";

                        if (!isPreview)
                        {
                            bool isNew;
                            bool.TryParse(GetDataFromXmlReader(xmlReader, "IsNew"), out isNew);
                            if (isNew)
                                masterSampleList.Type = "New";
                        }

                        MasterSampleLists.Add(masterSampleList);
                    }
                    else if (xmlReader.Name == "Sample" && xmlReader.IsStartElement())
                    {
                        var sampleList = MasterSampleLists[MasterSampleLists.Count - 1];

                        var sampleDetails = new SampleDetails
                        {
                            Title = GetDataFromXmlReader(xmlReader, "Title"),
                            ImageId = GetDataFromXmlReader(xmlReader, "ImageID")
                        };

                        xmlReader.MoveToAttribute("Type");
                        sampleDetails.Type = xmlReader.Value;

                        bool isUpdated;
                        bool.TryParse(GetDataFromXmlReader(xmlReader, "IsUpdated"), out isUpdated);
                        if (isUpdated)
                            sampleDetails.SampleType = "Updated";

                        var isNew = false;
                        if (!isUpdated)
                        {
                            bool.TryParse(GetDataFromXmlReader(xmlReader, "IsNew"), out isNew);
                            if (isNew)
                                sampleDetails.SampleType = "New";
                        }

                        if (sampleList.Type == null && (isUpdated || isNew))
                        {
                            sampleList.Type = "Updated";
                        }

                        sampleList.Samples.Add(sampleDetails);
                    }
                    xmlReader.Read();
                }
            }
        }

        private static string GetDataFromXmlReader(XmlReader reader, string attribute)
        {
            reader.MoveToAttribute(attribute);
            return reader.Value;
        }
    }
}