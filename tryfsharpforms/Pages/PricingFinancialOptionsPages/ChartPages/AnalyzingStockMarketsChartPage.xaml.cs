using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections;
using tryfsharplib;
using Syncfusion.SfBusyIndicator.XForms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class AnalyzingStockMarketsChartPage : ContentPage
	{
		public AnalyzingStockMarketsChartPage ()
		{
			InitializeComponent ();

			SfBusyIndicator busyIndicator = new SfBusyIndicator ();

			Chart.Opacity = .25;
			//Chart settings
			BackgroundColor = MyColors.MidnightBlue;

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

			relativeLayout.Children.Add (busyIndicator, Constraint.Constant (App.ScreenWidth / 2), Constraint.Constant (App.ScreenHeight / 3), Constraint.Constant (10), Constraint.Constant (10));

			//get data
			Task.Run (() => {
				Device.BeginInvokeOnMainThread (
					() => {
						var indicators = new AnalyzingStockMarkets.GetStockMarketIndicators ();

						var cd = indicators.ChartData;
						var hd = indicators.HistoricalData;

						BindingContext = new AnalyzingStockMarketsViewModel (cd);


						var vm = new AnalyzingStockMarketsViewModel (cd);
						first.Label = vm.DataArray [0] [0].Name;
						second.Label = vm.DataArray [1] [1].Name;
						third.Label = vm.DataArray [2] [2].Name;
						fourth.Label = vm.DataArray [3] [3].Name;
						fifth.Label = vm.DataArray [4] [4].Name;
						sixth.Label = vm.DataArray [5] [5].Name;

						//turn off busy indicator
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;

						Chart.FadeTo (1, 500, Easing.CubicIn);

					});

			});


		}
	}
}

