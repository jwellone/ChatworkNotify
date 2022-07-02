using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = RoomMessagesContentDeleteApi.ResponseParameter;

	/// <summary> メッセージを削除 </summary>
	public class RoomMessagesContentDeleteApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public string message_id;
		}

		public int RoomId { get; set; }
		public string MessageId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/messages/" + MessageId; } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			var request = UnityWebRequest.Delete(uri);
			request.downloadHandler = new DownloadHandlerBuffer();
			return request;
		}
	}
}