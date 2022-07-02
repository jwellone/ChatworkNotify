using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomTasksNewCreateApi.RequestParameter;
	using ResponseParameter = RoomTasksNewCreateApi.ResponseParameter;

	/// <summary> チャットに新しいタスクを追加 </summary>
	public class RoomTasksNewCreateApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class RequestParameter : IRequestParam
		{
			public string body;
			public int limit = 0; // UnixTime
			public eLimitType limit_type = eLimitType.none;
			public List<int> to_ids = new List<int>();
		}

		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public List<int> task_ids;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/tasks"; } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Post(uri, CreateSendData());
		}

		protected new WWWForm CreateSendData()
		{
			var form = new WWWForm();

			form.AddField("body", RequestParam.body);

			if (RequestParam.limit > 0)
			{
				form.AddField("limit", RequestParam.limit.ToString());
			}

			form.AddField("limit_type", RequestParam.limit_type.ToString());
			form.AddField("to_ids", string.Join(",", RequestParam.to_ids));

			return form;
		}
	}
}