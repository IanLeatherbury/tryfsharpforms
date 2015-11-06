#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using System.Threading.Tasks;
using SampleBrowser.Common;
using Xamarin.Forms;

namespace SampleBrowser
{
    public partial class ControlPage : ContentPage
    {
        private readonly Label aboutContent = new Label();
        private readonly ListView rootList = new ListView();
        private readonly Grid rootGrid = new Grid();
        private readonly ControlListViewModel controlList;
        private readonly Label dummyContent;
        private readonly Grid rootLayout;

        private readonly Label indicator = new Label
        {
            IsVisible = false,
            Text = "Loading...",
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        };

        protected override void OnAppearing()
        {
            base.OnAppearing();
            indicator.IsVisible = false;
			if (Device.OS == TargetPlatform.iOS)
			{
				Title = "Essential Studio";
			}
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                rootGrid.IsVisible = true;
            }
            else
            {
                rootList.IsVisible = true;
            }
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                int maxColumnCount;
                int maxRowCount;
                if (width > height)
                {
                    //Landscape
                    maxColumnCount = Device.OnPlatform(5, 6, 0);
                    maxRowCount = Device.OnPlatform(4, 3, 0);
                }
                else
                {
                    //Portrait
                    maxColumnCount = 4;
                    maxRowCount = 5;
                }

                var currentColumn = 0;
                var currentRow = 0;

                Grid.SetRow(dummyContent, maxRowCount - 1);
                Grid.SetColumn(dummyContent, maxColumnCount - 1);

                foreach (var child in rootGrid.Children.Where(child => !(child is Label)))
                {
                    Grid.SetColumn(child, currentColumn);
                    Grid.SetRow(child, currentRow);

                    currentColumn++;
                    if (currentColumn != maxColumnCount) continue;
                    currentColumn = 0;
                    currentRow++;
                }
            }

