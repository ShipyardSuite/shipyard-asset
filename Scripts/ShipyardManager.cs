using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

using SimpleJSON;

using ShipyardSDK;

public class ShipyardManager : ShipyardSDK.SingletonPersistent<ShipyardManager>
{

	private int updateInterval = 1;
	private float nextUpdateTime = 0;

	public bool online;
	public bool connected;
	public bool loggedIn;
	public string projectTitle;
	public string projectId;
	public string token;

	public Player player;
	public List<MessageOfTheDay> messages = new List<MessageOfTheDay>();
	public List<Asset> assets = new List<Asset>();

	// Start is called before the first frame update
	void Awake()
	{
		online = Connection.OnlineState;
	}

	// Update is called once per frame
	void Update()
	{
		if (isLoggedIn)
		{
			if (Time.time >= nextUpdateTime)
			{
				//UpdatePlayer(status =>
				//{
    //                // ...
				//});

				nextUpdateTime += updateInterval;
			}
		}
	}

    public void DownloadImage(string MediaUrl, System.Action<DownloadHandlerTexture> callback)
    {
		StartCoroutine(Connection.DownloadImage(MediaUrl, (returnValue) => {
			callback(returnValue);
        }));
	}

	public void Connect(System.Action<bool> callback)
	{
        StartCoroutine(Connection.GetRequest("connect/" + token, (returnValue) =>
        {
			string successMessage = returnValue["success"];

			if (successMessage.ToLower() == "true")
			{
			    connected = true;

			    JSONNode data = returnValue["data"];

			    projectTitle = data["title"];
			    projectId = data["id"];
			}
			else
			{
			    Debug.Log("Error");
			}


			callback(connected);
        }));
    }

	public void LoginPlayer(string playerName, System.Action<bool> callback)
	{
		StartCoroutine(Connection.PostRequest("login", "{\"playerName\": \"" + playerName + "\",\"projectId\": \"" + projectId + "\"}", (returnValue) =>
        {
			string successMessage = returnValue["success"];

			if (successMessage.ToLower() == "true")
			{
				loggedIn = true;

				JSONNode data = returnValue["data"];

				player = new Player(data);
			}
			else
			{
				Debug.Log("Error");
			}


			callback(loggedIn);
		}));
	}

	//public void UpdatePlayer(System.Action<bool> callback)
	//{
	//	StartCoroutine(Connection.PostRequest("/player/update", "{\"playerId\": \"" + player.id + "\"}", (returnValue) =>
	//	{
 //           /*
	//		string successMessage = returnValue["success"];

	//		if (successMessage.ToLower() == "true")
	//		{
	//			loggedIn = true;

	//			JSONNode data = returnValue["data"];

	//			player = new Player(data);

	//		}
	//		else
	//		{
	//			Debug.Log("Error");
	//		}
 //           */

	//		callback(true);
	//	}));
	//}

	//public void GetMessageOfTheDay(System.Action<int> callback)
	//{
	//	int messagesAmount = 0;

	//	StartCoroutine(Connection.GetRequest("/project/" + token + "/messageOfTheDay", (returnValue) =>
	//	{
			

	//		//string successMessage = returnValue["success"];

	//		//if (successMessage.ToLower() == "true")
	//		//{
	//		//	JSONNode data = returnValue["data"];

	//		//	messagesAmount = data.Count;

	//		//	for(int i = 0; i < messagesAmount; i++)
 //  //             {
	//		//		//Debug.Log(returnValue["data"][i]);
	//		//		messages.Add(new MessageOfTheDay(returnValue["data"][i]));
	//		//	}
	//		//}
	//		//else
	//		//{
	//		//	Debug.Log("Error");
	//		//}

	//		callback(messagesAmount);
	//	}));
	//}

	//public void GetContent(System.Action<bool> callback)
	//{
	//	int assetAmount = 0;

	//	StartCoroutine(Connection.GetRequest("/project/" + token + "/content", (returnValue) =>
	//	{
	//		string successMessage = returnValue["success"];

	//		if (successMessage.ToLower() == "true")
	//		{
	//			JSONNode data = returnValue["data"];

	//			assetAmount = data.Count;

	//			for (int i = 0; i < assetAmount; i++)
	//			{
	//				assets.Add(new Asset(returnValue["data"][i]));
	//			}
	//		}
	//		else
	//		{
	//			Debug.Log("Error");
	//		}

	//		callback(true);
	//	}));
	//}

	public bool isConnected
	{
		get
		{
			return connected;
		}
	}

    public bool isLoggedIn
    {
        get
        {
			return loggedIn;
        }
    }

	/*
     *
     *public MessageOfTheDay MessageOfTheDay = new MessageOfTheDay();

			//MessageOfTheDay.Initialize(recievedString);
    public string projectTitle
	{
		get
		{
			if (isConnected == true)
			{
				return _projectTitle;
			}
			return "";
		}
	}

	public bool isConnected
	{
		get
		{
			if (connection == true)
			{
				string successMessage = recievedString["success"];

				if (successMessage.ToLower() == "true")
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			return false;
		}
	}*/
}
