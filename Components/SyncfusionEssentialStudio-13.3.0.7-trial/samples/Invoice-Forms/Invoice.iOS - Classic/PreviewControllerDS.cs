#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using MonoTouch.QuickLook;

namespace XamarinIOInvoice.iOS
{
	public class PreviewControllerDS : QLPreviewControllerDataSource
	{
		private QLPreviewItem _item;

		public PreviewControllerDS(QLPreviewItem item)
		{
			_item = item;
		}

		public override int PreviewItemCount (QLPreviewController controller)
		{
			return 1;
		}

		public override QLPreviewItem GetPreviewItem (QLPreviewController controller, int index)
		{
			return _item;
		}
	}
}

