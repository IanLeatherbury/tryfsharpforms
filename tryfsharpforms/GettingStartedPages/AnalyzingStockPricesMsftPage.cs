using System;

using Xamarin.Forms;
using Syncfusion.SfBusyIndicator.XForms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public class AnalyzingStockPricesMsftPage : ContentPage
	{
		SfBusyIndicator busyIndicator = new SfBusyIndicator ();
		Button getStatsButton = new Button{ Text = "Get stats!" };

		public AnalyzingStockPricesMsftPage ()
		{
			busyIndicator.ViewBoxWidth = 150;
			busyIndicator.ViewBoxHeight = 150;
			busyIndicator.HeightRequest = 50;
			busyIndicator.WidthRequest = 50;
			busyIndicator.BackgroundColor = Color.White;
			busyIndicator.AnimationType = AnimationTypes.DoubleCircle;
			busyIndicator.TextColor = Color.FromHex ("#958C7B");
			busyIndicator.IsVisible = false;
			busyIndicator.IsBusy = false;

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Get basics statistics about Microsoft",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold,
					},
					getStatsButton,
					busyIndicator,
				}
			};

			getStatsButton.Clicked += GetStatsButton_Clicked;
		}

		void GetStatsButton_Clicked (object sender, EventArgs e)
		{
			busyIndicator.IsBusy = true;
			busyIndicator.IsVisible = true;

			Task.Run (() => {	
				Device.BeginInvokeOnMainThread (
					() => {
						Navigation.PushAsync (new AnalyzingStockPricesPage());
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;
					});
			});
		}
	}
}


