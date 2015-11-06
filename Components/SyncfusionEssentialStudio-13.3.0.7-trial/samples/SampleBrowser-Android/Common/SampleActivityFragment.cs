#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections;
using System.Collections.Generic;
using Java.Lang;
using System.Xml;
using Org.XmlPull.V1;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using Android.Graphics;

namespace SampleBrowser
{
			
	public class SampleActivityFragment : Android.App.Fragment
	{
		
		ListView list;
		List<SampleBase> aSamples;
		List<List<SampleBase>> CurrentSamples= new List<List<SampleBase>>();
		SampleLayout sampleLayout;

		public override void OnCreate(Bundle savedInstanceState) {
			base.OnCreate(savedInstanceState);
			ParseXML();
			sampleLayout = new SampleLayout(MainActivity.context, aSamples);
			sampleLayout.NotifyDataSetChanged ();

		}

		public override void OnViewCreated(View view, Bundle savedInstanceState) {
			
			list = (ListView)view.FindViewById (Resource.Id.list);
			list.Adapter =sampleLayout;
			list.ItemClick += (object sender, Android.Widget.AdapterView.ItemClickEventArgs e) => {
				CreateSample(aSamples[e.Position]);
			};
		}

		void CreateSample(SampleBase sample) {
			CurrentSamples.Add(aSamples);
			Group group = (Group) sample;
			if (group.subGroups.Count > 0) {
				this.aSamples = group.subGroups;
			} else if (((Group) sample).samples.Count > 0) {
				this.aSamples = ((Group)sample).samples;
				MainActivity.mainActivity.MoveToSample((Group)sample);
			}
		}

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			View fragView = inflater.Inflate (Resource.Layout.showcase_layout, container, false);
			fragView.SetBackgroundColor (Color.White);
			return fragView;
		}

		void ParseXML()
		{

			XmlReader xtr =Resources.GetXml (Resource.Xml.samplelist);
			xtr.Read();
			while (!xtr.EOF)
			{
				List<SampleBase> groups = new List<SampleBase> ();
				xtr.Read ();
				if (xtr.Name == "Samples" && !xtr.IsStartElement()) break;
				bool isGroup = false;
				while (!isGroup) {

					if (xtr.Name == "Group" && xtr.IsStartElement ()) {
						Group group = new Group ();

						SetSample (group, xtr);
						xtr.Read ();
						List<SampleBase> samples = new List<SampleBase>();
						bool isSample = false;
						while (!isSample) {

							if (xtr.Name == "Sample" && xtr.IsStartElement ()) {
								Sample tc = new Sample ();
								SetSample (tc, xtr);
								samples.Add (tc);
								xtr.Read ();
								xtr.Read ();
								if (xtr.Name == "Group" && !xtr.IsStartElement ()) {
									isSample = true;
									xtr.Read ();
									group.samples = samples;
									groups.Add (group);
								}
							} else if (xtr.Name == "Group" && !xtr.IsStartElement ()) {
								isSample = true;
								xtr.Read ();
								groups.Add (group);
							}
						}
						if (xtr.Name == "Samples" && !xtr.IsStartElement()) {
							isGroup = true;
							xtr.Read();
						}


					}

				}

				xtr.Read();
				this.aSamples = groups;
			} 
			xtr.Close();

		}


		void SetSample(SampleBase sample,XmlReader reader)
		{
			reader.MoveToAttribute ("Name");
			sample.Name = getValueFromReader (reader);
			reader.MoveToAttribute ("Title");
			sample.Title = getValueFromReader (reader);
			reader.MoveToAttribute ("Type");
			sample.Type = getValueFromReader (reader);
			reader.MoveToAttribute("ImageId");
			sample.ImageId = getValueFromReader (reader);

		}

		string getValueFromReader(XmlReader reader)
		{
			return reader.Value != null ? reader.Value : null;
		}

	


	}



}

