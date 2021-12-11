using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using XboxAIOTool.Objects.Models.Json;

namespace XboxAIOTool.Objects
{
	public class Constants1
	{
		public static Random Random = new Random();

		public static readonly HttpClientHandler HttpClientHandler;

		public static HttpClient HttpClient;

		public static User.Profile Profile
		{
			[CompilerGenerated]
			get
			{
				return _003CProfile_003Ek__BackingField;
			}
			set
			{
				_003CProfile_003Ek__BackingField = value;
			}
		}

		static Constants1()
		{
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_0022: Expected O, but got Unknown
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			HttpClientHandler val = new HttpClientHandler();
			val.set_AllowAutoRedirect(false);
			val.set_PreAuthenticate(true);
			HttpClientHandler = val;
			HttpClient = new HttpClient((HttpMessageHandler)(object)HttpClientHandler, false);
		}
	}
}
