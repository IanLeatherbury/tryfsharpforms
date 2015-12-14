using System;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public enum Borders
	{
		None,
		Thin
	}

	public class GetDataButton : Button
	{
		public GetDataButton(Borders border, double opacity = 0)
		{
			BackgroundColor = Color.Transparent;
			TextColor = Color.White;
			FontSize = 18;
			Opacity = opacity;
			FontFamily = Device.OnPlatform(
				iOS: "Segoe-UI",
				Android: "Droid Sans Mono",
				WinPhone: "Comic Sans MS"
			);

			switch(border){
			case Borders.None:
				break;
			case Borders.Thin:
				BorderRadius = 3;
				BorderColor = MyColors.Turqoise;
				BorderWidth = 1;
				break;
			}
		}
	}
}


