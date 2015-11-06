#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfTreeMap.iOS;
#if __UNIFIED__
using UIKit;
using CoreGraphics;
using Foundation;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif
namespace SampleBrowser
{
	public class GettingStarted : SampleView
	{
		SFTreeMap tree ;
		UILabel label;
		UIView view;
		public override void LayoutSubviews ()
		{
			base.LayoutSubviews ();
			view.Frame =  new CGRect(Frame.Location.X,0,Frame.Size.Width,Frame.Size.Height);
			tree.Frame = new CGRect(Frame.Location.X,0,Frame.Size.Width-6,Frame.Size.Height);
			view.AddSubview (tree);
			label.Frame=new CGRect(0,0,Frame.Size.Width,40);
			tree.LegendSettings.Size= new CGSize (this.Frame.Size.Width, 60);
			SetNeedsDisplay ();
		}

		public GettingStarted ()
		{
			view = new UIView ();
			label = new UILabel ();
			label.Text = "Getting Started";
			label.Frame=new  CGRect(0,0,300,30);
			//view.AddSubview (label);
			tree = new SFTreeMap ();
			tree.LeafItemSettings = new SFLeafItemSetting ();
			tree.LeafItemSettings.LabelStyle = new SFStyle () { Font = UIFont.SystemFontOfSize (12), Color = UIColor.White };
			tree.LeafItemSettings.LabelPath = (NSString)"Label";
			tree.LeafItemSettings.ShowLabels = true;
			tree.LeafItemSettings.Gap = 2;
			tree.LeafItemSettings.BorderColor=UIColor.Gray;
			tree.LeafItemSettings.BorderWidth = 1;
			NSMutableArray ranges = new NSMutableArray ();
			ranges.Add (new SFRange () {
				LegendLabel = (NSString)"1 % Growth",
				From = 0,
				To = 1,
				Color = UIColor.FromRGB (0x77, 0xD8, 0xD8)
			});
			ranges.Add (new SFRange () {
				LegendLabel = (NSString)"2 % Growth",
				From = 0,
				To = 2,
				Color = UIColor.FromRGB (0xAE, 0xD9, 0x60)
			});
			ranges.Add (new SFRange () {
				LegendLabel = (NSString)"3 % Growth",
				From = 0,
				To = 3,
				Color = UIColor.FromRGB (0xFF, 0xAF, 0x51)
			});
			ranges.Add (new SFRange () {
				LegendLabel = (NSString)"4 % Growth",
				From = 0,
				To = 4,
				Color = UIColor.FromRGB (0xF3, 0xD2, 0x40)
			});
			tree.LeafItemColorMapping = new SFRangeColorMapping () { Ranges = ranges };
			CGSize legendSize = new CGSize (this.Frame.Size.Width, 60);
			CGSize iconSize = new CGSize (17, 17);
			UIColor legendColor = UIColor.Gray;
			tree.LegendSettings = new SFLegendSetting () {
				LabelStyle = new SFStyle () {
					Font = UIFont.SystemFontOfSize (12),
					Color = legendColor
				},
				IconSize = iconSize,
				ShowLegend = true,
				Size = legendSize
			};
			GetPopulationData ();
			tree.Items = PopulationDetails;


			AddSubview (view);
			control = this;
		}

		void  GetPopulationData ()
		{
			PopulationDetails = new NSMutableArray ();

			PopulationDetails.Add (new SFTreeMapItem () { Label = (NSString)"Indonesia", ColorWeight = 3, Weight = 237641326 });
			PopulationDetails.Add (new SFTreeMapItem () { Label = (NSString)"Russia", ColorWeight = 2, Weight = 152518015 });
			PopulationDetails.Add (new SFTreeMapItem () { Label = (NSString)"United States", ColorWeight = 4, Weight = 315645000 });
			PopulationDetails.Add (new SFTreeMapItem () { Label = (NSString)"Mexico", ColorWeight = 2, Weight = 112336538 });
			PopulationDetails.Add (new SFTreeMapItem () { Label = (NSString)"Nigeria", ColorWeight = 2, Weight = 170901000 });
			PopulationDetails.Add (new SFTreeMapItem () { Label = (NSString)"Egypt", ColorWeight = 1, Weight = 83661000 });
			PopulationDetails.Add (new SFTreeMapItem () { Label = (NSString)"Germany", ColorWeight = 1, Weight = 81993000 });
			PopulationDetails.Add (new SFTreeMapItem () { Label = (NSString)"France", ColorWeight = 1, Weight = 65605000 });
			PopulationDetails.Add (new SFTreeMapItem () { Label = (NSString)"UK", ColorWeight = 1, Weight = 63181775 });
		}

		public NSMutableArray PopulationDetails {
			get;
			set;
		}

	}
}

