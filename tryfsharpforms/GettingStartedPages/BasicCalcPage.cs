using System;
using tryfsharplib;
using Xamarin.Forms;

namespace tryfsharpforms
{
	public class BasicCalcPage : ContentPage
	{
		LoginEntry rateEntry = new LoginEntry { Placeholder = "Rate" };
		LoginEntry valueEntry = new LoginEntry { Placeholder = "Amount" };
		Button calculateButton = new Button { Text = "Calculate!", TextColor = MyColors.Clouds };
		Label amountLabel = new Label { HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = MyColors.Clouds };

		public BasicCalcPage ()
		{
			BackgroundColor = MyColors.MidnightBlue;
			Content = new StackLayout { 
				Padding = new Thickness(15),
				Children = {
					new Label { Text = "Currency Converter", TextColor = MyColors.Clouds},
					rateEntry,
					valueEntry,
					calculateButton,
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


