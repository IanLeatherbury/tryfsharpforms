﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using Syncfusion.SfBusyIndicator.XForms.iOS;

namespace tryfsharpforms.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

			new SfChartRenderer();

			new SfBusyIndicatorRenderer ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}

