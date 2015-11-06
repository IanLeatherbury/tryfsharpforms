#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using BusyIndicatorSample.WinPhone.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using BusyIndicatorSample;
using System.Windows.Media;
using SampleBrowser;

[assembly: ExportRenderer(typeof(PickerAdv), typeof(PickerAdvRenderer))]
namespace BusyIndicatorSample.WinPhone.Renderer
{
    class PickerAdvRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                this.Control.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
    }
}
