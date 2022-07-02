using System.Collections.Generic;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = IncomingRequestsApi.ResponseParameter;

	/// <summary> 自分に対するコンタクト承認依頼一覧を取得する </summary>
	public class IncomingRequestsApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public List<IncomingRequest> data;
		}

		public override string EndPoint { get { return "incoming_requests"; } }
	}
}