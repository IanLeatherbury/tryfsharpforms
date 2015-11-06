#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Collections.Generic;

using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Sfbusyindicator;
using Android.Graphics;
using Com.Syncfusion.Sfbusyindicator.Enums;

namespace SampleBrowser
{
	public class BusyIndicator : SamplePage
	{
		SfBusyIndicator sfBusyIndicator;
		Spinner spinner;
		public override View GetSampleContent (Context con)
		{
			spinner = new Spinner(con);
			spinner.SetMinimumHeight(60);
			spinner.DropDownWidth = 500;
			spinner.SetBackgroundColor(Color.Gray);
		
			List<String> list = new List<String>();
			list.Add("Ball");
			list.Add("Battery");
			list.Add("DoubleCircle");
			list.Add("ECG");
			list.Add("Globe");
			list.Add("HorizontalPulsingBox");
			list.Add("MovieTimer");
			list.Add("Print");
			list.Add("Rectangle");
			list.Add("RollingBall");
			list.Add("SingleCircle");
			list.Add("SlicedCircle");
			list.Add("ZoomingTarget");

			ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
				(con, Android.Resource.Layout.SimpleSpinnerItem, list);
			dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinner.Adapter = dataAdapter;
			spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs> (spinner_ItemSelected);

			TextView textView = new TextView(con);
			textView.TextSize = 20;
			textView.Text = "Animation Type";
			TextView textView1 = new TextView(con);
			textView1.TextSize = 10;
			textView.SetTextColor(Color.Black);

			TextView textView2 = new TextView(con);
			textView2.TextSize = 10;
			textView2.SetTextColor(Color.Black);

			LinearLayout linearLayout = new LinearLayout(con);
			linearLayout.SetPadding(20, 20, 20, 30);
			linearLayout.SetBackgroundColor(Color.Rgb(236,235,242));
			linearLayout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,
				LinearLayout.LayoutParams.WrapContent);
			linearLayout.Orientation = Orientation.Vertical;
			linearLayout.AddView(textView);
			linearLayout.AddView(textView2);
			linearLayout.AddView(spinner);
			linearLayout.AddView(textView1);

			sfBusyIndicator = new SfBusyIndicator(con);
			sfBusyIndicator.IsBusy = true;
			sfBusyIndicator.TextColor = Color.Rgb(62,101,254);
			sfBusyIndicator.AnimationType = AnimationTypes.DoubleCircle;
			sfBusyIndicator.ViewBoxWidth = 200;
			sfBusyIndicator.ViewBoxHeight = 200;
			sfBusyIndicator.TextSize = 60;
			sfBusyIndicator.Title = "";
			sfBusyIndicator.SetBackgroundColor(Color.Rgb(255,255,255));
			linearLayout.AddView(sfBusyIndicator);
			// Set our view from the "main" layout resource
			return linearLayout;
		}
		private void spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			String selectedItem = spinner.GetItemAtPosition (e.Position).ToString ();
			if(selectedItem.Equals("Ball")) {
				sfBusyIndicator.TextColor = Color.ParseColor("#243FD9");
				sfBusyIndicator.AnimationType = AnimationTypes.Ball;
			}
			else if(selectedItem.Equals("Battery")){
				sfBusyIndicator.TextColor = Color.ParseColor("#A70015");
				sfBusyIndicator.AnimationType = AnimationTypes.Battery;}
			else if(selectedItem.Equals("DoubleCircle")){
				sfBusyIndicator.TextColor = Color.ParseColor("#958C7B");
				sfBusyIndicator.AnimationType = AnimationTypes.DoubleCircle;}
			else if(selectedItem.Equals("ECG")){
				sfBusyIndicator.TextColor = Color.ParseColor("#DA901A");
				sfBusyIndicator.AnimationType = AnimationTypes.Ecg;}
			else if(selectedItem.Equals("Globe")){
				sfBusyIndicator.TextColor = Color.ParseColor("#9EA8EE");
				sfBusyIndicator.AnimationType = AnimationTypes.Globe;}
			else if(selectedItem.Equals("HorizontalPulsingBox")){
				sfBusyIndicator.TextColor = Color.ParseColor("#E42E06");
				sfBusyIndicator.AnimationType = AnimationTypes.HorizontalPulsingBox;}
			else if(selectedItem.Equals("MovieTimer")){
				sfBusyIndicator.TextColor = Color.ParseColor("#2d2d2d");
				sfBusyIndicator.SecondaryColor = Color.ParseColor("#9b9b9b");
				sfBusyIndicator.AnimationType = AnimationTypes.MovieTimer;}
			else if(selectedItem.Equals("Print")){
				sfBusyIndicator.TextColor = Color.ParseColor("#5E6FF8");
				sfBusyIndicator.AnimationType = AnimationTypes.Print;}
			else if(selectedItem.Equals("Rectangle")){
				sfBusyIndicator.TextColor = Color.ParseColor("#27AA9E");
				sfBusyIndicator.AnimationType = AnimationTypes.Rectangle;}
			else if(selectedItem.Equals("RollingBall")){
				sfBusyIndicator.TextColor = Color.ParseColor("#2d2d2d");
				sfBusyIndicator.SecondaryColor = Color.White;
				sfBusyIndicator.AnimationType = AnimationTypes.RollingBall;}
			else if(selectedItem.Equals("SingleCircle")){
				sfBusyIndicator.TextColor = Color.ParseColor("#AF2541");
				sfBusyIndicator.AnimationType = AnimationTypes.SingleCircle;}
			else if(selectedItem.Equals("SlicedCircle")){
				sfBusyIndicator.TextColor = Color.ParseColor("#779772");
				sfBusyIndicator.AnimationType = AnimationTypes.SlicedCircle;}
			else if(selectedItem.Equals("ZoomingTarget")) {
				sfBusyIndicator.TextColor = Color.ParseColor("#ED8F3C");
				sfBusyIndicator.AnimationType = AnimationTypes.ZoomingTarget;
			}
		}
	}
}

