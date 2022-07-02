using UnityEngine;
using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	public interface IResponseParser
	{
		T Parse<T> ( UnityWebRequest request ) where T : class, IResponseParam;
	}

	public class DefaultResponseParse : IResponseParser
	{
		public T Parse<T> ( UnityWebRequest request ) where T : class, IResponseParam
		{
			return JsonUtility.FromJson<T>( request.downloadHandler.text );
		}
	}
}