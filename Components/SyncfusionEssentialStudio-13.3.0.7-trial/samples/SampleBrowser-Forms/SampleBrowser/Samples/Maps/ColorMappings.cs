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
using System.Collections.ObjectModel;

namespace SampleBrowser
{
	public class ColorMappings  : SamplePage
	{
		SfMaps maps;
		public ColorMappings ()
		{
			maps = new SfMaps ();
			maps.BackgroundColor = Color.White;
			ShapeFileLayer layer = new ShapeFileLayer();
			layer.Uri ="usa_state.shp";
			layer.ShapeIDTableField ="STATE_NAME";
			layer.ShapeIDPath ="Name";
			layer.ItemsSource = GetDataSource ();
			layer.BubbleMarkerSettings = null;
			SetColorMapping(layer.ShapeSettings);
			layer.ShapeSettings.ShapeColorValuePath ="Type";
			maps.Layers.Add (layer);
			Content = maps;
		}

		public SfMaps GetView()
		{
			return maps;
		}

		List<AgricultureData> GetDataSource()
		{
			List<AgricultureData> list= new List<AgricultureData>();
			list.Add(new AgricultureData("Alabama", "Vegetables", 9 ));
			list.Add(new AgricultureData( "Alaska", "Vegetables", 3 ));
			list.Add(new AgricultureData( "Arizona", "Rice", 11 ));
			list.Add(new AgricultureData( "Arkansas", "Vegetables", 6 ));
			list.Add(new AgricultureData( "California", "Rice", 55 ));
			list.Add(new AgricultureData( "Colorado", "Rice", 9 ));
			list.Add(new AgricultureData( "Connecticut", "Grains", 7 ));
			list.Add(new AgricultureData( "Delaware", "Grains", 3 ));
			list.Add(new AgricultureData( "District of Columbia", "Grains", 3 ));
			list.Add(new AgricultureData( "Florida", "Rice", 29 ));
			list.Add(new AgricultureData( "Georgia", "Rice", 16 ));
			list.Add(new AgricultureData( "Hawaii", "Grains", 4 ));
			list.Add(new AgricultureData( "Idaho", "Grains", 4 ));
			list.Add(new AgricultureData( "Illinois", "Vegetables", 20 ));
			list.Add(new AgricultureData( "Indiana", "Grains", 11 ));
			list.Add(new AgricultureData( "Iowa", "Vegetables", 6 ));
			list.Add(new AgricultureData( "Kansas", "Rice", 6 ));
			list.Add(new AgricultureData( "Kentucky", "Grains", 8 ));
			list.Add(new AgricultureData( "Louisiana", "Rice", 8 ));
			list.Add(new AgricultureData( "Maine", "Grains", 4 ));
			list.Add(new AgricultureData( "Maryland", "Grains", 10 ));
			list.Add(new AgricultureData( "Massachusetts", "Grains", 11 ));
			list.Add(new AgricultureData( "Michigan", "Grains", 16 ));
			list.Add(new AgricultureData( "Minnesota", "Wheat", 10 ));
			list.Add(new AgricultureData( "Mississippi", "Vegetables", 6 ));
			list.Add(new AgricultureData( "Missouri", "Vegetables", 10 ));
			list.Add(new AgricultureData( "Montana", "Grains", 3 ));
			list.Add(new AgricultureData( "Nebraska", "Rice", 5 ));
			list.Add(new AgricultureData( "Nevada", "Wheat", 6 ));
			list.Add(new AgricultureData( "New Hampshire", "Grains", 4 ));
			list.Add(new AgricultureData( "New Jersey", "Vegetables", 14 ));
			list.Add(new AgricultureData( "New Mexico", "Rice", 5 ));
			list.Add(new AgricultureData( "New York", "Vegetables", 29 ));
			list.Add(new AgricultureData( "North Carolina", "Rice", 15 ));
			list.Add(new AgricultureData( "North Dakota", "Grains", 3 ));
			list.Add(new AgricultureData( "Ohio", "Vegetables", 18 ));
			list.Add(new AgricultureData( "Oklahoma", "Rice", 7 ));
			list.Add(new AgricultureData( "Oregon", "Wheat", 7 ));
			list.Add(new AgricultureData( "Pennsylvania", "Vegetables", 20 ));
			list.Add(new AgricultureData( "Rhode Island", "Grains", 4 ));
			list.Add(new AgricultureData( "South Carolina", "Rice", 9 ));
			list.Add(new AgricultureData( "South Dakota", "Grains", 3 ));
			list.Add(new AgricultureData( "Tennessee", "Vegetables", 11 ));
			list.Add(new AgricultureData( "Texas", "Vegetables", 38 ));
			list.Add(new AgricultureData( "Utah", "Rice", 6 ));
			list.Add(new AgricultureData( "Vermont", "Grains", 3 ));
			list.Add(new AgricultureData( "Virginia", "Rice", 13 ));
			list.Add(new AgricultureData( "Washington", "Vegetables", 12 ));
			list.Add(new AgricultureData( "West Virginia", "Grains", 5 ));
			list.Add(new AgricultureData( "Wisconsin", "Grains", 10 ));
			list.Add(new AgricultureData( "Wyoming", "Wheat", 3 ));
			return list;
		}

		void SetColorMapping(ShapeSetting setting)
		{
			ObservableCollection<ColorMapping> colorMappings= new ObservableCollection<ColorMapping>();

			EqualColorMapping colorMapping1= new EqualColorMapping();
			colorMapping1.Value= "Vegetables";
			colorMapping1.LegendLabel= "Vegetables";
			colorMapping1.Color =Color.FromHex("#29BB9C");
			colorMappings.Add(colorMapping1);

			EqualColorMapping colorMapping2= new EqualColorMapping();
			colorMapping2.Value= "Rice";
			colorMapping2.LegendLabel= "Rice";
			colorMapping2.Color =Color.FromHex("#FD8C48");
			colorMappings.Add(colorMapping2);

			EqualColorMapping colorMapping3= new EqualColorMapping();
			colorMapping3.Value= "Wheat";
			colorMapping3.LegendLabel= "Wheat";
			colorMapping3.Color =Color.FromHex("#E54D42");
			colorMappings.Add(colorMapping3);

			EqualColorMapping colorMapping4= new EqualColorMapping();
			colorMapping4.Value= "Grains";
			colorMapping4.LegendLabel= "Grains";
			colorMapping4.Color =Color.FromHex("#3A99D9");
			colorMappings.Add(colorMapping4);

			setting.ColorMappings = colorMappings;
		}

	}
}


