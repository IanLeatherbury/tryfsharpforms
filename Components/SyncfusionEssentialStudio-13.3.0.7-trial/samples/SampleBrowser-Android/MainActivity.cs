#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using System.Runtime.Serialization;
using System.IO;
using System.Xml.Serialization;
using Java.IO;
using Org.XmlPull.V1;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

namespace SampleBrowser
{
	[Activity (Label = "SampleBrowser" ,  ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation | Android.Content.PM.ConfigChanges.ScreenSize,  Icon = "@drawable/icon" )]
	public class MainActivity : Activity
	{

		public static Activity context;
		public static Intent SelectedIntent;
		static Android.Content.Res.Orientation orientation= Android.Content.Res.Orientation.Portrait;
		public static MainActivity mainActivity;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			if (orientation == Android.Content.Res.Orientation.Portrait) {
				SetTheme (Resource.Style.PotraitTheme);
			} else {
				SetTheme (Resource.Style.LanscapeTheme);
			}

			context =mainActivity= this;
			SetContentView (Resource.Layout.layout);
			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			AddTab ("All Samples",  new SampleActivityFragment ());
			AddTab ("About Us",  new AboutPageFragment ());

			if (bundle != null)
				this.ActionBar.SelectTab(this.ActionBar.GetTabAt(bundle.GetInt("tab")));

		}

		public override void OnConfigurationChanged (Android.Content.Res.Configuration newConfig)
		{
			orientation = newConfig.Orientation;

				this.Finish ();
				Intent intent = new Intent(this, typeof(MainActivity));
				StartActivity(intent);

			base.OnConfigurationChanged (newConfig);
		}


		protected override void OnSaveInstanceState(Bundle outState)
		{
			outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);

			base.OnSaveInstanceState(outState);
		}

		void AddTab (string tabText, Fragment view)
		{
			var tab = this.ActionBar.NewTab ();            
			tab.SetText (tabText);
		
			tab.TabSelected += delegate(object sender, Android.App.ActionBar.TabEventArgs e)
			{
				var fragment = this.FragmentManager.FindFragmentById(Resource.Id.fragment_content);
				if (fragment != null)
					e.FragmentTransaction.Remove(fragment);         
				e.FragmentTransaction.Add (Resource.Id.fragment_content, view);
			};

			tab.TabUnselected += delegate(object sender, Android.App.ActionBar.TabEventArgs e) {
				e.FragmentTransaction.Remove(view);
			};

			this.ActionBar.AddTab (tab);
		}

		public override void OnBackPressed ()
		{
			base.OnBackPressed ();
		}

		public void MoveToSample(Group sample)
		{
			SampleActivity.selectedIndex=0;
			if(SelectedIntent==null)
				SelectedIntent = new Intent(this, typeof(SampleActivity));
			SelectedIntent.PutExtra("sample", sample);

			StartActivity(SelectedIntent);

			OverridePendingTransition(Resource.Animation.slideright,Resource.Animation.slide2);
			base.Finish ();


		}
	}
}


