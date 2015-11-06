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
using CoreGraphics;
using Foundation;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
#endif
namespace SampleBrowser
{
	public class SampleTableViewCell:UITableViewCell
	{
		public static readonly NSString Key = new NSString ("SampleTableViewCell");

		public SampleTableViewCell (): base (UITableViewCellStyle.Value1, Key)
		{
		}
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			CGSize size 			= new CGSize ();
			NSString labelString 	= (NSString) this.TextLabel.Text ;

			if (labelString != null) {
				UIStringAttributes attribs 			= new UIStringAttributes { Font = this.TextLabel.Font };
				size 								= labelString.GetSizeUsingAttributes (attribs);
				this.DetailTextLabel.Font 			= UIFont.FromName ("Helvetica", 10f);
				this.DetailTextLabel.Frame 			= new CGRect (size.Width + 20, 5, 60, 30);
				this.DetailTextLabel.TextAlignment 	= UITextAlignment.Left;
			}
		}
	}
}

