using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace ryo_4947123_mobile.ViewModels
{
	public class TopPageViewModel : BindableBase, INavigationAware
	{
		public DelegateCommand LoginCommand { get; }

		public TopPageViewModel(INavigationService navigationService)
		{

			this.LoginCommand = new DelegateCommand(
				executeMethod: async () =>
				{
					//Analytics.TrackEvent("Crash clicked", null);
					await navigationService.NavigateAsync(name: "TalkPage?userid=" + UserID);
				}
			);

			// ユーザ名の初期値を設定
			//UserID = "guest";
		}

		// 他のページへと画面遷移しようとしている時に呼ばれる
		public void OnNavigatedFrom(NavigationParameters parameters)
		{
			// :TODO とりあえずの対応。あとでちゃんと実装予定
			TodoItemManager.DefaultManager.UserID = UserID != "" ? UserID : "guest";
		}

		// 画面遷移してきた時に呼ばれる
		public void OnNavigatedTo(NavigationParameters parameters)
		{
		}

		private string userID = "";
		public string UserID
		{
			set { this.SetProperty(ref userID, value); }
			get { return userID; }
		}
	}
}
