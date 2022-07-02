namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = RoomDetails;

	/// <summary> チャット情報取得(名前、アイコン、種類) </summary>
	public class RoomApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString(); } }
	}
}