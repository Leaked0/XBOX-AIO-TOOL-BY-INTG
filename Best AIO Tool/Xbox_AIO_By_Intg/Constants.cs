using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace Xbox_AIO_By_Intg
{
	internal class Constants
	{
		private static string _003CDate_003Ek__BackingField;

		private static string _003CAPIENCRYPTKEY_003Ek__BackingField;

		public static bool Breached = false;

		public static bool Started = false;

		public static string IV = null;

		public static string Key = null;

		public static string ApiUrl = "https://api.auth.gg/csharp/";

		public static bool Initialized = false;

		public static Random random = new Random();

		public static string Token { get; set; }

		public static string Date
		{
			[CompilerGenerated]
			get
			{
				return _003CDate_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CDate_003Ek__BackingField = value;
			}
		}

		public static string APIENCRYPTKEY
		{
			[CompilerGenerated]
			get
			{
				return _003CAPIENCRYPTKEY_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CAPIENCRYPTKEY_003Ek__BackingField = value;
			}
		}

		public static string APIENCRYPTSALT { get; set; }

		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789", length)
				select s[random.Next(s.Length)]).ToArray());
		}

		public static string HWID()
		{
			return WindowsIdentity.GetCurrent().User.Value;
		}
	}
}