            base.OnSizeAllocated(width, height);
        }

        public ControlPage()
        {
            rootLayout = new Grid();
            
            
            dummyContent = new Label();

            controlList = new ControlListViewModel();

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                
                Title = Device.OnPlatform("Essential Studio", "  Essential Studio", "Essential Studio");
                var sampleList = controlList.MasterSampleLists;
                var count = sampleList.Count;

                rootGrid = new Grid();
                rootLayout.Children.Add(rootGrid);
                rootGrid.Padding = new Thickness(10);

                for (var i = 0; i < count; i++)
                {
                    var control = sampleList[i];

                    var content = new StackLayout {Padding = new Thickness(20, 40, 20, 20), StyleId = i.ToString()};

                    var tapGestue = new TapGestureRecognizer();
                    content.GestureRecognizers.Add(tapGestue);
                    tapGestue.Tapped += TapGestue_Tapped;

                    var absoluteLayout = new AbsoluteLayout {HeightRequest = 76, WidthRequest = 76};
                    var controlIcon = new Image
                    {
                        HeightRequest = 76,
                        WidthRequest = 76,
                        Aspect = Aspect.AspectFit,
                    };
                    if (Device.OS == TargetPlatform.Windows)
                        controlIcon.Source = ImageSource.FromFile("chart.png");
                    else
                        controlIcon.Source = ImageSource.FromResource("SampleBrowser.Icons." + control.ImageID);
                    var sampleName = new Label
                    {
                        Text = control.Title,
                        FontSize = 12,
                        HorizontalOptions = LayoutOptions.Center
                    };

                    content.Children.Add(absoluteLayout);
                    content.Children.Add(sampleName);
                    absoluteLayout.Children.Add(controlIcon);

                    absoluteLayout.HorizontalOptions = LayoutOptions.Center;

                    rootGrid.Children.Add(content);
                }
                rootGrid.Children.Add(dummyContent);
            }
            else
            {
                Title = "Essential Studio";

                rootList = new ListView();
                rootLayout.Children.Add(rootList);
               

                aboutContent.Text =
                    "Syncfusion Essential Studio is a collection of user interface and file format manipulation components that can be used to build line-of-business mobile applications.";
                aboutContent.TranslationX = 10;
                aboutContent.FontSize = 26;

                Title = Device.OS == TargetPlatform.Android ? "  Essential Studio" : "Essential Studio";
                rootList.ItemsSource = controlList.MasterSampleLists;
                rootList.ItemSelected += listview_ItemSelected;

                rootList.RowHeight = Device.OnPlatform(50, 50, 85);
                rootList.ItemTemplate = new DataTemplate(typeof (ControlListCellMobile));
            }
            rootLayout.Children.Add(indicator);
            Content = rootLayout;
        }

        private void TapGestue_Tapped(object sender, EventArgs e)
        {
            ListViewItemsChanged(controlList.MasterSampleLists[int.Parse(((StackLayout) sender).StyleId)]);
        }

        private void listview_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListViewItemsChanged(e.SelectedItem as MasterSample);
        }

        private async void ListViewItemsChanged(MasterSample item)
        {
            indicator.IsVisible = true;
            if (rootGrid != null)
                rootGrid.IsVisible = false;
            if (rootList != null)
                rootList.IsVisible = false;
            
            await Task.Delay(5);

			if (Device.OS == TargetPlatform.iOS)
			{
				Title = "Back";
			}

            if (item == null) return;

            if (Device.OS == TargetPlatform.WinPhone || (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows))
            {
                await Navigation.PushAsync(new MasterSamplePageWP(item));
            }
            else
            {
                await Navigation.PushAsync(new MasterSamplePage(item));
            }

            rootList.SelectedItem = null;
        }
    }

    internal class ControlListCellMobile : ViewCell
    {
        private readonly Image controlIcon;

        private readonly StackLayout rootLayout;

        public string Type
        {
            get { return (string) GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create<ControlListCellMobile, string>(p => p.Type, "", BindingMode.Default,
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
            var icon = new Label { TextColor = color, FontSize = 13, Text = newValue };
            ((ControlListCellMobile)bindable).rootLayout.Children.Add(icon);
        }

        public string ImageID
        {
            get { return (string) GetValue(ImageIDProperty); }
            set { SetValue(ImageIDProperty, value); }
        }

        public static readonly BindableProperty ImageIDProperty =
            BindableProperty.Create<ControlListCellMobile, string>(p => p.ImageID, null, BindingMode.Default,
                null, OnImageIDPropertyChanged);

        private static void OnImageIDPropertyChanged(BindableObject bindable, string oldValue, string newValue)
        {
            ((ControlListCellMobile) bindable).UpdateImage();
        }

        private void UpdateImage()
        {
            if (controlIcon != null)
            {
                if (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone)
                    controlIcon.Source = ImageSource.FromFile("Icons/" + ImageID);
                else
                    controlIcon.Source = ImageSource.FromResource("SampleBrowser.Icons." + ImageID);
            }
        }

        public ControlListCellMobile()
        {
            controlIcon = new Image
            {
                VerticalOptions = LayoutOptions.Center,
                HeightRequest = Device.OnPlatform(40, 40, 70),
                WidthRequest = Device.OnPlatform(40, 40, 70),
                Aspect = Aspect.AspectFill
            };

            this.SetBinding(ImageIDProperty, "ImageID");
            this.SetBinding(TypeProperty, "Type");

            var controlName = new LabelExt
            {
                VerticalOptions = LayoutOptions.Center,
            };

            if (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)
            {
           //     controlName.HorizontalOptions = LayoutOptions.FillAndExpand; 
                controlName.FontSize = 27;
            }
            else
                controlName.FontSize = Device.OnPlatform(18, 18, 27);

            controlName.SetBinding(Label.TextProperty, "Title");
           
            rootLayout = new StackLayout {Orientation = StackOrientation.Horizontal};
            rootLayout.Children.Add(controlIcon);
            rootLayout.Children.Add(controlName);

            rootLayout.Spacing = 10;

            rootLayout.Padding = Device.OnPlatform(new Thickness(15, 5, 5, 5), new Thickness(5, 5, 5, 5),
                new Thickness(15, 3, 5, 15));

            rootLayout.VerticalOptions = LayoutOptions.Center;
            View = rootLayout;
        }
    }

//
//    internal class ControlListCellTablet : ViewCell
//    {
//        private readonly Image controlIcon;
//
//        public string ImageID
//        {
//            get { return (string)GetValue(ImageIDProperty); }
//            set { SetValue(ImageIDProperty, value); }
//        }
//
//        public static readonly BindableProperty ImageIDProperty =
//            BindableProperty.Create<ControlListCellTablet, string>(p => p.ImageID, null, BindingMode.Default,
//                null, OnImageIDPropertyChanged);
//
//        private static void OnImageIDPropertyChanged(BindableObject bindable, string oldValue, string newValue)
//        {
//            ((ControlListCellTablet)bindable).UpdateImage();
//        }
//
//        private void UpdateImage()
//        {
//            if (controlIcon != null)
//            {
//                controlIcon.Source = ImageSource.FromResource("SampleBrowser.Icons." + ImageID);
//            }
//        }
//
//        public ControlListCellTablet()
//        {
//            controlIcon = new Image
//            {
//                HeightRequest = 130,
//                WidthRequest = 130, 
//                Aspect = Aspect.AspectFill
//            };
//
//            this.SetBinding(ImageIDProperty, "ImageID");
//
//            var controlLabel = new StackLayout { Orientation = StackOrientation.Vertical };
//            var controlName = new Label();
//            controlName.SetBinding(Label.TextProperty, "Title");
//            controlName.FontSize = 24;
//            controlLabel.Children.Add(controlName);
//
//            var descriptionLabel = new Label
//            {
//                FontSize = 15
//            };
//            descriptionLabel.SetBinding(Label.TextProperty, "Description");
//            controlLabel.Children.Add(descriptionLabel);
//
//            var rootLayout = new StackLayout { Orientation = StackOrientation.Horizontal };
//            //rootLayout.Padding = new Thickness(20);
//            rootLayout.Children.Add(controlIcon);
//            rootLayout.Children.Add(controlLabel);
//
//            rootLayout.Padding = new Thickness(5, 5, 5, 5);
//
//            rootLayout.VerticalOptions = LayoutOptions.Center;
//            View = rootLayout;
//        }
}