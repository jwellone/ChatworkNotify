using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomMessagesContentUpdateApi.RequestParameter;
	using ResponseParameter = RoomMessagesContentUpdateApi.ResponseParameter;

	/// <summary> チャットのメッセージを更新する </summary>
	public class RoomMessagesContentUpdateApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class RequestParameter : IRequestParam
		{
			public string body;
		}

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
			return UnityWebRequest.Put(uri, CreateSendData().data);
		}
	}
}