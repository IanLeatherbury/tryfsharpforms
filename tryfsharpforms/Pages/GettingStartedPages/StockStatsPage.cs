using System;

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

			#region Views
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
				TextColor = MyColors.Clouds
			};

			var standDevNumber = new Label {
				Text = "$" + System.Math.Round (stock.StandardDev, 2).ToString (),
				HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = MyColors.Turqoise
			};

			var basicStatsLabel = new Label { 
				Text = "Basic Statistics using Math.Net",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				TextColor = MyColors.Clouds
			};

			var meanLabel = new Label {
				Text = "Mean: ",
				HorizontalOptions = LayoutOptions.Start, TextColor = MyColors.Clouds
			};

			var mean = new Label {
				Text = "$" + System.Math.Round (stock.Mean, 2).ToString (),
				TextColor = MyColors.Turqoise
			};

			var maxLabel = new Label {
				Text = "Max: ",
				HorizontalOptions = LayoutOptions.Start, TextColor = MyColors.Clouds
			};

			var max = new Label {
				Text = "$" + System.Math.Round (stock.Max, 2),
				TextColor = MyColors.Turqoise
			};

			var minLabel = new Label {
				Text = "Min: ",
				HorizontalOptions = LayoutOptions.Start, TextColor = MyColors.Clouds
			};

			var min = new Label {
				Text = "$" + System.Math.Round (stock.Min, 2),
				TextColor = MyColors.Turqoise
			};

			var stdLabel = new Label {
				Text = "StdDev: ",
				HorizontalOptions = LayoutOptions.Start, TextColor = MyColors.Clouds
			};

			var stdDev = new Label {
				Text = "$" + System.Math.Round (stock.StandardDev, 2).ToString (),
				TextColor = MyColors.Turqoise
			};

			var boxView = new BoxView ();
			boxView.HeightRequest = 2;
			boxView.WidthRequest = App.ScreenWidth;
			boxView.Color = MyColors.Concrete;

			var boxView0 = new BoxView ();
			boxView0.HeightRequest = 1;
			boxView0.WidthRequest = App.ScreenWidth;
			boxView0.Color = MyColors.Concrete;

			var boxView1 = new BoxView ();
			boxView1.HeightRequest = 1;
			boxView1.WidthRequest = App.ScreenWidth;
			boxView1.Color = MyColors.Concrete;

			#endregion

			#region Find view sizes
			Func<RelativeLayout, double> standDevLabelWidth = (p) => standDevLabel.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Width;

			Func<RelativeLayout, double> standDevNumberWidth = (p) => standDevNumber.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Width;
			Func<RelativeLayout, double> standDevNumberHeight = (p) => standDevNumber.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Height;

			Func<RelativeLayout, double> meanNumberWidth = (p) => mean.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Width;

			Func<RelativeLayout, double> largeTickerWidth = (p) => largeTicker.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Width;
			Func<RelativeLayout, double> largeTickerHeight = (p) => largeTicker.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Height;

			Func<RelativeLayout, double> boxViewWidth = (p) => boxView.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Width;
			Func<RelativeLayout, double> boxViewHeight = (p) => boxView.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Height;

			Func<RelativeLayout, double> basicStatsLabelWidth = (p) => basicStatsLabel.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Width;
			Func<RelativeLayout, double> basicStatsLabelHeight = (p) => basicStatsLabel.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Height;

			Func<RelativeLayout, double> maxLabelHeight = (p) => maxLabel.GetSizeRequest (relativeLayout.Width, relativeLayout.Height).Request.Height;
			#endregion

			BackgroundColor = MyColors.MidnightBlue;

			relativeLayout.Children.Add (
				largeTicker, 
				xConstraint: Constraint.RelativeToParent (p => (p.Width * 0.5 - largeTickerWidth (p) * .5)),
				yConstraint: Constraint.Constant (10),
				widthConstraint: Constraint.RelativeToParent (p => (p.Width * 0.5 - largeTickerWidth (p) * .5))
			);

			relativeLayout.Children.Add (
				boxView,
				xConstraint: Constraint.RelativeToParent (p => (p.Width * 0.5 - boxViewWidth (p) * .5)),
				yConstraint: Constraint.RelativeToParent (p => (largeTicker.Y + largeTickerHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				standDevLabel,
				xConstraint: Constraint.RelativeToParent (p => (p.Width * 0.05)),
				yConstraint: Constraint.RelativeToParent (p => (boxView.Y + boxViewHeight (p) + 10))

			);

			relativeLayout.Children.Add (
				standDevNumber,
				xConstraint: Constraint.RelativeToParent (p => (p.Width - standDevNumberWidth (p) - 15)),
				yConstraint: Constraint.RelativeToParent (p => ((boxView.Y + boxViewHeight (p)) + 10))
			);

			relativeLayout.Children.Add (
				boxView0,
				xConstraint: Constraint.RelativeToParent (p => (p.Width * 0.5 - boxViewWidth (p) * .5)),
				yConstraint: Constraint.RelativeToParent (p => (standDevNumber.Y + standDevNumberHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				basicStatsLabel,
				xConstraint: Constraint.RelativeToParent (p => (p.Width * 0.5 - basicStatsLabelWidth (p) * .5)),
				yConstraint: Constraint.RelativeToParent (p => (boxView0.Y + boxViewHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				boxView1,
				xConstraint: Constraint.RelativeToParent (p => (p.Width * 0.5 - boxViewWidth (p) * .5)),
				yConstraint: Constraint.RelativeToParent (p => (basicStatsLabel.Y + basicStatsLabelHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				meanLabel,
				xConstraint: Constraint.RelativeToParent (p => (p.Width * 0.05)),
				yConstraint: Constraint.RelativeToParent (p => (boxView1.Y + boxViewHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				mean,
				xConstraint: Constraint.RelativeToParent (p => (p.Width - meanNumberWidth(p) - 15)),
				yConstraint: Constraint.RelativeToParent (p => (boxView1.Y + boxViewHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				maxLabel,
				xConstraint: Constraint.RelativeToParent (p => (p.Width * 0.05)),
				yConstraint: Constraint.RelativeToParent (p => (meanLabel.Y + maxLabelHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				max,
				xConstraint: Constraint.RelativeToParent (p => (p.Width - meanNumberWidth(p) - 15)),
				yConstraint: Constraint.RelativeToParent (p => (meanLabel.Y + maxLabelHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				minLabel,
				xConstraint: Constraint.RelativeToParent (p => (p.Width * 0.05)),
				yConstraint: Constraint.RelativeToParent (p => (maxLabel.Y + maxLabelHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				min,
				xConstraint: Constraint.RelativeToParent (p => (p.Width - meanNumberWidth(p) - 15)),
				yConstraint: Constraint.RelativeToParent (p => (maxLabel.Y + maxLabelHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				stdLabel,
				xConstraint: Constraint.RelativeToParent (p => (p.Width * 0.05)),
				yConstraint: Constraint.RelativeToParent (p => (minLabel.Y + maxLabelHeight (p) + 10))
			);

			relativeLayout.Children.Add (
				stdDev,
				xConstraint: Constraint.RelativeToParent (p => (p.Width - meanNumberWidth(p) - 15)),
				yConstraint: Constraint.RelativeToParent (p => (minLabel.Y + maxLabelHeight (p) + 10))
			);

			Content = relativeLayout;
		}
	}
}


