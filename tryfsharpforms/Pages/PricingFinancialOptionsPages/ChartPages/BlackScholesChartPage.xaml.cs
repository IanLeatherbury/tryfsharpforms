using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using Syncfusion.SfBusyIndicator.XForms;
using tryfsharplib;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class BlackScholesChartPage : ContentPage
	{
		SfChart chart = new SfChart ();
		SfBusyIndicator busyIndicator = new SfBusyIndicator ();

		public BlackScholesChartPage ()
		{
			InitializeComponent ();

			Chart.Opacity = .25;

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

			BackgroundColor = MyColors.MidnightBlue;

			relativeLayout.Children.Add (busyIndicator, Constraint.Constant (App.ScreenWidth / 2), Constraint.Constant (App.ScreenHeight / 3), Constraint.Constant (10), Constraint.Constant (10));

			Task.Run (() => {	
				PricingEuropeanOptions.BlackScholes bs = new PricingEuropeanOptions.BlackScholes ();

				var x = bs.TimePriceValues;

				Device.BeginInvokeOnMainThread (
					() => {
						BindingContext = new BlackScholesViewModel (x);

						//turn off busy indicator
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;

						Chart.FadeTo (1, 500, Easing.CubicIn);
					});
			});
		}
	}
}

