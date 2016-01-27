using System;
using System.Collections.Generic;

using Xamarin.Forms;
using tryfsharplib;
using System.Threading.Tasks;
using Syncfusion.SfBusyIndicator.XForms;

namespace tryfsharpforms
{
	public partial class KalmanRelationshipChartPage : ContentPage
	{
		public KalmanRelationshipChartPage ()
		{
			InitializeComponent ();

			SfBusyIndicator busyIndicator = new SfBusyIndicator ();

			BackgroundColor = MyColors.MidnightBlue;

			Chart.Opacity = .25;

			relativeLayout.Children.Add (busyIndicator, Constraint.Constant (App.ScreenWidth/2), Constraint.Constant (App.ScreenHeight/3), Constraint.Constant (10), Constraint.Constant (10));

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

				var indexPoints = indicators.IndexPoints;
				var lines = indicators.Lines;	
				var vm = new KalmanRelationshipViewModel (indexPoints, lines);

				Device.BeginInvokeOnMainThread (
					() => {
						BindingContext = vm;

						Market0.Label = vm.Points [0] [0].Name;
						Market1.Label = vm.Points [1] [0].Name;
						Market2.Label = vm.Points [2] [0].Name;
						Market3.Label = vm.Points [3] [0].Name;
						Market4.Label = vm.Points [4] [0].Name;
						Market5.Label = vm.Points [5] [0].Name;	

						//turn off busy indicator
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;

						Chart.FadeTo(1, 500, Easing.CubicIn);
					});
			});
		}
	}
}

