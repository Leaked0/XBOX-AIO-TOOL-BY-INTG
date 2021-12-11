using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Xbox_AIO_By_Intg.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

		public static Settings Default => defaultInstance;

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string auth
		{
			get
			{
				return (string)this["auth"];
			}
			set
			{
				this["auth"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Username
		{
			get
			{
				return (string)this["Username"];
			}
			set
			{
				this["Username"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Password
		{
			get
			{
				return (string)this["Password"];
			}
			set
			{
				this["Password"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string RemMe
		{
			get
			{
				return (string)this["RemMe"];
			}
			set
			{
				this["RemMe"] = value;
			}
		}

		public string Tok
		{
			get
			{
				return (string)this["Tok"];
			}
			set
			{
				this["Tok"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string Token
		{
			get
			{
				return (string)this["Token"];
			}
			set
			{
				this["Token"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string authxsts
		{
			get
			{
				return (string)this["authxsts"];
			}
			set
			{
				this["authxsts"] = value;
			}
		}
	}
}
