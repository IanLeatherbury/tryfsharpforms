﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


using UIKit;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using tryfsharpforms;
using tryfsharpforms.iOS.Renderers;

[assembly: ExportRenderer(typeof(DataEntry), typeof(LoginEntryRenderer))]

namespace tryfsharpforms.iOS.Renderers
{
	public class LoginEntryRenderer : EntryRenderer
	{
		UITextField nativeTextField;
		CALayer bottomBorder;
		bool isInitialized = false;

		protected override void OnElementPropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged (sender, e);

			if (e.PropertyName == "IsEnabled") {
				if (!nativeTextField.Enabled)
					nativeTextField.TextColor = UIColor.White;
				else
					nativeTextField.TextColor = UIColor.White;
			}
		}

		protected override void OnElementChanged (ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged (e);

			if (e.NewElement != null && !isInitialized) {
				var formsEntry = e.NewElement as DataEntry;
				nativeTextField = Control as UITextField;
				nativeTextField.Font = UIFont.FromName ("AppleSDGothicNeo-Light", 18);
				nativeTextField.TextColor = UIColor.White;
				nativeTextField.BorderStyle = UITextBorderStyle.None;

				if (!String.IsNullOrEmpty (formsEntry.Placeholder))
					nativeTextField.AttributedPlaceholder = new NSAttributedString (formsEntry.Placeholder, UIFont.FromName ("AppleSDGothicNeo-Light", 18), MyColors.Concrete.ToUIColor());

				bottomBorder = new CALayer ();
				bottomBorder.BackgroundColor = UIColor.White.CGColor;
				Control.Layer.AddSublayer (bottomBorder);

				isInitialized = true;
			}
		}

		public override CGSize SizeThatFits (CGSize size)
		{
			bottomBorder.Frame = new CGRect (0, size.Height - 1, size.Width, 1);
			return base.SizeThatFits (size);
		}
	}
}