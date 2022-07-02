using System.Collections.Generic;

namespace jwellone.Chatwork
{
	using QueryParameter = RoomMessagesApi.QueryParameter;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = RoomMessagesApi.ResponseParameter;

	/// <summary> メッセージ情報を取得 </summary>
	public class RoomMessagesApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class QueryParameter : IQueryParam
		{
			public int force;
		}

		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public List<MessageContent> data;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/messages"; } }
	}
}