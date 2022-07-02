using System;
using System.Collections.Generic;

namespace jwellone.Chatwork
{
	using QueryParameter = RoomFilesApi.QueryParameter;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = RoomFilesApi.ResponseParameter;

	/// <summary> チャットのファイル一覧を取得 </summary>
	public class RoomFilesApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[Serializable]
		public class QueryParameter : IQueryParam
		{
			public int account_id = 0;
		}

		[Serializable]
		public class ResponseParameter : IResponseParam
		{
			public List<FileDetails> data;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/files"; } }

		protected override void GetQueryString(ref System.Text.StringBuilder sb)
		{
			if (QueryParam.account_id > 0)
			{
				sb.Append("?account_id=").Append(QueryParam.account_id.ToString());
			}
		}
	}
}