using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using Foundation;

[assembly:ExportRenderer(typeof(tryfsharpforms.NativeCell), typeof(tryfsharpforms.iOS.MenuTextCellRenderer))]
namespace tryfsharpforms.iOS
{
	public class MenuTextCellRenderer : ViewCellRenderer
	{
		static NSString rid = new NSString ("NativeCell");

		public override UITableViewCell GetCell(Xamarin.Forms.Cell item, UITableViewCell reusableCell, UITableView tv)
		{
			var x = (NativeCell)item;
			Console.WriteLine (x);

			NativeiOSCell c = reusableCell as NativeiOSCell;

			if (c == null) {
				c = new NativeiOSCell (rid);
			}

			UIImage i = null;
			if (!String.IsNullOrWhiteSpace (x.ImageFilename)) {
				i = UIImage.FromFile ("Images/" + x.ImageFilename + ".jpg");
			}
			c.UpdateCell (x.Name, x.Category, i);

			return c;
		}
	}

	public class NativeiOSCell : UITableViewCell
	{
		UILabel headingLabel, subheadingLabel;
		UIImageView imageView;

		public NativeiOSCell (NSString cellId) : base (UITableViewCellStyle.Default, cellId)
		{
			SelectionStyle = UITableViewCellSelectionStyle.Gray;

			ContentView.BackgroundColor = UIColor.FromRGB (41, 128, 185);

			imageView = new UIImageView ();

			headingLabel = new UILabel () {
				Font = UIFont.FromName ("Cochin-BoldItalic", 22f),
				TextColor = UIColor.FromRGB (127, 51, 0),
				BackgroundColor = UIColor.Clear
			};

			subheadingLabel = new UILabel () {
				Font = UIFont.FromName ("AmericanTypewriter", 12f),
				TextColor = UIColor.FromRGB (38, 127, 0),
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};

			ContentView.Add (headingLabel);
			ContentView.Add (subheadingLabel);
			ContentView.Add (imageView);
		}

		public void UpdateCell (string caption, string subtitle, UIImage image)
		{
			headingLabel.Text = caption;
			subheadingLabel.Text = subtitle;
			imageView.Image = image;
		}

		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();

			headingLabel.Frame = new CoreGraphics.CGRect (5, 4, ContentView.Bounds.Width - 63, 25);
			subheadingLabel.Frame = new CoreGraphics.CGRect (100, 18, 100, 20);
			imageView.Frame = new CoreGraphics.CGRect (ContentView.Bounds.Width - 63, 5, 33, 33);
		}
	}


}

