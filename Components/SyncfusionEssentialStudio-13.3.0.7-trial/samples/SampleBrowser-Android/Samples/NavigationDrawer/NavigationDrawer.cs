#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Com.Syncfusion.Navigationdrawer;

namespace SampleBrowser
{
	[Activity (Label = "NavigationDrawer")]			
	public class NavigationDrawer : SamplePage
	{
		Button btn,leftbtn,rightbtn; ListView listView;
		SfNavigationDrawer slideDrawer;
		LinearLayout propertylayout, stackView3;
		AlertDialog.Builder builderSingle,builderSingle2;
		ArrayAdapter<String> dataadpater,dataAdapter,dataAdapter1;
		Spinner positionSpinner,animationSpinner;
		Position sliderposition = Position.Left;
		Transition sliderTransition =Transition.SlideOnTop;


		public override void OnApplyChanges ()
		{
			base.OnApplyChanges ();
			slideDrawer.Position=sliderposition;
			slideDrawer.Transition=sliderTransition;
		}
		int height,width;

		public override View GetPropertyWindowLayout (Context context)
		{
			int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
			propertylayout = new LinearLayout(context);
			propertylayout.Orientation = Orientation.Vertical;

			LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(
				width * 2, 3);

			layoutParams.SetMargins(0, 20, 0, 0);

			TextView culture = new TextView(context);
			culture.TextSize=20;
			culture.Text="Position";

			positionSpinner = new Spinner(context);
			positionSpinner.SetGravity(GravityFlags.Left);


			List<String> list = new List<String>();

			list.Add("Left");
			list.Add("Right");
			list.Add("Top");
			list.Add("Bottom");


			dataAdapter = new ArrayAdapter<String>
				(context, Android.Resource.Layout.SimpleSpinnerItem, list);
			dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);


			positionSpinner.Adapter = dataAdapter;
			positionSpinner.ItemSelected+= (object sender, AdapterView.ItemSelectedEventArgs e) => {
				String selectedItem= dataAdapter.GetItem(e.Position);
				if (selectedItem.Equals("Left")) {
					sliderposition = Position.Left;
				}
				if (selectedItem.Equals("Right")) {
					sliderposition = Position.Right;
				}
				if (selectedItem.Equals("Top")) {
					sliderposition = Position.Top;
				}
				if (selectedItem.Equals("Bottom")) {
					sliderposition = Position.Bottom;
				}
			};

			propertylayout.AddView(culture);
			propertylayout.AddView(positionSpinner);

			SeparatorView separate = new SeparatorView(context, width * 2);
			separate.separatorColor = Color.LightGray;
			separate.LayoutParameters=new ViewGroup.LayoutParams(width * 2, 3);
			propertylayout.AddView(separate, layoutParams);

			TextView culture2 = new TextView(context);
			culture2.TextSize=20;
			culture2.Text="Animations";

			animationSpinner = new Spinner(context);

			animationSpinner.SetGravity(GravityFlags.Left);


			List<String> list2 = new List<String>();

			list2.Add("SlideOnTop");
			list2.Add("Reveal");
			list2.Add("Push");



			dataAdapter1 = new ArrayAdapter<String>
				(context, Android.Resource.Layout.SimpleSpinnerItem, list2);

			dataAdapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);;

			animationSpinner.ItemSelected+= (object sender, AdapterView.ItemSelectedEventArgs e) => {
				String selectedItem= dataAdapter1.GetItem(e.Position);
				if (selectedItem.Equals("SlideOnTop")) {
					sliderTransition = Transition.SlideOnTop;
				}
				if (selectedItem.Equals("Reveal")) {
					sliderTransition =Transition.Reveal;
				}
				if (selectedItem.Equals("Push")) {
					sliderTransition =Transition.Push;
				}
			};

			animationSpinner.Adapter = dataAdapter1;
			propertylayout.AddView(culture2);
			propertylayout.AddView(animationSpinner);

			SeparatorView separate2 = new SeparatorView(context, width * 2);
			separate2.separatorColor = Color.LightGray;
			separate2.LayoutParameters=new ViewGroup.LayoutParams(width * 2, 3);
			propertylayout.AddView(separate2, layoutParams);

			propertylayout.SetPadding(20,20,20,20);

