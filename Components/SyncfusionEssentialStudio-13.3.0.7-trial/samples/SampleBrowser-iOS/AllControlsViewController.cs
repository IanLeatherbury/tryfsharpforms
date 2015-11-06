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
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using nint = System.Int32;
using nuint = System.Int32;
using nfloat = System.Single;
#endif
namespace SampleBrowser
{

	public class AllControlsViewController : UITableViewController
	{
		NSDictionary controlDict;

		NSArray	controlDictArray;
		public AllControlsViewController () : base (UITableViewStyle.Plain)
		{
			this.Title 								= "All Controls";
			this.TabBarItem.Title 					= "All Controls";
			this.TabBarItem.Image 					= UIImage.FromBundle ("Images/Allcontrols");
			this.TabBarItem.TitlePositionAdjustment = new UIOffset (0, -4);
		}

		public NSMutableArray controls {
			get;
			set;
		}
		 
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			

			controls = new NSMutableArray ();

			// Fetching data from plist files

			string controlListPathString 	= NSBundle.MainBundle.BundlePath+"/ControlList.plist";
			controlDict 					= new NSDictionary();
			controlDict 					= NSDictionary.FromFile(controlListPathString);
			NSString controlDictKey 		= new NSString ("Control");
		    controlDictArray 				= controlDict.ValueForKey (controlDictKey) as NSArray;

			this.PrepareControlList ();

			// Register the TableView's data source
			TableView.Source = new AllControlsViewSource (this);

		}

		private void PrepareControlList()
		{
			controls.RemoveAllObjects();

			if (controlDictArray.Count > 0) {
				
				for( nuint i=0;  i < controlDictArray.Count; i++)
				{
					NSDictionary dict 	= controlDictArray.GetItem<NSDictionary> (i);
					string image 		= dict.ValueForKey (new NSString ("ControlName")).ToString();
					image 				= "Images/" +  image;
					Control control 	= new Control ();
					control.name 		= new NSString( dict.ValueForKey (new NSString ("ControlName")).ToString());
					control.image 		= UIImage.FromBundle (image);

					if (dict.ValueForKey (new NSString ("IsNew")) != null && dict.ValueForKey (new NSString ("IsNew")).ToString () == "YES") {
						control.tag = new NSString ("NEW");
					} else if (dict.ValueForKey (new NSString ("IsUpdated")) != null && dict.ValueForKey (new NSString ("IsUpdated")).ToString () == "YES") {
						control.tag = new NSString ("UPDATED");
					} else if (dict.ValueForKey (new NSString ("IsPreview")) != null && dict.ValueForKey (new NSString ("IsPreview")).ToString () == "YES") {
						control.tag = new NSString ("PREVIEW");
					} else {
						control.tag = new NSString ("");
					}
					#if! __UNIFIED__
					if(dict.ValueForKey (new NSString ("ControlName")).ToString() != "DataGrid")
					#endif
					controls.Add (control);
				}
			}
		}

		class AllControlsViewSource : UITableViewSource
		{
			readonly AllControlsViewController controller;
			NSArray controls;
			NSDictionary sampleDict;

			public AllControlsViewSource (AllControlsViewController allControl)
			{
				this.controller = allControl;
				controls 		= this.controller.controls;
			}

			public override nint NumberOfSections (UITableView tableView)
			{
				return 1;
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return (nint) controls.Count;
			}

			public override nfloat GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
			{
				return 55;
			} 

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				nuint row = (nuint)indexPath.Row;

				Control ctrl 				= controls.GetItem<Control> (row);
				string sampleListPathString = NSBundle.MainBundle.BundlePath+"/SampleList.plist";
				sampleDict 					= new NSDictionary();
				sampleDict 					= NSDictionary.FromFile(sampleListPathString);

				NSMutableArray dictArray	= sampleDict.ValueForKey (new NSString (ctrl.name)) as NSMutableArray;
				NSMutableArray sampArray 	= new NSMutableArray ();

				for (nuint i = 0; i < dictArray.Count; i++) {
					NSDictionary dict = dictArray.GetItem<NSDictionary> (i);
					sampArray.Add(dict.ValueForKey( new NSString("SampleName")));
				}


				SampleViewController sampleController 	= new SampleViewController();
				sampleController.selectedControl 		= ctrl.name;
				sampleController.sampleDictionaryArray 	= dictArray;
				sampleController.sampleArray 			= sampArray;

				controller.NavigationController.PushViewController(sampleController,true);
			}
		
			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (AllControlsViewCell.Key) as AllControlsViewCell;
				if (cell == null)
					cell = new AllControlsViewCell ();
				
				// Configure the cell...

				nuint row = (nuint)indexPath.Row;

				Control ctrl 		= controls.GetItem<Control> (row);
				cell.TextLabel.Text = ctrl.name;

				if (ctrl.image != null) {
					cell.ImageView.Image = ctrl.image;
				}

				if (ctrl.tag == "NEW") {
					cell.DetailTextLabel.Text 		= "NEW";
					cell.DetailTextLabel.TextColor 	= UIColor.FromRGB (148, 75, 157);
				}
				else if (ctrl.tag == "UPDATED") {
					cell.DetailTextLabel.Text 		= "UPDATED";
					cell.DetailTextLabel.TextColor 	= UIColor.FromRGB (108, 189, 68);
				}
				else if (ctrl.tag == "PREVIEW") {
					cell.DetailTextLabel.Text 		= "PREVIEW";
					cell.DetailTextLabel.TextColor 	= UIColor.FromRGB (220, 141, 38);
				}

				cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				return cell;
			}
		}
	}
}

