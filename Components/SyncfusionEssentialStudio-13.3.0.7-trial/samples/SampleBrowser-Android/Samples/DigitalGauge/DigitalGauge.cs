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
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Gauges.SfDigitalGauge;
using System.Reflection.Emit;
using Java.Text;
using Java.Lang;
using Android.Util;
using Android.Graphics;
using Java.Util;

namespace SampleBrowser
{
	public class DigitalGauge : SamplePage
	{

		SfDigitalGauge digitalGauge1;
		SfDigitalGauge digitalGauge2;
		SfDigitalGauge digitalGauge3;
		SfDigitalGauge digitalGauge4;
		TextView text1, text2, text3, text4, text5, text6, text7, text8;


		public override View GetSampleContent (Context con)
		{
			SimpleDateFormat sdf = new SimpleDateFormat("HH mm ss");
			string currentDateandTime = sdf.Format(new Java.Util.Date());
			digitalGauge1 = new SfDigitalGauge(con);
			digitalGauge2 = new SfDigitalGauge(con);
			digitalGauge3 = new SfDigitalGauge(con);
			digitalGauge4 = new SfDigitalGauge(con);

			LinearLayout dln1 = new LinearLayout(con);
			dln1.SetGravity(GravityFlags.Center);
			dln1.AddView(digitalGauge1);
			digitalGauge1.CharacterStroke = Color.Rgb(20,108,237);
			digitalGauge1.CharacterHeight = 25 ;
			digitalGauge1.CharactersSpacing = 2;
			digitalGauge1.CharacterWidth = 12;
			digitalGauge1.SegmentStrokeWidth = 2;
			digitalGauge1.CharacterType = CharacterTypes.SegmentSeven;
			digitalGauge1.Value = currentDateandTime.ToString();
			digitalGauge1.DimmedSegmentColor = Color.Rgb(20,108,237);
			digitalGauge1.DimmedSegmentAlpha = 30;
			float cheight = TypedValue.ApplyDimension(ComplexUnitType.Pt,(float) digitalGauge1.CharacterHeight , con.Resources.DisplayMetrics);
			float cwidth = TypedValue.ApplyDimension(ComplexUnitType.Pt,(float)(8 * digitalGauge1.CharacterWidth + 8 * digitalGauge1.CharactersSpacing) , con.Resources.DisplayMetrics);
			digitalGauge1.LayoutParameters = (new LinearLayout.LayoutParams((int)cwidth, (int) cheight));
			digitalGauge1.SetBackgroundColor(Color.Rgb(240,240,240));
			digitalGauge2.SetBackgroundColor(Color.Rgb(240,240,240));
			digitalGauge3.SetBackgroundColor(Color.Rgb(240,240,240));
			digitalGauge4.SetBackgroundColor(Color.Rgb(240,240,240));

			LinearLayout dln2 = new LinearLayout(con);
			dln2.SetGravity(GravityFlags.Center);
			dln2.AddView(digitalGauge2);
			digitalGauge2.DimmedSegmentAlpha = 30;
			digitalGauge2.DimmedSegmentColor = Color.Rgb(2,186,94);
			digitalGauge2.CharacterStroke = Color.Rgb(2,186,94);
			digitalGauge2.CharacterHeight = 25 ;
			digitalGauge2.CharactersSpacing = 2;
			digitalGauge2.CharacterWidth = 12;
			digitalGauge2.SegmentStrokeWidth = 2;
			digitalGauge2.CharacterType = CharacterTypes.SegmentFourteen;
			digitalGauge2.Value = currentDateandTime;
			float cheight1 = TypedValue.ApplyDimension(ComplexUnitType.Pt,(float) digitalGauge2.CharacterHeight , con.Resources.DisplayMetrics);
			float cwidth1 = TypedValue.ApplyDimension(ComplexUnitType.Pt,(float)(8*digitalGauge2.CharacterWidth+8*digitalGauge2.CharactersSpacing) , con.Resources.DisplayMetrics);
			digitalGauge2.LayoutParameters = (new LinearLayout.LayoutParams((int)cwidth1, (int) cheight1));

			LinearLayout dln3 = new LinearLayout(con);
			dln3.SetGravity(GravityFlags.Center);
			dln3.AddView(digitalGauge3);
			digitalGauge3.DimmedSegmentAlpha = 30;
			digitalGauge3.DimmedSegmentColor = Color.Rgb(219,153,7);
			digitalGauge3.CharacterStroke = Color.Rgb(219,153,7);
			digitalGauge3.CharacterHeight = 25 ;
			digitalGauge3.CharactersSpacing = 2;
			digitalGauge3.CharacterWidth = 12;
			digitalGauge3.SegmentStrokeWidth = 2;
			digitalGauge3.CharacterType = CharacterTypes.SegmentSixteen;
			digitalGauge3.Value = currentDateandTime;
			float cheight2 = TypedValue.ApplyDimension(ComplexUnitType.Pt,(float) digitalGauge3.CharacterHeight , con.Resources.DisplayMetrics);
			float cwidth2 = TypedValue.ApplyDimension(ComplexUnitType.Pt,(float)(8*digitalGauge3.CharacterWidth+8*digitalGauge3.CharactersSpacing) , con.Resources.DisplayMetrics);
			digitalGauge3.LayoutParameters = (new LinearLayout.LayoutParams((int)cwidth2, (int) cheight2));

			LinearLayout dln4 = new LinearLayout(con);
			dln4.SetGravity(GravityFlags.Center);
			dln4.AddView(digitalGauge4);
			digitalGauge4.DimmedSegmentAlpha = 30;
			digitalGauge4.DimmedSegmentColor = Color.Rgb(249,66,53);
			digitalGauge4.CharacterStroke = Color.Rgb(249,66,53);
			digitalGauge4.CharacterHeight = 25 ;
			digitalGauge4.CharactersSpacing = 5;
			digitalGauge4.CharacterWidth = 9;
			digitalGauge4.SegmentStrokeWidth = 2;
			digitalGauge4.CharacterType = CharacterTypes.EightCrossEightDotMatrix;
			digitalGauge4.Value = currentDateandTime;
			float cheight3 = TypedValue.ApplyDimension(ComplexUnitType.Pt,(float) digitalGauge4.CharacterHeight , con.Resources.DisplayMetrics);
			float cwidth4 = TypedValue.ApplyDimension(ComplexUnitType.Pt,(float)(8*digitalGauge4.CharacterWidth+8*digitalGauge4.CharactersSpacing) , con.Resources.DisplayMetrics);
			digitalGauge4.LayoutParameters = (new LinearLayout.LayoutParams((int)cwidth4, (int) cheight3));

			text1 = new TextView(con);
			text2 = new TextView(con);
			text3 = new TextView(con);
			text4 = new TextView(con);
			text5 = new TextView(con);
			text6 = new TextView(con);
			text7 = new TextView(con);
			text8 = new TextView(con);

			LinearLayout tln1 = new LinearLayout(con);
			tln1.SetGravity(GravityFlags.Center);
			tln1.AddView(text1);
			LinearLayout tln2 = new LinearLayout(con);
			tln2.SetGravity(GravityFlags.Center);
			tln2.AddView(text2);
			LinearLayout tln3 = new LinearLayout(con);
			tln3.SetGravity(GravityFlags.Center);
			tln3.AddView(text3);
			LinearLayout tln4 = new LinearLayout(con);
			tln4.SetGravity(GravityFlags.Center);
			tln4.AddView(text4);
			text1.Text = "7 Segment";
			text1.SetTextColor(Color.Rgb(34,34,34));
			text1.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt,8 , con.Resources.DisplayMetrics);

