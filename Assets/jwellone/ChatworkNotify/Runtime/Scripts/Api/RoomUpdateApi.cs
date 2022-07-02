using UnityEngine;
using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomUpdateInfo;
	using ResponseParameter = RoomUpdateApi.ResponseParameter;

	// チャット情報更新(名前、アイコン、概要)
	public class RoomUpdateApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[System.Serializable]
		public class ResponseParameter : IResponseParam
		{
			public int room_id;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString(); } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Put(uri, CreateSendData().data);
		}

		protected new WWWForm CreateSendData()
		{
			var form = new WWWForm();
			AddField(ref form, "description", RequestParam.description);
			AddField(ref form, "icon_preset", RequestParam.icon_preset);
			AddField(ref form, "name", RequestParam.name);

			return form;
		}
	}
}