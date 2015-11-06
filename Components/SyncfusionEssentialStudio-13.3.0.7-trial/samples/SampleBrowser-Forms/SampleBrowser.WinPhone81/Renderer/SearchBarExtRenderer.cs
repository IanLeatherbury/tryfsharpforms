#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser;
using SampleBrowser.WinPhone81;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;
using System.Reflection;
using Windows.UI.Xaml.Controls;

[assembly: ExportRenderer(typeof(SearchBarExt), typeof(SearchBarExtRenderer))]
namespace SampleBrowser.WinPhone81
{
    public class SearchBarExtRenderer : ViewRenderer<SearchBarExt, TextBox>
    {
        #region Fields

        private TextBox nativeView;

        #endregion

        #region Property

        private SearchBarExt FormsView
        {
            get
            {
                return this.Element as SearchBarExt;
            }
        }

        #endregion

        #region Override Methods

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBarExt> e)
        {
            if (e.NewElement != null)
            {
                base.OnElementChanged(e);
                nativeView = new TextBox() { PlaceholderText = e.NewElement.Placeholder };
                nativeView.TextChanged += SearchBarExtRenderer_TextChanged;
                SetNativeControl(nativeView);
            }
        }

        #endregion

        #region CallBacks

        void SearchBarExtRenderer_TextChanged(object sender, Windows.UI.Xaml.Controls.TextChangedEventArgs e)
        {
            this.FormsView.Text = (sender as TextBox).Text;
        }

        #endregion

        #region Dispose

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.nativeView = null;
        }

        #endregion
    }
}
