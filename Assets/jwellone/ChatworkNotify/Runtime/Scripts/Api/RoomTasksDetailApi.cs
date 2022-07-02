namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = Task;

	/// <summary> タスク情報を取得 </summary>
	public class RoomTasksDetailApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		public int RoomId { get; set; }
		public int TasksId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/tasks/" + TasksId.ToString(); } }

	}
}