using System;

using Xamarin.Forms;

namespace ryo_4947123_mobile
{
	public class App : Application
	{
		public App ()
		{
			TodoItemManager.DefaultManager.UserID = "user1";

			// The root page of your application
			MainPage = new TodoList();
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

