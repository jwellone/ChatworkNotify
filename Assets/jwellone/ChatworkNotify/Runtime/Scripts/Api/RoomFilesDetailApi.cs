using System;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomFilesDetailApi.RequestParameter;
	using ResponseParameter = FileDetails;

	/// <summary> ファイル情報を取得 </summary>
	public class RoomFilesDetailApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[Serializable]
		public class RequestParameter : IRequestParam
		{
			public int create_download_url = 0; // 0:生成しない 1:ダウンロードする為のURLを生成する
		}

		public int RoomId { get; set; }
		public int FileId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/files/" + FileId.ToString(); } }
	}
}