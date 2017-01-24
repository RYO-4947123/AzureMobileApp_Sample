using System;
using Android.OS;
using Android.App;
using Android.Content;
using Android.Support.V4.App;
using Firebase.Messaging;

namespace ryo_4947123_mobile.Droid
{
	[Service]
	[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
	public class FirebaseMessagingServiceImpl : FirebaseMessagingService
	{

		public static Handler handler;

		// application is in the foreground, this method will fire.
		public override void OnMessageReceived(RemoteMessage message)
		{
			System.Diagnostics.Debug.WriteLine(message.GetNotification().Body);

			// 自分自身の投稿の場合は通知しない
			string fromUserID;
			message.Data.TryGetValue("from_userid", out fromUserID);
			if (fromUserID == TodoItemManager.DefaultManager.UserID)
			{
				//return; ←テストのため自分自身にも通知
			}

			showNotification(message);

			if (handler != null)
			{
				updateView();
			}
		}

		void showNotification(RemoteMessage message)
		{
			var intent = new Intent(this, typeof(MainActivity));
			intent.AddFlags(ActivityFlags.ClearTop);
			var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

			var notificationBuilder = new NotificationCompat.Builder(this)
															.SetSmallIcon(Resource.Drawable.icon)
															.SetContentTitle(message.GetNotification().Title ?? "from Firebase")
															.SetContentText(message.GetNotification().Body)
															.SetAutoCancel(true)
															.SetContentIntent(pendingIntent)
			                                                .SetColor((255 << 24) | (0 << 16) | (255 << 8) | 0)
			                                                .SetVibrate(new long[]{100,200,300,400});

			var notificationManager = NotificationManager.FromContext(this);

			notificationManager.Notify(0, notificationBuilder.Build());
		}

		void updateView()
		{
			handler.SendMessage(new Message());
		}
	}
}
