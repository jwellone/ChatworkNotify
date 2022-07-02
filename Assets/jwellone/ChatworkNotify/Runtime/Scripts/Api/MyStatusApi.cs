namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = MyStatus;

	///<summary> 自分の未読数、未読To数、未完了タスク数を返す </summary>
	public class MyStatusApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		public override string EndPoint { get { return "my/status"; } }
	}
}