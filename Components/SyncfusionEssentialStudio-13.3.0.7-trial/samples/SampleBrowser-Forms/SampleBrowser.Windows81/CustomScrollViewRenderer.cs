#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;
[assembly: ExportRenderer(typeof(CustomScrolView), typeof(SampleBrowser.Windows81.ScrollViewRendererExt))]
namespace SampleBrowser.Windows81
{
    public class ScrollViewRendererExt : ScrollViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ScrollView> e)
        {
            base.OnElementChanged(e);
            if(this.Control != null)
                (this.Control as ScrollViewer).ZoomMode = ZoomMode.Disabled;
        }
    }
}
