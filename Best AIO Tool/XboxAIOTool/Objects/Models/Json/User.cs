using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace XboxAIOTool.Objects.Models.Json
{
	public class User
	{
		public class ProfileModel
		{
			[JsonProperty("profileUsers")]
			private List<Profile> Profiles
			{
				[CompilerGenerated]
				get
				{
					return _003CProfiles_003Ek__BackingField;
				}
				set
				{
					_003CProfiles_003Ek__BackingField = value;
				}
			}

			public Profile Profile
			{
				get
				{
					Profile profile = Profiles.First();
					if (profile == null)
					{
						throw new Exception("Profile was not found.");
					}
					return profile;
				}
			}
		}

		public class Profile
		{
			[JsonProperty("id")]
			public string Xuid { get; set; }
		}
	}
}
