using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using ryo_4947123_mobile.Views;

namespace ryo_4947123_mobile
{
	public partial class App : PrismApplication
	{
		public App(IPlatformInitializer initializer = null) : base(initializer)
		{
			// Mobile Center 用のコード
			//MobileCenter.Start(services: new System.Type[] { typeof(Analytics), typeof(Crashes) });
			// クラッシュのデータ収集を有効化する
			//Crashes.Enabled = true;
		}

		// アプリのエントリーポイント
		protected override void OnInitialized()
		{
			InitializeComponent();

			NavigationService.NavigateAsync("NavigationPage/TopPage");
		}

		// コンテナに型を登録するメソッド
		protected override void RegisterTypes()
		{
			// コンテナにビューを登録
			this.Container.RegisterTypeForNavigation<NavigationPage>();
			this.Container.RegisterTypeForNavigation<TopPage>();
			this.Container.RegisterTypeForNavigation<TalkPage>();

			// コンテナにモバイルサービスクライアントを登録
			var client = new MobileServiceClient(mobileAppUri: Constants.ApplicationURL);
			this.Container.RegisterInstance<IMobileServiceClient>(client);
		}
	}
}
