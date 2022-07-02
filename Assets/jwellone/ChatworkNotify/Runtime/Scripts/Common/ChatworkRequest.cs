using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	public abstract class ChatworkRequest<TQueryParam,TRequestParam,TResponseParam> : ApiRequest<TQueryParam,TRequestParam,TResponseParam>
		where TQueryParam : IQueryParam, new()
		where TRequestParam : IRequestParam, new()
		where TResponseParam : class, IResponseParam
	{
		private class ResponseParse : IResponseParser
		{
			public T Parse<T> ( UnityWebRequest request ) where T : class, IResponseParam
			{
				var json = request.downloadHandler.text;
				if ( string.IsNullOrEmpty( json ) )
				{
					return null;
				}

				if ( json.StartsWith( "[" ))
				{
					json = "{\"data\":" + json + "}";
				}

				return JsonUtility.FromJson<T>( json );
			}
		}
		private static IResponseParser s_responseParser = new ResponseParse();

		protected override IResponseParser GetResponseParser ()
		{
			return s_responseParser;
		}

		protected void AddField ( ref WWWForm form, string key, string value )
		{
			if ( !string.IsNullOrEmpty( value ) )
			{
				form.AddField( key, value );
			}
		}

		protected void AddField<T> ( ref WWWForm form, string key, IList<T> list )
		{
			if ( list.Count > 0 )
			{
				form.AddField( key, string.Join( ",", list ) );
			}
		}
	}
}