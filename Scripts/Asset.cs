using System;
using SimpleJSON;

namespace ShipyardSDK
{
	[Serializable]
	public class Asset
	{
		private string DBID;

		public string name;
		public string id;

		public Asset(JSONNode input)
		{
			this.name = input["name"];
			this.id = input["identifier"];

            this.DBID = input["_id"];
		}

        public Asset(string id)
        {
			Asset asset = ShipyardManager.Instance.assets.Find((x) => x.id == id);

            if(asset != null)
            {
			    this.id = asset.id;
			    this.name = asset.name; 

                this.DBID = asset.DBID;
            }
		}

        public string getDBIdentifier
		{
            get { return DBID; }
        }
	}
}