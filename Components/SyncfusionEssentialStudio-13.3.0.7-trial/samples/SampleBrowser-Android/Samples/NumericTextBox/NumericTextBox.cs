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
using Com.Syncfusion.Numerictextbox;
using Android.Graphics;
using Android.Views.InputMethods;
using Android.Text;
using Android.Text.Style;

namespace SampleBrowser
{
	public class NumericTextBox : SamplePage
	{
		SfNumericTextBox principalamount,OutputNumbertxtBox, Interestvalue, periodValue;

		LinearLayout propertylayout,stackView3;
		//AlertDialog.Builder builderSingle;
		ArrayAdapter<String> dataAdapter;
		Spinner cultureSpinner;
		Java.Util.Locale localinfo;
		bool allownull=false;
		//Java.Lang.Object.Locale localinfo;
		public override View GetSampleContent (Context con)
		{
			Context localcontext = con;
			int width = con.Resources.DisplayMetrics.WidthPixels -40;
			FrameLayout frameLayout = new FrameLayout(con);
			FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.FillVertical);
			frameLayout.LayoutParameters = layoutParams;
			LinearLayout layout=new LinearLayout(con);
			layout.LayoutParameters=new ViewGroup.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
			layout.SetGravity(GravityFlags.FillVertical);
			layout.Orientation=Orientation.Vertical;
			TextView dummy0 = new TextView(con);
			dummy0.Text="Simple Interest Calculator";
			dummy0.Gravity=GravityFlags.Center;
			dummy0.TextSize=24;
			layout.AddView(dummy0);
			TextView dummy7 = new TextView(con);
			layout.AddView(dummy7);
			TextView dummy = new TextView(con);
			dummy.Text="The formula for finding simple interest is:";
			dummy.TextSize=18;
			layout.AddView(dummy);


			layout.FocusableInTouchMode=true;
			SpannableStringBuilder builder = new SpannableStringBuilder();
			TextView dummy1 = new TextView(con);
			String str= "Interest";
			SpannableString strSpannable= new SpannableString(str);
			strSpannable.SetSpan(new ForegroundColorSpan(Color.ParseColor("#66BB6A")), 0, str.Length, 0);
			builder.Append(strSpannable);
			builder.Append(" = Principal * Rate * Time");
			dummy1.SetText(builder, TextView.BufferType.Spannable);
			dummy1.TextSize=18;
			layout.AddView(dummy1);

			TextView dummy8 = new TextView(con);
			layout.AddView(dummy8);

			/*
        Principal amount Stack
       */

			LinearLayout principalStack = new LinearLayout(con);

			TextView txtPricipal = new TextView(con);
			txtPricipal.LayoutParameters=new ViewGroup.LayoutParams(width / 2, 100);
			txtPricipal.Text="Principal";

			principalamount =new SfNumericTextBox(con);
			principalamount.FormatString="C";
			principalamount.LayoutParameters=new ViewGroup.LayoutParams(width / 2, 100);
			principalamount.Value=1000;
			principalamount.AllowNull = true;
			principalamount.Watermark = "Principal Amount";
			principalamount.MaximumNumberDecimalDigits=2;
			var culture = new Java.Util.Locale("en","US");

			principalamount.CultureInfo = culture;
			principalamount.ValueChangeMode=ValueChangeMode.OnKeyFocus;
			principalStack.Orientation = Orientation.Horizontal;
			principalStack.AddView(txtPricipal);
			principalStack.AddView(principalamount);

			layout.AddView(principalStack);

			TextView dummy3 = new TextView(con);
			layout.AddView(dummy3);

			/*
        Interest Input Box
        */

			LinearLayout InterestcalStack = new LinearLayout(con);

			TextView txtInterest = new TextView(con);
			txtInterest.LayoutParameters=new ViewGroup.LayoutParams(width / 2, 100);
			txtInterest.Text="Interest Rate";
			Interestvalue =new SfNumericTextBox(con);
			Interestvalue.FormatString="P"; 
			Interestvalue.PercentDisplayMode=PercentDisplayMode.Compute;
			Interestvalue.MaximumNumberDecimalDigits=2;
			Interestvalue.ValueChangeMode=ValueChangeMode.OnKeyFocus;
			Interestvalue.LayoutParameters=new ViewGroup.LayoutParams(width / 2, 100);
			Interestvalue.Value=0.1f;
			Interestvalue.Watermark = "Rate of Interest";
			Interestvalue.AllowNull = true;
			Interestvalue.CultureInfo = culture;
			InterestcalStack.Orientation=Orientation.Horizontal;
			InterestcalStack.AddView(txtInterest);
			InterestcalStack.AddView(Interestvalue);


