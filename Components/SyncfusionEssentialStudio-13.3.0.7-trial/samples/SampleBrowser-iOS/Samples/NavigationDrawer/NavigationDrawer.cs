#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 



#endregion
using System;
using System.Collections.Generic;
using Syncfusion.SfNavigationDrawer.iOS;

#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif

namespace SampleBrowser
{
	public class NavigationDrawer : SampleView
	{
		private string selectedType;
		UILabel label3,label4;
		UIButton textbutton = new UIButton ();
		UILabel lbe;
		UIButton textbutton1 = new UIButton ();
		UIButton doneButton=new UIButton();
		UIPickerView picker1, picker2;

		public UITableView table;
		public string[] tableItems;
		UIView HeaderView;
		UIImageView imageview;
		static public SFNavigationDrawer sideMenuController;
		static public MainPageView mainView;
		private readonly IList<string> TAlignment = new List<string>
		{
			"Left",
			"Right",
			"Top",
			"Bottom"

		};
		private readonly IList<string> LAlignment = new List<string>
		{
			"SlideOnTop",
			"Reveal",
			"Push"
		};
		public NavigationDrawer ()
		{
			picker1 = new UIPickerView ();
			picker2 = new UIPickerView ();

			PickerModel model = new PickerModel (TAlignment);
			picker1.Model = model;
			PickerModel model1 = new PickerModel (LAlignment);
			picker2.Model = model1;

			label3 = new UILabel ();

			textbutton = new UIButton ();
			textbutton1 = new UIButton ();
			label4 = new UILabel ();



			label3.Text = "Position";
			label3.TextColor = UIColor.Black;
			label3.TextAlignment = UITextAlignment.Left;

			label4.Text = "Transition";
			label4.TextColor = UIColor.Black;
			label4.TextAlignment = UITextAlignment.Left;


			textbutton.SetTitle("Left",UIControlState.Normal);
			textbutton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			textbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textbutton.Layer.CornerRadius = 8;
			textbutton.Layer.BorderWidth = 2;
			textbutton.TouchUpInside += ShowPicker1;
			textbutton.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;


			textbutton1.SetTitle("SlideOnTop",UIControlState.Normal);
			textbutton1.SetTitleColor(UIColor.Black,UIControlState.Normal);
			textbutton1.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			textbutton1.Layer.CornerRadius = 8;
			textbutton1.Layer.BorderWidth = 2;
			textbutton1.TouchUpInside += ShowPicker2;
			textbutton1.Layer.BorderColor =UIColor.FromRGB(246,246,246).CGColor;

			doneButton.SetTitle("Done\t",UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black,UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(246,246,246);

			model.PickerChanged += SelectedIndexChanged;
			model1.PickerChanged += SelectedIndexChanged1;

			picker1.ShowSelectionIndicator = true;
			picker1.Hidden = true;

			picker2.ShowSelectionIndicator = true;
			picker2.Hidden = true;
			this.control = this;
		}


		public override void LayoutSubviews ()
		{

			//NavigationDrawer initialize
			sideMenuController = new SFNavigationDrawer ();
			mainView = new MainPageView(this.Frame);
			UIButton bn=new UIButton();
			bn.Frame =new CGRect (10, 10, 30, 30);
			bn.SetBackgroundImage (new UIImage ("Images/menu.png"), UIControlState.Normal);
			mainView.AddSubview (bn);

			sideMenuController.ContentView = mainView;
			if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
			{
				sideMenuController.DrawerWidth = (this.Bounds.Width*40)/100;
			}
			else
				sideMenuController.DrawerWidth = (this.Bounds.Width*60)/100;

			sideMenuController.DrawerHeight = this.Bounds.Height;
			mainView.Frame = new CGRect (0, 0, this.Bounds.Width, this.Bounds.Height);

			//Menu Page Design
			table = new UITableView(new CGRect(0, 0, sideMenuController.DrawerWidth, this.Frame.Height)); // defaults to Plain style
			tableItems = new string[] {"Home","Profile","Inbox","Outbox","Sent Items","Trash"};
			TableSource sc = new TableSource(tableItems);
			sc.customise = false;
			table.Source = sc;
			this.BackgroundColor = UIColor.FromRGB(63,134,246);
			HeaderView = new UIView ();
			HeaderView.Frame = new CGRect (0, 0, sideMenuController.DrawerWidth, 100);
			HeaderView.BackgroundColor = UIColor.FromRGB (49, 173, 225);
			UIView centerview = new UIView ();
			centerview.Frame = new CGRect (0, 100, sideMenuController.DrawerWidth, 500);
			centerview.Add (table);
			lbe = new UILabel ();
			lbe.Frame =new CGRect (0, 70, sideMenuController.DrawerWidth, 30);
			lbe.Text="James Pollock";
			lbe.TextColor = UIColor.White;
			lbe.TextAlignment = UITextAlignment.Center;
			HeaderView.AddSubview (lbe);

			imageview=new UIImageView();
			imageview.Frame =new CGRect ((sideMenuController.DrawerWidth/2)-25, 15, 50, 50);
			imageview.Image = new UIImage ("Images/User.png");

			HeaderView.AddSubview (imageview);

			sideMenuController.DrawerHeaderView = HeaderView;
			sideMenuController.DrawerContentView = centerview;
			sideMenuController.Position = SFNavigationDrawerPosition.SFNavigationDrawerPositionLeft;

			this.AddSubview (sideMenuController.View);


			bn.TouchDown+= (object sender, System.EventArgs e) => 
			{
				sideMenuController.ToggleDrawer();

			};



			foreach (var view in this.Subviews) {


				label3.Frame = new CGRect (this.Frame.X +10, this.Frame.Y-20, this.Frame.Size.Width - 20, 30);
				textbutton.Frame=new CGRect(this.Frame.X +10, this.Frame.Y+20, this.Frame.Size.Width - 20, 30);	
				label4.Frame = new CGRect (this.Frame.X +10, this.Frame.Y+60, this.Frame.Size.Width - 20, 30);
				textbutton1.Frame=new CGRect(this.Frame.X +10, this.Frame.Y+100, this.Frame.Size.Width - 20, 30);	
				picker1.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width, this.Frame.Size.Height/3);
				picker2.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width , this.Frame.Size.Height/3);
				doneButton.Frame = new CGRect (0, this.Frame.Size.Height-(this.Frame.Size.Height/3), this.Frame.Size.Width, 30);
			}


		}
		UIView view1 = new UIView ();
		public override UIView optionView()
		{
			base.optionView ();
			view1.AddSubview (label3);
			view1.AddSubview (textbutton);
			view1.AddSubview (label4);
			view1.AddSubview (textbutton1);
			view1.AddSubview (picker1);
			view1.AddSubview (picker2);
			view1.AddSubview (doneButton);
			return view1;
		}
		void ShowPicker1 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			picker1.Hidden = false;
			picker2.Hidden = true;
		}

		void HidePicker (object sender, EventArgs e) {

			doneButton.Hidden = true;
			picker2.Hidden = true;
			picker1.Hidden = true;
		}

		void ShowPicker2 (object sender, EventArgs e) {

			doneButton.Hidden = false;
			picker1.Hidden = true;
			picker2.Hidden = false;
		}

		private void SelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			textbutton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "Left") {
				sideMenuController.Position = SFNavigationDrawerPosition.SFNavigationDrawerPositionLeft;
				sideMenuController.DrawerHeight =this.Frame.Height;
				if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					sideMenuController.DrawerWidth = (this.Bounds.Width*40)/100;
				}
				else
					sideMenuController.DrawerWidth = (this.Bounds.Width*60)/100;
				
				table.Frame=new CGRect (0, 0, sideMenuController.DrawerWidth, this.Frame.Height);
				lbe.Frame=new CGRect (0, 70, sideMenuController.DrawerWidth, 30);
				imageview.Frame =new CGRect ((sideMenuController.DrawerWidth/2)-25, 15, 50, 50);
			} 
			else if (selectedType == "Top") {
				sideMenuController.Position = SFNavigationDrawerPosition.SFNavigationDrawerPositionTop;
				sideMenuController.DrawerHeight =200;
				sideMenuController.DrawerWidth = this.Frame.Width;
				table.Frame=new CGRect (0, 0, this.Frame.Width, 100);
				lbe.Frame=new CGRect (0, 70, this.Frame.Width, 30);
				imageview.Frame =new CGRect ((this.Frame.Width/2)-25, 15, 50, 50);
			}
			else if (selectedType == "Bottom") {
				sideMenuController.Position = SFNavigationDrawerPosition.SFNavigationDrawerPositionBottom;
				sideMenuController.DrawerHeight =300;
				sideMenuController.DrawerWidth = this.Frame.Width;
				table.Frame=new CGRect (0, 0, this.Frame.Width, 100);
				lbe.Frame=new CGRect (0, 70, this.Frame.Width, 30);
				imageview.Frame =new CGRect ((this.Frame.Width/2)-25, 15, 50, 50);
			}
			else 
			{
				sideMenuController.Position=SFNavigationDrawerPosition.SFNavigationDrawerPositionRight;
				sideMenuController.DrawerHeight =this.Frame.Height;
				if((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
				{
					sideMenuController.DrawerWidth = (this.Bounds.Width*40)/100;
				}
				else
					sideMenuController.DrawerWidth = (this.Bounds.Width*60)/100;
				
				table.Frame=new CGRect (0, 0, sideMenuController.DrawerWidth, this.Frame.Height);
				lbe.Frame=new CGRect (0, 70, sideMenuController.DrawerWidth, 30);
				imageview.Frame =new CGRect ((sideMenuController.DrawerWidth/2)-25, 15, 50, 50);
			} 
		}
		private void SelectedIndexChanged1(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			textbutton1.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "SlideOnTop") {
				sideMenuController.Transition = SFNavigationDrawerTransition.SFNavigationDrawerTransitionSlideOnTop;
			} else if (selectedType == "Reveal") {
				sideMenuController.Transition = SFNavigationDrawerTransition.SFNavigationDrawerTransitionReveal;
			}
			else{
				sideMenuController.Transition = SFNavigationDrawerTransition.SFNavigationDrawerTransitionPush;
			}
		}
	}
}
