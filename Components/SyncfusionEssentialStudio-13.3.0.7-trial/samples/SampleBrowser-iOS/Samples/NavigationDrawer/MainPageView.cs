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
	public class MainPageView : UIView
	{
		public UIView content;
		UIView background;
		UITableView maintable;
		public string[] tableItems;
		public string[] contentItems;
		UILabel header;
		UIButton img1;
		UIButton img2;
		UIButton img3;
		UIButton img4;
		UIButton img5;
		UIButton img6;

		public MainPageView (CGRect bounds)
		{
			header = new UILabel ();
			this.BackgroundColor = UIColor.FromRGB(49,173,225);
			this.Frame = new CGRect (0, 0, bounds.Width, bounds.Height);
			content =new UIView(new CGRect(0,0,this.Frame.Width,this.Frame.Height));
			background=new UIView(new CGRect(0,50,this.Frame.Width,this.Frame.Height+72));
			background.BackgroundColor = UIColor.White;
			setvalue1 (0);
			this.Add(background);
			background.Add(content);

			header.Frame =new CGRect ((bounds.Width/2)-100, 10, 200, 30);
			header.Text="Home";
			header.TextColor = UIColor.White;
			header.TextAlignment = UITextAlignment.Center;
			this.AddSubview (header);
		}
		public MainPageView ()
		{
			

		}


		public void setvalue1(int index)
		{
			foreach(UIView sub in this.Subviews)
			{
				if(sub==content)
				sub.RemoveFromSuperview();
			}
			content.RemoveFromSuperview ();
			content =new UIView(new CGRect(0,0,this.Frame.Width,this.Frame.Height));
			if (index == 0) {
				header.Text = "Home";
				nfloat width = ((this.Frame.Width)-30) / 2;
				nfloat height = (this.Frame.Height-100) /3;
				content.BackgroundColor = UIColor.White;
				img1 = new UIButton ();
				img1.SetBackgroundImage (new UIImage ("Images/profile.png"), UIControlState.Normal);
				img1.Frame = new CGRect (10, 10, width, height);
				img1.TouchUpInside += ShowSelection;
				content.AddSubview (img1);
				img2 = new UIButton ();
				img2.SetBackgroundImage (new UIImage ("Images/outbox.png"), UIControlState.Normal);
				img2.Frame = new CGRect (10, height+20, width, height);
				img2.TouchUpInside += ShowSelection;
				content.AddSubview (img2);
				img3 = new UIButton ();
				img3.SetBackgroundImage (new UIImage ("Images/trash.png"), UIControlState.Normal);
				img3.Frame = new CGRect (10, (height*2)+30, width, height);
				img3.TouchUpInside += ShowSelection;
				content.AddSubview (img3);
				img4 = new UIButton ();
				img4.SetBackgroundImage (new UIImage ("Images/inbox.png"), UIControlState.Normal);
				img4.Frame = new CGRect (20+width, 10, width, height);
				img4.TouchUpInside += ShowSelection;
				content.AddSubview (img4);
				img5 = new UIButton ();
				img5.SetBackgroundImage (new UIImage ("Images/sentitem.png"), UIControlState.Normal);
				img5.Frame = new CGRect (20+width, height+20, width, height);
				img5.TouchUpInside += ShowSelection;
				content.AddSubview (img5);
				img6 = new UIButton ();
				img6.SetBackgroundImage (new UIImage ("Images/power.png"), UIControlState.Normal);
				img6.Frame = new CGRect (20+width, (height*2)+30, width, height);
				img6.TouchUpInside += ShowSelection;
				content.AddSubview (img6);
			}
			else if (index == 1) {
				header.Text = "Profile";
				content.BackgroundColor = UIColor.White;
				UILabel lbe = new UILabel ();
				lbe.Frame =new CGRect ((this.Frame.Width/2)+20, 20, 200, 30);
				lbe.Text="James Pollock";
				lbe.TextAlignment = UITextAlignment.Left;
				content.AddSubview (lbe);
				UILabel lbe1 = new UILabel ();
				lbe1.Frame =new CGRect ((this.Frame.Width/2)+20, 45, 200, 30);
				lbe1.Text="Age 30";
				lbe1.Font = UIFont.FromName ("Helvetica", 18f);
				lbe1.TextAlignment = UITextAlignment.Left;
				content.AddSubview (lbe1);
				UILabel lbe3 = new UILabel ();
				lbe3.Frame =new CGRect (10, 120, this.Frame.Width-20, 1);
				lbe3.BackgroundColor = UIColor.Gray;
				content.AddSubview (lbe3);
				UIImageView imageview=new UIImageView();
				imageview.Frame =new CGRect ((this.Frame.Width/2)-80, 10, 80, 80);
				imageview.Image = new UIImage ("Images/User.png");

				content.Add (imageview);
				UILabel cnt = new UILabel ();
				cnt.Frame =new CGRect (20, 130, this.Frame.Width-40, 200);
				cnt.Text="It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout." +
					" The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters. \n\nWhen looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters." +
					"\n\n James Pollock";
				cnt.Font = UIFont.FromName ("Helvetica", 15f);
				cnt.LineBreakMode = UILineBreakMode.WordWrap;
				cnt.Lines = 0;
				content.AddSubview (cnt);

			}else if (index == 2) {
				header.Text = "Inbox";
				maintable = new UITableView (new CGRect (0, 0, this.Frame.Width, this.Frame.Height)); // defaults to Plain style
				tableItems = new string[] { "John", "Caster", "Joey", "Xavier", "Gonzalez", "Rodriguez", "Ruben" };
				contentItems = new string[] {"Hi John, See you at 10AM", "Hi Caster, See you at 11AM", "Hi Joey, See you at 1PM", "Hi Xavier, See you at 2PM", "Hi Gonzalez, See you at 3PM", "Hi Rodriguez, See you at 4PM",
					"Hi Ruben, See you at 6PM"
				};
				TableSource sc = new TableSource (tableItems, contentItems);
				sc.customise = true;
				maintable.Source = sc;
				content.Add (maintable);

			} else if (index == 3) {
				header.Text = "Outbox";
				maintable = new UITableView (new CGRect (0, 0, this.Frame.Width, this.Frame.Height)); // defaults to Plain style
				tableItems = new string[] { "Ruben", "Rodriguez", "Gonzalez", "Xavier", "Joey", "Caster", "John" };
				contentItems = new string[] {"Hi Ruben, See you at 6PM", "Hi Rodriguez, See you at 4PM", "Hi Gonzalez, See you at 3PM", "Hi Xavier, See you at 2PM", "Hi Joey, See you at 1PM", "Hi Caster, See you at 11AM",
					"Hi John, See you at 10AM"
				};
				TableSource sc = new TableSource (tableItems, contentItems);
				sc.customise = true;
				maintable.Source = sc;
				content.Add (maintable);
			}else if (index == 4) {
				header.Text = "Sent";
				maintable = new UITableView (new CGRect (0, 0, this.Frame.Width, this.Frame.Height)); // defaults to Plain style
				tableItems = new string[] { "Gonzalez", "Rodriguez", "Ruben", "John", "Caster", "Joey", "Xavier"};
				contentItems = new string[] {"Hi Gonzalez, See you at 3PM", "Hi Rodriguez, See you at 4PM", "Hi Ruben, See you at 6PM", "Hi John, See you at 10AM", "Hi Caster, See you at 11AM", "Hi Joey, See you at 1PM",
					"Hi Xavier, See you at 2PM"
				};
				TableSource sc = new TableSource (tableItems, contentItems);
				sc.customise = true;
				maintable.Source = sc;
				content.Add (maintable);
			}
			else if (index == 5) {
				header.Text = "Trash";
				maintable = new UITableView (new CGRect (0, 0, this.Frame.Width, this.Frame.Height)); // defaults to Plain style
				tableItems = new string[] { "Xavier", "Joey", "Caster", "John", "Gonzalez", "Rodriguez", "Ruben" };
				contentItems = new string[] {"Hi Xavier, See you at 2PM", "Hi Joey, See you at 1PM", "Hi , See you at 11AM", "Hi John, See you at 10AM", "Hi Gonzalez, See you at 3PM", "Hi Rodriguez, See you at 4PM",
					"Hi Ruben, See you at 6PM"
				};
				TableSource sc = new TableSource (tableItems, contentItems);
				sc.customise = true;
				maintable.Source = sc;
				content.Add (maintable);
			}
			background.Add(content);
		}
		void ShowSelection (object sender, EventArgs e) {

			if (img1 == sender)
				setvalue1 (1);
			else if (img2 == sender)
				setvalue1 (3);
			else if (img3 == sender)
				setvalue1 (5);
			else if (img4 == sender)
				setvalue1 (2);
			else if (img5 == sender)
				setvalue1 (4);

		}



	}
}
