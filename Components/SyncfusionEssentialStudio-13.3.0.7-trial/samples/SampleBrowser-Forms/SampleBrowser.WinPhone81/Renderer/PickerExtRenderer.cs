#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using SampleBrowser;
using Xamarin.Forms.Platform.WinRT;
using Windows.UI.Xaml.Media;
using Windows.UI;

[assembly: ExportRenderer(typeof(PickerExt), typeof(SampleBrowser.WinPhone.PickerExtRenderer))]
namespace  SampleBrowser.WinPhone
{
    class PickerExtRenderer : PickerRenderer
    {
        TapGestureRecognizer tapGestureRecognizer = null;
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                tapGestureRecognizer.Tapped -= tapGestureRecognizer_Tapped;
            }
            if(e.NewElement != null)
            {
                tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += tapGestureRecognizer_Tapped;
                (e.NewElement as Picker).GestureRecognizers.Add(tapGestureRecognizer);   
            }
        }

        private async void tapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var picker = sender as Picker;
            string[] array = picker.Items.ToArray<string>();
            var action = await App.Current.MainPage.DisplayActionSheet("CHOOSE AN ITEM", null, null, array);
            if (action == null) return;
            picker.SelectedIndex = Array.IndexOf(array, action);
            picker.Focus();
        }          
    }
}