			layout.AddView(InterestcalStack);

			TextView dummy2 = new TextView(con);
			layout.AddView(dummy2);



			/*
          Period Input TextBox
         */
			LinearLayout periodStack = new LinearLayout(con);

			TextView period = new TextView(con);
			period.LayoutParameters=new ViewGroup.LayoutParams(width / 2, 100);
			period.Text="Term";

			periodValue =new SfNumericTextBox(con);
			periodValue.FormatString=" years";
			periodValue.MaximumNumberDecimalDigits=0;
			periodValue.LayoutParameters=new ViewGroup.LayoutParams(width / 2, 100);
			periodValue.Value=20;
			periodValue.Watermark = "Period (in years)";
			periodValue.ValueChangeMode=ValueChangeMode.OnKeyFocus;
			periodValue.CultureInfo = culture;
			periodValue.AllowNull = true;

			periodStack.Orientation=Orientation.Horizontal;

			periodStack.AddView(period);
			periodStack.AddView(periodValue);

			layout.AddView(periodStack);



			/*
        OutPut values
         */

			LinearLayout outputStack = new LinearLayout(con);

			TextView outputtxt = new TextView(con);
			outputtxt.LayoutParameters=new ViewGroup.LayoutParams(width / 2, 100);
			outputtxt.Text="Interest";
			outputtxt.SetTextColor(Color.ParseColor("#66BB6A"));

			OutputNumbertxtBox =new SfNumericTextBox(con);
			OutputNumbertxtBox.FormatString="c";
			OutputNumbertxtBox.MaximumNumberDecimalDigits=0;
			OutputNumbertxtBox.AllowNull=true;
			OutputNumbertxtBox.CultureInfo = culture;
			OutputNumbertxtBox.Watermark="Enter Values";
			OutputNumbertxtBox.Clickable=false;
			OutputNumbertxtBox.Value = (float)(1000 * 0.1 * 20);
			OutputNumbertxtBox.Enabled=false;
			OutputNumbertxtBox.LayoutParameters=new ViewGroup.LayoutParams(width / 2, 100);
			OutputNumbertxtBox.ValueChangeMode=ValueChangeMode.OnLostFocus;


			outputStack.Orientation=Orientation.Horizontal;

			outputStack.AddView(outputtxt);
			outputStack.AddView(OutputNumbertxtBox);
			layout.AddView(outputStack);

			TextView dummy4 = new TextView(con);
			layout.SetPadding(20, 20, 10, 20);
			layout.AddView(dummy4);

			principalamount.ValueChanged+= (object sender, SfNumericTextBox.ValueChangedEventArgs e) => {
				if(!e.P1.ToString().Equals("")&&!periodValue.Value.ToString().Equals("")&&!Interestvalue.Value.ToString().Equals(""))
					OutputNumbertxtBox.Value=e.P1 * periodValue.Value *  Interestvalue.Value;

			};

			periodValue.ValueChanged+= (object sender, SfNumericTextBox.ValueChangedEventArgs e) => {
				if(!e.P1.ToString().Equals("")&&!principalamount.Value.ToString().Equals("")&&!Interestvalue.Value.ToString().Equals(""))
					OutputNumbertxtBox.Value=e.P1* principalamount.Value*Interestvalue.Value;

			};

			Interestvalue.ValueChanged+= (object sender, SfNumericTextBox.ValueChangedEventArgs e) => {
				if(!e.P1.ToString().Equals("")&&!principalamount.Value.ToString().Equals("")&&!periodValue.Value.ToString().Equals(""))
					OutputNumbertxtBox.Value=e.P1 * principalamount.Value *  periodValue.Value;

			};

			layout.Touch+= (object sender, View.TouchEventArgs e) => {
				if(OutputNumbertxtBox.IsFocused || Interestvalue.IsFocused ||periodValue.IsFocused || principalamount.IsFocused){
					Rect outRect = new Rect();
					OutputNumbertxtBox.GetGlobalVisibleRect(outRect);
					Interestvalue.GetGlobalVisibleRect(outRect);
					periodValue.GetGlobalVisibleRect(outRect);
					principalamount.GetGlobalVisibleRect(outRect);

					if (!outRect.Contains((int)e.Event.RawX, (int)e.Event.RawY)) {
						if(!OutputNumbertxtBox.Value.ToString().Equals(""))
							OutputNumbertxtBox.ClearFocus();
						if(!Interestvalue.Value.ToString().Equals(""))
							Interestvalue.ClearFocus();
						if(!periodValue.Value.ToString().Equals(""))
							periodValue.ClearFocus();
						if(!principalamount.Value.ToString().Equals(""))
							principalamount.ClearFocus();

					}
					hideSoftKeyboard((Activity)localcontext);
				}
			};






