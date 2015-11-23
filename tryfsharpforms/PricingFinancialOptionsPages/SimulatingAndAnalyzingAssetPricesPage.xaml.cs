using System;
using System.Collections.Generic;
using tryfsharplib;
using System.Linq;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using Syncfusion.SfBusyIndicator.XForms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class SimulatingAndAnalyzingAssetPricesPage : ContentPage
	{
		Button generateButton = new Button{ Text = "Generate!" };
		Button compareMsftButton = new Button { Text = "Compare" };
		Button compareMsftHistoricalGbmButton = new Button { Text = "Compare" };
		StackLayout sl = new StackLayout ();
		SfBusyIndicator busyIndicator = new SfBusyIndicator ();

		public ObservableCollection<DoubleDataPoint> RandomWalkCollection { get; set; }

		public SimulatingAndAnalyzingAssetPricesPage ()
		{
			InitializeComponent ();

			busyIndicator.ViewBoxWidth = 150;
			busyIndicator.ViewBoxHeight = 150;
			busyIndicator.HeightRequest = 50;
			busyIndicator.WidthRequest = 50;
			busyIndicator.BackgroundColor = Color.White;
			busyIndicator.AnimationType = AnimationTypes.DoubleCircle;
			busyIndicator.TextColor = Color.FromHex ("#958C7B");
			busyIndicator.IsVisible = false;
			busyIndicator.IsBusy = false;

			Content = sl;
			sl.Padding = new Thickness (15);
			sl.Children.Add (new Label { 
				Text = "Generate Geometric Brownian Motion",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontAttributes = FontAttributes.Bold, 
			});
			sl.Children.Add (generateButton);
			sl.Children.Add (
				new Label { 
					Text = "Compare Msft against GBM",
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					FontAttributes = FontAttributes.Bold, 
				});
			sl.Children.Add (compareMsftButton);
			sl.Children.Add (
				new Label { 
					Text = "Use historical data for better drift/volatility",
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					FontAttributes = FontAttributes.Bold, 
				});
			sl.Children.Add (compareMsftHistoricalGbmButton);
			sl.Children.Add (busyIndicator);

			generateButton.Clicked += GenerateButton_Clicked;
			compareMsftButton.Clicked += CompareMsftButton_Clicked;
			compareMsftHistoricalGbmButton.Clicked += CompareMsftHistoricalGbmButton_Clicked;
		}

		void GenerateButton_Clicked (object sender, EventArgs e)
		{
			SimulatingAndAnalyzingAssetPrices.RandomWalk rw = new SimulatingAndAnalyzingAssetPrices.RandomWalk (10.0);

			Navigation.PushAsync (new BrownianMotionChartPage (rw.BrownianSeq, rw.BrownianSeq1, rw.BrownianSeq2));
		}

		void CompareMsftButton_Clicked (object sender, EventArgs e)
		{
//			this is not properly implemented. needs non optimized drift/vol  
//			SimulatingAndAnalyzingAssetPrices.RandomWalk rw = new SimulatingAndAnalyzingAssetPrices.RandomWalk (10.0);

			busyIndicator.IsBusy = true;
			busyIndicator.IsVisible = true;

			Task.Run (() => {	
				SimulatingAndAnalyzingAssetPrices.GetMsftCsvData msftData = new SimulatingAndAnalyzingAssetPrices.GetMsftCsvData ();
				Device.BeginInvokeOnMainThread (
					() => {
						Navigation.PushAsync (new CompareMsftGbmChartPage (msftData.MsftActual, msftData.MsftSimulated));
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;
					});
			});
		}

		void CompareMsftHistoricalGbmButton_Clicked (object sender, EventArgs e)
		{
			busyIndicator.IsBusy = true;
			busyIndicator.IsVisible = true;

			Task.Run (() => {	
				SimulatingAndAnalyzingAssetPrices.GetMsftCsvData rw = new SimulatingAndAnalyzingAssetPrices.GetMsftCsvData ();
				SimulatingAndAnalyzingAssetPrices.GetMsftCsvData msftData = new SimulatingAndAnalyzingAssetPrices.GetMsftCsvData ();

				var actual = rw.MsftActual;
				var sim = rw.MsftSimulated;

				Device.BeginInvokeOnMainThread (
					() => {
						Navigation.PushAsync (new CompareMsftHistoricalVolDriftChartPage (actual, sim));
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;
					});
			});
		}
	}
}	