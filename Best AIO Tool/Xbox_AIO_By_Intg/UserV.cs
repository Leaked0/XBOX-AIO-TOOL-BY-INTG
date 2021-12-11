using System.Runtime.CompilerServices;

namespace Xbox_AIO_By_Intg
{
	internal class UserV
	{
		private static string _003CIP_003Ek__BackingField;

		private static string _003CUserVariable_003Ek__BackingField;

		public static string ID { get; set; }

		public static string Username { get; set; }

		public static string Password { get; set; }

		public static string Email { get; set; }

		public static string HWID { get; set; }

		public static string IP
		{
			[CompilerGenerated]
			get
			{
				return _003CIP_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CIP_003Ek__BackingField = value;
			}
		}

		public static string UserVariable
		{
			[CompilerGenerated]
			get
			{
				return _003CUserVariable_003Ek__BackingField;
			}
			[CompilerGenerated]
			set
			{
				_003CUserVariable_003Ek__BackingField = value;
			}
		}

		public static string Rank { get; set; }

		public static string Expiry { get; set; }

		public static string LastLogin { get; set; }

		public static string RegisterDate { get; set; }
	}
}
