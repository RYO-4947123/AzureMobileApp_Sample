using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace ryo_4947123_mobile.ViewModels
{
	public class TalkPageViewModel : BindableBase, INavigationAware
	{
		public TalkPageViewModel(INavigationService navigationService)
		{
		}

		// 他のページへと画面遷移しようとしている時に呼ばれる
		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		// 画面遷移してきた時に呼ばれる
		public void OnNavigatedTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("userid") && (string)parameters["userid"] != "")
				CurrentUserID = (string)parameters["userid"];
			else
				CurrentUserID = "guest";
		}

		private string currentUserID;
		public string CurrentUserID
		{
			set { this.SetProperty(ref currentUserID, value); }
			get { return currentUserID; }
		}
	}
}
