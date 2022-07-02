using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomMemberMessage;
	using ResponseParameter = RoomMessagesSendingApi.ResponseParameter;

	/// <summary> チャットに新しいメッセージを追加 </summary>
	public class RoomMessagesSendingApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public string message_id;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/messages"; } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Post(uri, CreateSendData());
		}
	}
}