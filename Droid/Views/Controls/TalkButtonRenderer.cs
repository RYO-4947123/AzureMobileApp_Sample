using System;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Xamarin.Forms.ExportRenderer(typeof(ryo_4947123_mobile.Views.Controls.TalkButton), typeof(ryo_4947123_mobile.Droid.Views.Controls.TalkButtonRenderer))]
namespace ryo_4947123_mobile.Droid.Views.Controls
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

				// マテリアルデザイン対応からデフォルトで全て大文字となってしまうので、
				// 明示的に大文字／小文字を区別するように設定する
				button.SetAllCaps(false);
			}
		}
	}
}
