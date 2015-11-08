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
		Button calcuatePayoffButton = new Button { Text = "Calculate Call Payoff!" };
		Button calculateBottomStraddleButton = new Button { Text = "Calculate Bottom Straddle!" };


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
						FontAttributes = FontAttributes.Bold,
					},
					callValueEntry,
					new Label { 
						Text = "Enter a Put value",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold,
					},
					putValueEntry,
					calcuatePayoffButton,
					new Label { 
						Text = "Create a Bottom Straddle",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
					},
					bottomStraddleEntry,
					calculateBottomStraddleButton
				}
			};

			calcuatePayoffButton.Clicked += CalcuatePayoffButton_Clicked;
			calculateBottomStraddleButton.Clicked += CalculateBottomStraddleButton_Clicked;
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