			frameLayout.AddView(layout);

			ScrollView scrollView = new ScrollView(con);
			scrollView.AddView(frameLayout);

			return scrollView;
		}

		public override void OnApplyChanges ()
		{
			principalamount.CultureInfo = localinfo;
			OutputNumbertxtBox.CultureInfo = localinfo;
			principalamount.AllowNull = allownull;
			periodValue.AllowNull = allownull;
			Interestvalue.AllowNull = allownull;
			base.OnApplyChanges ();
		}

		public override View GetPropertyWindowLayout (Context context)
		{
			/**
		 * Property Window
		 * */
			int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
			propertylayout = new LinearLayout(context); //= new LinearLayout(context);
			propertylayout.Orientation=Orientation.Vertical;

			LinearLayout.LayoutParams layoutParams1 = new LinearLayout.LayoutParams(
				width * 2, 5);

			layoutParams1.SetMargins(0, 20, 0, 0);

			TextView culturetxt = new TextView(context);
			culturetxt.TextSize=20;
			culturetxt.Text="Culture";

			cultureSpinner = new Spinner(context);
			//cultureSpinner.Gravity=GravityFlags.Left;


			List<String> list = new List<String>();

			list.Add("United States");
			list.Add("United Kingdom");
			list.Add("Japan");
			list.Add("France");
			list.Add("Italy");


			dataAdapter = new ArrayAdapter<String>
				(context, Android.Resource.Layout.SimpleSpinnerItem, list);
			dataAdapter.SetDropDownViewResource
			(Android.Resource.Layout.SimpleSpinnerDropDownItem);

			cultureSpinner.Adapter = dataAdapter;

			cultureSpinner.ItemSelected+= (object sender, AdapterView.ItemSelectedEventArgs e) => {
				String selectedItem = dataAdapter.GetItem(e.Position);

				if (selectedItem.Equals("United States")) {
					localinfo=Java.Util.Locale.Us; //new Java.Util.Locale("en","US");
				}
				if (selectedItem.Equals("United Kingdom")) {
					localinfo=Java.Util.Locale.Uk;
										
				}
				if (selectedItem.Equals("Japan")) {
					localinfo=Java.Util.Locale.Japan;
				}
				if (selectedItem.Equals("France")) {
					localinfo=Java.Util.Locale.France;
				}
				if (selectedItem.Equals("Italy")) {
					localinfo=Java.Util.Locale.Italy;
				}

			};
			propertylayout.AddView(culturetxt);
			propertylayout.AddView(cultureSpinner);

			SeparatorView separate = new SeparatorView(context, width * 2);
			separate.LayoutParameters=new ViewGroup.LayoutParams(width * 2, 5);
			propertylayout.AddView(separate, layoutParams1);

			TextView textView6 = new TextView(context);
			textView6.Text="Allow Null";
			textView6.Gravity=GravityFlags.Center;
			textView6.TextSize=20;

			Switch checkBox = new Switch(context);
			checkBox.Checked=true;
			checkBox.CheckedChange+= (object send, CompoundButton.CheckedChangeEventArgs eve) => {
				if(!eve.IsChecked)
					allownull = false;
				else
					allownull = true;
			};

			LinearLayout.LayoutParams layoutParams3 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			layoutParams3.SetMargins(0, 10, 0, 0);
			LinearLayout.LayoutParams layoutParams4 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.WrapContent, 55);
			layoutParams4.SetMargins(0, 10, 0, 0);
			stackView3 = new LinearLayout(context);
			stackView3.AddView(textView6,layoutParams4);
			stackView3.AddView(checkBox, layoutParams3);
			stackView3.Orientation=Orientation.Horizontal;
			propertylayout.AddView(stackView3);
			SeparatorView separate3 = new SeparatorView(context, width * 2);
			separate3.LayoutParameters=new ViewGroup.LayoutParams(width * 2, 5);
			LinearLayout.LayoutParams layoutParams5 = new LinearLayout.LayoutParams(width * 2, 5);
			layoutParams5.SetMargins(0, 20, 15, 0);
			propertylayout.AddView(separate3, layoutParams5);
			propertylayout.SetPadding(20,20,20,20);
			
			return  propertylayout;
		}

		public static void hideSoftKeyboard(Activity activity) {
			InputMethodManager inputMethodManager = (InputMethodManager) activity.GetSystemService(Activity.InputMethodService);
			inputMethodManager.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, 0);

		}
	}
}

