using UnityEngine;
using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomLink;
	using ResponseParameter = RoomLinkDetail;

	/// <summary> 招待リンクを作成する </summary>
	public class RoomLinkNewCreateApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/link"; } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Post(uri, CreateSendData());
		}

		protected new WWWForm CreateSendData()
		{
			var form = new WWWForm();
			AddField(ref form, "code", RequestParam.code);
			AddField(ref form, "description", RequestParam.description);

			if (RequestParam.need_acceptance != eNeedAcceptance.none)
			{
				form.AddField("need_acceptance", RequestParam.need_acceptance == eNeedAcceptance.no ? "0" : "1");
			}

			return form;
		}
	}
}