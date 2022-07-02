using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;
using UnityEngine.Networking;

namespace jwellone.Chatwork
{
	public class ResponseDataContractJsonParser : IResponseParser
	{
		public T Parse<T> ( UnityWebRequest request ) where T : class, IResponseParam
		{
			var json =request.downloadHandler.text;
			if ( string.IsNullOrEmpty( json ) )
			{
				return null;
			}

			using ( var stream = new MemoryStream(Encoding.Unicode.GetBytes( json ) ) ) 
			{
				var serializer = new DataContractJsonSerializer( typeof(T) );
				return serializer.ReadObject( stream ) as T;
			}
		}
	}
}