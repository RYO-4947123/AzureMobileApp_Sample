using System;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace ryo_4947123_mobile
{
	public class TodoItem
	{
		string id;
		string text;
		bool done;
		string userID;
		bool isSelf = false;

		[JsonProperty(PropertyName = "id")]
		public string Id
		{
			get { return id; }
			set { id = value;}
		}

		[JsonProperty(PropertyName = "text")]
		public string Text
		{
			get { return text; }
			set { text = value;}
		}

		[JsonProperty(PropertyName = "complete")]
		public bool Done
		{
			get { return done; }
			set { done = value;}
		}

		[JsonProperty(PropertyName = "userid")]
		public string UserID
		{
			get { return userID; }
			set { userID = value; }
		}

        [Version]
        public string Version { get; set; }

		// ユーザ自身の投稿かどうか
		[JsonIgnore]
		public bool IsSelf
		{
			get { return isSelf; }
			set { isSelf = value; }
		}

		// ユーザ以外からの投稿かどうか
		[JsonIgnore]
		public bool IsOther
		{
			get { return !isSelf; }
			//set { isSelf = !value; }
		}
	}
}

