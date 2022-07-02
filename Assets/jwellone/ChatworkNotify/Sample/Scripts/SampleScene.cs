using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace jwellone.Chatwork.Sample
{
	public class SampleScene : MonoBehaviour
	{
		[SerializeField]
		private string m_apiUrl = "https://api.chatwork.com/v2";

		[SerializeField, Header("ChatworkApiトークン")]
		private string m_token;

		[SerializeField]
		private Text m_textLog = null;

		[SerializeField]
		private InputField m_inputField = null;

		private string Url => m_apiUrl;
		private readonly Hashtable m_commonHeader = new Hashtable();

		private void Awake()
		{
			m_inputField.text = m_token;
			m_commonHeader.Add("X-ChatWorkToken", m_token);
		}

		public void OnClickUpdateToken()
		{
			m_token = m_inputField.text;
			m_commonHeader.Clear();
			m_commonHeader.Add("X-ChatWorkToken", m_token);
		}

		public void OnClickGetRooms()
		{
			var api = new RoomsApi();
			api.Callback = OnResponse;
			StartCoroutine(api.Send(Url, m_commonHeader));
		}

		private void OnResponse<T>(Response<T> response) where T : class, IResponseParam
		{
			var sb = new System.Text.StringBuilder();

			sb.Append(response.IsSuccess ? "<color=green>" : "<color=red>");

			sb.Append("code : ").AppendLine(response.Code.ToString());
			sb.Append("status : ");

			if (response.IsHttpError)
			{
				sb.Append("HttpError ");
			}

			if (response.IsNetworkError)
			{
				sb.Append("NetworkError ");
			}

			if (response.IsInternalError)
			{
				sb.Append("InternalError ");
			}

			sb.AppendLine("");
			sb.Append("error : ").AppendLine(response.Error);

			if (response.IsSuccess)
			{
				sb.Append("responseParam : ").AppendLine(JsonUtility.ToJson(response.Param));
			}

			sb.Append("</color>");

			m_textLog.text = sb.ToString();
		}

#if UNITY_EDITOR
		[UnityEditor.CustomEditor(typeof(SampleScene))]
		private class CustomInspector : UnityEditor.Editor
		{
			public override void OnInspectorGUI()
			{
				if (GUILayout.Button("トークン発行"))
				{
					Application.OpenURL("https://www.chatwork.com/service/packages/chatwork/subpackages/api/token.php");
				}

				if (GUILayout.Button("APIドキュメント"))
				{
					Application.OpenURL("https://developer.chatwork.com/ja/endpoints.html");
				}

				base.OnInspectorGUI();
			}
		}
#endif
	}
}