using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = EmptyResponseParam;

	/// <summary> 招待リンクを削除する </summary>
	public class RoomLinkDeleteApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/link"; } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Delete(uri);
		}
	}
}