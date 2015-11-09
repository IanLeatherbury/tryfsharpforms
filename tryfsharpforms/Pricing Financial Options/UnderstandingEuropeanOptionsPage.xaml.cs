using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class UnderstandingEuropeanOptionsPage : ContentPage
	{
		Entry callValueEntry = new Entry { Placeholder = "30", Text = "30" };
		Entry putValueEntry = new Entry { Placeholder = "70", Text = "70" };
		Entry bottomStraddleEntry = new Entry { Placeholder = "30", Text = "30" };
		Entry butterflyLowPriceEntry = new Entry { Placeholder = "20", Text = "20" };
		Entry butterflyHighPriceEntry = new Entry { Placeholder = "80", Text = "80" };
		Button calcuatePayoffButton = new Button { Text = "Calculate Call Payoff!" };
		Button calculateBottomStraddleButton = new Button { Text = "Calculate Bottom Straddle!" };
		Button calculateButterflySpreadButton = new Button {Text = "Calculate Butterfly Spread!"};


		public UnderstandingEuropeanOptionsPage ()
		{
			InitializeComponent ();

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Compare call/put price against $100",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
					},
					new Label { 
						Text = "Enter a Call value",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
					},
					callValueEntry,
					new Label { 
						Text = "Enter a Put value",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
					},
					putValueEntry,
					calcuatePayoffButton,
					new Label { 
						Text = "Create a Bottom Straddle",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
					},
					bottomStraddleEntry,
					calculateBottomStraddleButton,
					new Label { 
						Text = "Create a Butterfly Spread",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
					},					
					new Label { 
						Text = "Enter a low price",
						HorizontalOptions = LayoutOptions.CenterAndExpand, 
					},
					butterflyLowPriceEntry,
					new Label { 
						Text = "Enter a high price",
						HorizontalOptions = LayoutOptions.CenterAndExpand, 
					},
					butterflyHighPriceEntry,
					calculateButterflySpreadButton
				}
			};

			calcuatePayoffButton.Clicked += CalcuatePayoffButton_Clicked;
			calculateBottomStraddleButton.Clicked += CalculateBottomStraddleButton_Clicked;
			calculateButterflySpreadButton.Clicked += CalculateButterflySpreadButton_Clicked;
		}

		void CalculateButterflySpreadButton_Clicked (object sender, EventArgs e)
		{
			ButterflySpread bf = new ButterflySpread (Double.Parse (butterflyLowPriceEntry.Text), 
				Double.Parse (butterflyHighPriceEntry.Text));
			Navigation.PushAsync(new ButterflyChartPage(bf.Payoff));
		}

		void CalculateBottomStraddleButton_Clicked (object sender, EventArgs e)
		{
			BottomStraddle bs = new BottomStraddle (Double.Parse (bottomStraddleEntry.Text));
			Navigation.PushAsync (new BottomStraddleChartPage (bs.Payoff));
		}

		void CalcuatePayoffButton_Clicked (object sender, EventArgs e)
		{
			PricingFinancialOptions callPrice = new PricingFinancialOptions (Double.Parse (callValueEntry.Text));
			PricingFinancialOptions putPrice = new PricingFinancialOptions (Double.Parse (putValueEntry.Text));
			
			Navigation.PushAsync (new CalcuateCallPutPayoffChartPage (callPrice.CallPayoff, putPrice.PutPayoff));
		}
	}
}

