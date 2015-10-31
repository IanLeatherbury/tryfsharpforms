using System;
using tryfsharplib;
using Xamarin.Forms;

namespace tryfsharpforms
{
	public class BasicCalc : ContentPage
	{
//		ConvertCurrency flib = new tryfsharplib.ConvertCurrency (79.8M, 1000M);
		Entry rateEntry = new Entry { Placeholder = "79.8" };
		Entry valueEntry = new Entry { Placeholder = "1000" };
		Button calculateButton = new Button {Text = "Calculate!" };
		Label amountLabel = new Label {HorizontalOptions=LayoutOptions.CenterAndExpand};

		public BasicCalc ()
		{
			Content = new StackLayout { 
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

		void OnButtonClicked(object sender, EventArgs e)
		{
			
			decimal rate = decimal.Parse (rateEntry.Text);
			decimal value = decimal.Parse (valueEntry.Text);
			var flib = new ConvertCurrency (rate, value);

			amountLabel.Text = flib.ConvertedCurrency.ToString ();
		}
	}
}


