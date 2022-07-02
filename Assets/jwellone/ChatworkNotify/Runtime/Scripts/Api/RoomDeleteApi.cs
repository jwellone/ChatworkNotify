using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomDeleteApi.RequestParameter;
	using ResponseParameter = EmptyResponseParam;

	/// <summary> グループチャットを退席/削除する </summary>
	public class RoomDeleteApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class RequestParameter : IRequestParam
		{
			public eActionType action_type;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString(); } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			var request = UnityWebRequest.Delete(uri);
			request.uploadHandler = new UploadHandlerRaw(CreateSendData().data);
			return request;
		}
	}
}