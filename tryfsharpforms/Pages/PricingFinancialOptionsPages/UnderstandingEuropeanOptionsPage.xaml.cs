using System;
using System.Collections.Generic;
using tryfsharplib;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace tryfsharpforms
{
	public partial class UnderstandingEuropeanOptionsPage : ContentPage
	{

		ObservableCollection<Sections> sections = new ObservableCollection<Sections> ();

		public UnderstandingEuropeanOptionsPage ()
		{
			InitializeComponent ();

			BackgroundColor = MyColors.MidnightBlue;

			Title = "Try F#!"; 

			sections.Add (new Sections{ SectionName = "Call/Put" });
			sections.Add (new Sections{ SectionName = "Bottom Straddle" });
			sections.Add (new Sections{ SectionName = "Butterfly" });

			var listView = new ListView ();
			listView.ItemTemplate = new DataTemplate (typeof(CustomCell));
			listView.BackgroundColor = MyColors.WetAsphalt;
			listView.ItemsSource = sections;
			listView.ItemSelected += OnSelection;

			Content = listView;

		}

		public class CustomCell : ViewCell
		{
			public CustomCell ()
			{
				var label = new Label ();
				label.VerticalOptions = LayoutOptions.CenterAndExpand;
				var stackLayout = new StackLayout ();
				stackLayout.Padding = new Thickness (15);

				label.SetBinding (Label.TextProperty, "SectionName");
				label.TextColor = Color.White;

				stackLayout.Children.Add (label);

				View = stackLayout;
			}
		}

		void OnSelection (object sender, SelectedItemChangedEventArgs e)
		{
			if (e.SelectedItem == null) {
				return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
			}

			Sections s = (Sections)e.SelectedItem;

			switch (s.SectionName) {
			case "Call/Put":
				Navigation.PushAsync (new CallPutPage ());
				break;
			case "Bottom Straddle":
				Navigation.PushAsync (new BottomStraddlePage ());
				break;
			case "Butterfly":
				Navigation.PushAsync (new ButterflyPage ());
				break;
			};

			((ListView)sender).SelectedItem = null; 
		}
	}
}

