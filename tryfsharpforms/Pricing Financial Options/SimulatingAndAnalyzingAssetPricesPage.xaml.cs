using System;
using System.Collections.Generic;
using tryfsharplib;
using System.Linq;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace tryfsharpforms
{
	public partial class SimulatingAndAnalyzingAssetPricesPage : ContentPage
	{
		Button generateButton = new Button{Text = "Generate!"};

		public ObservableCollection<DoubleDataPoint> RandomWalkCollection { get; set; }

		public SimulatingAndAnalyzingAssetPricesPage ()
		{
			InitializeComponent ();

			Content = new StackLayout { 
				Padding = new Thickness (15),
				Children = {
					new Label { 
						Text = "Generate Geometric Brownian Motion",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold, 
					},
					generateButton
				}
			};

			generateButton.Clicked += GenerateButton_Clicked;
		}

		void GenerateButton_Clicked (object sender, EventArgs e)
		{
			SimulatingAndAnalyzingAssetPrices.RandomWalk rw = new SimulatingAndAnalyzingAssetPrices.RandomWalk (10.0);

			Navigation.PushAsync(new BrownianMotionChartPage(rw.BrownianSeq));
		}
	}
}

