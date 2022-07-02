using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomMessagesReadApi.RequestParameter;
	using ResponseParameter = RoomMemberMessageReadInfo;

	/// <summary> メッセージを既読にする </summary>
	public class RoomMessagesReadApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class RequestParameter : IRequestParam
		{
			public string message_id;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/messages/read"; } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Put(uri, CreateSendData().data);
		}
	}
}