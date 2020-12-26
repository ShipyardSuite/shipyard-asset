using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using SimpleJSON;

namespace ShipyardClient
{
    public class Api : MonoBehaviour
    {
        public static string apiURL = "http://localhost:3069/connection/api/";

		//GetRequest
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

		//PostRequest
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

		//PutRequest
		//DeleteRequest
	}
}
