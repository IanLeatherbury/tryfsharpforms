#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Content;
using Android.App;
using Android.Graphics.Drawables;

namespace SampleBrowser
{
	[Activity (Label = "AppTheme")]
	public class PropertyWindow : Activity
	{
		
		protected override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			var mActionBar = ActionBar;
			mActionBar.SetDisplayHomeAsUpEnabled(true);
			mActionBar.SetDisplayShowCustomEnabled(true);
			mActionBar.SetIcon(new ColorDrawable(Resources.GetColor(Android.Resource.Color.Transparent)));    
			mActionBar.SetDisplayShowTitleEnabled(false);
			LayoutInflater mInflater = LayoutInflater.From(this);
			View mCustomView = mInflater.Inflate(Resource.Layout.property_header, null);
			mActionBar.CustomView =mCustomView;

			if(SampleActivity.sample.PropertyView==null)
			{
				SampleActivity.sample.PropertyView = SampleActivity.sample.GetPropertyWindowLayout(this);


			}
			SampleActivity.propertyWindow = this;

			SetContentView(SampleActivity.sample.PropertyView);


			RelativeLayout settingButton = (RelativeLayout) mCustomView
				.FindViewById(Resource.Id.imageButton);
			settingButton.Click += (object sender, EventArgs e) => {

				onProperyWindowClick();
			};

			RelativeLayout backButton = (RelativeLayout) mCustomView
				.FindViewById(Resource.Id.textParent);
			backButton.Click+= (object sender, EventArgs e) => 
			{
				Finish();
			};
			TextView textView = (TextView) FindViewById(Resource.Id.title_text);
			textView.Text = SampleActivity.selectedPageSample.Title;
		}



		public void onProperyWindowClick()
		{
			Intent intent = MainActivity.SelectedIntent;
			SampleActivity.sample.OnApplyChanges(SampleActivity.sample.SampleView);
			StartActivity(intent);
			OverridePendingTransition(Resource.Animation.slide, Resource.Animation.slideleft);

		}

		public void OnBackButtonPressed() {
			Intent intent = MainActivity.SelectedIntent;
			StartActivity(intent);
			OverridePendingTransition(Resource.Animation.slide,Resource.Animation.slideleft);
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

