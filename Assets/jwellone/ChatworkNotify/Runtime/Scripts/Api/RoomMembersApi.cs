using System.Collections.Generic;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = RoomMembersApi.ResponseParameter;

	/// <summary> チャットのメンバー一覧を取得 </summary>
	public class RoomMembersApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public List<RoomMember> data;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/members"; } }
	}
}