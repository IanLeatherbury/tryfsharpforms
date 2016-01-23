using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfBusyIndicator.XForms;
using tryfsharplib;


namespace tryfsharpforms
{
	public partial class CompareMsftHistoricalVolDriftChartPage : ContentPage
	{
		IEnumerable<Tuple<DateTime, double>> actual;
		IEnumerable<Tuple<DateTime, double>> sim;

		public CompareMsftHistoricalVolDriftChartPage ()
		{
			InitializeComponent ();

			SfBusyIndicator busyIndicator = new SfBusyIndicator ();

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

			//get data
			Task.Run (() => {
				Device.BeginInvokeOnMainThread (
					() => {
						//get data
						SimulatingAndAnalyzingAssetPrices.GetMsftCsvData msftData = new SimulatingAndAnalyzingAssetPrices.GetMsftCsvData ();

						//set data
						actual = msftData.MsftActual;
						sim = msftData.MsftSimulated;

						//turn of busy indicator
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;

						//set binding context
						//TODO: Nullcheck
						Chart.FadeTo(1, 500, Easing.CubicIn);
						BindingContext = new DateTimeDoubleViewModel (actual, sim);
					});
				
			});

			//Chart settings
			BackgroundColor = MyColors.MidnightBlue;
			series1.Color = MyColors.Turqoise;
			series2.Color = MyColors.Concrete;

			relativeLayout.Children.Add (busyIndicator, Constraint.Constant (App.ScreenWidth/2), Constraint.Constant (App.ScreenHeight/3), Constraint.Constant (10), Constraint.Constant (10));
		}
	}
}