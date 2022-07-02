using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	/// <summary> 自分に対するコンタクト承認依頼をキャンセルする </summary>
	public class IncomingRequestsDeleteApi : ChatworkRequest<EmptyQueryParam, EmptyRequestParam, EmptyResponseParam>
	{
		public int RequestId { get; set; }

		public override string EndPoint { get { return "incoming_requests/" + RequestId.ToString(); } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Delete(uri);
		}
	}
}