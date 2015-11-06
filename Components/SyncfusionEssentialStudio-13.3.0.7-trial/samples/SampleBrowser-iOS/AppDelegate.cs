#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Linq;
using System.Collections.Generic;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif
namespace SampleBrowser
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		
	
		UIWindow window;
		InitialTabBarController tabController;
		AllControlsViewController allControls;
		AboutViewController	aboutView;
		UINavigationController nav1;
		UINavigationController nav2;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window 							= new UIWindow (UIScreen.MainScreen.Bounds);
			tabController 					= new InitialTabBarController ();
			nav1 							= new UINavigationController ();
			nav2 							= new UINavigationController ();
			allControls 					= new AllControlsViewController ();
			aboutView 						= new AboutViewController ();
			nav1.ViewControllers 			= new UIViewController[] { allControls };
			nav2.ViewControllers 			= new UIViewController[] { aboutView };
			tabController.ViewControllers 	= new UIViewController[] { nav1, nav2 };
			window.RootViewController 		= tabController;
			window.MakeKeyAndVisible ();		
			return true;
		}
	}
}

