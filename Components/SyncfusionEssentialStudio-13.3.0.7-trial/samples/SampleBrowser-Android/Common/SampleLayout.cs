#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Widget;
using Android.App;
using System.Collections.Generic;
using Android.Views;
using Android.Graphics;
using Android.Text;

namespace SampleBrowser
{
	public class SampleLayout : ArrayAdapter<String>{
		private Activity context;
		public List<SampleBase> Samples;
		public SampleLayout(Activity context, List<SampleBase> samples):base(context, Resource.Layout.listitem_layout) {
			 


			this.Samples= samples;
			this.context = context;
			AddItems(samples);
		}

		public void AddItems(List<SampleBase> samples)
		{
			this.Clear();
			for (int i = 0; i < samples.Count; i++) {
				this.Add(samples[i].Name);
			}
			this.Samples= samples;
		}
		LayoutInflater inflater;



		public override View GetView(int index, View view, ViewGroup parent) {
			if (inflater == null)
				inflater = MainActivity.context.LayoutInflater;
			View rowView= inflater.Inflate(Resource.Layout.listitem_layout, null, true);
			TextView txtTitle = (TextView) rowView.FindViewById(Resource.Id.txt);
			rowView.SetPadding (15, 0, 15, 0);
			ImageView imageView = (ImageView) rowView.FindViewById(Resource.Id.img);
			SampleBase sample= this.Samples[index];
			txtTitle.Text = sample.Title;
			txtTitle.SetTextColor (Color.Black);
			if(sample.ImageId==null)
			{
				txtTitle.SetPadding(20,0,0,0);
				txtTitle.SetMaxWidth(300);
			}
			else {
				txtTitle.SetPadding(25,0,0,0);
				imageView.SetPadding (10, 0, 0, 0);
				imageView.SetImageResource(context.Resources.GetIdentifier("drawable/" + sample.ImageId, null, context.PackageName));
			}
			if(!sample.Type.Equals("")) {
				TextView textView = (TextView) rowView.FindViewById(Resource.Id.tagtxt);
				if (sample.Type.ToLower().Equals("new")) {
					textView.TextFormatted =Html.FromHtml("<sup><font color=\"#944b9d\"><small>NEW</small></font></sup>");

				} else if (sample.Type.ToLower().Equals("updated")) {
					textView.TextFormatted  =Html.FromHtml("<sup><font color=\"#6cbd44\"><small>UPDATED</small></font></sup>");

				} else if (sample.Type.ToLower().Equals("preview")) {
					textView.TextFormatted  =Html.FromHtml("<sup><font color=\"#dc8d26\"><small>PREVIEW</small></font></sup>");
				}

			}
			return rowView;
		}
	}
}

