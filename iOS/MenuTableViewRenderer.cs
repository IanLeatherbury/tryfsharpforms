using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;

[assembly:ExportRenderer(typeof(tryfsharpforms.MenuTableView), typeof(tryfsharpforms.iOS.MenuTableViewRenderer))]
namespace tryfsharpforms.iOS
{
	public class MenuTableViewRenderer : TableViewRenderer
	{
		protected override void OnElementChanged (ElementChangedEventArgs<TableView> e)
		{
			base.OnElementChanged (e);

			if (Control == null)
				return;

			var tableView = Control as UITableView;
			tableView.BackgroundColor = UIColor.FromRGB (189, 195, 199);
		}
	}
}

