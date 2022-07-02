namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = MessageContent;

	/// <summary> メッセージ情報を取得 </summary>
	public class RoomMessageContentApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		public int RoomId { get; set; }
		public string MessageId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/messages/" + MessageId; } }
	}
}