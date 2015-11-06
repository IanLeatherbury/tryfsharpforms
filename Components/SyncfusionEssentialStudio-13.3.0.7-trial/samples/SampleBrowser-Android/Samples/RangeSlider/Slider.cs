#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Com.Syncfusion.Sfrangeslider;
using System;
using System.Threading.Tasks;
using Android.Widget;
using Android.Views;


namespace SampleBrowser
{
	//[con(Label = "Slider")]
	public class Slider : SamplePage
	{
		SfRangeSlider range;
		ImageView img;
		public override View GetSampleContent (Context con)
		{
			int height = con.Resources.DisplayMetrics.HeightPixels/2;

			LinearLayout linearLayout = new LinearLayout(con);
			linearLayout.SetGravity (Android.Views.GravityFlags.CenterHorizontal);
			linearLayout.Orientation = Android.Widget.Orientation.Vertical;
			linearLayout.SetBackgroundColor(Color.White);
			img = new ImageView(con);
			img.SetImageResource (Resource.Drawable.mount);
			linearLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			linearLayout.SetPadding(20, 20, 20, 20);
			FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(height+(height/3.5)),GravityFlags.Center);
			img.SetPadding(12, 0, 10, 0);
			img.LayoutParameters = (layoutParams);


			range=new SfRangeSlider(con);
			range.Minimum = 0;range.Maximum = 100; range.Value = 100;
			range.ShowRange = false; range.SnapsTo = SnapsTo.None;
			range.Orientation = Com.Syncfusion.Sfrangeslider.Orientation.Horizontal;
			range.TickPlacement = TickPlacement.BottomRight;
			range.ShowValueLabel = true; range.TickFrequency = 20;
			range.ValuePlacement = ValuePlacement.BottomRight;
			range.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 150));
			range.ValueChanged += ValueChanged ;
				
			linearLayout.AddView(img);

			TextView text1 = new TextView(con);
			text1.Text = "  Opacity";
			text1.TextSize=20;
			text1.Gravity = GravityFlags.Left;
			range.SetY(-30);
			linearLayout.AddView(text1);
			linearLayout.AddView(range);

			FrameLayout frame = new FrameLayout(con);
			frame.SetBackgroundColor (Color.White);
			frame.LayoutParameters = ( new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent,GravityFlags.Center));
			frame.AddView(linearLayout);

			return frame;
		}

	
			
		public void ValueChanged(object sender, SfRangeSlider.ValueChangedEventArgs e) {
			float alpha = (float)(e.P1 / 100);
			img.Alpha = alpha;
		}
	}
}