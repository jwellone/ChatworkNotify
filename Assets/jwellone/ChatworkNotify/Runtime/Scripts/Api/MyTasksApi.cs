using System.Collections.Generic;

namespace jwellone.Chatwork
{
	using QueryParameter = MyTasksApi.QueryParameter;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = MyTasksApi.ResponseParameter;

	///<summary> 自分のタスク一覧を取得する(100件まで取得可能) </summary>
	public class MyTasksApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		public class QueryParameter : IQueryParam
		{
			public int assigned_by_account_id;
			public eTaskStatus status = eTaskStatus.open;
		}

		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public List<Task> data;
		}

		public override string EndPoint { get { return "my/tasks"; } }
	}
}