#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.XlsIO.Parser.Biff_Records.ObjRecords;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace SampleBrowser
{
    public class MasterSamplePage : SampleDetailsPage
    {
        ListView listView;
        MasterSample sampleList;

        public MasterSamplePage(MasterSample sampleList)
        {
            this.sampleList = sampleList;

            Title = Device.OS == TargetPlatform.Android ? "  " + sampleList.Title : sampleList.Title;

            if (sampleList.Samples.Count == 1)
            {
                var type = Type.GetType(sampleList.Samples[0].Type);
                if (type == null)
                {
                    Detail = new EmptyContent();
                }
                else
                {
                    var samplePage = Activator.CreateInstance(type) as SamplePage;
                    Detail = samplePage;
                }
            }
            else if (sampleList.Samples.Count > 1)
            {
                listView = new ListView
                {
                    ItemsSource = sampleList.Samples,
                    RowHeight = 40,
                    ItemTemplate = new DataTemplate(typeof(SampleListCell)),
                    BackgroundColor = Color.Gray
                };

                Master = listView;

                listView.ItemSelected += (sender, args) =>
                {
                    if (listView.SelectedItem == null)
                        return;

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
                };

                SelectSample();
            }
        }

        async void SelectSample()
        {
            if (Device.OS == TargetPlatform.iOS && Device.Idiom == TargetIdiom.Phone)
                await Task.Delay(50);
            listView.SelectedItem = sampleList.Samples[0];
        }
    }

    internal class SampleListCell : ViewCell
    {
		private readonly StackLayout rootLayout;

		public string Type
		{
			get { return (string)GetValue(TypeProperty); }
			set { SetValue(TypeProperty, value); }
		}

		public static readonly BindableProperty TypeProperty =
			BindableProperty.Create<SampleListCell, string>(p => p.Type, "", BindingMode.Default,
				null, OnTypePropertyChanged);

        private static void OnTypePropertyChanged(BindableObject bindable, string oldValue, string newValue)
        {
            Color color;
            switch (newValue)
            {
                case "New":
                    color = Color.FromRgb(148, 75, 157);
                    break;
                case "Preview":
                    color = Color.FromRgb(220, 141, 38);
                    break;
                default:
                    color = Color.FromRgb(108, 189, 68);
                    break;
            }

            var icon = new Label {TextColor = color, Text = newValue};
            icon.FontSize = (Device.OS == TargetPlatform.WinPhone ||
                             (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows))
                ? 15
                : 10;
            
            ((SampleListCell) bindable).rootLayout.Children.Add(icon);
        }

        public SampleListCell()
        {
			this.SetBinding (TypeProperty, "SampleType");

            var sampleName = new LabelExt { VerticalOptions = LayoutOptions.Center };
            sampleName.SetBinding(Label.TextProperty, "Title");
            sampleName.VerticalOptions = LayoutOptions.Center;
            //if (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone)
            //    sampleName.HorizontalOptions = LayoutOptions.FillAndExpand;

            sampleName.FontSize = Device.Idiom == TargetIdiom.Tablet
                ? Device.OnPlatform(15, 15, 25)
                : Device.OnPlatform(13, 13, 25);

			sampleName.VerticalOptions = LayoutOptions.Center;
            if ((Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone) || Device.OS == TargetPlatform.WinPhone)
            {
                sampleName.TextColor = Color.White;
                sampleName.FontSize = 23;
            }
            else
                sampleName.TextColor = Color.Black;

			rootLayout = new StackLayout {Orientation = StackOrientation.Horizontal};
            if (Device.Idiom != TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
                sampleName.SetBinding(Label.TextColorProperty, new Binding("ForegroundColor"));
                rootLayout.SetBinding(Layout.BackgroundColorProperty, new Binding("BackgroundColor"));
            }

            rootLayout.Children.Add(sampleName);
            rootLayout.Padding = new Thickness(12, 10, 5, 5);
			rootLayout.VerticalOptions = LayoutOptions.Center;
			rootLayout.HorizontalOptions = LayoutOptions.Center;

			View = rootLayout;
        }
    }

    public class LabelExt : Label
    {
       
    }
}