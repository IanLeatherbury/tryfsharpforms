using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;
using Syncfusion.SfBusyIndicator.XForms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public partial class PricingEuropeanOptionsPage : BasePage
	{
		GetDataButton calcBsMsft = new GetDataButton (Borders.Thin, 1){ Text = "Calculate!" };

		Label msftBsLabel = new Label { 
			HorizontalOptions = LayoutOptions.CenterAndExpand,
			FontAttributes = FontAttributes.Bold, 
		};

		public PricingEuropeanOptionsPage ()
		{
			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Calculate Black-Scholes for Msft",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
						TextColor = MyColors.Clouds
					},
					calcBsMsft,
					msftBsLabel,
				}
			};

			calcBsMsft.Clicked += CalcBsMsft_Clicked;
		}

		void CalcBsMsft_Clicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new BlackScholesChartPage ());
		}
	}
}

