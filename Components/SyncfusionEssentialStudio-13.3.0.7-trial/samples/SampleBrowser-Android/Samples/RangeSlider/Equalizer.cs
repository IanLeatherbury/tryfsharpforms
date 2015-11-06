#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using droid = Android.Widget.Orientation;

using Com.Syncfusion.Sfrangeslider;
using Android.Graphics;
using Android.Content;
namespace SampleBrowser
{
	//[con(Label = "Orientation")]
	public class Equalizer : SamplePage
	{
		SfRangeSlider slider1,slider2,slider3;

		TextView textView,textView1,textView2,textView3,textView4,textView5,textView6,textView7,textView8,textView9,textView10;


		public override View GetSampleContent (Context con)
		{
			LinearLayout mainLayout,layout1,layout2,layout3;;	
			int height =  con.Resources.DisplayMetrics.HeightPixels/2;
			int width = con.Resources.DisplayMetrics.WidthPixels/3;
			/**
         	* Defining Linear Layout
         	*/
			mainLayout = new LinearLayout(con);
			mainLayout.SetBackgroundColor(Color.White);
			mainLayout.SetGravity(GravityFlags.Center);

			LinearLayout parentLayout=new LinearLayout(con);
			parentLayout.Orientation=droid.Vertical;
			parentLayout.SetBackgroundColor(Color.White);
			parentLayout.LayoutParameters=new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

			FrameLayout.LayoutParams sliderLayout = new FrameLayout.LayoutParams(width,height+(height/4));


			textView = new TextView(con);
			textView7 = new TextView(con);
			textView8 = new TextView(con);
			textView9 = new TextView(con);
			textView9.Text="";
			textView.Typeface=  Typeface.Create("Roboto", TypefaceStyle.Normal);
			textView9.TextSize=20;				
			textView9.Gravity=GravityFlags.Center;
			textView9.SetTextColor (Color.Argb(255,182,182,182));

			//parentLayout.AddView(textView9);

			textView10 = new TextView(con);
			parentLayout.AddView(textView10);
			parentLayout.AddView(mainLayout);
			parentLayout.SetGravity(GravityFlags.Center);

			/**
         	* Defining First Slider
         	*/
			slider1 =  new SfRangeSlider(con);
			slider1.Minimum=-12;
			slider1.Maximum=12;
			slider1.TickFrequency=12;
			slider1.TrackSelectionColor=Color.Gray;
			slider1.Orientation=Com.Syncfusion.Sfrangeslider.Orientation.Vertical;
			slider1.TickPlacement=TickPlacement.None;
			slider1.ValuePlacement=ValuePlacement.TopLeft;
			slider1.ShowValueLabel=true;
			slider1.SnapsTo=SnapsTo.None;
			slider1.Value=6;
			// slider1.setLayoutParams(sliderLayout);

			slider1.ValueChanged += (object sender, SfRangeSlider.ValueChangedEventArgs e) => {
				String str=(string)(Math.Round(e.P1)+".0db");
				textView4.Text=str;
			};							


			layout1 = new LinearLayout(con);
			layout1.Orientation=droid.Vertical;
			layout1.SetGravity(GravityFlags.Center);
			textView1=new TextView(con);
			textView1.Text="60HZ";
			textView1.TextSize=20;
			textView1.SetTextColor(Color.Black);
			textView1.Gravity=GravityFlags.Center;
			textView1.Typeface = Typeface.Create("Helvetica", TypefaceStyle.Normal);
			textView4 = new TextView(con);
			textView4.TextSize=14;
			textView4.SetTextColor(Color.Argb(255, 50, 180, 228));
			textView4.Text="0.0db";
			textView4.Typeface=Typeface.Create("Helvetica", TypefaceStyle.Normal);
			textView4.Gravity=GravityFlags.Center;




			layout1.AddView(textView1);
			layout1.AddView(textView4);
			layout1.AddView(textView);
			layout1.AddView(slider1,sliderLayout);
			/**
         	* Defining Second Slider
         	*/
			slider2 =  new SfRangeSlider(con);
			slider2.Minimum=-12;
			slider2.Maximum=12;
			slider2.TickFrequency=12;
			slider2.TrackSelectionColor=Color.Gray;
			slider2.Orientation=Com.Syncfusion.Sfrangeslider.Orientation.Vertical;
			slider2.TickPlacement=TickPlacement.None;
			slider2.ValuePlacement=ValuePlacement.TopLeft;
			slider2.ShowValueLabel=true;
			slider2.SnapsTo=SnapsTo.None;
			slider2.Value=-3;
			slider2.LayoutParameters=sliderLayout;
			slider2.ValueChanged+= (object sender, SfRangeSlider.ValueChangedEventArgs e) => {
				textView5.Text=Convert.ToString(Math.Round(e.P1)+".0db");
			};



			layout2 = new LinearLayout(con);
			layout2.Orientation=droid.Vertical;
			layout2.SetGravity(GravityFlags.Center);
			textView2=new TextView(con);
			textView2.Text="170HZ";
			textView2.TextSize=20;
			textView2.SetTextColor(Color.Black);
			textView2.Gravity=GravityFlags.Center;
			textView2.Typeface = Typeface.Create("Helvetica", TypefaceStyle.Normal);
			textView5 = new TextView(con);
			textView5.TextSize=14;
			textView5.SetTextColor(Color.Argb(255, 50, 180, 228));
			textView5.Text="0.0db";
			textView5.Typeface=Typeface.Create("Helvetica", TypefaceStyle.Normal);
			textView5.Gravity=GravityFlags.Center;


			layout2.AddView(textView2);
			layout2.AddView(textView5);
			layout2.AddView(textView7);
			layout2.AddView(slider2,sliderLayout);


			/**
         	* Defining Third Slider
         	*/
			slider3 =  new SfRangeSlider(con);
			slider3.Minimum=-12;
			slider3.Maximum=12;
			slider3.TickFrequency=12;
			slider3.TrackSelectionColor=Color.Gray;
			slider3.Orientation=Com.Syncfusion.Sfrangeslider.Orientation.Vertical;
			slider3.TickPlacement=TickPlacement.None;
			slider3.ValuePlacement=ValuePlacement.TopLeft;
			slider3.ShowValueLabel=true;
			slider3.SnapsTo=SnapsTo.None;
			slider3.Value=12;
			slider3.LayoutParameters=sliderLayout;
			slider3.ValueChanged+= (object sender, SfRangeSlider.ValueChangedEventArgs e) => {
				textView6.Text=Convert.ToString(Math.Round(e.P1)+".0db");
			};


			layout3 = new LinearLayout(con);
			layout3.Orientation=droid.Vertical;
			layout3.SetGravity(GravityFlags.Center);
			textView3=new TextView(con);
			textView3.Text="310HZ";
			textView3.TextSize=20;
			textView3.SetTextColor(Color.Black);
			textView3.Gravity=GravityFlags.Center;
			textView3.Typeface = Typeface.Create("Helvetica", TypefaceStyle.Normal);
			textView6 = new TextView(con);
			textView6.TextSize=14;
			textView6.SetTextColor(Color.Argb(255, 50, 180, 228));
			textView6.Text="0.0db";
			textView6.Typeface=Typeface.Create("Helvetica", TypefaceStyle.Normal);
			textView6.Gravity=GravityFlags.Center;



			layout3.AddView(textView3);
			layout3.AddView(textView6);
			layout3.AddView(textView8);
			layout3.AddView(slider3,sliderLayout);





			/**
         	* Adding sliders to Layout
         	*/
			mainLayout.AddView(layout1);
			mainLayout.AddView(layout2);
			mainLayout.AddView(layout3);

			return parentLayout;
		}

	}
}

