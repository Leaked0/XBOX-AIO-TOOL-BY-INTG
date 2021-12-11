using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Xbox_AIO_By_Intg
{
	internal class API
	{
		public static void Log(string username, string action)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(action))
			{
				MessageBox.Show("Missing log information!", ApplicationSettings.Name);
				Process.GetCurrentProcess().Kill();
			}
			using WebClient webClient = new WebClient();
			try
			{
				Security.Start();
				webClient.Proxy = null;
				Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
				{
					["token"] = Encryption.EncryptService(Constants.Token),
					["aid"] = Encryption.APIService(OnProgramStart.AID),
					["username"] = Encryption.APIService(username),
					["pcuser"] = Encryption.APIService(Environment.UserName),
					["session_id"] = Constants.IV,
					["api_id"] = Constants.APIENCRYPTSALT,
					["api_key"] = Constants.APIENCRYPTKEY,
					["data"] = Encryption.APIService(action),
					["session_key"] = Constants.Key,
					["secret"] = Encryption.APIService(OnProgramStart.Secret),
					["type"] = Encryption.APIService("log")
				}))).Split("|".ToCharArray());
				Security.End();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
		}

		public static bool AIO(string AIO)
		{
			if (AIOLogin(AIO))
			{
				return true;
			}
			if (AIORegister(AIO))
			{
				return true;
			}
			return false;
		}

		public static bool AIOLogin(string AIO)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(AIO))
			{
				MessageBox.Show("Missing user login information!", ApplicationSettings.Name);
				Process.GetCurrentProcess().Kill();
			}
			string[] array = new string[0];
			using WebClient webClient = new WebClient();
			try
			{
				Security.Start();
				webClient.Proxy = null;
				array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
				{
					["token"] = Encryption.EncryptService(Constants.Token),
					["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
					["aid"] = Encryption.APIService(OnProgramStart.AID),
					["session_id"] = Constants.IV,
					["api_id"] = Constants.APIENCRYPTSALT,
					["api_key"] = Constants.APIENCRYPTKEY,
					["username"] = Encryption.APIService(AIO),
					["password"] = Encryption.APIService(AIO),
					["hwid"] = Encryption.APIService(Constants.HWID()),
					["session_key"] = Constants.Key,
					["secret"] = Encryption.APIService(OnProgramStart.Secret),
					["type"] = Encryption.APIService("login")
				}))).Split("|".ToCharArray());
				if (array[0] != Constants.Token)
				{
					MessageBox.Show("Security error has been triggered!", OnProgramStart.Name);
					Process.GetCurrentProcess().Kill();
				}
				if (Security.MaliciousCheck(array[1]))
				{
					MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name);
					Process.GetCurrentProcess().Kill();
				}
				if (Constants.Breached)
				{
					MessageBox.Show("Possible malicious activity detected!", OnProgramStart.Name);
					Process.GetCurrentProcess().Kill();
				}
				switch (array[2])
				{
				case "invalid_hwid":
					MessageBox.Show("This user is binded to another computer, please contact support!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "hwid_updated":
					MessageBox.Show("New machine has been binded, re-open the application!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "time_expired":
					MessageBox.Show("Your subscription has expired!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "invalid_details":
					Security.End();
					return false;
				case "success":
				{
					Security.End();
					UserV.ID = array[3];
					UserV.Username = array[4];
					UserV.Password = array[5];
					UserV.Email = array[6];
					UserV.HWID = array[7];
					UserV.UserVariable = array[8];
					UserV.Rank = array[9];
					UserV.IP = array[10];
					UserV.Expiry = array[11];
					UserV.LastLogin = array[12];
					UserV.RegisterDate = array[13];
					string text = array[14];
					string[] array2 = text.Split('~');
					foreach (string text2 in array2)
					{
						string[] array3 = text2.Split('^');
						try
						{
							App.Variables.Add(array3[0], array3[1]);
						}
						catch
						{
						}
					}
					return true;
				}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ApplicationSettings.Name);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			return false;
		}

		public static bool AIORegister(string AIO)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(AIO))
			{
				MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name);
				Process.GetCurrentProcess().Kill();
			}
			string[] array = new string[0];
			using WebClient webClient = new WebClient();
			try
			{
				Security.Start();
				webClient.Proxy = null;
				array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
				{
					["token"] = Encryption.EncryptService(Constants.Token),
					["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
					["aid"] = Encryption.APIService(OnProgramStart.AID),
					["session_id"] = Constants.IV,
					["api_id"] = Constants.APIENCRYPTSALT,
					["api_key"] = Constants.APIENCRYPTKEY,
					["session_key"] = Constants.Key,
					["secret"] = Encryption.APIService(OnProgramStart.Secret),
					["type"] = Encryption.APIService("register"),
					["username"] = Encryption.APIService(AIO),
					["password"] = Encryption.APIService(AIO),
					["email"] = Encryption.APIService(AIO),
					["license"] = Encryption.APIService(AIO),
					["hwid"] = Encryption.APIService(Constants.HWID())
				}))).Split("|".ToCharArray());
				if (array[0] != Constants.Token)
				{
					MessageBox.Show("Security error has been triggered!", OnProgramStart.Name);
					Security.End();
					Process.GetCurrentProcess().Kill();
				}
				Security.End();
				string text = array[2];
				if (text == "success")
				{
					return true;
				}
				if (text == "error")
				{
					return false;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ApplicationSettings.Name);
				Process.GetCurrentProcess().Kill();
			}
			return false;
		}

		public static bool Login(string username, string password)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
			{
				MessageBox.Show("Missing user login information!", ApplicationSettings.Name);
				Process.GetCurrentProcess().Kill();
			}
			string[] array = new string[0];
			using WebClient webClient = new WebClient();
			try
			{
				Security.Start();
				webClient.Proxy = null;
				array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
				{
					["token"] = Encryption.EncryptService(Constants.Token),
					["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
					["aid"] = Encryption.APIService(OnProgramStart.AID),
					["session_id"] = Constants.IV,
					["api_id"] = Constants.APIENCRYPTSALT,
					["api_key"] = Constants.APIENCRYPTKEY,
					["username"] = Encryption.APIService(username),
					["password"] = Encryption.APIService(password),
					["hwid"] = Encryption.APIService(Constants.HWID()),
					["session_key"] = Constants.Key,
					["secret"] = Encryption.APIService(OnProgramStart.Secret),
					["type"] = Encryption.APIService("login")
				}))).Split("|".ToCharArray());
				if (array[0] != Constants.Token)
				{
					MessageBox.Show("Security error has been triggered!", OnProgramStart.Name);
					Process.GetCurrentProcess().Kill();
				}
				switch (array[2])
				{
				case "invalid_hwid":
					MessageBox.Show("This user is binded to another computer, please contact support!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "hwid_updated":
					MessageBox.Show("New machine has been binded, re-open the application!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "time_expired":
					MessageBox.Show("Your subscription has expired!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "invalid_details":
					MessageBox.Show("Sorry, your username/password does not match!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "success":
				{
					UserV.ID = array[3];
					UserV.Username = array[4];
					UserV.Password = array[5];
					UserV.Email = array[6];
					UserV.HWID = array[7];
					UserV.UserVariable = array[8];
					UserV.Rank = array[9];
					UserV.IP = array[10];
					UserV.Expiry = array[11];
					UserV.LastLogin = array[12];
					UserV.RegisterDate = array[13];
					string text = array[14];
					string[] array2 = text.Split('~');
					foreach (string text2 in array2)
					{
						string[] array3 = text2.Split('^');
						try
						{
							App.Variables.Add(array3[0], array3[1]);
						}
						catch
						{
						}
					}
					Security.End();
					return true;
				}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ApplicationSettings.Name);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			return false;
		}

		public static bool Register(string username, string password, string email, string license)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(license))
			{
				MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name);
				Process.GetCurrentProcess().Kill();
			}
			string[] array = new string[0];
			using WebClient webClient = new WebClient();
			try
			{
				Security.Start();
				webClient.Proxy = null;
				array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
				{
					["token"] = Encryption.EncryptService(Constants.Token),
					["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
					["aid"] = Encryption.APIService(OnProgramStart.AID),
					["session_id"] = Constants.IV,
					["api_id"] = Constants.APIENCRYPTSALT,
					["api_key"] = Constants.APIENCRYPTKEY,
					["session_key"] = Constants.Key,
					["secret"] = Encryption.APIService(OnProgramStart.Secret),
					["type"] = Encryption.APIService("register"),
					["username"] = Encryption.APIService(username),
					["password"] = Encryption.APIService(password),
					["email"] = Encryption.APIService(email),
					["license"] = Encryption.APIService(license),
					["hwid"] = Encryption.APIService(Constants.HWID())
				}))).Split("|".ToCharArray());
				if (array[0] != Constants.Token)
				{
					MessageBox.Show("Security error has been triggered!", OnProgramStart.Name);
					Security.End();
					Process.GetCurrentProcess().Kill();
				}
				switch (array[2])
				{
				case "invalid_username":
					MessageBox.Show("You entered an invalid/used username!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "email_used":
					MessageBox.Show("Email has already been used!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "invalid_license":
					MessageBox.Show("License does not exist!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "success":
					Security.End();
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ApplicationSettings.Name);
				Process.GetCurrentProcess().Kill();
			}
			return false;
		}

		public static bool ExtendSubscription(string username, string password, string license)
		{
			if (!Constants.Initialized)
			{
				MessageBox.Show("Please initialize your application first!", OnProgramStart.Name);
				Security.End();
				Process.GetCurrentProcess().Kill();
			}
			if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(license))
			{
				MessageBox.Show("Invalid registrar information!", ApplicationSettings.Name);
				Process.GetCurrentProcess().Kill();
			}
			string[] array = new string[0];
			using WebClient webClient = new WebClient();
			try
			{
				Security.Start();
				webClient.Proxy = null;
				array = Encryption.DecryptService(Encoding.Default.GetString(webClient.UploadValues(Constants.ApiUrl, new NameValueCollection
				{
					["token"] = Encryption.EncryptService(Constants.Token),
					["timestamp"] = Encryption.EncryptService(DateTime.Now.ToString()),
					["aid"] = Encryption.APIService(OnProgramStart.AID),
					["session_id"] = Constants.IV,
					["api_id"] = Constants.APIENCRYPTSALT,
					["api_key"] = Constants.APIENCRYPTKEY,
					["session_key"] = Constants.Key,
					["secret"] = Encryption.APIService(OnProgramStart.Secret),
					["type"] = Encryption.APIService("extend"),
					["username"] = Encryption.APIService(username),
					["password"] = Encryption.APIService(password),
					["license"] = Encryption.APIService(license)
				}))).Split("|".ToCharArray());
				if (array[0] != Constants.Token)
				{
					MessageBox.Show("Security error has been triggered!", OnProgramStart.Name);
					Security.End();
					Process.GetCurrentProcess().Kill();
				}
				switch (array[2])
				{
				case "invalid_details":
					MessageBox.Show("Your user details are invalid!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "invalid_token":
					MessageBox.Show("Token does not exist!", ApplicationSettings.Name);
					Security.End();
					return false;
				case "success":
					Security.End();
					return true;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ApplicationSettings.Name);
				Process.GetCurrentProcess().Kill();
			}
			return false;
		}
	}
}
