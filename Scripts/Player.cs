using System;
using SimpleJSON;

namespace ShipyardSDK
{
	[Serializable]
	public class Player
    {
		public string id;
		public string name;
		public int points;

		public Player(JSONNode input)
		{
			this.id = input["_id"];
			this.name = input["name"];
			this.points = input["points"] | 0;
		}
	}
}