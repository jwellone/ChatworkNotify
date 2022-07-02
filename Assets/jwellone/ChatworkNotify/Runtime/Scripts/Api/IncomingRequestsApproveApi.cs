using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = Contact;

	/// <summary> 自分に対するコンタクト承認依頼を承認する </summary>
	public class IncomingRequestsApproveApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		public int RequestId { get; set; }

		public override string EndPoint { get { return "incoming_requests/" + RequestId.ToString(); } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Put(uri, CreateSendData().data);
		}
	}
}