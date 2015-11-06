#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;
#else
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif
namespace SampleBrowser
{
	public class AllControlsViewCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString ("AllControlsViewCell");

		public AllControlsViewCell () : base (UITableViewCellStyle.Value1, Key)
		{
			
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			CGSize size 			= new CGSize ();
			NSString labelString 	= (NSString) this.TextLabel.Text ;
			if (labelString != null) {
				UIStringAttributes attribs 	= new UIStringAttributes { Font = this.TextLabel.Font };
				size 						= labelString.GetSizeUsingAttributes (attribs);
				this.DetailTextLabel.Font 	= UIFont.FromName ("Helvetica", 10f);
				this.DetailTextLabel.Frame 	= new CGRect (size.Width + 66f, 10f, 49.5f, 30f);

				if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
					this.DetailTextLabel.Frame = new CGRect (size.Width + 70, 10, 49.5f, 30f);
				}
			}
		}
	}
}

