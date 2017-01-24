using System;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(ryo_4947123_mobile.TalkButton), typeof(ryo_4947123_mobile.Droid.TalkButtonRenderer))]
namespace ryo_4947123_mobile.Droid
{
	public class TalkButtonRenderer : Xamarin.Forms.Platform.Android.ButtonRenderer
	{
		public TalkButtonRenderer()
		{
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
		{
			base.OnElementChanged(e);

			Android.Widget.Button button = Control as Android.Widget.Button;

			if (button != null)
			{
				button.Gravity = GravityFlags.Left;
				button.SetPadding(10, 10, 10, 10);
			}
		}
	}
}
