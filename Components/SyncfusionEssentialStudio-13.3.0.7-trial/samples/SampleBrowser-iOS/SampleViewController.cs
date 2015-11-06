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
using Foundation;
using CoreGraphics;
using ObjCRuntime;
#else
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.CoreGraphics;
using MonoTouch.ObjCRuntime;
using CGRect = System.Drawing.RectangleF;
using nint = System.Int32;
using nuint = System.Int32;
using nfloat = System.Single;
#endif
namespace SampleBrowser
{
	public class SampleViewController: UIViewController
	{
		
		bool menuVisible;
		UIView fadeOutView;
		CGRect sampleFrame;

		UIBarButtonItem menuButton;
		UIBarButtonItem optionButton;
		public SampleViewController ()
		{	

		}
			
		public SampleView sample {
			get;
			set;
		}

		public NSString selectedControl {
			get;
			set;
		}

		public NSString selectedSample {
			get;
			set;
		}

		public UIView menuView {
			get;
			set;
		}

		public UIView optionView {
			get;
			set;
		}

		public UITableView menuTable {
			get;
			set;
		}

		public NSArray sampleArray {
			get;
			set;
		}

		public NSArray sampleDictionaryArray {
			get;
			set;
		}

		public override void ViewDidLoad ()
		{
			this.View.BackgroundColor 	= UIColor.White;

			menuVisible = false;
			nfloat height              	= this.View.Bounds.Height - 64 - 49;
			nfloat left                	= this.View.Bounds.Width - 260;
			menuView                  	= new UIView(new CGRect( left, 64, 260, height));
			menuTable 					= new UITableView (new CGRect (0, 0, 260, height));
			menuTable.Layer.BorderWidth = 0.5f;
			menuTable.Layer.BorderColor = (UIColor.FromRGBA (0.537f, 0.537f, 0.537f, 0.5f)).CGColor;
			menuTable.BackgroundColor 	= UIColor.White;
			menuTable.Source 			= new sampleDataSource (this) ;
			NSIndexPath indexPath 		= NSIndexPath.FromRowSection (0, 0);
			menuTable.SelectRow (indexPath, false, UITableViewScrollPosition.Top);
			menuView.AddSubview (menuTable);


			fadeOutView               	= new UIView(this.View.Bounds);
			fadeOutView.BackgroundColor	= UIColor.FromRGBA( 0.537f ,0.537f,0.537f,0.3f);

			menuButton 				= new UIBarButtonItem();
			menuButton.Image 		= UIImage.FromBundle ("Images/menu");
			menuButton.Style 		= UIBarButtonItemStyle.Plain;
			menuButton.Target 		= this;
			menuButton.Clicked 	   += OpenMenu;

			optionButton 			= new UIBarButtonItem ();
			optionButton.Image 		= UIImage.FromBundle ("Images/Option");
			optionButton.Style 		= UIBarButtonItemStyle.Plain;
			optionButton.Target 	= this;
			optionButton.Clicked   += OpenOptionView;

			UITapGestureRecognizer singleFingerTap 	= new UITapGestureRecognizer ();
			singleFingerTap.AddTarget(() 			=> HandleSingleTap(singleFingerTap));

			fadeOutView.AddGestureRecognizer (singleFingerTap);

			selectedSample = sampleArray.GetItem<NSString> (0);
			this.LoadSample (selectedSample);
			this.NavigationController.InteractivePopGestureRecognizer.Enabled = false;
		}

		public override void ViewWillDisappear (bool animated)
		{
			sample.dispose ();
			base.ViewWillDisappear (animated);
		}

		void HandleSingleTap (UITapGestureRecognizer gesture){
			if(menuVisible){
				menuVisible = false;
				HideMenu ();
			}
		}

		void OpenOptionView (object sender, EventArgs ea) 
		{
			menuVisible = false;
			HideMenu ();
			OptionViewController optionController 	= new OptionViewController ();
			optionController.sampleView 			= sample;
			optionController.optionView 			= optionView;
			this.NavigationController.PushViewController (optionController, true);
		}

		void OpenMenu (object sender, EventArgs ea) {
			if (menuVisible) {
				menuVisible = false;
				HideMenu ();
			} else {
				menuVisible = true;
				this.View.AddSubview (fadeOutView);
				this.View.AddSubview (menuView);
				ShowMenu ();
			}
		}

		void ShowMenu()
		{
			menuView.Transform = CGAffineTransform.MakeScale (0, 1);
			menuView.Alpha     = 0;
			UIView.Animate (0.25, () => {
				menuView.Alpha = 1;
				menuView.Transform = CGAffineTransform.MakeScale (1, 1);
			});
		}

		void HideMenu()
		{
			menuView.Transform = CGAffineTransform.MakeScale(1,1);
			fadeOutView.RemoveFromSuperview ();
			UIView.AnimateNotify (0.25, () => {
				menuView.Alpha = 0;
				menuView.Transform = CGAffineTransform.MakeScale(0.001f,1);
			},(bool finished)=>{
				if(finished)
					menuView.RemoveFromSuperview();
			}
			);
		}

