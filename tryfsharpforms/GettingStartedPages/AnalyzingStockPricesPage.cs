﻿using System;
using tryfsharplib;

using Xamarin.Forms;
using Syncfusion.SfBusyIndicator.XForms;
using System.Threading.Tasks;

namespace tryfsharpforms
{
	public class AnalyzingStockPricesPage : ContentPage
	{
		SfBusyIndicator busyIndicator = new SfBusyIndicator ();
		Button getStatsButton = new Button{ Text = "Get stats!", TextColor = MyColors.Clouds };
		Entry stockEntry = new Entry{ Placeholder = "MSFT", Text = "SPY", TextColor = MyColors.Clouds, BackgroundColor = MyColors.WetAsphalt };

		public AnalyzingStockPricesPage ()
		{
			BackgroundColor = MyColors.MidnightBlue;
			busyIndicator.ViewBoxWidth = 150;
			busyIndicator.ViewBoxHeight = 150;
			busyIndicator.HeightRequest = 50;
			busyIndicator.WidthRequest = 50;
			busyIndicator.BackgroundColor = MyColors.MidnightBlue;
			busyIndicator.AnimationType = AnimationTypes.DoubleCircle;
			busyIndicator.TextColor = MyColors.Turqoise;
			busyIndicator.IsVisible = false;
			busyIndicator.IsBusy = false;

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Get basics statistics about a stock",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
						TextColor = MyColors.Clouds
					},
					stockEntry,
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
						Navigation.PushAsync (new StockStatsPage (stockEntry.Text));
						busyIndicator.IsVisible = false;
						busyIndicator.IsBusy = false;
					});
			});
		}
	}
}


