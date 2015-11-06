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
	public class SampleView : UIView
	{
		public SampleView ()
		{
		}

		public UIView control {
			get;
			set;
		}

		public virtual UIView optionView()
		{
			return null;
		}

		public virtual void dispose ()
		{
			// Method for overriding.
		}
	}
}

