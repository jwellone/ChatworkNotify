using UnityEngine;
using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = NewRoomDetails;
	using ResponseParameter = RoomNewCreateApi.ResponseParameter;

	/// <summary> グループチャットを新規作成 </summary>
	public class RoomNewCreateApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public int room_id;
		}

		public override string EndPoint { get { return "rooms"; } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Post(uri, CreateSendData());
		}

		protected new WWWForm CreateSendData()
		{
			var form = new WWWForm();

			AddField(ref form, "description", RequestParam.description);
			AddField(ref form, "icon_preset", RequestParam.icon_preset);
			form.AddField("link", RequestParam.link ? "1" : "0");
			AddField(ref form, "link_code", RequestParam.link_code);
			form.AddField("link_need_acceptance", RequestParam.link_need_acceptance ? "1" : "0");
			AddField(ref form, "members_admin_ids", RequestParam.members_admin_ids);
			AddField(ref form, "members_member_ids", RequestParam.members_member_ids);
			AddField(ref form, "members_readonly_ids", RequestParam.members_readonly_ids);
			AddField(ref form, "name", RequestParam.name);

			return form;
		}
	}
}