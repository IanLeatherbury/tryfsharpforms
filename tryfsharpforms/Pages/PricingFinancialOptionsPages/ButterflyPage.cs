using System;

using Xamarin.Forms;
using tryfsharplib;

namespace tryfsharpforms
{
	public class ButterflyPage : ContentPage
	{
		LoginEntry butterflyLowPriceEntry = new LoginEntry { Placeholder = "Enter a low price. e.g. '20'", Keyboard = Keyboard.Numeric };
		LoginEntry butterflyHighPriceEntry = new LoginEntry { Placeholder = "Enter a high price. e.g. '80'", Keyboard = Keyboard.Numeric };
		GetDataButton calculateButterflySpreadButton = new GetDataButton (Borders.Thin, 1) { Text = "Calculate Butterfly Spread!" };

		public ButterflyPage ()
		{
			BackgroundColor = MyColors.MidnightBlue;

			var stackLayout = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Create a Butterfly Spread",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
						TextColor = MyColors.Clouds
					},					
					butterflyLowPriceEntry,
					butterflyHighPriceEntry,
					new BoxView{ HeightRequest = 10, Opacity = 0 },
					calculateButterflySpreadButton
				}
			};

			var scrollView = new ScrollView ();
			scrollView.Content = stackLayout;

			Content = scrollView;
			
			calculateButterflySpreadButton.Clicked += CalculateButterflySpreadButton_Clicked;
		}

		void CalculateButterflySpreadButton_Clicked (object sender, EventArgs e)
		{
			ButterflySpread bf = new ButterflySpread (Double.Parse (butterflyLowPriceEntry.Text), 
				Double.Parse (butterflyHighPriceEntry.Text));
			Navigation.PushAsync (new ButterflyChartPage (bf.Payoff));
		}
	}
}


