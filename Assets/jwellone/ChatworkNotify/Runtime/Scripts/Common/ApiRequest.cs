using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	public enum ResponseStatus
	{
		Success = 0x00,
		HttpError = (0x1 << 0),
		NetworkError = (0x1 << 1),
		InternalError = (0x1 << 2),
	}

	public class Response<TResponseParam> where TResponseParam : class, IResponseParam
	{
		public bool IsSuccess { get { return Status == (uint)ResponseStatus.Success; } }
		public bool IsHttpError { get { return (Status & (uint)ResponseStatus.HttpError) != 0; } }
		public bool IsNetworkError { get { return (Status & (uint)ResponseStatus.NetworkError) != 0; } }
		public bool IsInternalError { get { return (Status & (uint)ResponseStatus.InternalError) != 0; } }
		public bool IsEmptyParam { get { return Param == null; } }
		public uint Status { get; private set; }
		public long Code { get; private set; }
		public string Error { get; private set; }
		public TResponseParam Param { get; private set; }

		public Response(uint status, long code, string error, TResponseParam param)
		{
			Status = status;
			Code = code;
			Error = error;
			Param = param;
		}
	}

	[System.Serializable]
	public abstract class ApiRequest<TQueryParam, TRequestParam, TResponseParam>
		where TQueryParam : IQueryParam, new()
		where TRequestParam : IRequestParam, new()
		where TResponseParam : class, IResponseParam
	{
		private readonly static IResponseParser s_defaultResponseParse = new DefaultResponseParse();

		private bool m_isAbort = false;
		private UnityWebRequest m_request = null;

		public abstract string EndPoint { get; }
		public TQueryParam QueryParam { get; } = new TQueryParam();
		public TRequestParam RequestParam { get; } = new TRequestParam();

		public Response<TResponseParam> Response { get; private set; }

		public Action<Response<TResponseParam>> Callback { get; set; }

		public IEnumerator Send(string url, Hashtable header)
		{
			m_request = CreateRequest(CreateUri(url));

			AddHeader(header);

			if (null != header)
			{
				foreach (DictionaryEntry entry in header)
				{
					m_request.SetRequestHeader(entry.Key.ToString(), entry.Value.ToString());
				}
			}

			m_request.SendWebRequest();

			while (!m_request.isDone)
			{
				yield return null;
			}

			uint status = (uint)ResponseStatus.Success;
			if (m_request.result == UnityWebRequest.Result.ConnectionError)
			{
				status |= (uint)ResponseStatus.NetworkError;
			}

			if (m_request.result == UnityWebRequest.Result.ProtocolError)
			{
				status |= (uint)ResponseStatus.HttpError;
			}

			TResponseParam responseParam = null;
			try
			{
				responseParam = GetResponseParser().Parse<TResponseParam>(m_request);
			}
			catch (Exception ex)
			{
				Debug.LogError("[Api]Response parser failed. " + ex.ToString());
				status |= (uint)ResponseStatus.InternalError;
			}

			m_isAbort = false;

			Response = new Response<TResponseParam>(status, m_request.responseCode, m_request.error, responseParam);

			m_request.Dispose();
			m_request = null;

			OnReceived();

			Callback?.Invoke(Response);
		}

		public void Abort()
		{
			if (m_isAbort || m_request == null || m_request.isDone)
			{
				return;
			}

			m_isAbort = true;
			m_request.Abort();
		}

		protected string CreateUri(string url)
		{
			if (typeof(EmptyQueryParam) == typeof(TQueryParam))
			{
				return System.IO.Path.Combine(url, EndPoint);
			}

			var sb = new System.Text.StringBuilder();

			sb.Append(System.IO.Path.Combine(url, EndPoint));

			GetQueryString(ref sb);

			return sb.ToString();
		}

		protected virtual void AddHeader(Hashtable header)
		{
		}

		protected virtual UnityWebRequest CreateRequest(string uri)
		{
			return UnityWebRequest.Get(uri);
		}

		protected virtual void GetQueryString(ref System.Text.StringBuilder sb)
		{
			var count = 0;
			var fields = typeof(TQueryParam).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
			foreach (var field in fields)
			{
				sb.Append((++count == 1) ? "?" : "&");
				sb.Append(field.Name).Append("=").Append(field.GetValue(QueryParam).ToString());
			}
		}

		protected virtual IResponseParser GetResponseParser()
		{
			return s_defaultResponseParse;
		}

		protected virtual void OnReceived()
		{
		}

		protected WWWForm CreateSendData()
		{
			var form = new WWWForm();
			var fields = typeof(TRequestParam).GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

			foreach (var field in fields)
			{
				form.AddField(field.Name, field.GetValue(RequestParam).ToString());
			}

			return form;
		}
	}
}