			text2.Text = "14 Segment";
			text2.SetTextColor(Color.Rgb(34,34,34));
			text2.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt,8 , con.Resources.DisplayMetrics);

			text3.Text = "16 Segment";
			text3.SetTextColor(Color.Rgb(34,34,34));
			text3.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt,8 , con.Resources.DisplayMetrics);

			text4.Text = "8 X 8 DotMatrix";
			text4.SetTextColor(Color.Rgb(34,34,34));
			text4.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt,8 , con.Resources.DisplayMetrics);
			text5.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt,8 , con.Resources.DisplayMetrics);
			text6.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt,8 , con.Resources.DisplayMetrics);
			text7.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt,8 , con.Resources.DisplayMetrics);
			text8.TextSize = TypedValue.ApplyDimension(ComplexUnitType.Pt,8 , con.Resources.DisplayMetrics);
			ScrollView sc = new ScrollView(con);
			sc.HorizontalScrollBarEnabled = true;
			LinearLayout fr = new LinearLayout(con);
			fr.Orientation = Orientation.Vertical;
			//fr.AddView(text5);
			fr.AddView(tln1);
			fr.AddView(dln1);
			fr.AddView(text6);
			fr.AddView(tln2);
			fr.AddView(dln2);
			fr.AddView(text7);
			fr.AddView(tln3);
			fr.AddView(dln3);
			fr.AddView(text8);
			fr.AddView(tln4);
			fr.AddView(dln4);
			fr.SetGravity(GravityFlags.Center);
			ScrollView scroll = new ScrollView (con);			
			LinearLayout ly = new LinearLayout(con);
			ly.AddView(fr);
			ly.SetBackgroundColor (Color.White);
			ly.SetGravity(GravityFlags.Center);
			//sc.addView(ly);
			sc.SetForegroundGravity(GravityFlags.Center);
			sc.SetPadding(2,2,2,2);
			sc.SetBackgroundColor(Color.Rgb(248,248,248));
			// Set our view from the "main" layout resource
			scroll.AddView(ly);
			return scroll;
		}
	}
}

