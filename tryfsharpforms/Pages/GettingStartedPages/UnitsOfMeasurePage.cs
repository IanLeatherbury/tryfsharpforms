using System;

using Xamarin.Forms;

using tryfsharplib;

namespace tryfsharpforms
{
	public class UnitsOfMeasurePage : BasePage
	{
		DataEntry rateEntryEur = new DataEntry { Placeholder = ".91" };
		DataEntry valueEntryUsd = new DataEntry { Placeholder = "1000" };
		GetDataButton calculateButton = new GetDataButton (Borders.Thin, 1) {
			Text = "Calculate!",
			TextColor = MyColors.Clouds
		};
		Label amountLabel = new Label { HorizontalOptions = LayoutOptions.CenterAndExpand, TextColor = MyColors.Clouds };

		public UnitsOfMeasurePage ()
		{
			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Strongly Typed Currency Converter",
						HorizontalOptions = LayoutOptions.CenterAndExpand, 
						TextColor = MyColors.Clouds,
						FontAttributes = FontAttributes.Bold
					},
					new Label { 
						Text = "USD to EUR", 
						TextColor = MyColors.Clouds
					},
					rateEntryEur,
					valueEntryUsd,
					new BoxView{ HeightRequest = 10, Opacity = 0 },
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


