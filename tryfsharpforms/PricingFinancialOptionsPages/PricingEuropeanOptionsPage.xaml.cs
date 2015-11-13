using System;
using System.Collections.Generic;
using HelloFSharpXamarinFormsPortable.FSharp;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class PricingEuropeanOptionsPage : ContentPage
	{
		Button calcBsMsft = new Button{ Text = "Calculate!" };
		Label msftBsLabel = new Label { 
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				FontAttributes = FontAttributes.Bold, 
			};

		public PricingEuropeanOptionsPage ()
		{
			InitializeComponent ();

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Calcualte Black-Scholes for Msft",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
					},
					calcBsMsft,
					msftBsLabel
				}
			};

			calcBsMsft.Clicked += CalcBsMsft_Clicked;

		}

		void CalcBsMsft_Clicked (object sender, EventArgs e)
		{
			

			PricingEuropeanOptions.BlackScholes bs = new PricingEuropeanOptions.BlackScholes ();

//			msftBsLabel.Text = bs

			var x = bs.TimePriceValues;

			Navigation.PushAsync (new BlackScholesChartPage (x));
		
		}
	}
}

