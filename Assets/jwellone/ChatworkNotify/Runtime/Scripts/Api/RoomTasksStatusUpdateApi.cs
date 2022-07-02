using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomTasksStatusUpdateApi.RequestParameter;
	using ResponseParameter = RoomTasksStatusUpdateApi.ResponseParameter;

	/// <summary> タスク完了状態を変更する </summary>
	public class RoomTasksStatusUpdateApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class RequestParameter : IRequestParam
		{
			public eTaskStatus body = eTaskStatus.open;
		}

		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public int task_id;
		}

		public int RoomId { get; set; }
		public int TasksId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/tasks/" + TasksId.ToString() + "/status"; } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Put(uri, CreateSendData().data);
		}
	}
}