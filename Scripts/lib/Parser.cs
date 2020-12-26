using SimpleJSON;

namespace ShipyardClient
{
	public class Parser
	{
		private string json;

		public Parser(string input)
		{
			this.json = input;
		}

		public JSONNode content()
		{
			return JSON.Parse(json);
		}
	}
}