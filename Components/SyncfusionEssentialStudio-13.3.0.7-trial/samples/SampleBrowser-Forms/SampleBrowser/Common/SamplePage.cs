#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;

namespace SampleBrowser
{
    public class SamplePage : ContentPage
    {
        internal View Master { get; set; }

        internal bool IsPropertyViewVisible { get; set; }

        private readonly AbsoluteLayout contentLayout;

        private AbsoluteLayout propertyLayout;

        private ToolbarItem sampleListToolbarItem;

        private bool isSampleListVisible;

        private ToolbarItem toolbarItem;

        private View sampleList;

        private BoxView touchView;

        const double sampleListWidth = 240; // Width/100*40;

        internal View SampleList
        {
            get { return sampleList; }
            set
            {
                sampleList = value;

                if (contentLayout.Children.Contains(sampleList)) return;
                contentLayout.Children.Add(sampleList);
                sampleList.IsVisible = false;
            }
        }

        public View ContentView
        {
            get { return (View) GetValue(ContentViewProperty); }
            set { SetValue(ContentViewProperty, value); }
        }

        public static readonly BindableProperty ContentViewProperty =
            BindableProperty.Create<SamplePage, View>(p => p.ContentView, null, BindingMode.Default, null,
                OnContentViewChanged);

        private static void OnContentViewChanged(BindableObject bindable, View oldValue, View newValue)
        {
            ((SamplePage) bindable).OnContentViewChanged();
        }

        private void OnContentViewChanged()
        {
            touchView = new BoxView {BackgroundColor = Color.Gray, Opacity = 0.5, IsVisible = false};

            contentLayout.Children.Add(ContentView);
            contentLayout.Children.Add(touchView);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += tapGestureRecognizer_Tapped;
            touchView.GestureRecognizers.Add(tapGestureRecognizer);

            if (Device.OS == TargetPlatform.Android)
                contentLayout.BackgroundColor = Color.White;
            Content = contentLayout;
        }

        private void tapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (!isSampleListVisible) return;
            touchView.IsVisible = false;
            HideSampleList();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            var margin = Device.Idiom == TargetIdiom.Tablet ? 25 : 10;
            var spacing = Device.OS == TargetPlatform.iOS ? 1 : 2;

            double toolbarItemHeight = (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone) ? 55 : 0;
            AbsoluteLayout.SetLayoutBounds(ContentView,
                new Rectangle(((Device.OS == TargetPlatform.iOS) ? margin/2 : margin), margin,
                    contentLayout.Width - margin*spacing, contentLayout.Height - margin*spacing - toolbarItemHeight));

            AbsoluteLayout.SetLayoutBounds(touchView, new Rectangle(0, 0, width, height));

            if (PropertyView != null)
                AbsoluteLayout.SetLayoutBounds(PropertyView,
                    new Rectangle(margin, margin, contentLayout.Width - margin*spacing,
                        contentLayout.Height - margin*spacing));

            if (isSampleListVisible)
                PositionSampleList(width, height);
        }

        public void ShowSampleList()
        {
            if (sampleList == null) return;
            touchView.IsVisible = true;
            sampleList.IsVisible = true;
            sampleList.BackgroundColor = Color.White;
            PositionSampleList(Width, Height);
        }

        private void PositionSampleList(double width, double height)
        {
            AbsoluteLayout.SetLayoutBounds(sampleList,
                new Rectangle(width - sampleListWidth, 0, sampleListWidth, height));
        }        

        public void HideSampleList()
        {
            if (sampleList == null) return;
            touchView.IsVisible = false;
            sampleList.IsVisible = false;
            isSampleListVisible = false;
        }

        public View PropertyView
        {
            get { return (View) GetValue(PropertyViewProperty); }
            set { SetValue(PropertyViewProperty, value); }
        }

        public static readonly BindableProperty PropertyViewProperty =
            BindableProperty.Create<SamplePage, View>(p => p.PropertyView, null, BindingMode.Default, null,
                OnPropertyViewChanged);

        private static void OnPropertyViewChanged(BindableObject bindable, View oldValue, View newValue)
        {
            ((SamplePage) bindable).AddSettingToolbar();
        }

        public SamplePage()
        {
            contentLayout = new AbsoluteLayout();
        }

        private void toolbarItem_Clicked(object sender, EventArgs e)
        {
            if (toolbarItem.Text == "Settings")
            {
                ShowSettingsView();
            }
            else
            {
                HideSettingsView();
            }
        }

        private void AddSettingToolbar()
        {
            if (toolbarItem != null) return;
            toolbarItem = new ToolbarItem {Text = "Settings", Icon = "Setting.png"};
            toolbarItem.Clicked += toolbarItem_Clicked;
            ToolbarItems.Add(toolbarItem);

            propertyLayout = new AbsoluteLayout();
            if (PropertyView != null)
            {
                propertyLayout.Children.Add(PropertyView);
                if (Device.OS == TargetPlatform.Windows && Device.Idiom == TargetIdiom.Phone)
                {
                    if (PropertyView is Layout<View>)
                        UpdatePicker(PropertyView as Layout<View>);
                }
            }
        }

        void UpdatePicker(Layout<View> layout)
        {
            foreach (var child in layout.Children)
            {
                if (child is Layout<View>)
                {
                    UpdatePicker(child as Layout<View>);
                }
                else if (child is Picker)
                {
                    (child as Picker).VerticalOptions = LayoutOptions.FillAndExpand;
                }
            }
        }

        private void ShowSettingsView()
        {
            ToolbarItems.Remove(sampleListToolbarItem);
            IsPropertyViewVisible = true;
            Content = propertyLayout;
            toolbarItem.Text = "Apply";
            toolbarItem.Icon = "Apply.png";
            HideSampleList();
        }

        private void HideSettingsView()
        {
	        if (sampleListToolbarItem != null)
            	ToolbarItems.Insert(1, sampleListToolbarItem);
            Content = contentLayout;
            IsPropertyViewVisible = false;
            toolbarItem.Text = "Settings";
            toolbarItem.Icon = "Setting.png";
        }

        internal void UpdateSampleList()
        {
            sampleListToolbarItem = new ToolbarItem("List", "Controls.png", ValidateSampleList);
            ToolbarItems.Add(sampleListToolbarItem);
        }

        private void ValidateSampleList()
        {
            if (!isSampleListVisible)
            {
                isSampleListVisible = true;
                SampleList = Master;
                ShowSampleList();
            }
            else
            {
                isSampleListVisible = false;
                HideSampleList();
            }
        }
    }
}