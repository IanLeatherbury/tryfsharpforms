#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Xamarin.Forms;

namespace SampleBrowser
{
    public class SampleDetailsPage : MultiPage<ContentPage>
    {
        public ContentPage Detail
        {
            get { return (ContentPage) GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }

        public static readonly BindableProperty DetailProperty =
            BindableProperty.Create<SampleDetailsPage, ContentPage>(p => p.Detail, null, BindingMode.Default, null,
                OnDetailPropertyChanged);

        private static void OnDetailPropertyChanged(BindableObject bindable, ContentPage oldValue, ContentPage newValue)
        {
            ((SampleDetailsPage) bindable).SwapChildren();
        }

        private void SwapChildren()
        {
            Children.Clear();
            if (Detail == null) return;

            Children.Add(Detail);

            var samplePage = Detail as SamplePage;

            if (Master == null || Device.OS == TargetPlatform.WinPhone || (Device.Idiom == TargetIdiom.Phone && Device.OS == TargetPlatform.Windows)) return;
            samplePage.Master = Master;
            samplePage.UpdateSampleList();
        }

        public View Master
        {
            get { return (View) GetValue(MasterProperty); }
            set { SetValue(MasterProperty, value); }
        }

        public static readonly BindableProperty MasterProperty =
            BindableProperty.Create<SampleDetailsPage, View>(p => p.Master, null, BindingMode.Default, null,
                OnMasterPropertyChanged);

        private static void OnMasterPropertyChanged(BindableObject bindable, View oldValue, View newValue)
        {

        }

        protected override ContentPage CreateDefault(object item)
        {
            return null;
        }
    }
}