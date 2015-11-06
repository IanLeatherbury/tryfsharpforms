#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Drawing;

#if __UNIFIED__
using UIKit;
using CoreGraphics;
using Foundation;

#else
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using MonoTouch.Foundation;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat = System.Single;
#endif
namespace SampleBrowser
{
	public class AboutViewController : UIViewController
	{
		public AboutViewController ()
		{
			this.Title 								= "About";
			this.TabBarItem.Title 					= "About";
			this.TabBarItem.Image 					= UIImage.FromBundle ("Images/About");
			this.TabBarItem.TitlePositionAdjustment = new UIOffset (0, -4);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.View.BackgroundColor 	= UIColor.White;
			CGRect parentBounds 		= this.View.Bounds;
			float yPos					= 80f;

			UILabel content 			= new UILabel(RectangleF.Empty);
			content.Text 				= "Essential Studio for iOS is a collection of user interface and file format manipulation components, that can be used to build line-of-business mobile applications.";
			content.Lines 				= 0;
			content.LineBreakMode 		= UILineBreakMode.WordWrap;
			content.Font 				= UIFont.FromName("Helvetica neue", 14f);
			content.ClipsToBounds 		= true;
			content.BackgroundColor 	= UIColor.Clear;
			content.TextColor			= UIColor.FromRGB (137,137,137);
			content.TextAlignment 		= UITextAlignment.Left;
			CGRect contentFrame 		= new CGRect();
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad) {
				contentFrame = new CGRect (23, yPos, parentBounds.Size.Width - 46, 50);
				yPos += 60;
			} 
			else {
				contentFrame = new CGRect (23, yPos, parentBounds.Size.Width - 46, 80);
				yPos += 90;
			}

			content.Frame 				= contentFrame;
			this.View.AddSubview (content);

			UILabel version 			= new UILabel(RectangleF.Empty);
			version.Text 				= "Version 13.3.0.7";
			version.Lines		 		= 1;
			version.Font 				= UIFont.FromName("Helvetica neue", 14f);
			version.ClipsToBounds 		= true;
			version.BackgroundColor 	= UIColor.Clear;
			version.TextColor 			= UIColor.FromRGB (137,137,137);
			version.TextAlignment 		= UITextAlignment.Left;
			CGSize versionSize 			= this.measureLabel (version);
			version.Frame 				= new CGRect (23, yPos, versionSize.Width, versionSize.Height);
			yPos 						+= (float)versionSize.Height + 30;

			this.View.AddSubview (version);

			UILabel contact 			= new UILabel(RectangleF.Empty);
			contact.Text 				= "Contact Us";
			contact.Lines 				= 1;
			contact.Font 				= UIFont.FromName("Helvetica neue", 17f);
			contact.ClipsToBounds 		= true;
			contact.BackgroundColor 	= UIColor.Clear;
			contact.TextColor 			= UIColor.Gray;
			contact.TextAlignment 		= UITextAlignment.Left;
			CGSize contactSize 			= this.measureLabel (contact);
			contact.Frame 				= new CGRect (23, yPos, contactSize.Width, contactSize.Height);
			yPos 						+= (float)contactSize.Height + 20;

			this.View.AddSubview (contact);

			UILabel web 				= new UILabel (RectangleF.Empty);
			web.AttributedText 			= new NSAttributedString (
											"http://www.syncfusion.com", 
											underlineStyle: NSUnderlineStyle.Single);
			web.Lines 					= 1;
			web.Font 					= UIFont.FromName("Helvetica neue", 14f);
			web.ClipsToBounds 			= false;
			web.BackgroundColor 		= UIColor.Clear;
			web.TextColor 				= UIColor.FromRGB (137,137,137);
			web.TextAlignment 			= UITextAlignment.Left;
			CGSize webSize 				= this.measureLabel (web);
			web.Frame 					= new CGRect (23, yPos, webSize.Width+20, webSize.Height);
			web.UserInteractionEnabled 	= true;
			yPos 						+= (float)webSize.Height+15;
			var tap 					= new UITapGestureRecognizer();
			tap.AddTarget(() 			=> UIApplication.SharedApplication.OpenUrl(new NSUrl(web.Text)));
			tap.NumberOfTapsRequired 	= 1;
			tap.DelaysTouchesBegan 		= true;
			web.AddGestureRecognizer(tap);

			View.AddSubview (web);

			UILabel support 				= new UILabel(RectangleF.Empty);
			support.Text 					= "support@syncfusion.com";
			support.AttributedText 			= new NSAttributedString (
												"support@syncfusion.com", 
												underlineStyle: NSUnderlineStyle.Single);
			support.Lines 					= 1;
			support.Font 					= UIFont.FromName("Helvetica neue", 14f);
			support.ClipsToBounds 			= true;
			support.BackgroundColor 		= UIColor.Clear;
			support.TextColor 				= UIColor.FromRGB (137,137,137);
			support.TextAlignment 			= UITextAlignment.Left;
			CGSize supportSize 				= this.measureLabel (support);
			support.Frame 					= new CGRect (23, yPos, supportSize.Width, supportSize.Height);
			support.UserInteractionEnabled 	= true;
			yPos 							+= (float)supportSize.Height+15;
			var tapSupport		 			= new UITapGestureRecognizer();
			tapSupport.AddTarget(() 		=> UIApplication.SharedApplication.OpenUrl(new NSUrl("mailto:support@syncfusion.com")));
			tapSupport.NumberOfTapsRequired = 1;
			tapSupport.DelaysTouchesBegan 	= true;
			support.AddGestureRecognizer(tapSupport);

			View.AddSubview (support);
		}

		private CGSize measureLabel (UILabel label)
		{
			CGSize labelSize = new CGSize();
			if(label.Text.Length >0)
			{
				NSString labelString 		= (NSString) label.Text ;
				UIStringAttributes attribs 	= new UIStringAttributes { Font = label.Font };
				labelSize 					= labelString.GetSizeUsingAttributes(attribs);
			}
			return labelSize;
		}
	}

}

