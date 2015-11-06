#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using Android.Views.InputMethods;


#endregion
using System;
using Com.Syncfusion.Autocomplete;
using Android.Widget;
using Android.Views;
using System.Runtime.Remoting.Contexts;
using Android.Graphics;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Android.App;
using Android.Content;

using SampleBrowser;



namespace SampleBrowser
{
	public class AutoComplete : SamplePage
	{
		Spinner spinner1,text3;
		EditText etext1,etext2,etext3;
		SuggestionMode suggestionModes = SuggestionMode.StartsWith;
		AutoCompleteMode autoCompleteMode = AutoCompleteMode.Suggest;
		LinearLayout propertylayout, stackView2, stackView3,stackView4;
		int minimum = 1,popupdelay = 100,maximum = 400;
		ArrayAdapter<String> dataAdapter,dataadapter1;
		SfAutoComplete autoComplete1,autoComplete2;
		TextView text1s,text2s,text3s,text4s,text6s;
		TextView text11,text22,text33,text44,text55,text66,text77,text88;
		Button buttons;
		int cc=0;
		Spinner spinners;
		AlertDialog.Builder dlgAlert;
		List<String> Title = new List<String> ();
		List<String> Country = new List<String> ();
		List<String> Experience = new List<String> ();
		public override View GetPropertyWindowLayout (Android.Content.Context context)
		{
			int width = context.Resources.DisplayMetrics.WidthPixels / 2;
			propertylayout = new LinearLayout(context);
			propertylayout.Orientation = Orientation.Vertical;
			LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(
				width * 2, 5);
			layoutParams.SetMargins(0, 20, 0, 0);
			//SuggestionMode
			TextView textView1 = new TextView(context);
			textView1.Text = "Suggestion Mode";
			textView1.TextSize=20;
			textView1.Gravity  = GravityFlags.Left;
			TextView textview2 = new TextView(context);
			propertylayout.AddView(textview2);
			spinner1 = new Spinner(context);
			//spinner1.Gravity  = GravityFlags.Left;
			propertylayout.AddView(textView1);
			propertylayout.AddView(spinner1);
			List<String> list = new List<String>();
			list.Add("StartsWith");
			list.Add("StartsWithCaseSensitive");
			list.Add("Contains");
			list.Add("ContainsWithCaseSensitive");
			list.Add("EndsWith");
			list.Add("EndsWithCaseSensitive");
			list.Add("Equals");
			list.Add("EqualsWithCaseSensitive");
			//list.add("None");

			dataAdapter = new ArrayAdapter<String> (context, Android.Resource.Layout.SimpleSpinnerItem, list);
			dataAdapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);

			spinner1.Adapter = dataAdapter;

			spinner1.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
				String selectedItem = dataAdapter.GetItem (e.Position);
				
				if (selectedItem.Equals ("StartsWith")) {
					suggestionModes = SuggestionMode.StartsWith;
									
				} else if (selectedItem.Equals ("StartsWithCaseSensitive")) {
					suggestionModes = SuggestionMode.StartsWithCaseSensitive;
										
				} else if (selectedItem.Equals ("Contains")) {
					suggestionModes = SuggestionMode.Contains;
									
				} else if (selectedItem.Equals ("ContainsWithCaseSensitive")) {
					suggestionModes = SuggestionMode.ContainsWithCaseSensitive;
										
				} else if (selectedItem.Equals ("EndsWith")) {
					suggestionModes = SuggestionMode.EndsWith;
										
				} else if (selectedItem.Equals ("EndsWithCaseSensitive")) {
					suggestionModes = SuggestionMode.EndsWithCaseSensitive;
										
				} else if (selectedItem.Equals ("Equals")) {
					suggestionModes = SuggestionMode.Equals;
										
				} else if (selectedItem.Equals ("EqualsWithCaseSensitive")) {
					suggestionModes = SuggestionMode.EqualsWithCaseSensitive;
										
				}
			};
			//Separator 1
			SeparatorView separate = new SeparatorView(context, width * 2);
			separate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
			LinearLayout.LayoutParams layoutParam1 = new LinearLayout.LayoutParams(
				width * 2, 5);
			layoutParam1.SetMargins(0, 20, 0, 0);
			propertylayout.AddView(separate,layoutParam1);