			return propertylayout;
		}


		public override View GetSampleContent (Context context)
		{
			btn = new Button(context);
			btn.SetBackgroundResource(Resource.Drawable.burgericon);
			FrameLayout.LayoutParams btlayoutParams = new FrameLayout.LayoutParams(42,32, GravityFlags.Center);

			btn.LayoutParameters = btlayoutParams;
			btn.SetPadding (10,0,0,0);
			btn.Gravity=GravityFlags.CenterVertical;


			TextView textView = new TextView(context);
			textView.TextSize=20;
			textView.Text="Home";
			textView.SetTextColor (Color.White);
			textView.Gravity=GravityFlags.Center;
			LinearLayout linearLayout =  new LinearLayout(context);
			FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 70, GravityFlags.Center);
			layoutParams.SetMargins (10,0,0,0);
			linearLayout.SetPadding (10,0,0,0);
			linearLayout.AddView(btn);linearLayout.AddView(textView,layoutParams);
			linearLayout.SetBackgroundColor(Color.Rgb(47,173,227));



			height = context.Resources.DisplayMetrics.HeightPixels-75;
			width =context.Resources.DisplayMetrics.WidthPixels;

			LinearLayout linear2 = new LinearLayout(context);
			linear2.Orientation=Orientation.Vertical;
			linear2.LayoutParameters = new ViewGroup.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			FrameLayout.LayoutParams layout2= new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
			linear2.AddView(linearLayout,layout2);

			/**
			 * Main Content
			 * */




			FrameLayout gridLayout = new FrameLayout(context);
			gridLayout.LayoutParameters=new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

			/**
         * item1
         */

			FrameLayout grid1 = new FrameLayout(context);
			ImageView img1 = new ImageView(context);
			img1.SetScaleType (ImageView.ScaleType.FitXy);
			img1.SetImageResource(Resource.Drawable.profile);

			FrameLayout.LayoutParams layoutParams1 = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.Center);

			grid1.AddView(img1, layoutParams1);

			grid1.LayoutParameters=new ViewGroup.LayoutParams((width-20) / 2,(height - 100)/3);

			/**
         * item2
         */

			FrameLayout grid2 = new FrameLayout(context);
			ImageView img2 = new ImageView(context);
			img2.SetImageResource(Resource.Drawable.inbox);
			img2.SetScaleType (ImageView.ScaleType.FitXy);
			grid2.AddView(img2, layoutParams1);
			grid2.LayoutParameters=new ViewGroup.LayoutParams((width-20) / 2,(height - 100)/3);

			/**
         * item3
         */

			FrameLayout grid3 = new FrameLayout(context);
			ImageView img3 = new ImageView(context);
			img3.SetImageResource(Resource.Drawable.outbox);
			img3.SetScaleType (ImageView.ScaleType.FitXy);
			grid3.AddView(img3, layoutParams1);
			grid3.LayoutParameters=new ViewGroup.LayoutParams((width-20) / 2,(height - 100)/3);


			/**
         * item4
         */

			FrameLayout grid4 = new FrameLayout(context);
			ImageView img4 = new ImageView(context);
			img4.SetImageResource(Resource.Drawable.flag);
			img4.SetScaleType (ImageView.ScaleType.FitXy);
			grid4.AddView(img4, layoutParams1);
			grid4.LayoutParameters=new ViewGroup.LayoutParams((width-20) / 2,(height - 100)/3);
			/**
         * item5
         */
			FrameLayout grid5 = new FrameLayout(context);
			ImageView img5 = new ImageView(context);
			img5.SetImageResource(Resource.Drawable.trash);
			img5.SetScaleType (ImageView.ScaleType.FitXy);

			grid5.AddView(img5, layoutParams1);

			grid5.LayoutParameters=new ViewGroup.LayoutParams((width-20) / 2,(height - 155)/3);



			/**
         * item6
         */



			FrameLayout grid6 = new FrameLayout(context);
			ImageView img6 = new ImageView(context);
			img6.SetImageResource(Resource.Drawable.power);		
			grid6.AddView(img6, layoutParams1);
			img6.SetScaleType (ImageView.ScaleType.FitXy);
			grid6.LayoutParameters=new ViewGroup.LayoutParams((width-20) / 2,(height - 155)/3);


			img1.SetPadding (0,0,0,3);
			img2.SetPadding (-1,0,0,3);
			img3.SetPadding (0,0,0,0);
			img4.SetPadding (-1,0,0,0);
			img5.SetPadding (0,0,0,15);
			img6.SetPadding (-1,0,0,15);
			int x=0;
			int y=5;

			int x1,y1;
			x1= (x)+(width/2);
			y1 = (2*y)+((height-100)/3);
			grid1.SetX(x); grid1.SetY(y);
			grid2.SetX(x1); grid2.SetY(y);
			grid3.SetX(x); grid3.SetY(y1);
			grid4.SetX(x1); grid4.SetY(y1);
			grid5.SetX(x); grid5.SetY((2*y1));
			grid6.SetX(x1); grid6.SetY((2*y1));

			gridLayout.AddView(grid1);
			gridLayout.AddView(grid2);
			gridLayout.AddView(grid3);
			gridLayout.AddView(grid4);
			gridLayout.AddView(grid5);
			gridLayout.AddView(grid6);

			FrameLayout ContentFrame = new FrameLayout (context);
			ContentFrame.LayoutParameters = new ViewGroup.LayoutParams (ViewGroup.LayoutParams.MatchParent, height-75);
			ContentFrame.SetBackgroundColor (Color.White);
			ContentFrame.AddView (gridLayout);
			gridLayout.SetBackgroundColor (Color.White);
			linear2.AddView (ContentFrame);



			LinearLayout contentLayout= new LinearLayout(context);

			RoundedImageView imgvw=new RoundedImageView(context,120,120);
			imgvw.SetPadding(0,10,0,10);
			imgvw.SetImageResource(Resource.Drawable.user);
			LinearLayout.LayoutParams layparams8 = new LinearLayout.LayoutParams(120, 120);
			layparams8.Gravity = GravityFlags.Center;
			imgvw.LayoutParameters=new ViewGroup.LayoutParams(120, 120);

			TextView text = new TextView(context);
			text.Text="James Pollock";
			text.Gravity=GravityFlags.Center;
			text.TextSize=17;
			text.SetTextColor(Color.White);
			text.SetPadding (0,20,0,0);
			text.LayoutParameters=new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			LinearLayout headerLayout=new LinearLayout(context);
			headerLayout.Orientation=Orientation.Vertical;
			headerLayout.SetBackgroundColor(Color.Rgb(47,173,227));
			headerLayout.LayoutParameters=new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 200);
			headerLayout.SetGravity (GravityFlags.Center);
			headerLayout.AddView(imgvw,layparams8);
			headerLayout.AddView(text);
			LinearLayout.LayoutParams layparams2 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int) (height * 0.15));
			layparams2.Gravity = GravityFlags.Center;
			contentLayout.AddView(headerLayout);
			LinearLayout.LayoutParams layparams5 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent,  (2));

			contentLayout.AddView(new SeparatorView(context,width){separatorColor=Color.LightGray},layparams5);
			contentLayout.SetBackgroundColor (Color.White);
			linear2.SetBackgroundColor(Color.White);

			slideDrawer = new Com.Syncfusion.Navigationdrawer.SfNavigationDrawer(context);
			slideDrawer.ContentView=linear2;
			slideDrawer.DrawerWidth = (float)(width * 0.60);
			slideDrawer.DrawerHeight = (float)(height * 0.60);
			slideDrawer.Transition=Transition.SlideOnTop;
			slideDrawer.LayoutParameters=new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			listView = new ListView(context);
			listView.VerticalScrollBarEnabled = true;
			btn.Click+= (object sender, EventArgs e) => {
				slideDrawer.ToggleDrawer();
			};

			List<String> list = new List<String>();

			list.Add("Home");
			list.Add("Profile");
			list.Add("Inbox");
			list.Add("Outbox");
			list.Add("Sent Items");
			list.Add("Trash");



			ArrayAdapter<String> arrayAdapter =new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleListItem1,list);
			listView.SetAdapter(arrayAdapter);
			listView.SetBackgroundColor(Color.White);
			listView.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent,ViewGroup.LayoutParams.MatchParent);
			contentLayout.AddView(listView);

			contentLayout.Orientation=Orientation.Vertical;

			FrameLayout frame = new FrameLayout (context);
			frame.LayoutParameters = new ViewGroup.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			frame.SetBackgroundColor (Color.White);
			frame.AddView (contentLayout);
			slideDrawer.DrawerContentView=frame;



			/**
			 * profile content
			 * */

			LinearLayout profilelayout = new LinearLayout(context);
			profilelayout.LayoutParameters = new ViewGroup.LayoutParams (ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			profilelayout.Orientation = Orientation.Vertical;
			LinearLayout linearLayout2 = new LinearLayout(context);
			linearLayout2.SetGravity(GravityFlags.Center);
			linearLayout2.SetPadding(0,30,0,30);
			linearLayout2.LayoutParameters=new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			RoundedImageView rddimgvw=new RoundedImageView(context,  150,  150);
			rddimgvw.LayoutParameters=new ViewGroup.LayoutParams(  150,  150);
			rddimgvw.SetImageResource(Resource.Drawable.user);
			LinearLayout txtlayout=new LinearLayout(context);
			txtlayout.SetPadding(40,0,0,0);
			txtlayout.Orientation=Orientation.Vertical;
			TextView txtvw=new TextView(context);
			txtvw.TextSize=20;
			txtvw.Text="JamesPollock";
			txtvw.SetTextColor (Color.Black);

			TextView txtvw1=new TextView(context);
			txtvw1.Text="Age 30";
			txtvw1.TextSize=13;			
			txtvw1.SetTextColor (Color.Black);
			txtlayout.AddView(txtvw);
			txtlayout.AddView(txtvw1);
			linearLayout2.AddView(rddimgvw);
			linearLayout2.AddView(txtlayout);
			linearLayout2.SetBackgroundColor(Color.White);
			profilelayout.AddView(linearLayout2);
			//int Width=context.getResources().getDisplayMetrics().widthPixels;
			profilelayout.Orientation=Orientation.Vertical;
			FrameLayout.LayoutParams separatorparams=new FrameLayout.LayoutParams(width,2,GravityFlags.Center);
			SeparatorView separatorView = new SeparatorView(context,width);
			separatorView.separatorColor = Color.LightGray;
			//separatorView.Invalidate ();
			separatorView.SetPadding(20,0,20,20);

			profilelayout.AddView(separatorView, separatorparams);

			TextView textView60 =  new TextView(context);
			textView60.TextSize=16;
			textView60.SetPadding(20,0,20,0);
			textView60.SetBackgroundColor(Color.White);
			textView60.Text="\n" +
				"It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
				"\n" + "\n" + "when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
				"\n" + "\n" + "James Pollock";
			//textView.setHorizontallyScrolling(false);
			profilelayout.AddView(textView60);
			profilelayout.SetBackgroundColor (Color.White);


			/**
         * InBox Layout
         */
			LinearLayout inboxLayout=new LinearLayout(context);
			inboxLayout.LayoutParameters=new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			inboxLayout.SetBackgroundColor (Color.White);
			inboxLayout.Orientation=Orientation.Vertical;
			LinearLayout mail1=new LinearLayout(context);
			TextView textView8 = new TextView(context);
			textView8.Text="John";
			textView8.TextSize=18;
			TextView textView9 = new TextView(context);
			textView9.Text="Update on Timeline";
			textView9.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView9.TextSize=16;
			TextView textView10 = new TextView(context);
			textView10.Text="Hi John, See you at 10AM";

			SeparatorView separate4 = new SeparatorView(context, width * 2);
			separate4.separatorColor = Color.LightGray;
			separate4.LayoutParameters=new ViewGroup.LayoutParams(width * 2, 3);

			LinearLayout.LayoutParams layoutParams5 = new LinearLayout.LayoutParams(width * 2, 3);
			layoutParams5.SetMargins(0, 10, 15, 0);
			textView10.TextSize=13;
			mail1.AddView(textView8);
			mail1.AddView(textView10);

			LinearLayout mail2=new LinearLayout(context);
			TextView textView11 = new TextView(context);
			textView11.Text="Caster";
			textView11.TextSize=18;
			TextView textView12 = new TextView(context);
			textView12.Text="Update on Timeline";
			textView12.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView12.TextSize=16;
			TextView textView13 = new TextView(context);
			textView13.Text="Hi Caster, See you at 11AM";
			//textView13.setTextColor(Color.parseColor("#1CAEE4"));
			textView13.TextSize=13;
			mail2.AddView(textView11);
			//mail2.addView(textView12);
			mail2.AddView(textView13);

			SeparatorView separate1 = new SeparatorView(context, width * 2);
			separate1.separatorColor = Color.LightGray;
			separate1.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));




			LinearLayout mail3=new LinearLayout(context);
			TextView textView14 = new TextView(context);
			textView14.Text="Joey";
			textView14.TextSize=18;
			TextView textView15 = new TextView(context);
			textView15.Text="Update on Timeline";
			textView15.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView15.TextSize=16;
			TextView textView16 = new TextView(context);
			textView16.Text="Hi Joey, See you at 1PM";
			textView16.TextSize=13;
			mail3.AddView(textView14);
			mail3.AddView(textView16);

			SeparatorView separate5 = new SeparatorView(context, width * 2);
			separate5.separatorColor = Color.LightGray;
			separate5.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			LinearLayout mail4=new LinearLayout(context);
			TextView textView17 = new TextView(context);
			textView17.Text="Xavier";
			textView17.TextSize=18;
			TextView textView18 = new TextView(context);
			textView18.Text="Update on Timeline";
			textView18.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView18.TextSize=16;
			TextView textView19 = new TextView(context);
			textView19.Text="Hi Xavier, See you at 2PM";
			textView19.TextSize=13;
			mail4.AddView(textView17);
			mail4.AddView(textView19);

			SeparatorView separate3 = new SeparatorView(context, width * 2);
			separate3.separatorColor = Color.LightGray;
			separate3.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			LinearLayout mail9=new LinearLayout(context);
			TextView textView33 = new TextView(context);
			textView33.Text="Gonzalez";
			textView33.TextSize=18;
			TextView textView34 = new TextView(context);
			textView34.Text="Update on Timeline";
			textView34.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView34.TextSize=16;
			TextView textView35 = new TextView(context);
			textView35.Text="Hi Gonzalez, See you at 3PM";
			textView35.TextSize=13;
			mail9.AddView(textView33);
			//mail4.addView(textView18);
			mail9.AddView(textView35);

			SeparatorView separate7 = new SeparatorView(context, width * 2);
			separate7.separatorColor = Color.LightGray;
			separate7.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			LinearLayout mail10=new LinearLayout(context);
			TextView textView36 = new TextView(context);
			textView36.Text="Rodriguez";
			textView36.TextSize=18;
			TextView textView37 = new TextView(context);
			textView37.Text="Update on Timeline";
			textView37.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView37.TextSize=16;
			TextView textView38 = new TextView(context);
			textView38.Text="Hi Rodriguez, See you at 4PM";
			textView38.TextSize=13;
			mail10.AddView(textView36);
			mail10.AddView(textView38);

			SeparatorView separate10 = new SeparatorView(context, width * 2);
			separate10.separatorColor = Color.LightGray;
			separate10.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			LinearLayout mail11=new LinearLayout(context);
			TextView textView39 = new TextView(context);
			textView39.Text="Ruben";
			textView39.TextSize=18;
			TextView textView40 = new TextView(context);
			textView40.Text="Update on Timeline";
			textView40.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView40.TextSize=16;
			TextView textView41 = new TextView(context);
			textView41.Text="Hi Ruben, See you at 6PM";
			textView41.TextSize=13;
			mail11.AddView(textView39);
			mail11.AddView(textView41);

			SeparatorView separate11 = new SeparatorView(context, width * 2);
			separate11.separatorColor = Color.LightGray;
			separate11.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			mail1.Orientation=Orientation.Vertical;
			mail2.Orientation=Orientation.Vertical;
			mail3.Orientation=Orientation.Vertical;
			mail4.Orientation=Orientation.Vertical;
			mail9.Orientation=Orientation.Vertical;
			mail10.Orientation=Orientation.Vertical;
			mail11.Orientation=Orientation.Vertical;

			mail1.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail1.SetPadding(20,10,10,5);
			mail2.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail2.SetPadding(20,10,10,5);
			mail3.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail3.SetPadding(20,10,10,5);
			mail4.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail4.SetPadding(20,10,10,5);
			mail9.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail9.SetPadding(20,10,10,5);
			mail10.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail10.SetPadding(20,10,10,5);
			mail11.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail11.SetPadding(20,10,10,5);

			inboxLayout.SetPadding(20,0,20,20);
			inboxLayout.AddView(mail1);
			inboxLayout.AddView(separate4,layoutParams5);
			inboxLayout.AddView(mail2);
			inboxLayout.AddView(separate1,layoutParams5);
			inboxLayout.AddView(mail3);
			inboxLayout.AddView(separate5,layoutParams5);
			inboxLayout.AddView(mail4);
			inboxLayout.AddView(separate3,layoutParams5);
			inboxLayout.AddView(mail9);
			inboxLayout.AddView(separate7,layoutParams5);
			inboxLayout.AddView(mail10);
			inboxLayout.AddView(separate11,layoutParams5);
			inboxLayout.AddView(mail11);
			inboxLayout.AddView(separate10,layoutParams5);

			img2.Click+= (object sender, EventArgs e) => {

				ContentFrame.RemoveAllViews();
				inboxLayout.RemoveAllViews();
				inboxLayout.SetPadding(20,0,20,20);
				inboxLayout.AddView(mail1);
				inboxLayout.AddView(separate4,layoutParams5);
				inboxLayout.AddView(mail2);
				inboxLayout.AddView(separate1,layoutParams5);
				inboxLayout.AddView(mail3);
				inboxLayout.AddView(separate5,layoutParams5);
				inboxLayout.AddView(mail4);
				inboxLayout.AddView(separate3,layoutParams5);
				inboxLayout.AddView(mail9);
				inboxLayout.AddView(separate7,layoutParams5);
				inboxLayout.AddView(mail10);
				inboxLayout.AddView(separate11,layoutParams5);
				inboxLayout.AddView(mail11);
				inboxLayout.AddView(separate10,layoutParams5);
				ContentFrame.AddView(inboxLayout);
				textView.Text="Inbox";

			};

			/**
         * Outbox content
         */


			LinearLayout outboxlayout=new LinearLayout(context);
			outboxlayout.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
			outboxlayout.SetBackgroundColor(Color.White);
			outboxlayout.Orientation=(Orientation.Vertical);
			LinearLayout mail5=new LinearLayout(context);
			TextView textView20 = new TextView(context);
			textView20.Text="Ruben";
			textView20.TextSize=20;
			TextView textView21 = new TextView(context);
			textView21.Text="Update on Timeline";
			textView21.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView21.TextSize=16;
			TextView textView22 = new TextView(context);
			textView22.Text="Hi Ruben, see you at 6PM";

			SeparatorView separate6 = new SeparatorView(context, width * 2);
			separate6.separatorColor = Color.LightGray;
			separate6.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			textView22.TextSize=13;
			mail5.AddView(textView20);
			mail5.AddView(textView22);

			LinearLayout mail6=new LinearLayout(context);
			TextView textView23 = new TextView(context);
			textView23.Text="Rodriguez";
			textView23.TextSize=20;
			TextView textView24 = new TextView(context);
			textView24.Text="Update on Timeline";
			textView24.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView24.TextSize=16;
			TextView textView25 = new TextView(context);
			textView25.Text="Hi Rodriguez, see you at 4PM";
			textView25.TextSize=13;
			mail6.AddView(textView23);
			mail6.AddView(textView25);

			LinearLayout mail12=new LinearLayout(context);
			TextView textView42 = new TextView(context);
			textView42.Text="Gonzalez";
			textView42.TextSize=20;
			TextView textView43 = new TextView(context);
			textView43.Text="Update on Timeline";
			textView43.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView43.TextSize=16;
			TextView textView44 = new TextView(context);
			textView44.Text="Hi Gonzalez, see you at 3PM";
			mail12.AddView(textView42);
			//mail12.addView(textView43);
			mail12.AddView(textView44);

			SeparatorView separate14 = new SeparatorView(context, width * 2);
			separate14.separatorColor = Color.LightGray;
			separate14.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			mail12.Orientation=Orientation.Vertical;
			mail12.Orientation=(Orientation.Vertical);
			mail5.Orientation=Orientation.Vertical;
			mail6.Orientation=Orientation.Vertical;

			LinearLayout mail13=new LinearLayout(context);
			TextView textView45 = new TextView(context);
			textView45.Text="Xavier";
			textView45.TextSize=20;
			TextView textView46 = new TextView(context);
			textView46.Text="Update on Timeline";
			textView46.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView46.TextSize=16;
			TextView textView47 = new TextView(context);
			textView47.Text="Hi Xavier, see you at 2PM";

			SeparatorView separate15 = new SeparatorView(context, width * 2);
			separate15.separatorColor = Color.LightGray;
			separate15.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			mail13.AddView(textView45);
			mail13.AddView(textView47);

			mail13.Orientation=(Orientation.Vertical);
			mail13.Orientation=(Orientation.Vertical);

			LinearLayout mail14=new LinearLayout(context);
			TextView textView48 = new TextView(context);
			textView48.Text="Joey";
			textView48.TextSize=20;
			TextView textView49 = new TextView(context);
			textView49.Text="Update on Timeline";
			textView49.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView49.TextSize=16;
			TextView textView50 = new TextView(context);
			textView50.Text="Hi Joey, see you at 1PM";

			SeparatorView separate16 = new SeparatorView(context, width * 2);
			separate16.separatorColor = Color.LightGray;
			separate16.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			mail14.AddView(textView48);
			//mail12.addView(textView43);
			mail14.AddView(textView50);

			mail14.Orientation=(Orientation.Vertical);
			mail14.Orientation=(Orientation.Vertical);

			LinearLayout mail15=new LinearLayout(context);
			TextView textView51 = new TextView(context);
			textView51.Text="Joey";
			textView51.TextSize=20;
			TextView textView52 = new TextView(context);
			textView52.Text="Update on Timeline";
			textView52.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView52.TextSize=16;
			TextView textView53 = new TextView(context);
			textView53.Text="Hi Joey, see you at 1PM";

			SeparatorView separate17 = new SeparatorView(context, width * 2);
			separate17.separatorColor = Color.LightGray;
			separate17.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			mail15.AddView(textView51);
			mail15.AddView(textView53);

			mail15.Orientation=(Orientation.Vertical);
			mail15.Orientation=(Orientation.Vertical);


			LinearLayout mail16=new LinearLayout(context);
			TextView textView54 = new TextView(context);
			textView54.Text=("Caster");
			textView54.TextSize=(20);
			TextView textView55 = new TextView(context);
			textView55.Text=("Update on Timeline");
			textView55.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView55.TextSize=(16);
			TextView textView56 = new TextView(context);
			textView56.Text=("Hi Caster, see you at 11PM");

			SeparatorView separate18 = new SeparatorView(context, width * 2);
			separate18.separatorColor = Color.LightGray;
			separate18.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			mail16.AddView(textView54);
			mail16.AddView(textView56);

			mail16.Orientation=(Orientation.Vertical);
			mail16.Orientation=(Orientation.Vertical);

			LinearLayout mail17=new LinearLayout(context);
			TextView textView57 = new TextView(context);
			textView57.Text="john";
			textView57.TextSize=20;
			TextView textView58 = new TextView(context);
			textView58.Text=("Update on Timeline");
			textView58.SetTextColor(Color.ParseColor("#1CAEE4"));
			textView58.TextSize=(16);
			TextView textView59 = new TextView(context);
			textView59.Text=("Hi John, see you at 10AM");

			SeparatorView separate19 = new SeparatorView(context, width * 2);
			separate19.separatorColor = Color.LightGray;
			separate19.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));

			mail17.AddView(textView57);
			mail17.AddView(textView59);

			mail17.Orientation=(Orientation.Vertical);
			mail17.Orientation=(Orientation.Vertical);

			mail6.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail6.SetPadding(20, 10, 10, 10);
			mail5.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail5.SetPadding(20,10,10,5);
			mail12.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail12.SetPadding(20,10,10,5);
			mail13.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail13.SetPadding(20,10,10,5);
			mail14.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail14.SetPadding(20,10,10,5);
			mail15.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail15.SetPadding(20,10,10,5);
			mail16.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail16.SetPadding(20,10,10,5);
			mail17.LayoutParameters=(new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
			mail17.SetPadding(20,10,10,5);

			SeparatorView separate13 = new SeparatorView(context, width * 2);
			separate13.separatorColor = Color.LightGray;
			separate13.LayoutParameters=(new ViewGroup.LayoutParams(width * 2, 3));




			outboxlayout.SetPadding(20, 0, 20, 20);
			outboxlayout.AddView(mail5);
			outboxlayout.AddView(separate13, layoutParams5);
			outboxlayout.AddView(mail6);
			outboxlayout.AddView(separate6, layoutParams5);
			outboxlayout.AddView(mail12);
			outboxlayout.AddView(separate14, layoutParams5);
			outboxlayout.AddView(mail13);
			outboxlayout.AddView(separate15, layoutParams5);
			outboxlayout.AddView(mail15);
			outboxlayout.AddView(separate17, layoutParams5);
			outboxlayout.AddView(mail16);
			outboxlayout.AddView(separate18, layoutParams5);
			outboxlayout.AddView(mail17);
			outboxlayout.AddView(separate19, layoutParams5);

			img3.Click+= (object sender, EventArgs e) => {




				ContentFrame.RemoveAllViews();
				outboxlayout.RemoveAllViews();
				outboxlayout.SetPadding(20, 0, 20, 20);
				outboxlayout.AddView(mail5);
				outboxlayout.AddView(separate13, layoutParams5);
				outboxlayout.AddView(mail6);
				outboxlayout.AddView(separate6, layoutParams5);
				outboxlayout.AddView(mail12);
				outboxlayout.AddView(separate14, layoutParams5);
				outboxlayout.AddView(mail13);
				outboxlayout.AddView(separate15, layoutParams5);
				outboxlayout.AddView(mail15);
				outboxlayout.AddView(separate17, layoutParams5);
				outboxlayout.AddView(mail16);
				outboxlayout.AddView(separate18, layoutParams5);
				outboxlayout.AddView(mail17);
				outboxlayout.AddView(separate19, layoutParams5);
				ContentFrame.AddView(outboxlayout);
				textView.Text="OutBox";
			};



			listView.ItemClick+= (object sender, AdapterView.ItemClickEventArgs e) => {
				String selitem= arrayAdapter.GetItem(e.Position);
				if(selitem.Equals("Home")){
					ContentFrame.RemoveAllViews();
					ContentFrame.AddView(gridLayout);
					textView.Text="Home";

				}
				if(selitem.Equals("Profile")){
					ContentFrame.RemoveAllViews();
					ContentFrame.AddView(profilelayout);
					textView.Text="Profile";

				}
				if(selitem.Equals("Inbox")){
					ContentFrame.RemoveAllViews();
					inboxLayout.RemoveAllViews();
					inboxLayout.SetPadding(20,0,20,20);
					inboxLayout.AddView(mail1);
					inboxLayout.AddView(separate4,layoutParams5);
					inboxLayout.AddView(mail2);
					inboxLayout.AddView(separate1,layoutParams5);
					inboxLayout.AddView(mail3);
					inboxLayout.AddView(separate5,layoutParams5);
					inboxLayout.AddView(mail4);
					inboxLayout.AddView(separate3,layoutParams5);
					inboxLayout.AddView(mail9);
					inboxLayout.AddView(separate7,layoutParams5);
					inboxLayout.AddView(mail10);
					inboxLayout.AddView(separate11,layoutParams5);
					inboxLayout.AddView(mail11);
					inboxLayout.AddView(separate10,layoutParams5);
					ContentFrame.AddView(inboxLayout);
					textView.Text="Inbox";
				}
				if(selitem.Equals("Outbox")){

					ContentFrame.RemoveAllViews();
					outboxlayout.RemoveAllViews();
					outboxlayout.SetPadding(20, 0, 20, 20);
					outboxlayout.AddView(mail5);
					outboxlayout.AddView(separate13, layoutParams5);
					outboxlayout.AddView(mail6);
					outboxlayout.AddView(separate6, layoutParams5);
					outboxlayout.AddView(mail12);
					outboxlayout.AddView(separate14, layoutParams5);
					outboxlayout.AddView(mail13);
					outboxlayout.AddView(separate15, layoutParams5);
					outboxlayout.AddView(mail15);
					outboxlayout.AddView(separate17, layoutParams5);
					outboxlayout.AddView(mail16);
					outboxlayout.AddView(separate18, layoutParams5);
					outboxlayout.AddView(mail17);
					outboxlayout.AddView(separate19, layoutParams5);
					ContentFrame.AddView(outboxlayout);
					textView.Text="OutBox";
				}
				if(selitem.Equals("Sent Items")){
					ContentFrame.RemoveAllViews();
					inboxLayout.RemoveAllViews();
					inboxLayout.SetPadding(20,0,20,20);

					inboxLayout.AddView(mail10);
					inboxLayout.AddView(separate1,layoutParams5);
					inboxLayout.AddView(mail9);
					inboxLayout.AddView(separate5,layoutParams5);
					inboxLayout.AddView(mail4);
					inboxLayout.AddView(separate3,layoutParams5);
					inboxLayout.AddView(mail3);
					inboxLayout.AddView(separate10,layoutParams5);
					inboxLayout.AddView(mail11);
					inboxLayout.AddView(separate4,layoutParams5);
					inboxLayout.AddView(mail1);
					inboxLayout.AddView(separate7,layoutParams5);
					inboxLayout.AddView(mail2);
					inboxLayout.AddView(separate11,layoutParams5);
					ContentFrame.AddView(inboxLayout);
					textView.Text="Sent Items";
				}
				if(selitem.Equals("Trash")){
					ContentFrame.RemoveAllViews();
					outboxlayout.RemoveAllViews();
					outboxlayout.SetPadding(20, 0, 20, 20);
					outboxlayout.AddView(mail13);
					outboxlayout.AddView(separate15, layoutParams5);
					outboxlayout.AddView(mail5);
					outboxlayout.AddView(separate13, layoutParams5);
					outboxlayout.AddView(mail12);
					outboxlayout.AddView(separate14, layoutParams5);
					outboxlayout.AddView(mail15);
					outboxlayout.AddView(separate17, layoutParams5);
					outboxlayout.AddView(mail17);
					outboxlayout.AddView(separate19, layoutParams5);
					outboxlayout.AddView(mail16);
					outboxlayout.AddView(separate18, layoutParams5);
					outboxlayout.AddView(mail6);
					outboxlayout.AddView(separate6, layoutParams5);
					ContentFrame.AddView(outboxlayout);
					textView.Text="Trash";
				}
				slideDrawer.ToggleDrawer();


			};


			img1.Click+= (object sender, EventArgs e) => {
				ContentFrame.RemoveAllViews();
				ContentFrame.AddView(profilelayout);
				textView.Text="Profile";
			};





			img4.Click+= (object sender, EventArgs e) => {
				ContentFrame.RemoveAllViews();
				inboxLayout.RemoveAllViews();
				inboxLayout.SetPadding(20,0,20,20);

				inboxLayout.AddView(mail10);
				inboxLayout.AddView(separate1,layoutParams5);
				inboxLayout.AddView(mail9);
				inboxLayout.AddView(separate5,layoutParams5);
				inboxLayout.AddView(mail4);
				inboxLayout.AddView(separate3,layoutParams5);
				inboxLayout.AddView(mail3);
				inboxLayout.AddView(separate10,layoutParams5);
				inboxLayout.AddView(mail11);
				inboxLayout.AddView(separate4,layoutParams5);
				inboxLayout.AddView(mail1);
				inboxLayout.AddView(separate7,layoutParams5);
				inboxLayout.AddView(mail2);
				inboxLayout.AddView(separate11,layoutParams5);
				ContentFrame.AddView(inboxLayout);
				textView.Text="Sent Items";
			};
			img5.Click+= (object sender, EventArgs e) => {
				ContentFrame.RemoveAllViews();
				outboxlayout.RemoveAllViews();
				outboxlayout.SetPadding(20, 0, 20, 20);
				outboxlayout.AddView(mail13);
				outboxlayout.AddView(separate15, layoutParams5);
				outboxlayout.AddView(mail5);
				outboxlayout.AddView(separate13, layoutParams5);
				outboxlayout.AddView(mail12);
				outboxlayout.AddView(separate14, layoutParams5);
				outboxlayout.AddView(mail15);
				outboxlayout.AddView(separate17, layoutParams5);
				outboxlayout.AddView(mail17);
				outboxlayout.AddView(separate19, layoutParams5);
				outboxlayout.AddView(mail16);
				outboxlayout.AddView(separate18, layoutParams5);
				outboxlayout.AddView(mail6);
				outboxlayout.AddView(separate6, layoutParams5);
				ContentFrame.AddView(outboxlayout);
				textView.Text="Trash";
			};


			return slideDrawer;
		}


	}
}

