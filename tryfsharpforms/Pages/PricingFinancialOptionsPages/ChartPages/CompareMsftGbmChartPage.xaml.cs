using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Syncfusion.SfBusyIndicator.XForms;
using tryfsharplib;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class CompareMsftGbmChartPage : ContentPage
	{
		IEnumerable<Tuple<DateTime,double>> data;
		IEnumerable<Tuple<DateTime,double>> data1;

		public CompareMsftGbmChartPage ()
		{
			InitializeComponent ();

			Chart.Opacity = .25;

			SfBusyIndicator busyIndicator = new SfBusyIndicator ();

			Task.Run (() => {	
				SimulatingAndAnalyzingAssetPrices.GetMsftCsvData msftData = new SimulatingAndAnalyzingAssetPrices.GetMsftCsvData ();

				Device.BeginInvokeOnMainThread (
					() => {
						//set data
						data = msftData.MsftActual;
						data1 = msftData.MsftSimulated;

						//turn of busy indicator
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;

						//set binding context
						//TODO: Nullcheck
						Chart.FadeTo (1, 500, Easing.CubicIn);
						BindingContext = new DateTimeDoubleViewModel (data, data1);
					});
			});

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
			series1.Color = MyColors.Turqoise;
			series2.Color = MyColors.Concrete;

			relativeLayout.Children.Add (busyIndicator, Constraint.Constant (App.ScreenWidth / 2), Constraint.Constant (App.ScreenHeight / 3), Constraint.Constant (10), Constraint.Constant (10));


		}
	}
}

