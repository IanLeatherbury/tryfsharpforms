using System;
using System.Collections.Generic;

using Xamarin.Forms;
using tryfsharplib;
using Syncfusion.SfBusyIndicator.XForms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class FittedVersusObservedChartPage : ContentPage
	{
		public FittedVersusObservedChartPage ()
		{
			InitializeComponent ();

			SfBusyIndicator busyIndicator = new SfBusyIndicator ();

			BackgroundColor = MyColors.MidnightBlue;

			Chart.Opacity = .25;

			relativeLayout.Children.Add (busyIndicator, Constraint.Constant (App.ScreenWidth / 2), Constraint.Constant (App.ScreenHeight / 3), Constraint.Constant (10), Constraint.Constant (10));

			//Busy Indicator
			busyIndicator.ViewBoxWidth = 150;
			busyIndicator.ViewBoxHeight = 150;
			busyIndicator.HeightRequest = 50;
			busyIndicator.WidthRequest = 50;
			busyIndicator.BackgroundColor = MyColors.MidnightBlue;
			busyIndicator.AnimationType = AnimationTypes.DoubleCircle;
			busyIndicator.TextColor = MyColors.Turqoise;
			busyIndicator.IsVisible = true;
			busyIndicator.IsBusy = true;
			busyIndicator.HorizontalOptions = LayoutOptions.Center;
			busyIndicator.VerticalOptions = LayoutOptions.Center;

			//get data
			Task.Run (() => {

				AnalyzingStockMarkets.GetStockMarketIndicators indicators = new AnalyzingStockMarkets.GetStockMarketIndicators ();

				var original = indicators.OriginalObservedData;
				var fitted = indicators.FittedData;

				Device.BeginInvokeOnMainThread (
					() => {
						BindingContext = new AnalyzingMarketInteractionsViewModel (original, fitted);

						//turn off busy indicator
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;

						series1.Color = MyColors.Turqoise;
						series2.Color = MyColors.Concrete;

						Chart.FadeTo (1, 500, Easing.CubicIn);
					});
			});
		}
	}
}

