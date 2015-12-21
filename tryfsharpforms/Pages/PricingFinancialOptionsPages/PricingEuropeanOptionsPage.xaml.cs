using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;
using Syncfusion.SfBusyIndicator.XForms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class PricingEuropeanOptionsPage : ContentPage
	{
		Button calcBsMsft = new Button{ Text = "Calculate!" };
		Label msftBsLabel = new Label { 
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			FontAttributes = FontAttributes.Bold, 
		};
		SfBusyIndicator busyIndicator = new SfBusyIndicator ();

		public PricingEuropeanOptionsPage ()
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

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Calculate Black-Scholes for Msft",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
					},
					calcBsMsft,
					msftBsLabel,
					busyIndicator
				}
			};

			calcBsMsft.Clicked += CalcBsMsft_Clicked;

		}

		void CalcBsMsft_Clicked (object sender, EventArgs e)
		{
			busyIndicator.IsBusy = true;
			busyIndicator.IsVisible = true;

			Task.Run (() => {	
				PricingEuropeanOptions.BlackScholes bs = new PricingEuropeanOptions.BlackScholes ();
				var x = bs.TimePriceValues;
				Device.BeginInvokeOnMainThread (
					() => {
						Navigation.PushAsync (new BlackScholesChartPage (x));
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;
					});
			});
		}
	}
}

