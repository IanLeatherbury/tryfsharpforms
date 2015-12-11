﻿using System;

using Xamarin.Forms;
using tryfsharplib;

namespace tryfsharpforms
{
	public class StockStatsPage : ContentPage
	{

		public StockStatsPage (string stockTicker)
		{


			var stock = new ChartingAndComparingPrices.ComparingStocks (stockTicker, new DateTime (2014, 1, 1), DateTime.Now);

			RelativeLayout relativeLayout = new RelativeLayout ();

			var largeTicker = new Label {
				Text = stockTicker.ToUpper (),
				FontSize = 30,
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				TextColor = MyColors.Clouds,
				WidthRequest = 50,
				HeightRequest = 25
			};

			var standDevLabel = new Label { 
				Text = "Standard Deviation",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontAttributes = FontAttributes.Bold, TextColor = MyColors.Clouds
			};

			var standDevNumber = new Label {
				Text = "$" + System.Math.Round (stock.StandardDev, 2).ToString (),
				HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = MyColors.Clouds
			};

			var basicStatsLabel = new Label { 
				Text = "Basic Statistics using Math.Net",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontAttributes = FontAttributes.Bold, TextColor = MyColors.Clouds
			};

			var meanLabel = new Label {
				Text = "Mean: " + System.Math.Round (stock.Mean, 2).ToString (),
				HorizontalOptions = LayoutOptions.Start, TextColor = MyColors.Clouds
			};

			var maxLabel = new Label {
				Text = "Max: " + System.Math.Round (stock.Max, 2),
				HorizontalOptions = LayoutOptions.Start, TextColor = MyColors.Clouds
			};

			var minLabel = new Label {
				Text = "Min: " + System.Math.Round (stock.Min, 2),
				HorizontalOptions = LayoutOptions.Start, TextColor = MyColors.Clouds
			};

			var stdLabel = new Label {
				Text = "StdDev: " + System.Math.Round (stock.StandardDev, 2).ToString (),
				HorizontalOptions = LayoutOptions.Start, TextColor = MyColors.Clouds
			};

			Func<RelativeLayout, double> standDevLabelWidth = (p) => standDevLabel.GetSizeRequest(relativeLayout.Width, relativeLayout.Height).Request.Width;
			//dashboard is rel layout
			//			dashboard.Children.Add(
			//				reportName,
			//				xConstraint: Constraint.Constant(10),
			//				yConstraint: Constraint.Constant(10),
			//				widthConstraint: Constraint.RelativeToParent(p=>p.Width * 0.6 - 10)
			//			);

			var boxView = new BoxView ();
			boxView.HeightRequest = 1;
			boxView.WidthRequest = App.ScreenWidth;
			boxView.Color = MyColors.Clouds;

			BackgroundColor = MyColors.MidnightBlue;

			relativeLayout.Children.Add (
				largeTicker, 
				Constraint.RelativeToParent ((parent) => {
					return (parent.Width * .5 - 25);
				}),
				Constraint.Constant (20),
				Constraint.Constant (100),
				Constraint.Constant (25)
			);

			relativeLayout.Children.Add (boxView,
				Constraint.Constant (0),
				Constraint.Constant(30)
			);

			Content = relativeLayout;
		}
	}
}


