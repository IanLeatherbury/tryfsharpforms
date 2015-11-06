#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Content;
using Com.Syncfusion.Sfrangeslider;
using Android.Widget;
using Android.Views;
using Android.Graphics;

using SampleBrowser;

using droid = Android.Widget.Orientation;

using System.Collections.Generic;
using System;


namespace SampleBrowser
{
	//[con(Label = "Getting Started")]
	public class GettingStarted : SamplePage
	{
		SfRangeSlider range,range2;
		View Content;
		public static TickPlacement tickplacement= TickPlacement.BottomRight;

		public static ValuePlacement valueplacement=ValuePlacement.BottomRight;

		public static bool showlabel=true;

		public static SnapsTo snapsto = SnapsTo.None;

		string val1,val2,val3,val4;

		public override View GetSampleContent (Context con)
		{
			
			LinearLayout linearLayout = new LinearLayout(con);
			linearLayout.SetPadding(20, 20, 20, 30);
			linearLayout.SetBackgroundColor(Color.Rgb(236, 235, 242));
			linearLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			linearLayout.Orientation = Android.Widget.Orientation.Vertical;


			TextView textView3 = new TextView(con);
			textView3.TextSize=20;
			textView3.Text=" "+"Departure";
			textView3.SetTextColor (Color.Black);

			range = new SfRangeSlider(con);
			range.Minimum= 0;
			range.Maximum=12;
			range.TickFrequency=2;
			range.ShowValueLabel=showlabel;
			range.StepFrequency=6;
			range.DirectionReversed=false;
			range.ValuePlacement=valueplacement;
			range.RangeEnd=12;
			range.RangeStart=0;
			range.TickPlacement=tickplacement;
			range.ShowRange=showlabel;
			range.SnapsTo=snapsto;

			range.Orientation=Com.Syncfusion.Sfrangeslider.Orientation.Horizontal;


			range.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 150);

			LinearLayout depstack =new LinearLayout (con);
			depstack.Orientation = Android.Widget.Orientation.Horizontal;
			depstack.AddView (textView3);
			TextView textView4 = new TextView(con);
			textView4.TextSize=13;
			textView4.Text="  "+"(in Hours)";
			textView4.LayoutParameters = new ViewGroup.LayoutParams (ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent);
			textView4.SetTextColor (Color.ParseColor("#939394"));
			textView4.Gravity = GravityFlags.Center;
			depstack.AddView (textView4);

			TextView textView7 = new TextView(con);
			textView7.SetHeight (50);
			linearLayout.AddView (textView7);
			linearLayout.AddView (depstack);
			TextView textView10 = new TextView(con);
			TextView textView12 = new TextView(con);
			linearLayout.AddView (textView12);
			linearLayout.AddView (textView10);

			linearLayout.AddView(range);

			textView10.TextSize=13;
			val3 = "12";
			val4 = Math.Round (range.RangeEnd).ToString ();
			textView10.SetTextColor (Color.ParseColor ("#939394"));
			textView10.Text = "  "+"Time:  "+val3 +"AM " +" - "+ val4 +" PM";
			textView10.Gravity = GravityFlags.Left;
			range.RangeChanged += (object sender, SfRangeSlider.RangeChangedEventArgs e) => {
				String pmstr2="AM",pmstr1 = "AM";
				if(Math.Round(e.P1).ToString() =="0" ) {
					val3 = "12";
					pmstr1 = "AM";
				}
				else
					val3 =  Convert.ToString(Math.Round(e.P1));

				if (e.P2 <= 12)
					val4 = Convert.ToString(Math.Round(e.P2));


				if(Math.Round(e.P2).ToString()=="12")
					pmstr2 = "PM";


				if(Math.Round(e.P2).ToString()=="12")
					pmstr2 = "PM";
				if(Convert.ToString(Math.Round(e.P1)).Equals(Convert.ToString(Math.Round(e.P2)))){
					if(Math.Round(e.P1).ToString() =="0" )
						textView10.Text="  "+"Time: "+val3 +" "+ pmstr1;
					else if(Math.Round(e.P2).ToString()=="12")
						textView10.Text="  "+"Time: "+val4 +" "+ pmstr2;
					else
						textView10.Text="  "+"Time: "+val3 +" "+ pmstr1;
				}
				else
					textView10.Text="  "+"Time: " +val3+" "+ pmstr1 + " - "+ val4+" " + pmstr2;
			};


