using System;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public class UnitsOfMeasurePage : ContentPage
	{
		Entry rateEntryEur = new Entry { Placeholder = ".91 Eur/Usd" };
		Entry valueEntryUsd = new Entry { Placeholder = "1000 Usd" };
		Button calculateButton = new Button { Text = "Calculate!" };
		Label amountLabel = new Label { HorizontalOptions = LayoutOptions.CenterAndExpand };

		public UnitsOfMeasurePage ()
		{

			Content = new StackLayout { 
				Padding = new Thickness(15),
				Children = {
					new Label { 
						Text = "Strongly Typed Currency Converter",
						HorizontalOptions = LayoutOptions.CenterAndExpand
					},
					new Label { Text = "USD to EUR" },
					rateEntryEur,
					new Label { Text = "Value" },
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
				var flib = new tryfsharplib.ConvertCurrency.ConvertCurrency (rate, value);

				amountLabel.Text = "€" + flib.ConvertedCurrency.ToString ();
			} else {
				amountLabel.Text = "Be sure to enter a rate and a dollar amount!";
			}

		}
	}
}


