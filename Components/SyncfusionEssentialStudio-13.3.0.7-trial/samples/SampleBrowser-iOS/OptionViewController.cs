#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
#if __UNIFIED__
using UIKit;
#else
using MonoTouch.UIKit;
#endif
namespace SampleBrowser
{
	public class OptionViewController: UIViewController
	{
		public OptionViewController ()
		{
		}
		public SampleView sampleView {
			get;
			set;
		}

		public UIView optionView {
			get;
			set;
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.Title = "Options";
			this.View.BackgroundColor = UIColor.White;
			this.View.AddSubview (optionView);
		}
	}
}

