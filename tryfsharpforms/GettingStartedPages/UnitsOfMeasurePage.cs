using System;

using Xamarin.Forms;
using tryfsharplib;

namespace tryfsharpforms
{
	public class UnitsOfMeasurePage : ContentPage
	{
		LoginEntry rateEntryEur = new LoginEntry { Placeholder = ".91" };
		LoginEntry valueEntryUsd = new LoginEntry { Placeholder = "1000" };
		Button calculateButton = new Button { Text = "Calculate!", TextColor = MyColors.Clouds };
		Label amountLabel = new Label { HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = MyColors.Clouds };

		public UnitsOfMeasurePage ()
		{
			BackgroundColor = MyColors.MidnightBlue;

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Strongly Typed Currency Converter",
						HorizontalOptions = LayoutOptions.CenterAndExpand, 
						TextColor = MyColors.Clouds
					},
					new Label { 
						Text = "USD to EUR", 
						TextColor = MyColors.Clouds
					},
					rateEntryEur,
					valueEntryUsd,
					calculateButton,
					amountLabel
				}
			};

			calculateButton.Clicked += OnButtonClicked;
		}

		void OnButtonClicked (object sender, EventArgs e)
		{
			if ((rateEntryEur.Text != null) && (valueEntryUsd.Text != null)) {
				decimal rate = decimal.Parse (rateEntryEur.Text);
				decimal value = decimal.Parse (valueEntryUsd.Text);
				var flib = new ConvertCurrency.ConvertCurrency (rate, value);

				amountLabel.Text = "€" + flib.ConvertedCurrency.ToString ();
			} else {
				amountLabel.Text = "Be sure to enter a rate and a dollar amount!";
			}

		}
	}
}


