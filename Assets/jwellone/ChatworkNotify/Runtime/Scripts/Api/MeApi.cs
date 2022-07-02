namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = Me;

	///<summary> 自分自身の情報を取得 </summary>
	public class MeApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		public override string EndPoint { get { return "me"; } }
	}
}