			TextView textView6 = new TextView(con);
			textView6.SetHeight (70);
			linearLayout.AddView (textView6);
			TextView textView2 = new TextView(con);
			textView2.TextSize=20;
			textView2.Text=" "+"Arrival";
			textView2.SetTextColor (Color.Black);
			//linearLayout.AddView(textView2);


			range2 = new SfRangeSlider(con);
			range2.Minimum= 0;
			range2.Maximum=12;
			range2.TickFrequency=2;
			range2.ShowValueLabel=showlabel;
			range2.StepFrequency=6;
			range2.DirectionReversed=false;
			range2.ValuePlacement=valueplacement;
			range2.RangeEnd=12;
			range2.RangeStart=0;
			range2.TickPlacement=tickplacement;
			range2.ShowRange=showlabel;
			range2.SnapsTo=snapsto;
			range2.Orientation = Com.Syncfusion.Sfrangeslider.Orientation.Horizontal;
			range2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 150);
			TextView textView5 = new TextView(con);
			textView5.TextSize=13;
			textView5.Text="  "+"(in Hours)";
			textView5.Gravity = GravityFlags.Center;
			textView5.LayoutParameters = new ViewGroup.LayoutParams (ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.MatchParent);
			textView5.SetTextColor (Color.ParseColor("#939394"));
			TextView textView8 = new TextView(con);
			textView8.SetHeight (50);
			LinearLayout arrivestack =new LinearLayout (con);
			arrivestack.Orientation = Android.Widget.Orientation.Horizontal;
			arrivestack.AddView (textView2);

			arrivestack.AddView (textView5);
			linearLayout.AddView (textView8);
			linearLayout.AddView (arrivestack);
			TextView textView13 = new TextView(con);
			linearLayout.AddView (textView13);
			TextView textView9 = new TextView(con);
			linearLayout.AddView (textView9);
			linearLayout.AddView(range2);

			textView9.TextSize=13;
			textView9.SetTextColor (Color.ParseColor ("#939394"));
			val1 = "12";
			val2 = Math.Round (range2.RangeEnd).ToString ();
			textView9.Text = "  "+"Time:  "+val1 +"AM " +" - "+ val2 +" PM";
			textView9.Gravity = GravityFlags.Left;
			range2.RangeChanged += (object sender, SfRangeSlider.RangeChangedEventArgs e) => {
				String pmstr2="AM",pmstr1 = "AM";
				if(Math.Round(e.P1).ToString() =="0" ) {
					val1 = "12";
					pmstr1 = "AM";
				}
				else
					val1 =  Convert.ToString(Math.Round(e.P1));

				if (e.P2 <= 12)
					val2 = Convert.ToString(Math.Round(e.P2));





				if(Math.Round(e.P2).ToString()=="12")
					pmstr2 = "PM";
				if(Convert.ToString(Math.Round(e.P1)).Equals(Convert.ToString(Math.Round(e.P2)))){
					if(Math.Round(e.P1).ToString() =="0" )
						textView9.Text="  "+"Time: "+val1 +" "+ pmstr1;
					else if(Math.Round(e.P2).ToString()=="12")
						textView9.Text="  "+"Time: "+val2 +" "+ pmstr2;
					else
						textView9.Text="  "+"Time: "+val1 +" "+ pmstr1;
				}
				else
					textView9.Text="  "+"Time: " +val1+" "+ pmstr1 + " - "+ val2+" " + pmstr2;
			};

