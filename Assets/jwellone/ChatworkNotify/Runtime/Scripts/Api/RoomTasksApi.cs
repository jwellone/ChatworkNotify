namespace jwellone.Chatwork
{
	using QueryParameter = RoomTasksApi.QueryPrameter;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = Task;

	/// <summary> チャットのタスク一覧を取得  </summary>
	public class RoomTasksApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class QueryPrameter : IQueryParam
		{
			public int account_id = -1;
			public int assigned_by_account_id = -1;
			public eTaskStatus status = eTaskStatus.none;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/tasks"; } }

		protected override void GetQueryString(ref System.Text.StringBuilder sb)
		{
			var count = 0;

			if (QueryParam.account_id != -1)
			{
				sb.Append((++count == 1) ? "?" : "&");
				sb.Append("account_id").Append("=").Append(QueryParam.account_id.ToString());
			}

			if (QueryParam.assigned_by_account_id != -1)
			{
				sb.Append((++count == 1) ? "?" : "&");
				sb.Append("assigned_by_account_id").Append("=").Append(QueryParam.assigned_by_account_id.ToString());
			}

			if (QueryParam.status != eTaskStatus.none)
			{
				sb.Append((++count == 1) ? "?" : "&");
				sb.Append("status").Append("=").Append(QueryParam.status.ToString());
			}
		}
	}
}