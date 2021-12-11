using Newtonsoft.Json;

namespace Xbox_AIO_FTW.Objects.Models.Json
{
	public class MultiplayerSummary
	{
		[JsonProperty("InParty")]
		private int InParty { get; set; }

		public bool InParty2 => InParty > 0;

		public bool IsInParty => InParty > 0;

		[JsonProperty("InMultiplayerSession")]
		private int InMultiplayerSession { get; set; }

		public bool IsInMultiplayerSession => InMultiplayerSession > 0;
	}
}
