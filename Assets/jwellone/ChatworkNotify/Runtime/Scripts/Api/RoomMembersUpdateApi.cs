using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomMemberAuthority;
	using ResponseParameter = RoomMembersUpdateApi.ResponseParameter;

	/// <summary> チャットのメンバーを一括変更 </summary>
	public class RoomMembersUpdateApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[DataContract]
		public class ResponseParameter : IResponseParam
		{
			[DataMember(Name = "admin")]
			public List<int> admin_ids;
			[DataMember(Name = "member")]
			public List<int> member_ids;
			[DataMember(Name = "readonly")]
			public List<int> readonly_ids;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/members"; } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Put(uri, CreateSendData().data);
		}

		protected override IResponseParser GetResponseParser()
		{
			return new ResponseDataContractJsonParser();
		}

		protected new WWWForm CreateSendData()
		{
			var form = new WWWForm();
			AddField(ref form, "members_admin_ids", RequestParam.members_admin_ids);
			AddField(ref form, "members_member_ids", RequestParam.members_member_ids);
			AddField(ref form, "members_readonly_ids", RequestParam.members_readonly_ids);

			return form;
		}
	}
}