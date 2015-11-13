using System;
using HelloFSharpXamarinFormsPortable.FSharp;
using Xamarin.Forms;

namespace tryfsharpforms
{
	public class BasicCalcPage : ContentPage
	{
		Entry rateEntry = new Entry { Placeholder = "79.8" };
		Entry valueEntry = new Entry { Placeholder = "1000" };
		Button calculateButton = new Button { Text = "Calculate!" };
		Label amountLabel = new Label { HorizontalOptions = LayoutOptions.CenterAndExpand };

		public BasicCalcPage ()
		{
			Content = new StackLayout { 
				Padding = new Thickness(15),
				Children = {
					new Label { Text = "Currency Converter" },
					new Label { Text = "Rate" },
					rateEntry,
					new Label { Text = "Value" },
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


