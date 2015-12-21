using System;
using tryfsharplib;
using Xamarin.Forms;

namespace tryfsharpforms
{
	public class BasicCalcPage : ContentPage
	{
		LoginEntry rateEntry = new LoginEntry { Placeholder = "Rate" };
		LoginEntry valueEntry = new LoginEntry { Placeholder = "Amount" };
		GetDataButton calculateButton = new GetDataButton (Borders.Thin, 1) {
			Text = "Calculate!",
			TextColor = MyColors.Clouds
		};
		Label amountLabel = new Label { HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = MyColors.Clouds };

		public BasicCalcPage ()
		{
			BackgroundColor = MyColors.MidnightBlue;
			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { Text = "Currency Converter", TextColor = MyColors.Clouds },
					rateEntry,
					valueEntry,
					new BoxView{ HeightRequest = 10, Opacity = 0 },
					calculateButton,
					new BoxView{ HeightRequest = 10, Opacity = 0 },
					amountLabel
				}
			};

			calculateButton.Clicked += OnButtonClicked;
		}

		void OnButtonClicked (object sender, EventArgs e)
		{
			if ((rateEntry.Text != null) && (valueEntry.Text != null)) {
				decimal rate = decimal.Parse (rateEntry.Text);
				decimal value = decimal.Parse (valueEntry.Text);
				var flib = new ConvertCurrency.ConvertCurrency (rate, value);

				amountLabel.Text = flib.ConvertedCurrency.ToString ();
			} else {
				amountLabel.Text = "Be sure to enter a rate and a dollar amount!";
			}
		}
	}
}


