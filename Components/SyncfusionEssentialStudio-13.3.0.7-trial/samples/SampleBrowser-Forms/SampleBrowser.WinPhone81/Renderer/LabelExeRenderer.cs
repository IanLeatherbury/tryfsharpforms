#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser;
using SampleBrowser.WinPhone81.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.WinRT;

[assembly: ExportRenderer(typeof(LabelExt), typeof(LabelExtRenderer))]
namespace SampleBrowser.WinPhone81.Renderer
{
    public class LabelExtRenderer : ViewRenderer<LabelExt, TextBlock>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<LabelExt> e)
        {
            base.OnElementChanged(e);

            TextBlock textBlock = new TextBlock();
            textBlock.Text = e.NewElement.Text;
            textBlock.FontSize = e.NewElement.FontSize;
            
            SetNativeControl(textBlock);
        }
    }
}