			return linearLayout;
		}

		Spinner tickSpinner, labelSpinner;

		View content;

		LinearLayout propertylayout, stackView2, stackView3,stackView4;

		ArrayAdapter<String> labelAdapter, dataAdapter;

		public override View GetPropertyWindowLayout (Android.Content.Context context)
		{
			int width = context.Resources.DisplayMetrics.WidthPixels / 2;


			propertylayout = new LinearLayout (context);
			propertylayout.Orientation = droid.Vertical;

			LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams (
				width * 2, 5);

			layoutParams.SetMargins (0, 5, 0, 0);

			TextView textView1 = new TextView (context);
			textView1.Text = "  " + "TICK PLACEMENT";
			textView1.TextSize = 15;
			textView1.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
			textView1.SetTextColor (Color.White);
			textView1.Gravity = GravityFlags.Left;
			TextView textview2 = new TextView (context);
			textview2.SetHeight (14);
			propertylayout.AddView (textview2);
			tickSpinner = new Spinner (context);
			tickSpinner.SetPadding (0, 0, 0, 0);
			propertylayout.AddView (textView1);			
			SeparatorView separate = new SeparatorView (context, width * 2);
			separate.LayoutParameters = new ViewGroup.LayoutParams (width * 2, 5);
			propertylayout.AddView (separate, layoutParams);
			TextView textview8 = new TextView (context);
			textview8.SetHeight (20);
			propertylayout.AddView (textview8);
			propertylayout.AddView (tickSpinner);
			TextView textview3 = new TextView (context);
			propertylayout.AddView (textview3);
			List<String> list = new List<String> ();

			list.Add ("BottomRight");
			list.Add ("TopLeft");
			list.Add ("Outside");
			list.Add ("Inline");
			list.Add ("None");


			dataAdapter = new ArrayAdapter<String> (context, Android.Resource.Layout.SimpleSpinnerItem, list);
			dataAdapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);

			tickSpinner.Adapter = dataAdapter;

			tickSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
				String selectedItem = dataAdapter.GetItem (e.Position);
				if (selectedItem.Equals ("BottomRight")) {
					tickplacement = TickPlacement.BottomRight;

				} else if (selectedItem.Equals ("TopLeft")) {
					tickplacement = TickPlacement.TopLeft;

				} else if (selectedItem.Equals ("Inline")) {
					tickplacement = TickPlacement.Inline;

				} else if (selectedItem.Equals ("Outside")) {
					tickplacement = TickPlacement.Outside;

				} else if (selectedItem.Equals ("None")) {
					tickplacement = TickPlacement.None;

				}
			};


			TextView textView3 = new TextView (context);
			textView3.Text = "  " + "LABEL PLACEMENT";
			textView3.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
			textView3.Gravity = GravityFlags.Left;
			textView3.TextSize = 15;
			textView3.SetTextColor (Color.White);
			List<String> labelList = new List<String> ();
			labelList.Add ("BottomRight");
			labelList.Add ("TopLeft");

			labelSpinner = new Spinner (context);

			labelSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
				String selectedItem = dataAdapter.GetItem (e.Position);
				if (selectedItem.Equals ("TopLeft")) {
					valueplacement = ValuePlacement.TopLeft;

				} else if (selectedItem.Equals ("BottomRight")) {
					valueplacement = ValuePlacement.BottomRight;


				}
			};



			labelAdapter = new ArrayAdapter<String> (context, Android.Resource.Layout.SimpleSpinnerItem, labelList);
			labelAdapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);

			labelSpinner.Adapter = labelAdapter;
			labelSpinner.SetPadding (0, 0, 0, 0);

			LinearLayout.LayoutParams layoutParams2 = new LinearLayout.LayoutParams (width * 2, 7);

			layoutParams2.SetMargins (0, 5, 0, 0);
			propertylayout.AddView (textView3);

			SeparatorView separate2 = new SeparatorView (context, width * 2);
			separate2.LayoutParameters = new ViewGroup.LayoutParams (width * 2, 7);

			propertylayout.AddView (separate2, layoutParams2);
			TextView textview9 = new TextView (context);
			textview9.SetHeight (20);
			propertylayout.AddView (textview9);
			propertylayout.AddView (labelSpinner);
			propertylayout.SetPadding (15, 0, 15, 0);
			TextView textview7 = new TextView (context);
			textview7.SetHeight (20);
			propertylayout.AddView (textview7);

			TextView textView6 = new TextView (context);
			textView6.Text = "  " + "Show Label";
			textView6.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
			textView6.Gravity = GravityFlags.Center;
			textView6.TextSize = 16;

			Switch checkBox = new Switch (context);
			checkBox.Checked = true;
			checkBox.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
				if (e.IsChecked)
					showlabel = true;
				else
					showlabel = false;
			};

			LinearLayout.LayoutParams layoutParams3 = new LinearLayout.LayoutParams (
				ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			layoutParams3.SetMargins (0, 10, 0, 0);

			LinearLayout.LayoutParams layoutParams4 = new LinearLayout.LayoutParams (
				ViewGroup.LayoutParams.WrapContent, 55);
			layoutParams4.SetMargins (0, 10, 0, 0);

			stackView3 = new LinearLayout (context);
			stackView3.AddView (textView6, layoutParams4);



			stackView3.AddView (checkBox, layoutParams3);
			stackView3.Orientation = droid.Horizontal;
			propertylayout.AddView (stackView3);
			SeparatorView separate3 = new SeparatorView (context, width * 2);
			separate3.LayoutParameters = new ViewGroup.LayoutParams (width * 2, 5);
			LinearLayout.LayoutParams layoutParams7 = new LinearLayout.LayoutParams (
				width * 2, 5);

			layoutParams7.SetMargins (0, 30, 0, 0);
			propertylayout.AddView (separate3, layoutParams7);

			TextView textView7 = new TextView (context);
			textView7.Text = "  "+"SnapsToTicks";
			textView7.Typeface = Typeface.Create("Roboto", TypefaceStyle.Normal);
			textView7.Gravity = GravityFlags.Center;
			textView7.TextSize = 16;

			Switch checkBox2 = new Switch (context);
			checkBox2.Checked = false;
			checkBox2.CheckedChange += (object sender, CompoundButton.CheckedChangeEventArgs e) => {
				if (e.IsChecked)
					snapsto = SnapsTo.Ticks;
				else
					snapsto = SnapsTo.None;
			};

			LinearLayout.LayoutParams layoutParams5 = new LinearLayout.LayoutParams (
				ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			layoutParams5.SetMargins (0, 20, 0, 0);

			LinearLayout.LayoutParams layoutParams6 = new LinearLayout.LayoutParams (
				ViewGroup.LayoutParams.WrapContent, 55);
			layoutParams6.SetMargins (0, 20, 0, 0);

			stackView4 = new LinearLayout (context);
			stackView4.AddView (textView7, layoutParams6);



			stackView4.AddView (checkBox2, layoutParams5);
			stackView4.Orientation = droid.Horizontal;
			propertylayout.AddView (stackView4);
			SeparatorView separate4 = new SeparatorView (context, width * 2);
			separate4.LayoutParameters = new ViewGroup.LayoutParams (width * 2, 5);
			LinearLayout.LayoutParams layoutParams8 = new LinearLayout.LayoutParams (
				width * 2, 5);

			layoutParams8.SetMargins (0, 30, 0, 0);
			propertylayout.AddView (separate4, layoutParams8);
			return propertylayout;
		}

		public override void OnApplyChanges ()
		{
			base.OnApplyChanges ();
			range2.TickPlacement=tickplacement;
			range.TickPlacement=tickplacement;

			range2.ValuePlacement=valueplacement;
			range.ValuePlacement=valueplacement;

			range2.ShowValueLabel=showlabel;
			range.ShowValueLabel=showlabel;

			range2.SnapsTo=snapsto;
			range.SnapsTo=snapsto;

		}


	}
}