using System;
using System.Collections.Generic;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = EmptyRequestParam;
	using ResponseParameter = ContactsApi.ResponseParameter;

	///<summary> 自分のコンタクト一覧を取得 </summary>
	public class ContactsApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[Serializable]
		public class ResponseParameter : IResponseParam
		{
			public List<Contact> data;
		}

		public override string EndPoint { get { return "contacts"; } }
	}
}