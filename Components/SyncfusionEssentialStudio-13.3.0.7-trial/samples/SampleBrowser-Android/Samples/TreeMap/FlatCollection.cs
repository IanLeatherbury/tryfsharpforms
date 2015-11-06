#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.Views;
using Android.Graphics;
using Com.Syncfusion.Treemap;
using System.Collections.Generic;
using Android.Widget;
using Com.Syncfusion.Treemap.Enums;
using Android.Content;

namespace SampleBrowser
{
	public class FlatCollection : SamplePage
	{
		public FlatCollection ()
		{
		}
		SfTreeMap tree;


		public override View GetSampleContent (Context context)
		{
			tree = new SfTreeMap (context);
			tree.LeafItemSettings = new LeafItemSetting (){ ShowLabels = true, Gap = 5, StrokeColor = Color.White, StrokeWidth = 2 };
			tree.LeafItemSettings.LabelStyle = new Style () { TextSize = 18, TextColor = Color.White };
			List<Range> ranges = new List<Range>();
			ranges.Add(new Range() { LegendLabel = "1 % Growth", From = 0, To = 1, Color = Color.ParseColor("#77D8D8") });
			ranges.Add(new Range() { LegendLabel = "2 % Growth", From = 0, To = 2, Color = Color.ParseColor("#AED960") });
			ranges.Add(new Range() { LegendLabel = "3 % Growth", From = 0, To = 3, Color = Color.ParseColor("#FFAF51") });
			ranges.Add(new Range() { LegendLabel = "4 % Growth", From = 0, To = 4, Color = Color.ParseColor("#F3D240") });
			tree.LeafItemColorMapping = new RangeColorMapping() { Ranges = ranges };
			Size legendSize =new Size(300, 60);
			Size iconSize = new Size(25, 25);
			Color legendColor=  Color.Gray;
			tree.LegendSettings = new LegendSetting()
			{
				LabelStyle = new Style()
				{
					TextSize = 14,
					TextColor = legendColor
				},
				IconSize = iconSize,
				ShowLegend = true,
				LegendSize = legendSize
			};
			GetPopulationData ();
			tree.Items = PopulationDetails;
			return tree;
		}

		
		void  GetPopulationData()
		{
			PopulationDetails = new List<TreeMapItem>();
			PopulationDetails.Add(new TreeMapItem() { Label = "Indonesia", ColorWeight = 3, Weight = 237641326 });
			PopulationDetails.Add(new TreeMapItem() { Label = "Russia", ColorWeight = 2, Weight = 152518015 });
			PopulationDetails.Add(new TreeMapItem() { Label = "United States", ColorWeight = 4, Weight = 315645000 });
			PopulationDetails.Add(new TreeMapItem() { Label = "Mexico", ColorWeight = 2, Weight = 112336538 });
			PopulationDetails.Add(new TreeMapItem() { Label = "Nigeria", ColorWeight = 2, Weight = 170901000 });
			PopulationDetails.Add(new TreeMapItem() { Label = "Egypt", ColorWeight = 1, Weight = 83661000 });
			PopulationDetails.Add(new TreeMapItem() { Label = "Germany", ColorWeight = 1, Weight = 81993000 });
			PopulationDetails.Add(new TreeMapItem() { Label = "France", ColorWeight = 1, Weight = 65605000 });
			PopulationDetails.Add(new TreeMapItem() { Label = "UK", ColorWeight = 1, Weight = 63181775 });
		}

		public List<TreeMapItem> PopulationDetails
		{
			get;
			set;
		}
	}
}

