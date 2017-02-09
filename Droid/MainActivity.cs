using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase.Messaging;
using Firebase.Iid;
using System.Threading.Tasks;
using ryo_4947123_mobile.Views;
using Xamarin.Forms;

namespace ryo_4947123_mobile.Droid
{
	[Activity (Label = "ryo_4947123_mobile.Droid",
		Icon = "@drawable/icon",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation
	    //,Theme = "@android:style/Theme.Holo.Light"
	    ,Theme = "@style/Theme.AppCompat.Light.NoActionBar"
	    )]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Initialize Azure Mobile Apps
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			// Initialize Xamarin Forms
			global::Xamarin.Forms.Forms.Init (this, bundle);

			App app = new App();

			EnableFCM(app);

			// Load the main application
			LoadApplication (app);
		}

		// FCMを有効化します
		private void EnableFCM(App app)
		{
			// 不明点
			// Debugビルドだと以下のようにDeleteInstanceId()を呼んでInstanceIdをリフレッシュしないと再起動後通知が受け取れない
			// Releaseビルドだと以下の作業は不要でSubscribeするだけでそのトピックへの通知を受け取ることができる
//#if DEBUG
			Task.Run(() =>
			{
				var instanceID = FirebaseInstanceId.Instance;
				instanceID.DeleteInstanceId();
				var iid1 = instanceID.Token;
				instanceID.GetToken(GetString(Resource.String.gcm_defaultSenderId), Firebase.Messaging.FirebaseMessaging.InstanceIdScope);
				FirebaseMessaging.Instance.SubscribeToTopic("all");
			});
			/*
#else
			Task.Run(() =>
			{
				FirebaseMessaging.Instance.SubscribeToTopic("all");
			});
#endif
			*/

			FirebaseMessagingServiceImpl.handler = new UpdateHandler(app);
		}

		private class UpdateHandler : Handler
		{
			private App app;

			public UpdateHandler(App app)
			{
				this.app = app;
			}

			public override void HandleMessage(Message msg)
			{
				var navigationPage = (NavigationPage)app.MainPage;
				if (navigationPage.CurrentPage.IsVisible)
				{
					((TalkPage)navigationPage.CurrentPage).OnSyncItems(null, null);
				}
			}
		}
	}
}

