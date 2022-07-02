using System.Collections.Generic;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = RoomsApi.ResponseParameter;

	/// <summary> 自分のチャット一覧の取得 </summary>
	public class RoomsApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public List<RoomDetails> data;
		}

		public override string EndPoint { get { return "rooms"; } }
	}
}