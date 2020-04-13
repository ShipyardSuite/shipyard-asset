    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using SimpleJSON;

namespace ShipyardSDK
{
	public class Connection : MonoBehaviour
	{
		public static string apiURL = "http://localhost:3069/connection/api/";

        public static bool OnlineState()
        {
			if (Application.internetReachability == NetworkReachability.NotReachable)
			{
				return false;
			}
			else
			{
				return true;
			}
		}

		public static IEnumerator GetRequest(string path, System.Action<JSONNode> callback)
		{
			UnityWebRequest www = UnityWebRequest.Get(apiURL + path);
			yield return www.SendWebRequest();

			if (www.isNetworkError)
			{
				Debug.Log("Error While Sending: " + www.error);
			}
			else
			{
				yield return null;

				JSONNode recievedString = new Parser(www.downloadHandler.text).content();

				callback(recievedString);
			}
		}

		public static IEnumerator PostRequest(string path, string body, System.Action<JSONNode> callback)
		{
			var data = new Dictionary<string, string> { { "query", body } };

			UnityWebRequest www = UnityWebRequest.Post(apiURL + path, data);
			yield return www.SendWebRequest();

			if (www.isNetworkError || www.isHttpError)
			{
				Debug.Log(www.error);
			}
			else
			{
				yield return null;

				JSONNode recievedString = new Parser(www.downloadHandler.text).content();

				callback(recievedString);
			}
		}

        public static IEnumerator DownloadImage(string MediaUrl, System.Action<DownloadHandlerTexture> callback)
		{

			UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
			yield return request.SendWebRequest();
			if (request.isNetworkError || request.isHttpError)
				Debug.Log(request.error);
			else
				//YourRawImage.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
                callback((DownloadHandlerTexture)request.downloadHandler);
		}
	}

}