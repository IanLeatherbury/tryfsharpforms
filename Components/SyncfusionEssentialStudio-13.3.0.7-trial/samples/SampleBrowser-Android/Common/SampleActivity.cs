#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Widget;
using Android.Content;
using Android.Views;
using Android.Graphics;
using System.Collections.Generic;
using System.Xml;
using System.Collections;
using Android.Graphics.Drawables;


namespace SampleBrowser
{
	[Activity (AlwaysRetainTaskState = true,  Theme = "@style/PropertyApp",  LaunchMode = Android.Content.PM.LaunchMode.SingleInstance)]
	public class SampleActivity : Activity
	{
		Group selectedGroup;
		public static int selectedIndex=0;
		public static Sample selectedPageSample;
		public static SamplePage sample;
		public static Intent propertyIndent;
		public static PropertyWindow propertyWindow;
		public static FrameLayout selectedLayout;
		public SampleActivity ()
		{
		}

		protected override void OnCreate (Android.OS.Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			var mActionBar = ActionBar;
			mActionBar.SetDisplayHomeAsUpEnabled(true);
			mActionBar.SetDisplayShowCustomEnabled(true);
			mActionBar.SetIcon(new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));    
			mActionBar.SetDisplayShowTitleEnabled(false);
			LayoutInflater mInflater = LayoutInflater.From(this);
			View mCustomView = mInflater.Inflate(Resource.Layout.samplelist_layout, null);

			selectedGroup= (Group)MainActivity.SelectedIntent.GetSerializableExtra("sample");
			SampleLayout sampleLayouts= new SampleLayout(MainActivity.context,selectedGroup.samples);
			mActionBar.CustomView = mCustomView;
			Sample selectedSample=(Sample)selectedGroup.samples[selectedIndex];

			SetContentView(Resource.Layout.SamplePage);
			ImageView imageButton = (ImageView) mCustomView
				.FindViewById(Resource.Id.imageButton);
			Context wrapper = new ContextThemeWrapper(this, Android.Resource.Style.Theme);
		    ListPopupWindow popupWindow = new ListPopupWindow(wrapper);
			popupWindow.SetBackgroundDrawable(Resources.GetDrawable(Resource.Drawable.listpopup));
				
			imageButton.Click += (object sender, EventArgs e) => {

				popupWindow.Show();
			};
			popupWindow.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {

				Sample subSamples = (Sample) selectedGroup.samples[e.Position];
				selectedIndex = e.Position;
				RefreshSample(subSamples);
				popupWindow.Dismiss();

			};

			RelativeLayout settingButton = (RelativeLayout) mCustomView
				.FindViewById(Resource.Id.settingsParent);
			settingButton.Click += (object sender, EventArgs e) => {

				onProperyWindowClick();
			};
			if(selectedGroup.samples.Count<=1)
			{
				imageButton.Visibility = ViewStates.Invisible;
				
			}
			popupWindow.AnchorView = imageButton;
			popupWindow.Width = measureContentWidth(sampleLayouts);
			popupWindow.SetAdapter(sampleLayouts);
			RefreshSample (selectedSample);
		}


		public void onProperyWindowClick()
		{
			if(propertyIndent!=null)
				StartActivity(propertyIndent);

			OverridePendingTransition(Resource.Animation.slideright,Resource.Animation.slide2);

		}

		public void OnBackButtonPressed ()
		{
			
			Finish();


		}



		private int measureContentWidth(ArrayAdapter listAdapter) {
			ViewGroup mMeasureParent = null;
			int maxWidth = 0;
			View itemView = null;
			int itemType = 0;

			ArrayAdapter adapter = listAdapter;
			int widthMeasureSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
			int heightMeasureSpec = View.MeasureSpec.MakeMeasureSpec(0, MeasureSpecMode.Unspecified);
			int count = adapter.Count;
			for (int i = 0; i < count; i++) {
				int positionType = adapter.GetItemViewType (i);
				if (positionType != itemType) {
					itemType = positionType;
					itemView = null;
				}

				if (mMeasureParent == null) {
					mMeasureParent = new FrameLayout(this);
				}

				itemView = adapter.GetView(i, itemView, mMeasureParent);
				itemView.Measure(widthMeasureSpec, heightMeasureSpec);

				int itemWidth = itemView.MeasuredWidth;

				if (itemWidth > maxWidth) {
					maxWidth = itemWidth;
				}
			}

			return maxWidth+40;
		}

		void RefreshSample(Sample selectedSample)
		{
			FrameLayout layout = (FrameLayout)FindViewById(Resource.Id.samplearea);
			layout.SetPadding (5, 5, 5, 5);
			layout.SetBackgroundColor (Color.White);
			selectedPageSample = selectedSample;
			ImageView settingsImage= (ImageView)FindViewById(Resource.Id.settings);
			if(propertyIndent!=null && propertyWindow!=null)
			{
				propertyWindow.Finish();
			}
			if (sample != null) {
				sample.Destroy();
			}
			propertyIndent = new Intent(this, typeof(PropertyWindow));
			TextView textView = (TextView) FindViewById(Resource.Id.title_text);
			textView.Text = selectedSample.Title;
			RelativeLayout settingButton = (RelativeLayout)FindViewById (Resource.Id.settingsParent);
			RelativeLayout textParent = (RelativeLayout)FindViewById (Resource.Id.textParent);
			textParent.Click+= (object sender, EventArgs e) => {

				OnBackButtonPressed();
			};
			bool isClassExists = Type.GetType("SampleBrowser."+selectedSample.Name)!=null;
			if (isClassExists) {
				var handle = Activator.CreateInstance (null, "SampleBrowser." + selectedSample.Name);
				sample = (SamplePage)handle.Unwrap ();
				layout.RemoveAllViews ();
				layout.AddView (sample.GetSampleContent (this));
				if (sample.GetPropertyWindowLayout (this) == null) {
					settingsImage.Visibility = ViewStates.Invisible;
					settingButton.Clickable = false;
				} else {
					settingsImage.Visibility = ViewStates.Visible;
					settingButton.Clickable = true;
				}
			}


		}

		public override void Finish ()
		{
			Intent intent = new Intent(this, typeof(MainActivity));
			StartActivity(intent);
			OverridePendingTransition(Resource.Animation.slide,Resource.Animation.slideleft);
			if(propertyWindow!=null)
			{
				propertyWindow.Finish();
			}
			base.Finish ();
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			switch (item.ItemId) {
			case Android.Resource.Id.Home:
				OnBackButtonPressed ();
				break;
			
			}
			return base.OnOptionsItemSelected(item);
		}
	}
}

