using System;

using Xamarin.Forms;

namespace tryfsharpforms
{
	public class App : Application
	{
		public App ()
		{
			var lib = new tryfsharplib.ConvertCurrency (1,1);
			// The root page of your application
			MainPage = new NavigationPage(new HomePage());
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

