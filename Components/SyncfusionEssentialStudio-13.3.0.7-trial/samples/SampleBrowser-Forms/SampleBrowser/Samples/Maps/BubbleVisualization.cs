#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfMaps.XForms;
using System.Collections.Generic;
using Xamarin.Forms;

namespace SampleBrowser
{
	public class BubbleVisualization : SamplePage
	{
		SfMaps maps;
		public BubbleVisualization ()
		{

			maps = new SfMaps ();
			ShapeFileLayer layer = new ShapeFileLayer ();
			maps.BackgroundColor = Color.White;
			layer.Uri ="world1.shp";
			layer.ItemsSource = GetDataSource();
			layer.ShapeIDPath = "Country";
			layer.ShapeIDTableField = "NAME";
			layer.ShapeSettings = new ShapeSetting ();
			layer.ShapeSettings.ShapeValuePath= "Country";
			layer.ShapeSettings.ShapeFill = Color.FromHex ("#A9D9F7");
			BubbleMarkerSetting marker = new BubbleMarkerSetting ()
			{  Fill = Color.FromHex ("#ffa500"), MinSize=25,MaxSize=75 };
			layer.BubbleMarkerSettings = marker;
			maps.Layers.Add (layer);
			Content = maps;
		}

		public SfMaps GetView()
		{
			return maps;
		}

		public List<BubbleData> GetDataSource()
		{
			List<BubbleData> list = new List<BubbleData> ();
			list.Add(new BubbleData("Brazil"));
			list.Add(new BubbleData("Canada"));
			list.Add(new BubbleData("Russia"));
			list.Add(new BubbleData("India"));
			list.Add(new BubbleData("Australia"));
			list.Add(new BubbleData("Japan"));
			list.Add(new BubbleData("Chad"));
			return list;
		}
	}
}

