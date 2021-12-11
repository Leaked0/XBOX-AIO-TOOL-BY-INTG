using System;

namespace XboxAIOTool.Objects.Models
{
	public class EndPoints
	{
		private const string BaseSessionDirectoryUrl = "https://sessiondirectory.xboxlive.com";

		private const string Handles = "https://sessiondirectory.xboxlive.com/handles/query?include=relatedInfo&followed=true";

		public static Uri MyProfile()
		{
			return new Uri("https://profile.xboxlive.com/users/me/profile/settings?settings=Gamertag");
		}

		public static Uri Profile(string gamertag)
		{
			return new Uri("https://profile.xboxlive.com/users/gt(" + gamertag + ")/profile/settings");
		}

		public static Uri Profile2(string gamertag)
		{
			return new Uri("https://profile.xboxlive.com/users/gt(" + gamertag + ")/gamerpic");
		}

		public static Uri GetGame()
		{
			return new Uri("https://sessiondirectory.xboxlive.com/handles/query?include=relatedInfo&followed=true");
		}

		public static Uri GetFriends(string xuid)
		{
			return new Uri("https://peoplehub.xboxlive.com/users/xuid(" + xuid + ")/people/social/decoration/broadcast,multiplayersummary,preferredcolor,socialManager");
		}
	}
}
