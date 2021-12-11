using Newtonsoft.Json;

namespace Xbox_AIO_FTW.Objects.Models.Json
{
	public class Friend
	{
		private string _003CXuid2_003Ek__BackingField;

		private string _003CDisplayName_003Ek__BackingField;

		[JsonProperty("xuid")]
		public string Xuid2
		{
			get
			{
				return _003CXuid2_003Ek__BackingField;
			}
			set
			{
				_003CXuid2_003Ek__BackingField = value;
			}
		}

		[JsonProperty("displayName")]
		public string DisplayName
		{
			get
			{
				return _003CDisplayName_003Ek__BackingField;
			}
			set
			{
				_003CDisplayName_003Ek__BackingField = value;
			}
		}

		[JsonProperty("isFollowingCaller")]
		public bool IsFollowingCaller
		{
			get
			{
				return _003CIsFollowingCaller_003Ek__BackingField;
			}
			set
			{
				_003CIsFollowingCaller_003Ek__BackingField = value;
			}
		}

		[JsonProperty("presenceState")]
		private string PresenceState2 { get; set; }

		public bool IsOffline => PresenceState2.ToLower() == "offline";

		[JsonProperty("multiplayerSummary")]
		public MultiplayerSummary MultiplayerSummary { get; set; }

		public bool IsOffline2 => PresenceState2.ToLower() == "offline";
	}
}
