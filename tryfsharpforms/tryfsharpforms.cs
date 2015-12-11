using System;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public class App : Application
	{
		public static int ScreenWidth;
		public static int ScreenHeight;

		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage (new HomePage ()){ 
				BarBackgroundColor = MyColors.WetAsphalt,
				BarTextColor = MyColors.Clouds,

			};
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