		void LoadSample (NSString sampleName){

			if(sample != null && sample.control.IsDescendantOfView(this.View)){
				sample.control.RemoveFromSuperview ();
				sample.dispose ();
			}

			this.Title 			= sampleName;
			string classname 	= "SampleBrowser." + sampleName;

			if(sampleName == "100% Stacked Area")
			{
				classname = "SampleBrowser.StackingArea100";
			}
			else if(sampleName == "100% Stacked Column")
			{
				classname = "SampleBrowser.StackingColumn100";
			}
			else if(sampleName == "100% Stacked Bar")
			{
				classname = "SampleBrowser.StackingBar100";
			}

			classname 	=  classname.Replace (" ", "");
			sampleFrame = new CGRect(this.View.Bounds.X,
				this.View.Bounds.Y + 66,
				this.View.Bounds.Width,
				this.View.Bounds.Height - 66 - 56);
			
			if (UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Pad && 
				!(this.selectedControl.ToString()== "DataGrid") && 
				!(this.selectedControl.ToString()== "NavigationDrawer") && 
				!(this.selectedControl.ToString()== "Calendar"))
			{
				sampleFrame = new CGRect(this.View.Bounds.X + 100,
					this.View.Bounds.Y + 66 + 100,
					this.View.Bounds.Width - 200,
					this.View.Bounds.Height - 66 - 56 -200);
			}

			Type sampleClass 		= Type.GetType (classname);

			if (sampleClass != null) 
			{
				sample = Activator.CreateInstance (sampleClass) as SampleView;
				sample.control.Frame = sampleFrame;
				optionView = sample.optionView ();

				this.NavigationItem.RightBarButtonItems = null;

				if (optionView != null) {
					optionView.Frame = sampleFrame;
					if (sampleArray.Count > 1) {
						this.NavigationItem.SetRightBarButtonItems (new UIBarButtonItem []{ menuButton, optionButton }, true);
						optionButton.ImageInsets= new UIEdgeInsets (0, 0, 0, -25);
					} else {
						this.NavigationItem.SetRightBarButtonItem (optionButton, true);
					}
				} 
				else if (sampleArray.Count > 1){
					this.NavigationItem.SetRightBarButtonItem (menuButton, true);
				}

				this.View.AddSubview (sample.control);
			} 
			else if (sampleArray.Count > 1)
			{
				this.NavigationItem.SetRightBarButtonItem (menuButton, true);
			}
		}

		class sampleDataSource:UITableViewSource
		{
			readonly SampleViewController controller;
			NSArray sampleArray;
			NSDictionary sampleDict;
			NSArray sampleDictArray;
			public sampleDataSource (SampleViewController sampleControl)
			{
				this.controller = sampleControl;
				sampleArray 	= this.controller.sampleArray;
				sampleDictArray = this.controller.sampleDictionaryArray;
			}

			public override nint NumberOfSections (UITableView tableView)
			{
				return 1;
			}

			public override nint RowsInSection (UITableView tableview, nint section)
			{
				return (nint) this.controller.sampleArray.Count;;
			}
				
			public override string TitleForHeader (UITableView tableView, nint section)
			{
				return this.controller.selectedControl;
			}

			public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
			{
				nuint row 				= (nuint)indexPath.Row;
				NSString selectedSample = sampleArray.GetItem<NSString> (row);
				// Load selected sample
				this.controller.LoadSample(selectedSample);
				this.controller.menuVisible = false;
				this.controller.HideMenu ();
			}

			public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
			{
				var cell = tableView.DequeueReusableCell (SampleTableViewCell.Key) as SampleTableViewCell;
				if (cell == null)
					cell = new SampleTableViewCell ();

				// Configure the cell...

				nuint row 			= (nuint)indexPath.Row;
				NSString sampleName = sampleArray.GetItem<NSString> (row);
				cell.TextLabel.Text = sampleName;
				sampleDict     		= sampleDictArray.GetItem<NSDictionary>(row);

				if (sampleDict.ValueForKey (new NSString ("SampleName")).ToString () == sampleName) {

					if (sampleDict.ValueForKey (new NSString ("IsNew")).ToString () == "YES") {
						cell.DetailTextLabel.Text 		= "NEW";
						cell.DetailTextLabel.TextColor 	= UIColor.FromRGB (148, 75, 157);
					} else if (sampleDict.ValueForKey (new NSString ("IsUpdated")).ToString () == "YES") {
						cell.DetailTextLabel.Text 		= "UPDATED";
						cell.DetailTextLabel.TextColor 	= UIColor.FromRGB (148, 75, 157);
					} else {
						cell.DetailTextLabel.Text 		= null;
					}
				}
					
				cell.Accessory = UITableViewCellAccessory.None;
				return cell;
			}
		}
	}
}