			//AutoCompleteMode
			TextView textV1 = new TextView(context);
			textV1.Text = "AutoComplete Mode";
			textV1.TextSize=20;
			textV1.Gravity = GravityFlags.Left;
			TextView textv2 = new TextView(context);
			propertylayout.AddView(textv2);
			text3 = new Spinner(context);
			propertylayout.AddView(textV1);
			propertylayout.AddView(text3);
			List<String> list1 = new List<String>();
			list1.Add("Suggest");
			list1.Add("SuggestAppend");
			list1.Add("Append");

			dataadapter1 = new ArrayAdapter<String> (context, Android.Resource.Layout.SimpleSpinnerItem, list1);
			dataadapter1.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);

			text3.Adapter = dataadapter1;

			text3.ItemSelected+= (object sender, AdapterView.ItemSelectedEventArgs e) => {
				String selectedItem = dataadapter1.GetItem(e.Position);
									if (selectedItem.Equals("Suggest")) {
										autoCompleteMode = AutoCompleteMode.Suggest;
										
									} else if (selectedItem.Equals("SuggestAppend")) {
										autoCompleteMode = AutoCompleteMode.SuggestAppend;
										
									} else if (selectedItem.Equals("Append")) {
										autoCompleteMode = AutoCompleteMode.Append;
										
									}
			};

			//Separator 2
			SeparatorView separate1 = new SeparatorView(context, width * 2);
			separate1.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);

			LinearLayout.LayoutParams layoutParams2 = new LinearLayout.LayoutParams(
				width * 2, 5);
			layoutParams2.SetMargins(0, 20, 0, 0);
			propertylayout.SetPadding(15, 0, 15, 0);

			//Separator 2
			SeparatorView separate2 = new SeparatorView(context, width * 2);
			separate2.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
			propertylayout.AddView(separate2, layoutParams2);

			//Min Prefix Character
			TextView textView7 = new TextView(context);
			textView7.Text = "Min Prefix Character";
			textView7.SetWidth(400);
			textView7.TextSize=20;
			etext1 = new EditText(context);
			etext1.Text = "1";
			etext1.TextSize=16;
			etext1.InputType = Android.Text.InputTypes.ClassPhone;
			etext1.TextChanged+= (object sender, Android.Text.TextChangedEventArgs e) => 
			{
				if(etext1.Text.Length > 0)
					minimum =  Convert.ToInt32(e.Text.ToString());
				else
					minimum = 1;
			};

			LinearLayout.LayoutParams layoutParams7 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			layoutParams7.SetMargins(0, 10, 0, 0);
			LinearLayout.LayoutParams layoutParams8 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.WrapContent, 55);
			layoutParams8.SetMargins(0, 10, 0, 0);
			stackView2 = new LinearLayout(context);
			stackView2.AddView(textView7,layoutParams8);
			stackView2.AddView(etext1, layoutParams7);
			stackView2.Orientation = Orientation.Horizontal;
			propertylayout.AddView(stackView2);
			SeparatorView separate4 = new SeparatorView(context, width * 2);
			separate4.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
			LinearLayout.LayoutParams layoutParams6 = new LinearLayout.LayoutParams(width * 2, 5);
			layoutParams6.SetMargins(0, 20, 15, 0);
			propertylayout.AddView(separate4, layoutParams6);

			//max DropDown height
			TextView textView8 = new TextView(context);
			textView8.Text = "Max DropDown Height";
			textView8.SetWidth(400);
			textView8.TextSize=20;
			etext2 = new EditText(context);
			etext2.Text = "200";
			etext2.TextSize=16;
			etext2.InputType = Android.Text.InputTypes.ClassPhone;
			etext2.TextChanged+= (object sender, Android.Text.TextChangedEventArgs e) => 
			{
				if(etext2.Text.Length>0)
					maximum =  Convert.ToInt32(e.Text.ToString());
				else
					maximum = 200;
			};

			LinearLayout.LayoutParams layoutParams9 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			layoutParams9.SetMargins(0, 10, 0, 0);
			LinearLayout.LayoutParams layoutParams10 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.WrapContent, 55);
			layoutParams10.SetMargins(0, 10, 0, 0);
			stackView3 = new LinearLayout(context);
			stackView3.AddView(textView8,layoutParams10);
			stackView3.AddView(etext2, layoutParams9);
			stackView3.Orientation = Orientation.Horizontal;
			propertylayout.AddView(stackView3);
			SeparatorView separate5 = new SeparatorView(context, width * 2);
			separate5.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
			LinearLayout.LayoutParams layoutParams11 = new LinearLayout.LayoutParams(width * 2, 5);
			layoutParams11.SetMargins(0, 20, 15, 0);
			propertylayout.AddView(separate5, layoutParams11);

			//Popup Delay
			TextView textView9 = new TextView(context);
			textView9.Text = "PopUp Delay";
			textView9.SetWidth(400);
			textView9.TextSize=20;
			etext3 = new EditText(context);
			etext3.Text = "100";
			etext3.TextSize=16;
			etext3.InputType = Android.Text.InputTypes.ClassPhone;
			etext1.SetWidth(50);
			etext2.SetWidth(50);
			etext3.SetWidth(50);

			etext3.TextChanged+= (object sender, Android.Text.TextChangedEventArgs e) => 
			{
				if(etext3.Text.Length>0)
					popupdelay=  Convert.ToInt32(e.Text.ToString());
				else
					popupdelay = 100;
			};
			LinearLayout.LayoutParams layoutParams12 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
			layoutParams12.SetMargins(0, 10, 0, 0);
			LinearLayout.LayoutParams layoutParams13 = new LinearLayout.LayoutParams(
				ViewGroup.LayoutParams.WrapContent, 55);
			layoutParams13.SetMargins(0, 10, 0, 0);
			stackView4 = new LinearLayout(context);
			stackView4.AddView(textView9,layoutParams13);
			stackView4.AddView(etext3, layoutParams12);
			stackView4.Orientation = Orientation.Horizontal;
			propertylayout.AddView(stackView4);
			SeparatorView separate6 = new SeparatorView(context, width * 2);
			separate6.LayoutParameters=new ViewGroup.LayoutParams(width * 2, 5);
			LinearLayout.LayoutParams layoutParams14 = new LinearLayout.LayoutParams(width * 2, 5);
			layoutParams14.SetMargins(0, 20, 15, 0);
			propertylayout.AddView(separate6, layoutParams14);

			return propertylayout;

		}

		public override View GetSampleContent (Android.Content.Context con)
		{
			
			dlgAlert = new AlertDialog.Builder(con);

			dlgAlert.SetTitle("Results");
			dlgAlert.SetPositiveButton("OK", (object sender, DialogClickEventArgs e) => 
				{
				});
			dlgAlert.SetCancelable(true);

			Title.Add ("Software");
			Title.Add ("Banking");
			Title.Add ("Media");
			Title.Add ("Medical");
			spinners = new Spinner(con);
			spinners.DropDownWidth = 500;
			spinners.SetBackgroundColor(Color.Gray);

			ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>
				(con, Android.Resource.Layout.SimpleSpinnerItem, Experience);
			dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spinners.Adapter = dataAdapter;

			Country.Add ("UAE");
			Country.Add ("Uruguay");
			Country.Add ("United States");
			Country.Add ("United Kingdom");
			Country.Add ("Ukraine");

			Experience.Add ("1");
			Experience.Add ("2");

			autoComplete1 = new SfAutoComplete(con);
			autoComplete2 = new SfAutoComplete(con);

			text1s = new TextView(con);
			text2s = new TextView(con);
			text3s = new TextView(con);
			text4s = new TextView(con);
			text6s = new TextView(con);

			text11 = new TextView(con);
			text22 = new TextView(con);
			text33 = new TextView(con);
			text44 = new TextView(con);
			text55 = new TextView(con);
			text66 = new TextView(con);
			text77 = new TextView(con);
			text88 = new TextView(con);

			buttons = new Button(con);
			buttons.SetWidth(ActionBar.LayoutParams.MatchParent);
			buttons.SetHeight(40);
			buttons.Text = "Search";
			buttons.SetTextColor(Color.White);
			buttons.SetBackgroundColor(Color.Gray);
			buttons.Click += (object sender, EventArgs e) => {
				GetResult();
				//dlgAlert.SetMessage(count + " Jobs Found");
				dlgAlert.SetMessage (cc + " Jobs Found");
				dlgAlert.Create ().Show ();
			};
			text11.SetHeight(10);
			text22.SetHeight(30);
			text33.SetHeight(10);
			text44.SetHeight(30);
			text55.SetHeight(10);
			text66.SetHeight(30);
			text77.SetHeight(10);
			text88.SetHeight(30);

			text1s.Text = "Job Search";
			text1s.TextSize = 30;
			text1s.Typeface = Typeface.DefaultBold;
			text2s.Text = "Country";
			text2s.TextSize = 16;
			text3s.Text = "Job Field";
			text3s.TextSize = 16;
			text4s.Text = "Experience";
			text4s.TextSize = 16;
			text6s.SetHeight(40);

			ArrayAdapter<String> adapters = new ArrayAdapter<String>(con,
				Android.Resource.Layout.SimpleListItem1, new Countrylist().Country);
			autoComplete1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 60);
			autoComplete1.SetAutoCompleteSource(adapters);
			autoComplete1.SuggestionMode = SuggestionMode.StartsWith;
			autoComplete1.MaximumDropDownHeight = 200;
			autoComplete1.Watermark = "Enter a country name";

			ArrayAdapter<String> adapters1 = new ArrayAdapter<String>(con,
				Android.Resource.Layout.SimpleListItem1, Title);
			autoComplete2.SetAutoCompleteSource(adapters1);
			autoComplete2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 60);
			autoComplete2.SuggestionMode = SuggestionMode.Contains;
			autoComplete2.MaximumDropDownHeight = 200;
			autoComplete2.Watermark = "Starts with ’S’, ‘M’ or ‘B’";

			ArrayAdapter<String> adapters2 = new ArrayAdapter<String>(con,
				Android.Resource.Layout.SimpleListItem1, Experience);
			spinners.Adapter = adapters2;
			spinners.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 60);

			LinearLayout linearLayout = new LinearLayout(con);
			linearLayout.SetPadding(20, 20, 20, 30);
			linearLayout.SetBackgroundColor(Color.Rgb(236, 236, 236));
			linearLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			linearLayout.Orientation = Orientation.Vertical;
			linearLayout.AddView(text1s);
			linearLayout.AddView(text6s);
			linearLayout.AddView(text2s);
			linearLayout.AddView(text11);
			linearLayout.AddView(autoComplete1);
			linearLayout.AddView(text22);
			linearLayout.AddView(text3s);
			linearLayout.AddView(text33);
			linearLayout.AddView(autoComplete2);
			linearLayout.AddView(text44);
			linearLayout.AddView(text4s);
			linearLayout.AddView(text55);
			linearLayout.AddView(spinners);
			linearLayout.AddView(text66);
			linearLayout.AddView(text88);
			linearLayout.AddView(buttons);
			linearLayout.Touch+= (object sender, View.TouchEventArgs e) => {
				//if(autoComplete1.IsFocused || autoComplete2.IsFocused ){
					Rect outRect = new Rect();
					autoComplete1.GetGlobalVisibleRect(outRect);
					autoComplete2.GetGlobalVisibleRect(outRect);

					if (!outRect.Contains((int)e.Event.RawX, (int)e.Event.RawY)) {
						autoComplete1.ClearFocus();
						autoComplete2.ClearFocus();

					}
					hideSoftKeyboard((Activity)con);
				//}
			};
			return linearLayout;
		}
		public void GetResult()
		{
			cc = 0;
			if (autoComplete1.Text.ToString ().Equals ("") || autoComplete2.Text.ToString ().Equals ("")) {
			} else {
				Random r = new Random ();
				cc = r.Next (5,60);
			}
		}
		public static void hideSoftKeyboard(Activity activity) {
			InputMethodManager inputMethodManager = (InputMethodManager) activity.GetSystemService(Activity.InputMethodService);
			inputMethodManager.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, 0);

		}
		public override void OnApplyChanges ()
		{
			base.OnApplyChanges ();
			autoComplete1.SuggestionMode = suggestionModes;
			autoComplete1.AutoCompleteMode = autoCompleteMode;
			autoComplete1.MinimumPrefixCharacters = minimum;
			autoComplete1.PopUpDelay = popupdelay;
			autoComplete1.MaximumDropDownHeight = maximum;
			autoComplete2.SuggestionMode = suggestionModes;
			autoComplete2.AutoCompleteMode = autoCompleteMode;
			autoComplete2.MinimumPrefixCharacters = minimum;
			autoComplete2.PopUpDelay = popupdelay;
			autoComplete2.MaximumDropDownHeight = maximum;
		}
	}
}