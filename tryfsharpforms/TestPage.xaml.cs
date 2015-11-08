using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public partial class TestPage : ContentPage
	{
		public TestPage ()
		{
			InitializeComponent ();

			Content = new StackLayout { 
				Children = {
					new Label { 
						Text = "Standard Deviation of MSFT over the last 30 days",
						HorizontalOptions = LayoutOptions.CenterAndExpand,
						FontAttributes = FontAttributes.Bold
					},
					new Entry {
						Placeholder="asda"
					}
				}
			};

		}
	}
}

