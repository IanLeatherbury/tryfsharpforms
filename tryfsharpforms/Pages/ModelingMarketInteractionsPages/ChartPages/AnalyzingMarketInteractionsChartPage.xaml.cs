using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfBusyIndicator.XForms;
using System.Threading.Tasks;
using tryfsharplib;

namespace tryfsharpforms
{
	public partial class AnalyzingMarketInteractionsChartPage : ContentPage
	{
		public AnalyzingMarketInteractionsChartPage ()
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

				var logliks = indicators.LogLikelihood;

				Device.BeginInvokeOnMainThread (
					() => {

						BindingContext = new AnalyzingMarketInteractionsViewModel (logliks);

						//turn off busy indicator
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;

						Chart.FadeTo (1, 500, Easing.CubicIn);
					});
			});






		}
	}
}

