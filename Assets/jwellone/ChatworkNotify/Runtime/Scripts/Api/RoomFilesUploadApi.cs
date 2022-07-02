using System;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text;

namespace jwellone.Chatwork
{
	using QueryParameter = EmptyQueryParam;
	using RequestParameter = RoomFilesUploadApi.RequestParameter;
	using ResponseParameter = RoomFilesUploadApi.ResponseParameter;

	public class RoomFilesUploadApi : ChatworkRequest<QueryParameter, RequestParameter, ResponseParameter>
	{
		[Serializable]
		public class RequestParameter : IRequestParam
		{
			public string fileName;
			public string contentType;
			public string message;
			public byte[] bytes;
		}

		[Serializable]
		public class ResponseParameter : IResponseParam
		{
			public int file_id;
		}

		public int RoomId { get; set; }

		public override string EndPoint { get { return "rooms/" + RoomId.ToString() + "/files"; } }

		protected override UnityWebRequest CreateRequest(string uri)
		{
			var boundary = Encoding.UTF8.GetString(UnityWebRequest.GenerateBoundary());
			var sb = new StringBuilder();
			sb.Append("--------------------------").Append(boundary).Append("\r\n");
			sb.Append("Content-Disposition: form-data; name=\"file\"; filename=\"").Append(RequestParam.fileName).Append("\"\r\n");
			sb.Append("Content-Type: ").Append(RequestParam.contentType).Append("\r\n\r\n");

			var enc = Encoding.GetEncoding("UTF-8");
			var bodyData = new List<byte>(enc.GetBytes(sb.ToString()));
			bodyData.AddRange(RequestParam.bytes);

			sb.Clear();
			sb.Append("\r\n");
			sb.Append("--------------------------").Append(boundary).Append("\r\n");
			sb.Append("Content-Disposition: form-data; name=\"message\"\r\n\r\n");
			sb.Append(RequestParam.message).Append("\r\n");
			sb.Append("--------------------------").Append(boundary).Append("--");

			bodyData.AddRange(enc.GetBytes(sb.ToString()));

			var downloadHandler = new UploadHandlerRaw(bodyData.ToArray());
			downloadHandler.contentType = string.Format("multipart/form-data; boundary=\"{0}\"", boundary);

			var request = new UnityWebRequest(uri);
			request.method = "POST";
			request.uploadHandler = downloadHandler;
			request.downloadHandler = new DownloadHandlerBuffer();

			return request;
		}
	}
}