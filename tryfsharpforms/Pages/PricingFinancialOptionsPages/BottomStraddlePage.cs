using System;

using Xamarin.Forms;
using tryfsharplib;

namespace tryfsharpforms
{
	public class BottomStraddlePage : ContentPage
	{
		DataEntry bottomStraddleEntry = new DataEntry { Placeholder = "Enter a value. e.g. '30'", Keyboard = Keyboard.Numeric };
		GetDataButton calculateBottomStraddleButton = new GetDataButton (Borders.Thin, 1) { Text = "Calculate Bottom Straddle!" };
		Label nullCheckLabel = new Label {TextColor = MyColors.Clouds, HorizontalOptions = LayoutOptions.CenterAndExpand};

		public BottomStraddlePage ()
		{
			BackgroundColor = MyColors.MidnightBlue;

			var stackLayout = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Create a Bottom Straddle",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
						TextColor = MyColors.Clouds
					},
					bottomStraddleEntry,
					new BoxView{ HeightRequest = 10, Opacity = 0 },
					calculateBottomStraddleButton,
					new BoxView{ HeightRequest = 10, Opacity = 0 },	
					nullCheckLabel
				}
			};

			var scrollView = new ScrollView ();
			scrollView.Content = stackLayout;

			Content = scrollView;

			calculateBottomStraddleButton.Clicked += CalculateBottomStraddleButton_Clicked;
		}

		void CalculateBottomStraddleButton_Clicked (object sender, EventArgs e)
		{
			if (bottomStraddleEntry.Text != null) {
				BottomStraddle bs = new BottomStraddle (Double.Parse (bottomStraddleEntry.Text));
				Navigation.PushAsync (new BottomStraddleChartPage (bs.Payoff));
				nullCheckLabel.Text = null;
			} else {
				nullCheckLabel.Text = "Don't forget to enter a value!";
			}
		}
	}
}


