namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = RoomLinkDetail;

	/// <summary> 招待リンクを取得する </summary>
	public class RoomLinkApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/link"; } }

		protected override IResponseParser GetResponseParser()
		{
			return new ResponseDataContractJsonParser();
		}
	}
}