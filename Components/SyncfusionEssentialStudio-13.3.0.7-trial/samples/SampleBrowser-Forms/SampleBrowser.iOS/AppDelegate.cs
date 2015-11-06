#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Foundation;
using SampleBrowser;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using UIKit;
using Syncfusion.SfBusyIndicator.XForms.iOS;
using Syncfusion.SfGauge.XForms.iOS;
using Syncfusion.SfRangeSlider.XForms.iOS;
using Syncfusion.SfAutoComplete.XForms.iOS;
using Syncfusion.SfNumericTextBox.XForms.iOS;
using Syncfusion.SfBarcode.XForms.iOS;
using Syncfusion.SfDataGrid.XForms.iOS;
using Syncfusion.SfTreeMap.XForms.iOS;

namespace SampleBrowser_Forms.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

			App.ScreenWidth = UIScreen.MainScreen.Bounds.Width;
            
            new SfChartRenderer();

			new SfBusyIndicatorRenderer ();

			new SfBarcodeRenderer ();
			
			new SfDigitalGaugeRenderer ();

			new SfLinearGaugeRenderer ();

			new SfRangeSliderRenderer ();

			new SfAutoCompleteRenderer ();

			new SfNumericTextBoxRenderer ();
			
			new SfTreeMapRenderer();
			
            SfDataGridRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
