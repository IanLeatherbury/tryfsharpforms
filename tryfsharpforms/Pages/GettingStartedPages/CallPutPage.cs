using System;

using Xamarin.Forms;
using tryfsharplib;

namespace tryfsharpforms
{
	public class CallPutPage : ContentPage
	{
		LoginEntry callValueEntry = new LoginEntry { Placeholder = "Call value. e.g. '30'", Keyboard = Keyboard.Numeric };
		LoginEntry putValueEntry = new LoginEntry { Placeholder = "Put value e.g. '70'", Keyboard = Keyboard.Numeric };

		GetDataButton calcuatePayoffButton = new GetDataButton (Borders.Thin, 1) { Text = "Calculate Call Payoff!" };

		public CallPutPage ()
		{
			BackgroundColor = MyColors.MidnightBlue;

			var stackLayout = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Compare call/put price against $100",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
						TextColor = MyColors.Clouds
					},
					new BoxView{ HeightRequest = 10, Opacity = 0 },
					callValueEntry,
					new BoxView{ HeightRequest = 10, Opacity = 0 },
					putValueEntry,
					new BoxView{ HeightRequest = 10, Opacity = 0 },
					calcuatePayoffButton,
				}
			};

			var scrollView = new ScrollView ();
			scrollView.Content = stackLayout;

			Content = scrollView;

			calcuatePayoffButton.Clicked += CalcuatePayoffButton_Clicked;
		}

		void CalcuatePayoffButton_Clicked (object sender, EventArgs e)
		{
			PricingFinancialOptions callPrice = new PricingFinancialOptions (Double.Parse (callValueEntry.Text));
			PricingFinancialOptions putPrice = new PricingFinancialOptions (Double.Parse (putValueEntry.Text));

			Navigation.PushAsync (new CalcuateCallPutPayoffChartPage (callPrice.CallPayoff, putPrice.PutPayoff));
		}
	
	}
}


