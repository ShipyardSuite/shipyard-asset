using System;
using System.Text.RegularExpressions;
using SimpleJSON;

namespace ShipyardSDK
{
	[Serializable]
	public class MessageOfTheDay
	{
		private long currentDate;
		private long startDate;
		private long endDate;

        public string title;
		public string text;
		public string imageURL;

		public bool active;

		public MessageOfTheDay(JSONNode input)
		{
			this.title = input["title"];
			this.text = input["text"];
            if(input["image"])
            {
				this.imageURL = input["image"];
            }

			startDate = DateTimeOffset.Parse(input["date"][0]).ToUnixTimeSeconds();
			if (input["date"][1] != null)
            {
				endDate = DateTimeOffset.Parse(input["date"][1]).ToUnixTimeSeconds();
            }
			currentDate = DateTimeOffset.Now.ToUnixTimeSeconds();

            if(endDate != 0)
            {
				active = currentDate >= startDate && currentDate <= endDate;
			}
            else
            {
				active = currentDate >= startDate;
			}
		}
	}
}
