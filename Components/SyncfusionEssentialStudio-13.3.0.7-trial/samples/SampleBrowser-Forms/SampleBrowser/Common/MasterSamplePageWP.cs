#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;

namespace SampleBrowser.Common
{
    public class MasterSamplePageWP : MasterDetailPage
    {
        public MasterSamplePageWP(MasterSample sampleList)
        {
            if (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone)
                NavigationPage.SetHasNavigationBar(this, false);
            Title = Device.OS == TargetPlatform.Android ? "  " + sampleList.Title : sampleList.Title;

            //if (sampleList.Samples.Count == 1)
            //{
            //    var type = Type.GetType(sampleList.Samples[0].Type);
            //    if (type == null)
            //    {
            //        Detail = new EmptyContent();
            //    }
            //    else
            //    {
            //        var samplePage = Activator.CreateInstance(type) as SamplePage;
            //        Detail = samplePage;
            //    }
            //}
            //else if (sampleList.Samples.Count > 1)
            {
                var listView = new ListView
                {
                    ItemsSource = sampleList.Samples,
                    ItemTemplate = new DataTemplate(typeof (SampleListCell)),
                    RowHeight = 45
                };
                var contentLayout = new StackLayout { Children = { listView } };
                if (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone)
                    contentLayout.Padding = new Thickness(0, 0, 0, 60);
                var master = new ContentPage {Title = "Sample List", Content = contentLayout };

                Master = master;
                Master.Icon = (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone)? "Assets/Controls.png" : "Controls.png";
                Detail = Activator.CreateInstance(Type.GetType(sampleList.Samples[0].Type)) as SamplePage;

                listView.ItemSelected += (sender, args) =>
                {
                    IsPresented = false;
                    if (listView.SelectedItem == null) return;

                    var sampleDetails = args.SelectedItem as SampleDetails;

                    var type = Type.GetType(sampleDetails.Type);
                    if (type == null)
                    {
                        Detail = new EmptyContent();
                    }
                    else
                    {
                        var samplePage = Activator.CreateInstance(type) as SamplePage;
                        Detail = samplePage;
                    }
                    //listView.SelectedItem = null;
                };

                if (sampleList.Samples.Count > 0)
                {
                    listView.SelectedItem = sampleList.Samples[0];
                }
            }
        }
    }
}