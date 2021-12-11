using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI.WinForms;
using XanderUI;
using Xbox_AIO_By_Intg;
using Xbox_AIO_By_Intg.Classes_Avatar;
using XBOX_AIO_TOOl;

namespace Best_AIO_Tool.Forms
{
	public class Main : Form
	{
		public static string AvatarManifest = "";

		private bool Spoofing;

		private string TitleID;

		private int MouseX;

		private int Mousey;

		private bool MouseM;

		private int counter = 60;

		private IContainer components;

		private Panel panel1;

		private XUIFlatTab xuiFlatTab1;

		private TabPage tabPage1;

		private GunaLabel ToolVersionLabel;

		private GunaLabel RankLabel;

		private GunaLabel ExpiryLabel;

		private GunaLabel UserNameLabel;

		private TabPage tabPage2;

		private BunifuTextBox AuthTokenTXT;

		private GunaAdvenceButton SetPicturebtn;

		private PictureBox pictureBox1;

		private BunifuGroupBox XboxOneModdedAvatar;

		private GunaAdvenceButton CopyAvatarsManifestX1;

		private GunaAdvenceButton SetCustomManifestXboxOne;

		private GunaTextBox XboxOneCustomManifest;

		private GunaAdvenceButton SetXboxOne;

		private GunaComboBox XOneAvatarCombo;

		private BunifuGroupBox X360AvatarCustomisation;

		private GunaAdvenceButton SetCustomManifest360btn;

		private GunaTextBox Custom360Manifest;

		private GunaAdvenceButton Set360PresetSelectionbtn;

		private GunaAdvenceButton Previewbtn;

		private PictureBox X360PictureBox2;

		private GunaComboBox X360AvatarCombo;

		private BunifuGroupBox Xbox360AvatarViewer;

		private GunaAdvenceButton StealAvatarbtn;

		private GunaAdvenceButton ViewAvatarbtn;

		private GunaTextBox X360GTTXT;

		private PictureBox X360PictureBox;

		private TabPage tabPage3;

		private BunifuGroupBox CretaeClubGroupBox;

		private GunaComboBox ClubTypeComboBox;

		private GunaAdvenceButton CreateClubbtn;

		private GunaAdvenceButton ReserveClubbtn;

		private GunaTextBox ClubNameTXT;

		private Timer ClubTimer;

		private GunaLabel CounterTXT;

		private TabPage tabPage4;

		private PictureBox pictureBox2;

		private PictureBox pictureBox3;

		private PictureBox pictureBox4;

		private BunifuGroupBox ProfilePicToolsBox;

		private GunaAdvenceButton SetPictureXboxBtn;

		private GunaComboBox XboxOneComboBox;

		private BunifuGroupBox StatusSpooferGroupBox;

		private GunaAdvenceButton SpoofStatusbtn2;

		private GunaAdvenceButton SpoofStatusbtn;

		private GunaTextBox Number;

		private GunaComboBox AppsComboBox;

		private GunaComboBox GamesComboBox;

		private GunaCheckBox CheckAppsCheckBox;

		private GunaCheckBox CheckGamesCheckBox;

		private GunaAdvenceButton StopSpoofingbtn;

		private GunaCheckBox OnOffCheckBox;

		private Timer OnOffSpam;

		private BunifuButton Closebtn;

		private BunifuButton Minimizebtn;

		public Main()
		{
			InitializeComponent();
		}

		public void Alert(string msg, Notify.enmType type)
		{
			Notify notify = new Notify();
			notify.showAlert(msg, type);
		}

		private void Main_Load(object sender, EventArgs e)
		{
			((Control)(object)UserNameLabel).Text = "Welcome:  " + UserV.Username;
			((Control)(object)RankLabel).Text = "Rank:  " + UserV.Rank;
			((Control)(object)ExpiryLabel).Text = "Expiry:  " + UserV.Expiry;
			((Control)(object)ToolVersionLabel).Text = "Version:  " + ApplicationSettings.Version;
			MessageBox.Show("Welcome:  " + UserV.Username + "\nExpiry:  " + UserV.Expiry + "\nRank:  " + UserV.Rank + "\nVersion  " + ApplicationSettings.Version + "\nYour IP:  " + UserV.IP);
			Alert("Welcome   " + UserV.Username, Notify.enmType.Success);
			((Control)(object)UserNameLabel).Parent = pictureBox1;
			((Control)(object)RankLabel).Parent = pictureBox1;
			((Control)(object)ExpiryLabel).Parent = pictureBox1;
			((Control)(object)ToolVersionLabel).Parent = pictureBox1;
		}

		private void SetPicturebtn_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Choose Ur Picture";
			openFileDialog.Filter = "All ur Images (*.jpg; *.jpeg; *.png)| *.jpg; *.jpeg; *.png";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
				pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
				((Control)(object)UserNameLabel).Parent = pictureBox1;
				((Control)(object)RankLabel).Parent = pictureBox1;
				((Control)(object)ExpiryLabel).Parent = pictureBox1;
				((Control)(object)ToolVersionLabel).Parent = pictureBox1;
				pictureBox2.Image = Image.FromFile(openFileDialog.FileName);
				pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
				((Control)(object)Xbox360AvatarViewer).Parent = pictureBox2;
				((Control)(object)X360AvatarCustomisation).Parent = pictureBox2;
				((Control)(object)XboxOneModdedAvatar).Parent = pictureBox2;
				pictureBox3.Image = Image.FromFile(openFileDialog.FileName);
				pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
				pictureBox4.Image = Image.FromFile(openFileDialog.FileName);
				pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
			}
			openFileDialog.Dispose();
		}

		public string FindTextBetween(string text, string left, string right)
		{
			int num = text.IndexOf(left);
			if (num == -1)
			{
				return string.Empty;
			}
			num += left.Length;
			int num2 = text.IndexOf(right, num);
			if (num2 == -1)
			{
				return string.Empty;
			}
			return text.Substring(num, num2 - num).Trim();
		}

		private void ViewAvatarbtn_Click(object sender, EventArgs e)
		{
			try
			{
				X360PictureBox.Load("http://avatar.xboxlive.com/avatar/" + ((Control)(object)X360GTTXT).Text + "/avatar-body.png");
			}
			catch
			{
				MessageBox.Show("Invalid Gamertag", "Invalid Parameter", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void StealAvatarbtn_Click(object sender, EventArgs e)
		{
			if (UserV.Rank == "1" || UserV.Rank == "2")
			{
				HttpWebRequest httpWebRequest = WebRequest.Create("https://profile.xboxlive.com/users/gt(" + ((Control)(object)X360GTTXT).Text + ")/profile/settings") as HttpWebRequest;
				httpWebRequest.Proxy = null;
				httpWebRequest.Method = "GET";
				httpWebRequest.Headers.Add("x-xbl-contract-version", "2");
				httpWebRequest.Headers.Add("Authorization", AuthTokenTXT.get_Text());
				WebResponse response = httpWebRequest.GetResponse();
				Stream responseStream = response.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string text = streamReader.ReadToEnd();
				string text2 = FindTextBetween(text, "id", ",");
				string text3 = text2.Replace("\"", "");
				string text4 = text3.Replace(":", "");
				HttpWebRequest httpWebRequest2 = WebRequest.Create("https://avatarservices.xboxlive.com/users/xuid(" + text4 + ")/avatar/manifest") as HttpWebRequest;
				httpWebRequest2.Proxy = null;
				httpWebRequest2.Method = "GET";
				httpWebRequest2.Headers.Add("x-xbl-contract-version", "3");
				httpWebRequest2.Headers.Add("Authorization", AuthTokenTXT.get_Text());
				httpWebRequest2.Headers.Add("Accept-Charset: UTF-8");
				httpWebRequest2.Accept = "Accept: */*";
				httpWebRequest2.Accept = "Content-Type: application/json";
				WebResponse response2 = httpWebRequest2.GetResponse();
				Stream responseStream2 = response2.GetResponseStream();
				StreamReader streamReader2 = new StreamReader(responseStream2);
				string text5 = streamReader2.ReadToEnd();
				string text6 = FindTextBetween(text5, "manifest", "==");
				string text7 = text6.Replace("\"", "");
				string text8 = text7.Replace(":", "") + "==";
				string text9 = (AvatarManifest = text8.Replace("{manifest", ""));
				try
				{
					Clipboard.SetText(AvatarManifest);
					Alert("Copied Manifest", Notify.enmType.Success);
				}
				catch
				{
					Alert("Error", Notify.enmType.Error);
				}
			}
		}

		private void Previewbtn_Click(object sender, EventArgs e)
		{
			if (((ListControl)(object)X360AvatarCombo).SelectedIndex == 0)
			{
				X360PictureBox2.Load("http://avatar.xboxlive.com/avatar/b/avatar-body.png");
			}
			else if (((ListControl)(object)X360AvatarCombo).SelectedIndex == 1)
			{
				X360PictureBox2.Load("http://avatar.xboxlive.com/avatar/Coding/avatar-body.png");
			}
			else if (((ListControl)(object)X360AvatarCombo).SelectedIndex == 2)
			{
				X360PictureBox2.Load("http://avatar.xboxlive.com/avatar/MajorNelson/avatar-body.png");
			}
		}

		private async void Set360PresetSelectionbtn_Click(object sender, EventArgs e)
		{
			if (!(UserV.Rank == "1") && !(UserV.Rank == "2"))
			{
				return;
			}
			HttpWebRequest httpWebRequest = WebRequest.Create("https://profile.xboxlive.com/users/me/id") as HttpWebRequest;
			httpWebRequest.Proxy = null;
			httpWebRequest.Method = "GET";
			httpWebRequest.Headers.Add("x-xbl-contract-version", "2");
			httpWebRequest.Headers.Add("Authorization", AuthTokenTXT.get_Text());
			WebResponse response = httpWebRequest.GetResponse();
			Stream responseStream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream);
			string text = streamReader.ReadToEnd();
			string text2 = FindTextBetween(text, "id", ",");
			string text3 = text2.Replace("\"", "");
			string text4 = text3.Replace(":", "");
			try
			{
				if (((ListControl)(object)X360AvatarCombo).SelectedIndex != 0)
				{
					if (((ListControl)(object)X360AvatarCombo).SelectedIndex != 1)
					{
						if (((ListControl)(object)X360AvatarCombo).SelectedIndex == 2)
						{
							await AvatarClass.PutAsync("https://avatarservices.xboxlive.com/users/xuid(" + text4 + ")/avatar/manifest", "{\"manifest\":\"AAAAAAAAAAA/gAAAABAAAAMcAAPByPEJoZyy4AAIAAADLAADwcjxCaGcsuAAIAAAAzYAA8HI8QmhnLLgAACAAAL6AAPByPEJoZyy4AAAAAAAAAAAAAAAAAAAAAAAACAAAroAA8HI8QmhnLLgAAAAAAAAAAAAAAAAAAAAAAAAQAACagADwcjxCaGcsuAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACAAADFQADwcjxCaGcsuAAAAAAAAAAAAAAAAAAAAAA/9eqcf9PRj3/tWFX/ypypP9JNCH/YXAf/2gmGP/PWWn/z1lpAAAAAgAAAAHByPEJoZyy4AACAAAAAAAAAAAAAAAAAAAAAAABAAIAA8HI8QmhnLLgAAEAAAAAAAAAAAAAAAAAAAAAEADpXjJDycthA1BTB9EQAAAA////////////////AAAHfKVAcpHLOEjJWFgIWwd8AAD//wAA/wD/AP8AAP8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIGM6YqHOvZjORE0H0QAgAAD/AAAA/wAAAP8AAAAAAAAQAKEAAcHI8QmhnLLgABAAAAAAAAAFyNvwAAACSQAAAAi6RsJBzxeZkVhYCBwACAAA//8AAP8A/wD/AAD/AAAABAHMAAPByPEJoZyy4AAEAAAAAAAAAAAAAAAAAAAAAAAAADH97u7uLgkAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==\"}", AuthTokenTXT.get_Text());
						}
					}
					else
					{
						await AvatarClass.PutAsync("https://avatarservices.xboxlive.com/users/xuid(" + text4 + ")/avatar/manifest", "{\"manifest\":\"AAAAAL8AAAA/gAAAABAAAAMfAAPByPEJoZyy4AAIAAADMgADwcjxCaGcsuAAIAAAAzsAA8HI8QmhnLLgAACAAALoAAPByPEJoZyy4AAAAAAAAAAAAAAAAAAAAAAAACAAAowAA8HI8QmhnLLgAAAAAAAAAAAAAAAAAAAAAAAAQAACbgADwcjxCaGcsuAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/gAAAAAAAAAAAAAAAAAAA//jbuf+YgFT/rS0t/66YQ/+YgFT/91qH/w0NDf/XX0f/119HAAAAAgAAAAHByPEJoZyy4AACAAAAAAAAAAAAAAAAAAAAAAABAAIAA8HI8QmhnLLgAAEAAAAAAAAAAAAAAAAAAAAAAnj+BcKxynmb41hYCIICeAAAAAAAAAAAAAAAAAAAAAAABAJTAAPByPEJoZyy4AAEAAAAAAAAAAAAAAAAAAAAAAiASB+iUcmR0plTUQgECIAAAAAAAAAAAAAAAAAAAAAAEAD7kSJTxHVRO1hYCBwQAAAAAAAAAAAAAAAAAAAAAAABAADBAAHByPEJoZyy4AEAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAuAAHByPEJoZyy4AAgAAAAAAAAAAAAAAAAAAAAAAAQAKMAAcHI8QmhnLLgABAAAAAAAAAAAAAAAAAAAAAAAAgAVgABwcjxCaGcsuAACAAAAAAAAAAAAAAAAAAAAAAABAJTAAPByPEJoZyy4AAEAAAAAAAAAAAAAAAAAADq0coRHqnVoQAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==\"}", AuthTokenTXT.get_Text());
					}
				}
				else
				{
					await AvatarClass.PutAsync("https://avatarservices.xboxlive.com/users/xuid(" + text4 + ")/avatar/manifest", "{\"manifest\":\"AAAAAL8AAAC/gAAAABAAAAMeAAPByPEJoZyy4AAIAAADNAADwcjxCaGcsuAAIAAAAzsAA8HI8QmhnLLgAACAAALuAAPByPEJoZyy4AAAAAAAAAAAAAAAAAAAAAAAACAAAsYAA8HI8QmhnLLgAAAAAAAAAAAAAAAAAAAAAAAAQAACbQADwcjxCaGcsuAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABAAAAscAA8HI8QmhnLLgAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA/9N5Pf9PRj3/5YmV/zEhFP9PRj3/wIlQ/09GPf+BJx//gScfAAAAAgAAAAHByPEJoZyy4AACAAAAAAAAAAAAAAAAAAAAAAABAAIAA8HI8QmhnLLgAAEAAAAAAAAAAAAAAAAAAAAAEABYV3JTyCTw8EFWCEQQAAAAAAAAAAAAAAAAAAAAAAAP/CpJohHLSLQDRE0H/w/8AAD//wAA/wD/AP8AAP8AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAIAAuAAHByPEJoZyy4AAgAAAAAAAAAAAAAAAAAAAAAAAQAJAAAcHI8QmhnLLgABAAAAAAAAAAAAAAAAAAAAAAAAgASAABwcjxCaGcsuAACAAA/9cpCf/XKQn/1ykJAAAABAJdAAPByPEJoZyy4AAEAAAAAAAAAAAAAAAAAADgAAdAWjYxGAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==\"} ", AuthTokenTXT.get_Text());
				}
				Alert("Avatar Successfully Set \nSuccess", Notify.enmType.Success);
			}
			catch
			{
				Alert("Error", Notify.enmType.Error);
			}
		}

		private async void SetCustomManifest360btn_Click(object sender, EventArgs e)
		{
			if (UserV.Rank == "1" || UserV.Rank == "2")
			{
				HttpWebRequest httpWebRequest = WebRequest.Create("https://profile.xboxlive.com/users/me/id") as HttpWebRequest;
				httpWebRequest.Proxy = null;
				httpWebRequest.Method = "GET";
				httpWebRequest.Headers.Add("x-xbl-contract-version", "2");
				httpWebRequest.Headers.Add("Authorization", AuthTokenTXT.get_Text());
				WebResponse response = httpWebRequest.GetResponse();
				Stream responseStream = response.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string text = streamReader.ReadToEnd();
				string text2 = FindTextBetween(text, "id", ",");
				string text3 = text2.Replace("\"", "");
				string text4 = text3.Replace(":", "");
				try
				{
					string body = "{\"manifest\":\"" + ((Control)(object)Custom360Manifest).Text + "\"}";
					await AvatarClass.PutAsync("https://avatarservices.xboxlive.com/users/xuid(" + text4 + ")/avatar/manifest", body, AuthTokenTXT.get_Text());
					Alert("Avatar Successfully Set", Notify.enmType.Success);
				}
				catch
				{
					Alert("Error", Notify.enmType.Error);
				}
			}
		}

		private async void SetXboxOne_Click(object sender, EventArgs e)
		{
			if (!(UserV.Rank == "1") && !(UserV.Rank == "2"))
			{
				return;
			}
			HttpWebRequest httpWebRequest = WebRequest.Create("https://profile.xboxlive.com/users/me/id") as HttpWebRequest;
			httpWebRequest.Proxy = null;
			httpWebRequest.Method = "GET";
			httpWebRequest.Headers.Add("x-xbl-contract-version", "2");
			httpWebRequest.Headers.Add("Authorization", AuthTokenTXT.get_Text());
			WebResponse response = httpWebRequest.GetResponse();
			Stream responseStream = response.GetResponseStream();
			StreamReader streamReader = new StreamReader(responseStream);
			string text = streamReader.ReadToEnd();
			string text2 = FindTextBetween(text, "id", ",");
			string text3 = text2.Replace("\"", "");
			string text4 = text3.Replace(":", "");
			try
			{
				if (((ListControl)(object)XOneAvatarCombo).SelectedIndex == 0)
				{
					await AvatarClass.PutAsync("https://avatarv3.xboxlive.com/users/xuid(" + text4 + ")/manifest", "<?xml version=\"1.0\" encoding=\"utf - 16\"?><Manifest Version=\"0.18\" Gender=\"Male\" Height=\"5.69\"><SkinColor Slot=\"0\" H=\"0.0697\" S=\"0.6417\" L=\"0.8684\" /><OuterIrisColor Slot=\"0\" H =\"0.0000\" S =\"1.0000\" L =\"0.0000\" /><Items><Item Id=\"115000\" Slot =\"Top\" ><Colors><Color Slot=\"0\" H =\"0.0000\" S =\"0.0000\" L =\"0.1019\" /><Color Slot=\"1\" H =\"0.0000\" S =\"0.0000\" L =\"0.7921\" /></Colors></Item><Item Id=\"107200\" Slot =\"Bottom\" ><Colors><Color Slot=\"0\" H =\"0.0000\" S =\"1.0000\" L = \"0.0000\" /><Color Slot=\"1\" H =\"0.0000\" S =\"1.0000\" L =\"0.0000\" /></Colors></Item><Item Id=\"138700\" Slot =\"Shoes\" ><Colors><Color Slot=\"0\" H =\"0.0708\" S =\"0.0899\" L =\"0.1870\" /><Color Slot=\"1\" H =\"0.0000\" S =\"0.0000\" L =\"0.0274\" /><Color Slot=\"2\" H =\"0.0453\" S =\"0.3895\" L =\"0.1467\" /></Colors></Item><Item Id=\"105500\" Slot =\"Hair\" ><Colors><Color Slot=\"0\" H =\"0.0000\" S =\"1.0000\" L=\"0.0000\" /><Color Slot=\"1\" H =\"0.0000\" S =\"1.0000\" L =\"0.0000\" /></Colors></Item><Item Id=\"100500\" Slot =\"Eyebrows\" ><Colors><Color Slot=\"0\" H =\"0.0000\" S =\"1.0000\" L =\"0.0000\" /></Colors></Item><Item Id=\"159800\" Slot =\"Eyelashes\" ><Colors><Color Slot=\"0\" H =\"0.0000\" S =\"0.3917\" L =\"0.0281\" /></Colors></Item><Item Id=\"110200\" Slot =\"Mount\" ><Colors><Color Slot=\"0\" H =\"0.6666\" S =\"0.0461\" L =\"0.1274\" /><Color Slot=\"1\" H =\"0.0243\" S =\"0.3398\" L =\"0.5782\" /><Color Slot=\"2\" H =\"0.4972\" S =\"0.5940\" L =\"0.3960\" /><Color Slot=\"3\" H =\"0.5807\" S =\"0.7903\" L =\"0.5137\" /></Colors></Item><Item Id=\"121400\" Slot =\"FingerRings\" ><Colors><Color Slot=\"0\" H =\"0.0000\" S =\"1.0000\" L =\"0.0000\" /></Colors></Item><Item Id=\"122700\" Slot =\"FacialHair\" ><Colors><Color Slot=\"0\" H =\"0.0000\" S =\"0.0000\" L =\"0.8014\" /></Colors></Item></Items><Textures /><Features><Feature Slot=\"BodyShape\" Id =\"000100\" /><Feature Slot=\"Jaw\" Id=\"957800\" /><Feature Slot=\"Ears\" Id=\"962300\" /><Feature Slot=\"Eyes\" Id = \"956600\" /></Features></Manifest>", AuthTokenTXT.get_Text(), "1");
					Alert("Avatar Successfully Set", Notify.enmType.Success);
				}
			}
			catch
			{
				Alert("Error", Notify.enmType.Error);
			}
		}

		private async void SetCustomManifestXboxOne_Click(object sender, EventArgs e)
		{
			if (UserV.Rank == "1" || UserV.Rank == "2")
			{
				HttpWebRequest httpWebRequest = WebRequest.Create("https://profile.xboxlive.com/users/me/id") as HttpWebRequest;
				httpWebRequest.Proxy = null;
				httpWebRequest.Method = "GET";
				httpWebRequest.Headers.Add("x-xbl-contract-version", "2");
				httpWebRequest.Headers.Add("Authorization", AuthTokenTXT.get_Text());
				WebResponse response = httpWebRequest.GetResponse();
				Stream responseStream = response.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string text = streamReader.ReadToEnd();
				string text2 = FindTextBetween(text, "id", ",");
				string text3 = text2.Replace("\"", "");
				string text4 = text3.Replace(":", "");
				try
				{
					string body = ((Control)(object)XboxOneCustomManifest).Text;
					await AvatarClass.PutAsync("https://avatarservices.xboxlive.com/users/xuid(" + text4 + ")/avatar/manifest", body, AuthTokenTXT.get_Text(), "1");
					Alert("Avatar Successfully Set", Notify.enmType.Success);
				}
				catch
				{
					Alert("Error", Notify.enmType.Error);
				}
			}
		}

		private void CopyAvatarsManifestX1_Click(object sender, EventArgs e)
		{
			if (UserV.Rank == "1" || UserV.Rank == "2")
			{
				HttpWebRequest httpWebRequest = WebRequest.Create("https://profile.xboxlive.com/users/me/id") as HttpWebRequest;
				httpWebRequest.Proxy = null;
				httpWebRequest.Method = "GET";
				httpWebRequest.Headers.Add("x-xbl-contract-version", "2");
				httpWebRequest.Headers.Add("Authorization", AuthTokenTXT.get_Text());
				WebResponse response = httpWebRequest.GetResponse();
				Stream responseStream = response.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string text = streamReader.ReadToEnd();
				string text2 = FindTextBetween(text, "id", ",");
				string text3 = text2.Replace("\"", "");
				string text4 = text3.Replace(":", "");
				HttpWebRequest httpWebRequest2 = WebRequest.Create("https://avatarv3.xboxlive.com/users/xuid(" + text4 + ")/manifest") as HttpWebRequest;
				httpWebRequest2.Proxy = null;
				httpWebRequest2.Method = "GET";
				httpWebRequest2.Headers.Add("x-xbl-contract-version", "1");
				httpWebRequest2.Headers.Add("Authorization", AuthTokenTXT.get_Text());
				httpWebRequest2.Accept = "Accept-Charset, UTF-8";
				httpWebRequest2.Accept = "Accept, */*";
				httpWebRequest2.Accept = "application/json";
				WebResponse response2 = httpWebRequest2.GetResponse();
				Stream responseStream2 = response2.GetResponseStream();
				StreamReader streamReader2 = new StreamReader(responseStream2);
				string text5 = streamReader2.ReadToEnd();
				string text6 = FindTextBetween(text5, "<", "</Manifest>");
				try
				{
					Clipboard.SetText("<" + text6 + "</Manifest>");
					Alert("copied Manifest", Notify.enmType.Success);
				}
				catch
				{
					Alert("Error", Notify.enmType.Error);
				}
			}
		}

		private void ClubTimer_Tick(object sender, EventArgs e)
		{
			counter--;
			if (counter == 0)
			{
				ClubTimer.Stop();
				((Control)(object)CounterTXT).Text = "Counter  " + counter;
			}
		}

		private async void ReserveClubbtn_Click(object sender, EventArgs e)
		{
			int num = 60;
			ClubTimer = new Timer();
			ClubTimer.Tick += ClubTimer_Tick;
			ClubTimer.Interval = 60000;
			ClubTimer.Start();
			((Control)(object)CounterTXT).Text = "Counter  " + num;
			if (!(UserV.Rank == "1") && !(UserV.Rank == "2"))
			{
				return;
			}
			try
			{
				string text = "{\"name\":\"" + ((Control)(object)ClubNameTXT).Text + "\"}";
				int length = text.Length;
				HttpWebRequest httpWebRequest = WebRequest.Create("https://clubaccounts.xboxlive.com/clubs/reserve") as HttpWebRequest;
				httpWebRequest.Proxy = null;
				httpWebRequest.Method = "POST";
				httpWebRequest.Headers.Add("x-xbl-contract-version", "1");
				httpWebRequest.Headers.Add("Authorization", AuthTokenTXT.get_Text());
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.Headers.Add("x-xbl-contentrestrictions", "AAAAAQHWz5NlGHSiGhEEoMhfRFSXomRyncvTZ/dwjSwRdWj5PAYDZ3aYuXCFbMii5hU0gjdfTSj67IjB0AbaxFBUgBg48qk9Z7hHIQ==");
				httpWebRequest.Headers.Add("Accept-Language", "en-AU");
				httpWebRequest.ContentType = "application/json; charset=UTF-8";
				httpWebRequest.Headers.Add("Signature", "AAAAAQHW2C1LIpyKxv5Df959zyagl/3inukMcNNILMqAu96hAxSv8a45RMv/Fk4qqr0L5nqrbR6nHQpPctxDwIgi1zbOycK/uoUtpw==");
				httpWebRequest.Headers.Add("Cache-Control", "no-cache");
				httpWebRequest.ContentLength = length;
				using StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
				string value = text;
				streamWriter.Write(value);
				streamWriter.Flush();
			}
			catch (Exception)
			{
				Alert("Error", Notify.enmType.Error);
			}
		}

		private void CreateClubbtn_Click(object sender, EventArgs e)
		{
			if (!(UserV.Rank == "1") && !(UserV.Rank == "2"))
			{
				return;
			}
			try
			{
				string text = "{\"type\":\"" + ((Control)(object)ClubTypeComboBox).Text + "\",\"name\":\"" + ((Control)(object)ClubNameTXT).Text + "\"}";
				int length = text.Length;
				HttpWebRequest httpWebRequest = WebRequest.Create("https://clubaccounts.xboxlive.com/clubs/create") as HttpWebRequest;
				httpWebRequest.Proxy = null;
				httpWebRequest.Method = "POST";
				httpWebRequest.Headers.Add("x-xbl-contract-version", "1");
				httpWebRequest.Headers.Add("Authorization", AuthTokenTXT.get_Text());
				httpWebRequest.Headers.Add("Accept-Encoding", "gzip, deflate");
				httpWebRequest.Headers.Add("x-xbl-contentrestrictions", "AAAAAQHWz5NlGHSiGhEEoMhfRFSXomRyncvTZ/dwjSwRdWj5PAYDZ3aYuXCFbMii5hU0gjdfTSj67IjB0AbaxFBUgBg48qk9Z7hHIQ==");
				httpWebRequest.Headers.Add("Accept-Language", "en-AU");
				httpWebRequest.ContentType = "application/json; charset=UTF-8";
				httpWebRequest.Headers.Add("Signature", "AAAAAQHW2C1LIpyKxv5Df959zyagl/3inukMcNNILMqAu96hAxSv8a45RMv/Fk4qqr0L5nqrbR6nHQpPctxDwIgi1zbOycK/uoUtpw==");
				httpWebRequest.Headers.Add("Cache-Control", "no-cache");
				httpWebRequest.ContentLength = length;
				using StreamWriter streamWriter = new StreamWriter(httpWebRequest.GetRequestStream());
				string value = text;
				streamWriter.Write(value);
				streamWriter.Flush();
			}
			catch (Exception)
			{
				Alert("Error", Notify.enmType.Error);
			}
		}

		private async void SetPictureXboxBtn_Click(object sender, EventArgs e)
		{
			if (!(UserV.Rank == "1") && !(UserV.Rank == "2"))
			{
				return;
			}
			try
			{
				if (((ListControl)(object)XboxOneComboBox).SelectedIndex != 0)
				{
					if (((ListControl)(object)XboxOneComboBox).SelectedIndex != 1)
					{
						if (((ListControl)(object)XboxOneComboBox).SelectedIndex != 2)
						{
							if (((ListControl)(object)XboxOneComboBox).SelectedIndex != 3)
							{
								if (((ListControl)(object)XboxOneComboBox).SelectedIndex == 4)
								{
									await AvatarClass.PostAsync("https://profile.xboxlive.com/users/me/profile/settings/PublicGamerpic", "{\"userSetting\":{\"id\":\"PublicGamerpic\",\"value\":\"https://dlassets-ssl.xboxlive.com/public/content/ppl/gamerpics/50048-00055-md.png\"}}", AuthTokenTXT.get_Text());
								}
							}
							else
							{
								await AvatarClass.PostAsync("https://profile.xboxlive.com/users/me/profile/settings/PublicGamerpic", "{\"userSetting\":{\"id\":\"PublicGamerpic\",\"value\":\"\"}}", AuthTokenTXT.get_Text());
							}
						}
						else
						{
							await AvatarClass.PostAsync("https://profile.xboxlive.com/users/me/profile/settings/PublicGamerpic", "{\"userSetting\":{\"id\":\"PublicGamerpic\",\"value\":\"https://dlassets-ssl.xboxlive.com/public/content/ppl/gamerpics/00033-00000-md.png\"}}", AuthTokenTXT.get_Text());
						}
					}
					else
					{
						await AvatarClass.PostAsync("https://profile.xboxlive.com/users/me/profile/settings/PublicGamerpic", "{\"userSetting\":{\"id\":\"PublicGamerpic\",\"value\":\"https://dlassets-ssl.xboxlive.com/public/content/ppl/gamerpics/00035-00001-md.png\"}}", AuthTokenTXT.get_Text());
					}
				}
				else
				{
					await AvatarClass.PostAsync("https://profile.xboxlive.com/users/me/profile/settings/PublicGamerpic", "{\"userSetting\":{\"id\":\"PublicGamerpic\",\"value\":\"https://dlassets-ssl.xboxlive.com/public/content/ppl/gamerpics/00035-00000-md.png\"}}", AuthTokenTXT.get_Text());
				}
				Alert("Picture Set Successfully", Notify.enmType.Success);
			}
			catch
			{
				Alert("Invalid Auth Token Refresh IT in Avatar Section", Notify.enmType.info);
			}
		}

		private void ChooseTitleID()
		{
			if (CheckGamesCheckBox.get_Checked())
			{
				if (((ListControl)(object)GamesComboBox).SelectedIndex == 0)
				{
					TitleID = "972249091";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 1)
				{
					TitleID = "1414793202";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 2)
				{
					TitleID = "1683566198";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 3)
				{
					TitleID = "926771636";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 4)
				{
					TitleID = "1985055561";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 5)
				{
					TitleID = "1790482525";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 6)
				{
					TitleID = "1664288261";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 7)
				{
					TitleID = "893395429";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 8)
				{
					TitleID = "1985144601";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 9)
				{
					TitleID = "945909358";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 10)
				{
					TitleID = "1925947069";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 11)
				{
					TitleID = "792158305";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 12)
				{
					TitleID = "210179407";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 13)
				{
					TitleID = "2030093255";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 14)
				{
					TitleID = "722916288";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 15)
				{
					TitleID = "1929807318";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 16)
				{
					TitleID = "2106381660";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 17)
				{
					TitleID = "2106872096";
				}
				else if (((ListControl)(object)GamesComboBox).SelectedIndex == 18)
				{
					TitleID = "1814675537";
				}
			}
		}

		private void ChooseTitleID2()
		{
			if (CheckAppsCheckBox.get_Checked())
			{
				if (((ListControl)(object)AppsComboBox).SelectedIndex == 0)
				{
					TitleID = "122001257";
				}
				else if (((ListControl)(object)AppsComboBox).SelectedIndex == 1)
				{
					TitleID = "327370029";
				}
				else if (((ListControl)(object)AppsComboBox).SelectedIndex == 2)
				{
					TitleID = "974494926";
				}
				else if (((ListControl)(object)AppsComboBox).SelectedIndex == 3)
				{
					TitleID = "442736763";
				}
				else if (((ListControl)(object)AppsComboBox).SelectedIndex == 4)
				{
					TitleID = "2123750646";
				}
				else if (((ListControl)(object)AppsComboBox).SelectedIndex == 5)
				{
					TitleID = "2011812409";
				}
				else if (((ListControl)(object)AppsComboBox).SelectedIndex == 6)
				{
					TitleID = "1745374032";
				}
				else if (((ListControl)(object)AppsComboBox).SelectedIndex == 7)
				{
					TitleID = "1527241288";
				}
				else if (((ListControl)(object)AppsComboBox).SelectedIndex == 8)
				{
					TitleID = "274278798";
				}
				else if (((ListControl)(object)AppsComboBox).SelectedIndex == 10)
				{
					TitleID = "750323071";
				}
				else if (((ListControl)(object)AppsComboBox).SelectedIndex == 11)
				{
					TitleID = "1951272099";
				}
			}
		}

		private async Task spoof(string xuid)
		{
			try
			{
				string body = "{\"titles\":[{\"expiration\":600,\"id\":" + TitleID + ",\"state\":\"active\",\"sandbox\":\"RETAIL\"}]}";
				await AvatarClass.PostAsync("https://presence-heartbeat.xboxlive.com/users/xuid(" + xuid + ")/devices/current", body, AuthTokenTXT.get_Text());
			}
			catch
			{
				Alert("Invalid Auth Token Refresh IT in Avatar Section", Notify.enmType.info);
				Spoofing = false;
			}
		}

		private async void SpoofStatusbtn_Click(object sender, EventArgs e)
		{
			if (!(UserV.Rank == "1") && !(UserV.Rank == "2"))
			{
				return;
			}
			try
			{
				string text = (await AvatarClass.GetAsync(string.Concat("https://profile.xboxlive.com/users/me/id"), AuthTokenTXT.get_Text())).responseBody.Remove(0, 8);
				string text2 = text.Remove(text.IndexOf('"'));
				string xuid = text2.Remove(text2.LastIndexOf(','));
				Spoofing = true;
				ChooseTitleID();
				while (Spoofing)
				{
					await spoof(xuid);
					await Task.Delay(300);
				}
			}
			catch
			{
				Alert("Invalid Auth Token Refresh IT in Avatar Section", Notify.enmType.info);
			}
		}

		private async void SpoofStatusbtn2_Click(object sender, EventArgs e)
		{
			if (!(UserV.Rank == "1") && !(UserV.Rank == "2"))
			{
				return;
			}
			try
			{
				string text = (await AvatarClass.GetAsync(string.Concat("https://profile.xboxlive.com/users/me/id"), AuthTokenTXT.get_Text())).responseBody.Remove(0, 8);
				string text2 = text.Remove(text.IndexOf('"'));
				string xuid = text2.Remove(text2.LastIndexOf(','));
				Spoofing = true;
				ChooseTitleID2();
				while (Spoofing)
				{
					await spoof(xuid);
					await Task.Delay(300);
				}
			}
			catch
			{
				Alert("Invalid Auth Token Refresh IT in Avatar Section", Notify.enmType.info);
			}
		}

		private async void StopSpoofingbtn_Click(object sender, EventArgs e)
		{
			if (!(UserV.Rank == "1") && !(UserV.Rank == "2"))
			{
				return;
			}
			try
			{
				string text = (await AvatarClass.GetAsync(string.Concat("https://profile.xboxlive.com/users/me/id"), AuthTokenTXT.get_Text())).responseBody.Remove(0, 8);
				string text2 = text.Remove(text.IndexOf('"'));
				string xuid = text2.Remove(text2.LastIndexOf(','));
				Spoofing = false;
				while (Spoofing)
				{
					await spoof(xuid);
					await Task.Delay(300);
				}
			}
			catch
			{
				Alert("Invalid Auth Token Refresh IT in Avatar Section", Notify.enmType.info);
			}
		}

		private void CheckGamesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (CheckGamesCheckBox.get_Checked())
			{
				((Control)(object)GamesComboBox).Show();
				((Control)(object)SpoofStatusbtn).Show();
			}
			else if (!CheckGamesCheckBox.get_Checked())
			{
				((Control)(object)GamesComboBox).Hide();
				((Control)(object)AppsComboBox).Show();
				CheckAppsCheckBox.set_Checked(true);
				((Control)(object)SpoofStatusbtn).Hide();
				((Control)(object)SpoofStatusbtn2).Show();
			}
		}

		private void CheckAppsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (CheckAppsCheckBox.get_Checked())
			{
				((Control)(object)AppsComboBox).Show();
				((Control)(object)SpoofStatusbtn2).Show();
			}
			else if (!CheckAppsCheckBox.get_Checked())
			{
				((Control)(object)AppsComboBox).Hide();
				((Control)(object)GamesComboBox).Show();
				CheckGamesCheckBox.set_Checked(true);
				((Control)(object)SpoofStatusbtn2).Hide();
				((Control)(object)SpoofStatusbtn).Show();
			}
		}

		private async Task SpoofAppeareanceOnline(string xuid)
		{
			try
			{
				await AvatarClass.PutAsync("https://userpresence.xboxlive.com/users/xuid(" + xuid + ")/state", "{\"state\":\"Active\"}", AuthTokenTXT.get_Text());
			}
			catch
			{
				Alert("Invalid Auth Token Refresh IT in Avatar Section", Notify.enmType.info);
				Spoofing = false;
			}
		}

		private async Task SpoofAppeareanceOffline(string xuid)
		{
			try
			{
				await AvatarClass.PutAsync("https://userpresence.xboxlive.com/users/xuid(" + xuid + ")/state", "{\"state\":\"Cloaked\"}", AuthTokenTXT.get_Text());
			}
			catch
			{
				Alert("Invalid Auth Token Refresh IT in Avatar Section", Notify.enmType.info);
				Spoofing = false;
			}
		}

		private async void OnOffSpam_Tick_1(object sender, EventArgs e)
		{
			if (UserV.Rank == "1" || UserV.Rank == "2")
			{
				try
				{
					string text = (await AvatarClass.GetAsync(string.Concat("https://profile.xboxlive.com/users/me/id"), AuthTokenTXT.get_Text())).responseBody.Remove(0, 8);
					string text2 = text.Remove(text.IndexOf('"'));
					string xuid = text2.Remove(text2.LastIndexOf(','));
					await Task.Delay(5);
					await SpoofAppeareanceOnline(xuid);
					await Task.Delay(5);
					await SpoofAppeareanceOffline(xuid);
				}
				catch
				{
					Alert("Invalid Auth Token Refresh IT in Avatar Section", Notify.enmType.info);
				}
			}
		}

		private void OnOffCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (OnOffCheckBox.get_Checked())
				{
					OnOffSpam.Start();
				}
				if (!OnOffCheckBox.get_Checked())
				{
					OnOffSpam.Stop();
				}
			}
			catch
			{
				Alert("Invalid Auth Token Refresh IT in Avatar Section", Notify.enmType.info);
			}
		}

		private void Closebtn_Click(object sender, EventArgs e)
		{
			Application.ExitThread();
			Close();
		}

		private void panel1_MouseDown(object sender, MouseEventArgs e)
		{
			MouseX = e.X;
			Mousey = e.Y;
			MouseM = true;
		}

		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			if (MouseM)
			{
				SetDesktopLocation(Control.MousePosition.X - MouseX, Control.MousePosition.Y - Mousey);
			}
		}

		private void panel1_MouseUp(object sender, MouseEventArgs e)
		{
			MouseM = false;
		}

		private void Minimizebtn_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0017: Expected O, but got Unknown
			//IL_0017: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Expected O, but got Unknown
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_004f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0059: Expected O, but got Unknown
			//IL_0065: Unknown result type (might be due to invalid IL or missing references)
			//IL_006f: Expected O, but got Unknown
			//IL_0070: Unknown result type (might be due to invalid IL or missing references)
			//IL_007a: Expected O, but got Unknown
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected O, but got Unknown
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0091: Unknown result type (might be due to invalid IL or missing references)
			//IL_009b: Expected O, but got Unknown
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00dd: Expected O, but got Unknown
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e8: Expected O, but got Unknown
			//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
			//IL_0109: Expected O, but got Unknown
			//IL_010a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0114: Expected O, but got Unknown
			//IL_0115: Unknown result type (might be due to invalid IL or missing references)
			//IL_011f: Expected O, but got Unknown
			//IL_0120: Unknown result type (might be due to invalid IL or missing references)
			//IL_012a: Expected O, but got Unknown
			//IL_0136: Unknown result type (might be due to invalid IL or missing references)
			//IL_0140: Expected O, but got Unknown
			//IL_0141: Unknown result type (might be due to invalid IL or missing references)
			//IL_014b: Expected O, but got Unknown
			//IL_014c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0156: Expected O, but got Unknown
			//IL_0157: Unknown result type (might be due to invalid IL or missing references)
			//IL_0161: Expected O, but got Unknown
			//IL_0162: Unknown result type (might be due to invalid IL or missing references)
			//IL_016c: Expected O, but got Unknown
			//IL_0183: Unknown result type (might be due to invalid IL or missing references)
			//IL_018d: Expected O, but got Unknown
			//IL_018e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0198: Expected O, but got Unknown
			//IL_0199: Unknown result type (might be due to invalid IL or missing references)
			//IL_01a3: Expected O, but got Unknown
			//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
			//IL_01ae: Expected O, but got Unknown
			//IL_01af: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b9: Expected O, but got Unknown
			//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c4: Expected O, but got Unknown
			//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_01cf: Expected O, but got Unknown
			//IL_020d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0217: Expected O, but got Unknown
			//IL_0218: Unknown result type (might be due to invalid IL or missing references)
			//IL_0222: Expected O, but got Unknown
			//IL_0223: Unknown result type (might be due to invalid IL or missing references)
			//IL_022d: Expected O, but got Unknown
			//IL_022e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0238: Expected O, but got Unknown
			//IL_0239: Unknown result type (might be due to invalid IL or missing references)
			//IL_0243: Expected O, but got Unknown
			//IL_0244: Unknown result type (might be due to invalid IL or missing references)
			//IL_024e: Expected O, but got Unknown
			//IL_024f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0259: Expected O, but got Unknown
			//IL_025a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0264: Expected O, but got Unknown
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026f: Expected O, but got Unknown
			//IL_0270: Unknown result type (might be due to invalid IL or missing references)
			//IL_027a: Expected O, but got Unknown
			//IL_027b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0285: Expected O, but got Unknown
			//IL_0286: Unknown result type (might be due to invalid IL or missing references)
			//IL_0290: Expected O, but got Unknown
			//IL_0291: Unknown result type (might be due to invalid IL or missing references)
			//IL_029b: Expected O, but got Unknown
			//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b7: Expected O, but got Unknown
			//IL_02b8: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c2: Expected O, but got Unknown
			components = new System.ComponentModel.Container();
			StateProperties val = new StateProperties();
			StateProperties val2 = new StateProperties();
			StateProperties val3 = new StateProperties();
			StateProperties val4 = new StateProperties();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Best_AIO_Tool.Forms.Main));
			BorderEdges val5 = new BorderEdges();
			BorderEdges val6 = new BorderEdges();
			panel1 = new System.Windows.Forms.Panel();
			xuiFlatTab1 = new XUIFlatTab();
			tabPage1 = new System.Windows.Forms.TabPage();
			SetPicturebtn = new GunaAdvenceButton();
			ToolVersionLabel = new GunaLabel();
			RankLabel = new GunaLabel();
			ExpiryLabel = new GunaLabel();
			UserNameLabel = new GunaLabel();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			tabPage2 = new System.Windows.Forms.TabPage();
			XboxOneModdedAvatar = new BunifuGroupBox();
			CopyAvatarsManifestX1 = new GunaAdvenceButton();
			SetCustomManifestXboxOne = new GunaAdvenceButton();
			XboxOneCustomManifest = new GunaTextBox();
			SetXboxOne = new GunaAdvenceButton();
			XOneAvatarCombo = new GunaComboBox();
			X360AvatarCustomisation = new BunifuGroupBox();
			SetCustomManifest360btn = new GunaAdvenceButton();
			Custom360Manifest = new GunaTextBox();
			Set360PresetSelectionbtn = new GunaAdvenceButton();
			Previewbtn = new GunaAdvenceButton();
			X360PictureBox2 = new System.Windows.Forms.PictureBox();
			X360AvatarCombo = new GunaComboBox();
			Xbox360AvatarViewer = new BunifuGroupBox();
			StealAvatarbtn = new GunaAdvenceButton();
			ViewAvatarbtn = new GunaAdvenceButton();
			X360GTTXT = new GunaTextBox();
			X360PictureBox = new System.Windows.Forms.PictureBox();
			tabPage3 = new System.Windows.Forms.TabPage();
			CounterTXT = new GunaLabel();
			CretaeClubGroupBox = new BunifuGroupBox();
			ClubTypeComboBox = new GunaComboBox();
			CreateClubbtn = new GunaAdvenceButton();
			ReserveClubbtn = new GunaAdvenceButton();
			ClubNameTXT = new GunaTextBox();
			AuthTokenTXT = new BunifuTextBox();
			ClubTimer = new System.Windows.Forms.Timer(components);
			tabPage4 = new System.Windows.Forms.TabPage();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			pictureBox3 = new System.Windows.Forms.PictureBox();
			pictureBox4 = new System.Windows.Forms.PictureBox();
			ProfilePicToolsBox = new BunifuGroupBox();
			XboxOneComboBox = new GunaComboBox();
			SetPictureXboxBtn = new GunaAdvenceButton();
			StatusSpooferGroupBox = new BunifuGroupBox();
			GamesComboBox = new GunaComboBox();
			AppsComboBox = new GunaComboBox();
			Number = new GunaTextBox();
			SpoofStatusbtn = new GunaAdvenceButton();
			SpoofStatusbtn2 = new GunaAdvenceButton();
			CheckGamesCheckBox = new GunaCheckBox();
			CheckAppsCheckBox = new GunaCheckBox();
			StopSpoofingbtn = new GunaAdvenceButton();
			OnOffCheckBox = new GunaCheckBox();
			OnOffSpam = new System.Windows.Forms.Timer(components);
			Closebtn = new BunifuButton();
			Minimizebtn = new BunifuButton();
			panel1.SuspendLayout();
			((System.Windows.Forms.Control)(object)xuiFlatTab1).SuspendLayout();
			tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			tabPage2.SuspendLayout();
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).SuspendLayout();
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).SuspendLayout();
			((System.ComponentModel.ISupportInitialize)X360PictureBox2).BeginInit();
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).SuspendLayout();
			((System.ComponentModel.ISupportInitialize)X360PictureBox).BeginInit();
			tabPage3.SuspendLayout();
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).SuspendLayout();
			tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).SuspendLayout();
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).SuspendLayout();
			SuspendLayout();
			panel1.Controls.Add((System.Windows.Forms.Control)(object)Closebtn);
			panel1.Controls.Add((System.Windows.Forms.Control)(object)Minimizebtn);
			panel1.Controls.Add((System.Windows.Forms.Control)(object)xuiFlatTab1);
			panel1.Controls.Add((System.Windows.Forms.Control)(object)AuthTokenTXT);
			panel1.Location = new System.Drawing.Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1004, 525);
			panel1.TabIndex = 0;
			panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(panel1_MouseDown);
			panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(panel1_MouseMove);
			panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(panel1_MouseUp);
			xuiFlatTab1.set_ActiveHeaderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			xuiFlatTab1.set_ActiveTextColor(System.Drawing.Color.Lime);
			xuiFlatTab1.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			((System.Windows.Forms.Control)(object)xuiFlatTab1).Controls.Add(tabPage1);
			((System.Windows.Forms.Control)(object)xuiFlatTab1).Controls.Add(tabPage2);
			((System.Windows.Forms.Control)(object)xuiFlatTab1).Controls.Add(tabPage3);
			((System.Windows.Forms.Control)(object)xuiFlatTab1).Controls.Add(tabPage4);
			((System.Windows.Forms.TabControl)(object)xuiFlatTab1).DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			xuiFlatTab1.set_HeaderBackgroundColor(System.Drawing.Color.Black);
			((System.Windows.Forms.TabControl)(object)xuiFlatTab1).HotTrack = true;
			xuiFlatTab1.set_InActiveHeaderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			xuiFlatTab1.set_InActiveTextColor(System.Drawing.Color.FromArgb(0, 0, 64));
			((System.Windows.Forms.TabControl)(object)xuiFlatTab1).ItemSize = new System.Drawing.Size(240, 16);
			((System.Windows.Forms.Control)(object)xuiFlatTab1).Location = new System.Drawing.Point(-3, 46);
			((System.Windows.Forms.Control)(object)xuiFlatTab1).Name = "xuiFlatTab1";
			xuiFlatTab1.set_OnlyTopLine(true);
			xuiFlatTab1.set_PageColor(System.Drawing.Color.Black);
			((System.Windows.Forms.TabControl)(object)xuiFlatTab1).SelectedIndex = 0;
			((System.Windows.Forms.Control)(object)xuiFlatTab1).Size = new System.Drawing.Size(1006, 482);
			((System.Windows.Forms.Control)(object)xuiFlatTab1).TabIndex = 2;
			tabPage1.BackColor = System.Drawing.Color.Black;
			tabPage1.Controls.Add((System.Windows.Forms.Control)(object)SetPicturebtn);
			tabPage1.Controls.Add((System.Windows.Forms.Control)(object)ToolVersionLabel);
			tabPage1.Controls.Add((System.Windows.Forms.Control)(object)RankLabel);
			tabPage1.Controls.Add((System.Windows.Forms.Control)(object)ExpiryLabel);
			tabPage1.Controls.Add((System.Windows.Forms.Control)(object)UserNameLabel);
			tabPage1.Controls.Add(pictureBox1);
			tabPage1.Location = new System.Drawing.Point(4, 20);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(998, 458);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Main";
			SetPicturebtn.set_Animated(true);
			SetPicturebtn.set_AnimationHoverSpeed(0.07f);
			SetPicturebtn.set_AnimationSpeed(0.03f);
			SetPicturebtn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetPicturebtn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			SetPicturebtn.set_BorderSize(3);
			SetPicturebtn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			SetPicturebtn.set_CheckedBorderColor(System.Drawing.Color.Black);
			SetPicturebtn.set_CheckedForeColor(System.Drawing.Color.Black);
			SetPicturebtn.set_CheckedImage((System.Drawing.Image)null);
			SetPicturebtn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetPicturebtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			SetPicturebtn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)SetPicturebtn).Font = new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)SetPicturebtn).ForeColor = System.Drawing.Color.Black;
			SetPicturebtn.set_Image((System.Drawing.Image)null);
			SetPicturebtn.set_ImageSize(new System.Drawing.Size(20, 20));
			SetPicturebtn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)SetPicturebtn).Location = new System.Drawing.Point(807, 6);
			((System.Windows.Forms.Control)(object)SetPicturebtn).Name = "SetPicturebtn";
			SetPicturebtn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetPicturebtn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			SetPicturebtn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			SetPicturebtn.set_OnHoverImage((System.Drawing.Image)null);
			SetPicturebtn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetPicturebtn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)SetPicturebtn).Size = new System.Drawing.Size(183, 30);
			((System.Windows.Forms.Control)(object)SetPicturebtn).TabIndex = 13;
			((System.Windows.Forms.Control)(object)SetPicturebtn).Text = "Change Background";
			SetPicturebtn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)SetPicturebtn).Click += new System.EventHandler(SetPicturebtn_Click);
			((System.Windows.Forms.Control)(object)ToolVersionLabel).AutoSize = true;
			((System.Windows.Forms.Control)(object)ToolVersionLabel).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)ToolVersionLabel).Font = new System.Drawing.Font("Segoe UI Black", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)ToolVersionLabel).ForeColor = System.Drawing.Color.FromArgb(64, 0, 64);
			((System.Windows.Forms.Control)(object)ToolVersionLabel).Location = new System.Drawing.Point(6, 66);
			((System.Windows.Forms.Control)(object)ToolVersionLabel).Name = "ToolVersionLabel";
			((System.Windows.Forms.Control)(object)ToolVersionLabel).Size = new System.Drawing.Size(137, 21);
			((System.Windows.Forms.Control)(object)ToolVersionLabel).TabIndex = 12;
			((System.Windows.Forms.Control)(object)ToolVersionLabel).Text = "Tool Version: V1";
			((System.Windows.Forms.Control)(object)RankLabel).AutoSize = true;
			((System.Windows.Forms.Control)(object)RankLabel).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)RankLabel).Font = new System.Drawing.Font("Segoe UI Black", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)RankLabel).ForeColor = System.Drawing.Color.FromArgb(64, 0, 64);
			((System.Windows.Forms.Control)(object)RankLabel).Location = new System.Drawing.Point(6, 45);
			((System.Windows.Forms.Control)(object)RankLabel).Name = "RankLabel";
			((System.Windows.Forms.Control)(object)RankLabel).Size = new System.Drawing.Size(152, 21);
			((System.Windows.Forms.Control)(object)RankLabel).TabIndex = 11;
			((System.Windows.Forms.Control)(object)RankLabel).Text = "Rank: Restart APP";
			((System.Windows.Forms.Control)(object)ExpiryLabel).AutoSize = true;
			((System.Windows.Forms.Control)(object)ExpiryLabel).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)ExpiryLabel).Font = new System.Drawing.Font("Segoe UI Black", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)ExpiryLabel).ForeColor = System.Drawing.Color.FromArgb(64, 0, 64);
			((System.Windows.Forms.Control)(object)ExpiryLabel).Location = new System.Drawing.Point(6, 24);
			((System.Windows.Forms.Control)(object)ExpiryLabel).Name = "ExpiryLabel";
			((System.Windows.Forms.Control)(object)ExpiryLabel).Size = new System.Drawing.Size(147, 21);
			((System.Windows.Forms.Control)(object)ExpiryLabel).TabIndex = 10;
			((System.Windows.Forms.Control)(object)ExpiryLabel).Text = "Expiry: Loading...";
			((System.Windows.Forms.Control)(object)UserNameLabel).AutoSize = true;
			((System.Windows.Forms.Control)(object)UserNameLabel).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)UserNameLabel).Font = new System.Drawing.Font("Segoe UI Black", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)UserNameLabel).ForeColor = System.Drawing.Color.FromArgb(64, 0, 64);
			((System.Windows.Forms.Control)(object)UserNameLabel).Location = new System.Drawing.Point(6, 3);
			((System.Windows.Forms.Control)(object)UserNameLabel).Name = "UserNameLabel";
			((System.Windows.Forms.Control)(object)UserNameLabel).Size = new System.Drawing.Size(169, 21);
			((System.Windows.Forms.Control)(object)UserNameLabel).TabIndex = 7;
			((System.Windows.Forms.Control)(object)UserNameLabel).Text = "Welcome Back, User";
			pictureBox1.Location = new System.Drawing.Point(-1, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(1004, 458);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 14;
			pictureBox1.TabStop = false;
			tabPage2.BackColor = System.Drawing.Color.Black;
			tabPage2.Controls.Add((System.Windows.Forms.Control)(object)XboxOneModdedAvatar);
			tabPage2.Controls.Add((System.Windows.Forms.Control)(object)X360AvatarCustomisation);
			tabPage2.Controls.Add((System.Windows.Forms.Control)(object)Xbox360AvatarViewer);
			tabPage2.Controls.Add(pictureBox2);
			tabPage2.Location = new System.Drawing.Point(4, 20);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(998, 458);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Avatar";
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).BackColor = System.Drawing.Color.Transparent;
			XboxOneModdedAvatar.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			XboxOneModdedAvatar.set_BorderRadius(1);
			XboxOneModdedAvatar.set_BorderThickness(5);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).Controls.Add((System.Windows.Forms.Control)(object)CopyAvatarsManifestX1);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).Controls.Add((System.Windows.Forms.Control)(object)SetCustomManifestXboxOne);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).Controls.Add((System.Windows.Forms.Control)(object)XboxOneCustomManifest);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).Controls.Add((System.Windows.Forms.Control)(object)SetXboxOne);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).Controls.Add((System.Windows.Forms.Control)(object)XOneAvatarCombo);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).ForeColor = System.Drawing.Color.Lime;
			XboxOneModdedAvatar.set_LabelAlign(System.Windows.Forms.HorizontalAlignment.Center);
			XboxOneModdedAvatar.set_LabelIndent(10);
			XboxOneModdedAvatar.set_LineStyle((LineStyles)0);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).Location = new System.Drawing.Point(682, 4);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).Name = "XboxOneModdedAvatar";
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).Size = new System.Drawing.Size(309, 384);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).TabIndex = 2;
			((System.Windows.Forms.GroupBox)(object)XboxOneModdedAvatar).TabStop = false;
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).Text = "Xbox One Modded Avatar";
			CopyAvatarsManifestX1.set_Animated(true);
			CopyAvatarsManifestX1.set_AnimationHoverSpeed(0.07f);
			CopyAvatarsManifestX1.set_AnimationSpeed(0.03f);
			CopyAvatarsManifestX1.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CopyAvatarsManifestX1.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			CopyAvatarsManifestX1.set_BorderSize(3);
			CopyAvatarsManifestX1.set_CheckedBaseColor(System.Drawing.Color.Lime);
			CopyAvatarsManifestX1.set_CheckedBorderColor(System.Drawing.Color.Black);
			CopyAvatarsManifestX1.set_CheckedForeColor(System.Drawing.Color.Black);
			CopyAvatarsManifestX1.set_CheckedImage((System.Drawing.Image)null);
			CopyAvatarsManifestX1.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CopyAvatarsManifestX1.set_DialogResult(System.Windows.Forms.DialogResult.None);
			CopyAvatarsManifestX1.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)CopyAvatarsManifestX1).Font = new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)CopyAvatarsManifestX1).ForeColor = System.Drawing.Color.Black;
			CopyAvatarsManifestX1.set_Image((System.Drawing.Image)null);
			CopyAvatarsManifestX1.set_ImageSize(new System.Drawing.Size(20, 20));
			CopyAvatarsManifestX1.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)CopyAvatarsManifestX1).Location = new System.Drawing.Point(6, 163);
			((System.Windows.Forms.Control)(object)CopyAvatarsManifestX1).Name = "CopyAvatarsManifestX1";
			CopyAvatarsManifestX1.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CopyAvatarsManifestX1.set_OnHoverBorderColor(System.Drawing.Color.Black);
			CopyAvatarsManifestX1.set_OnHoverForeColor(System.Drawing.Color.Lime);
			CopyAvatarsManifestX1.set_OnHoverImage((System.Drawing.Image)null);
			CopyAvatarsManifestX1.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CopyAvatarsManifestX1.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)CopyAvatarsManifestX1).Size = new System.Drawing.Size(297, 33);
			((System.Windows.Forms.Control)(object)CopyAvatarsManifestX1).TabIndex = 14;
			((System.Windows.Forms.Control)(object)CopyAvatarsManifestX1).Text = "Copy My Avatar's Manifest";
			CopyAvatarsManifestX1.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)CopyAvatarsManifestX1).Click += new System.EventHandler(CopyAvatarsManifestX1_Click);
			SetCustomManifestXboxOne.set_Animated(true);
			SetCustomManifestXboxOne.set_AnimationHoverSpeed(0.07f);
			SetCustomManifestXboxOne.set_AnimationSpeed(0.03f);
			SetCustomManifestXboxOne.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetCustomManifestXboxOne.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			SetCustomManifestXboxOne.set_BorderSize(3);
			SetCustomManifestXboxOne.set_CheckedBaseColor(System.Drawing.Color.Lime);
			SetCustomManifestXboxOne.set_CheckedBorderColor(System.Drawing.Color.Black);
			SetCustomManifestXboxOne.set_CheckedForeColor(System.Drawing.Color.Black);
			SetCustomManifestXboxOne.set_CheckedImage((System.Drawing.Image)null);
			SetCustomManifestXboxOne.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetCustomManifestXboxOne.set_DialogResult(System.Windows.Forms.DialogResult.None);
			SetCustomManifestXboxOne.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)SetCustomManifestXboxOne).Font = new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)SetCustomManifestXboxOne).ForeColor = System.Drawing.Color.Black;
			SetCustomManifestXboxOne.set_Image((System.Drawing.Image)null);
			SetCustomManifestXboxOne.set_ImageSize(new System.Drawing.Size(20, 20));
			SetCustomManifestXboxOne.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)SetCustomManifestXboxOne).Location = new System.Drawing.Point(6, 127);
			((System.Windows.Forms.Control)(object)SetCustomManifestXboxOne).Name = "SetCustomManifestXboxOne";
			SetCustomManifestXboxOne.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetCustomManifestXboxOne.set_OnHoverBorderColor(System.Drawing.Color.Black);
			SetCustomManifestXboxOne.set_OnHoverForeColor(System.Drawing.Color.Lime);
			SetCustomManifestXboxOne.set_OnHoverImage((System.Drawing.Image)null);
			SetCustomManifestXboxOne.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetCustomManifestXboxOne.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)SetCustomManifestXboxOne).Size = new System.Drawing.Size(297, 33);
			((System.Windows.Forms.Control)(object)SetCustomManifestXboxOne).TabIndex = 13;
			((System.Windows.Forms.Control)(object)SetCustomManifestXboxOne).Text = "Set Custom Xbox One Avatar Manifest";
			SetCustomManifestXboxOne.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)SetCustomManifestXboxOne).Click += new System.EventHandler(SetCustomManifestXboxOne_Click);
			XboxOneCustomManifest.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			XboxOneCustomManifest.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)XboxOneCustomManifest).Cursor = System.Windows.Forms.Cursors.IBeam;
			XboxOneCustomManifest.set_FocusedBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			XboxOneCustomManifest.set_FocusedBorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			XboxOneCustomManifest.set_FocusedForeColor(System.Drawing.SystemColors.ControlText);
			((System.Windows.Forms.Control)(object)XboxOneCustomManifest).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)XboxOneCustomManifest).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)XboxOneCustomManifest).Location = new System.Drawing.Point(6, 92);
			((System.Windows.Forms.Control)(object)XboxOneCustomManifest).Name = "XboxOneCustomManifest";
			XboxOneCustomManifest.set_PasswordChar('\0');
			XboxOneCustomManifest.set_SelectedText("");
			((System.Windows.Forms.Control)(object)XboxOneCustomManifest).Size = new System.Drawing.Size(297, 32);
			((System.Windows.Forms.Control)(object)XboxOneCustomManifest).TabIndex = 12;
			((System.Windows.Forms.Control)(object)XboxOneCustomManifest).Text = "Custom Manifest";
			XboxOneCustomManifest.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			SetXboxOne.set_Animated(true);
			SetXboxOne.set_AnimationHoverSpeed(0.07f);
			SetXboxOne.set_AnimationSpeed(0.03f);
			SetXboxOne.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetXboxOne.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			SetXboxOne.set_BorderSize(3);
			SetXboxOne.set_CheckedBaseColor(System.Drawing.Color.Lime);
			SetXboxOne.set_CheckedBorderColor(System.Drawing.Color.Black);
			SetXboxOne.set_CheckedForeColor(System.Drawing.Color.Black);
			SetXboxOne.set_CheckedImage((System.Drawing.Image)null);
			SetXboxOne.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetXboxOne.set_DialogResult(System.Windows.Forms.DialogResult.None);
			SetXboxOne.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)SetXboxOne).Font = new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)SetXboxOne).ForeColor = System.Drawing.Color.Black;
			SetXboxOne.set_Image((System.Drawing.Image)null);
			SetXboxOne.set_ImageSize(new System.Drawing.Size(20, 20));
			SetXboxOne.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)SetXboxOne).Location = new System.Drawing.Point(6, 56);
			((System.Windows.Forms.Control)(object)SetXboxOne).Name = "SetXboxOne";
			SetXboxOne.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetXboxOne.set_OnHoverBorderColor(System.Drawing.Color.Black);
			SetXboxOne.set_OnHoverForeColor(System.Drawing.Color.Lime);
			SetXboxOne.set_OnHoverImage((System.Drawing.Image)null);
			SetXboxOne.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetXboxOne.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)SetXboxOne).Size = new System.Drawing.Size(297, 33);
			((System.Windows.Forms.Control)(object)SetXboxOne).TabIndex = 11;
			((System.Windows.Forms.Control)(object)SetXboxOne).Text = "Set Preset Xbox One Avatar Selection";
			SetXboxOne.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)SetXboxOne).Click += new System.EventHandler(SetXboxOne_Click);
			((System.Windows.Forms.Control)(object)XOneAvatarCombo).BackColor = System.Drawing.Color.Transparent;
			XOneAvatarCombo.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			XOneAvatarCombo.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.ComboBox)(object)XOneAvatarCombo).DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			((System.Windows.Forms.ComboBox)(object)XOneAvatarCombo).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			XOneAvatarCombo.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)XOneAvatarCombo).Font = new System.Drawing.Font("Segoe UI", 10f);
			((System.Windows.Forms.Control)(object)XOneAvatarCombo).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.ListControl)(object)XOneAvatarCombo).FormattingEnabled = true;
			((System.Windows.Forms.ComboBox)(object)XOneAvatarCombo).Items.AddRange(new object[1] { "Luthor Avatar (Normal)" });
			((System.Windows.Forms.Control)(object)XOneAvatarCombo).Location = new System.Drawing.Point(6, 27);
			((System.Windows.Forms.Control)(object)XOneAvatarCombo).Name = "XOneAvatarCombo";
			XOneAvatarCombo.set_OnHoverItemBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			XOneAvatarCombo.set_OnHoverItemForeColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)XOneAvatarCombo).Size = new System.Drawing.Size(297, 26);
			((System.Windows.Forms.Control)(object)XOneAvatarCombo).TabIndex = 1;
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).BackColor = System.Drawing.Color.Transparent;
			X360AvatarCustomisation.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			X360AvatarCustomisation.set_BorderRadius(1);
			X360AvatarCustomisation.set_BorderThickness(5);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Controls.Add((System.Windows.Forms.Control)(object)SetCustomManifest360btn);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Controls.Add((System.Windows.Forms.Control)(object)Custom360Manifest);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Controls.Add((System.Windows.Forms.Control)(object)Set360PresetSelectionbtn);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Controls.Add((System.Windows.Forms.Control)(object)Previewbtn);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Controls.Add(X360PictureBox2);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Controls.Add((System.Windows.Forms.Control)(object)X360AvatarCombo);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).ForeColor = System.Drawing.Color.Lime;
			X360AvatarCustomisation.set_LabelAlign(System.Windows.Forms.HorizontalAlignment.Center);
			X360AvatarCustomisation.set_LabelIndent(10);
			X360AvatarCustomisation.set_LineStyle((LineStyles)0);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Location = new System.Drawing.Point(331, 4);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Name = "X360AvatarCustomisation";
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Size = new System.Drawing.Size(345, 384);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).TabIndex = 1;
			((System.Windows.Forms.GroupBox)(object)X360AvatarCustomisation).TabStop = false;
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).Text = "X360 Avatar Customisation";
			SetCustomManifest360btn.set_Animated(true);
			SetCustomManifest360btn.set_AnimationHoverSpeed(0.07f);
			SetCustomManifest360btn.set_AnimationSpeed(0.03f);
			SetCustomManifest360btn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetCustomManifest360btn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			SetCustomManifest360btn.set_BorderSize(3);
			SetCustomManifest360btn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			SetCustomManifest360btn.set_CheckedBorderColor(System.Drawing.Color.Black);
			SetCustomManifest360btn.set_CheckedForeColor(System.Drawing.Color.Black);
			SetCustomManifest360btn.set_CheckedImage((System.Drawing.Image)null);
			SetCustomManifest360btn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetCustomManifest360btn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			SetCustomManifest360btn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)SetCustomManifest360btn).Font = new System.Drawing.Font("Arial Black", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)SetCustomManifest360btn).ForeColor = System.Drawing.Color.Black;
			SetCustomManifest360btn.set_Image((System.Drawing.Image)null);
			SetCustomManifest360btn.set_ImageSize(new System.Drawing.Size(20, 20));
			SetCustomManifest360btn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)SetCustomManifest360btn).Location = new System.Drawing.Point(6, 294);
			((System.Windows.Forms.Control)(object)SetCustomManifest360btn).Name = "SetCustomManifest360btn";
			SetCustomManifest360btn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetCustomManifest360btn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			SetCustomManifest360btn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			SetCustomManifest360btn.set_OnHoverImage((System.Drawing.Image)null);
			SetCustomManifest360btn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetCustomManifest360btn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)SetCustomManifest360btn).Size = new System.Drawing.Size(191, 33);
			((System.Windows.Forms.Control)(object)SetCustomManifest360btn).TabIndex = 12;
			((System.Windows.Forms.Control)(object)SetCustomManifest360btn).Text = "Set Custom Avatar Manifest";
			SetCustomManifest360btn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)SetCustomManifest360btn).Click += new System.EventHandler(SetCustomManifest360btn_Click);
			Custom360Manifest.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Custom360Manifest.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)Custom360Manifest).Cursor = System.Windows.Forms.Cursors.IBeam;
			Custom360Manifest.set_FocusedBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Custom360Manifest.set_FocusedBorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			Custom360Manifest.set_FocusedForeColor(System.Drawing.SystemColors.ControlText);
			((System.Windows.Forms.Control)(object)Custom360Manifest).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)Custom360Manifest).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)Custom360Manifest).Location = new System.Drawing.Point(6, 259);
			((System.Windows.Forms.Control)(object)Custom360Manifest).Name = "Custom360Manifest";
			Custom360Manifest.set_PasswordChar('\0');
			Custom360Manifest.set_SelectedText("");
			((System.Windows.Forms.Control)(object)Custom360Manifest).Size = new System.Drawing.Size(191, 32);
			((System.Windows.Forms.Control)(object)Custom360Manifest).TabIndex = 11;
			((System.Windows.Forms.Control)(object)Custom360Manifest).Text = "Custom Manifest";
			Custom360Manifest.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			Set360PresetSelectionbtn.set_Animated(true);
			Set360PresetSelectionbtn.set_AnimationHoverSpeed(0.07f);
			Set360PresetSelectionbtn.set_AnimationSpeed(0.03f);
			Set360PresetSelectionbtn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Set360PresetSelectionbtn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			Set360PresetSelectionbtn.set_BorderSize(3);
			Set360PresetSelectionbtn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			Set360PresetSelectionbtn.set_CheckedBorderColor(System.Drawing.Color.Black);
			Set360PresetSelectionbtn.set_CheckedForeColor(System.Drawing.Color.Black);
			Set360PresetSelectionbtn.set_CheckedImage((System.Drawing.Image)null);
			Set360PresetSelectionbtn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Set360PresetSelectionbtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			Set360PresetSelectionbtn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)Set360PresetSelectionbtn).Font = new System.Drawing.Font("Arial Black", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)Set360PresetSelectionbtn).ForeColor = System.Drawing.Color.Black;
			Set360PresetSelectionbtn.set_Image((System.Drawing.Image)null);
			Set360PresetSelectionbtn.set_ImageSize(new System.Drawing.Size(20, 20));
			Set360PresetSelectionbtn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)Set360PresetSelectionbtn).Location = new System.Drawing.Point(6, 98);
			((System.Windows.Forms.Control)(object)Set360PresetSelectionbtn).Name = "Set360PresetSelectionbtn";
			Set360PresetSelectionbtn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Set360PresetSelectionbtn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			Set360PresetSelectionbtn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			Set360PresetSelectionbtn.set_OnHoverImage((System.Drawing.Image)null);
			Set360PresetSelectionbtn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Set360PresetSelectionbtn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)Set360PresetSelectionbtn).Size = new System.Drawing.Size(191, 32);
			((System.Windows.Forms.Control)(object)Set360PresetSelectionbtn).TabIndex = 9;
			((System.Windows.Forms.Control)(object)Set360PresetSelectionbtn).Text = "Set Preset Avatar Selection";
			Set360PresetSelectionbtn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)Set360PresetSelectionbtn).Click += new System.EventHandler(Set360PresetSelectionbtn_Click);
			Previewbtn.set_Animated(true);
			Previewbtn.set_AnimationHoverSpeed(0.07f);
			Previewbtn.set_AnimationSpeed(0.03f);
			Previewbtn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Previewbtn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			Previewbtn.set_BorderSize(3);
			Previewbtn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			Previewbtn.set_CheckedBorderColor(System.Drawing.Color.Black);
			Previewbtn.set_CheckedForeColor(System.Drawing.Color.Black);
			Previewbtn.set_CheckedImage((System.Drawing.Image)null);
			Previewbtn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Previewbtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			Previewbtn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)Previewbtn).Font = new System.Drawing.Font("Arial Black", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)Previewbtn).ForeColor = System.Drawing.Color.Black;
			Previewbtn.set_Image((System.Drawing.Image)null);
			Previewbtn.set_ImageSize(new System.Drawing.Size(20, 20));
			Previewbtn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)Previewbtn).Location = new System.Drawing.Point(6, 60);
			((System.Windows.Forms.Control)(object)Previewbtn).Name = "Previewbtn";
			Previewbtn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Previewbtn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			Previewbtn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			Previewbtn.set_OnHoverImage((System.Drawing.Image)null);
			Previewbtn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Previewbtn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)Previewbtn).Size = new System.Drawing.Size(191, 32);
			((System.Windows.Forms.Control)(object)Previewbtn).TabIndex = 8;
			((System.Windows.Forms.Control)(object)Previewbtn).Text = "Preview Avatar Selection";
			Previewbtn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)Previewbtn).Click += new System.EventHandler(Previewbtn_Click);
			X360PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			X360PictureBox2.Location = new System.Drawing.Point(203, 28);
			X360PictureBox2.Name = "X360PictureBox2";
			X360PictureBox2.Size = new System.Drawing.Size(136, 301);
			X360PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			X360PictureBox2.TabIndex = 6;
			X360PictureBox2.TabStop = false;
			((System.Windows.Forms.Control)(object)X360AvatarCombo).BackColor = System.Drawing.Color.Transparent;
			X360AvatarCombo.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			X360AvatarCombo.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.ComboBox)(object)X360AvatarCombo).DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			((System.Windows.Forms.ComboBox)(object)X360AvatarCombo).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			X360AvatarCombo.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)X360AvatarCombo).Font = new System.Drawing.Font("Segoe UI", 10f);
			((System.Windows.Forms.Control)(object)X360AvatarCombo).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.ListControl)(object)X360AvatarCombo).FormattingEnabled = true;
			((System.Windows.Forms.ComboBox)(object)X360AvatarCombo).Items.AddRange(new object[3] { "Golden", "Xbox Enforcement", "Major Nelson" });
			((System.Windows.Forms.Control)(object)X360AvatarCombo).Location = new System.Drawing.Point(6, 28);
			((System.Windows.Forms.Control)(object)X360AvatarCombo).Name = "X360AvatarCombo";
			X360AvatarCombo.set_OnHoverItemBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			X360AvatarCombo.set_OnHoverItemForeColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)X360AvatarCombo).Size = new System.Drawing.Size(191, 26);
			((System.Windows.Forms.Control)(object)X360AvatarCombo).TabIndex = 0;
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).BackColor = System.Drawing.Color.Transparent;
			Xbox360AvatarViewer.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Xbox360AvatarViewer.set_BorderRadius(1);
			Xbox360AvatarViewer.set_BorderThickness(5);
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).Controls.Add((System.Windows.Forms.Control)(object)StealAvatarbtn);
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).Controls.Add((System.Windows.Forms.Control)(object)ViewAvatarbtn);
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).Controls.Add((System.Windows.Forms.Control)(object)X360GTTXT);
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).Controls.Add(X360PictureBox);
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold);
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).ForeColor = System.Drawing.Color.Lime;
			Xbox360AvatarViewer.set_LabelAlign(System.Windows.Forms.HorizontalAlignment.Center);
			Xbox360AvatarViewer.set_LabelIndent(10);
			Xbox360AvatarViewer.set_LineStyle((LineStyles)0);
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).Location = new System.Drawing.Point(5, 4);
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).Name = "Xbox360AvatarViewer";
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).Size = new System.Drawing.Size(320, 384);
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).TabIndex = 0;
			((System.Windows.Forms.GroupBox)(object)Xbox360AvatarViewer).TabStop = false;
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).Text = "X360 Avatar Viewer";
			StealAvatarbtn.set_Animated(true);
			StealAvatarbtn.set_AnimationHoverSpeed(0.07f);
			StealAvatarbtn.set_AnimationSpeed(0.03f);
			StealAvatarbtn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			StealAvatarbtn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			StealAvatarbtn.set_BorderSize(3);
			StealAvatarbtn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			StealAvatarbtn.set_CheckedBorderColor(System.Drawing.Color.Black);
			StealAvatarbtn.set_CheckedForeColor(System.Drawing.Color.Black);
			StealAvatarbtn.set_CheckedImage((System.Drawing.Image)null);
			StealAvatarbtn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			StealAvatarbtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			StealAvatarbtn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)StealAvatarbtn).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)StealAvatarbtn).ForeColor = System.Drawing.Color.Black;
			StealAvatarbtn.set_Image((System.Drawing.Image)null);
			StealAvatarbtn.set_ImageSize(new System.Drawing.Size(20, 20));
			StealAvatarbtn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)StealAvatarbtn).Location = new System.Drawing.Point(16, 335);
			((System.Windows.Forms.Control)(object)StealAvatarbtn).Name = "StealAvatarbtn";
			StealAvatarbtn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			StealAvatarbtn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			StealAvatarbtn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			StealAvatarbtn.set_OnHoverImage((System.Drawing.Image)null);
			StealAvatarbtn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			StealAvatarbtn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)StealAvatarbtn).Size = new System.Drawing.Size(298, 41);
			((System.Windows.Forms.Control)(object)StealAvatarbtn).TabIndex = 9;
			((System.Windows.Forms.Control)(object)StealAvatarbtn).Text = "Steal Avatar Manifest";
			StealAvatarbtn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)StealAvatarbtn).Click += new System.EventHandler(StealAvatarbtn_Click);
			ViewAvatarbtn.set_Animated(true);
			ViewAvatarbtn.set_AnimationHoverSpeed(0.07f);
			ViewAvatarbtn.set_AnimationSpeed(0.03f);
			ViewAvatarbtn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ViewAvatarbtn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			ViewAvatarbtn.set_BorderSize(3);
			ViewAvatarbtn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			ViewAvatarbtn.set_CheckedBorderColor(System.Drawing.Color.Black);
			ViewAvatarbtn.set_CheckedForeColor(System.Drawing.Color.Black);
			ViewAvatarbtn.set_CheckedImage((System.Drawing.Image)null);
			ViewAvatarbtn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ViewAvatarbtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			ViewAvatarbtn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)ViewAvatarbtn).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)ViewAvatarbtn).ForeColor = System.Drawing.Color.Black;
			ViewAvatarbtn.set_Image((System.Drawing.Image)null);
			ViewAvatarbtn.set_ImageSize(new System.Drawing.Size(20, 20));
			ViewAvatarbtn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)ViewAvatarbtn).Location = new System.Drawing.Point(156, 66);
			((System.Windows.Forms.Control)(object)ViewAvatarbtn).Name = "ViewAvatarbtn";
			ViewAvatarbtn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ViewAvatarbtn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			ViewAvatarbtn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			ViewAvatarbtn.set_OnHoverImage((System.Drawing.Image)null);
			ViewAvatarbtn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ViewAvatarbtn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)ViewAvatarbtn).Size = new System.Drawing.Size(158, 33);
			((System.Windows.Forms.Control)(object)ViewAvatarbtn).TabIndex = 8;
			((System.Windows.Forms.Control)(object)ViewAvatarbtn).Text = "View Avatar";
			ViewAvatarbtn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)ViewAvatarbtn).Click += new System.EventHandler(ViewAvatarbtn_Click);
			X360GTTXT.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			X360GTTXT.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)X360GTTXT).Cursor = System.Windows.Forms.Cursors.IBeam;
			X360GTTXT.set_FocusedBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			X360GTTXT.set_FocusedBorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			X360GTTXT.set_FocusedForeColor(System.Drawing.SystemColors.ControlText);
			((System.Windows.Forms.Control)(object)X360GTTXT).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)X360GTTXT).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)X360GTTXT).Location = new System.Drawing.Point(156, 28);
			((System.Windows.Forms.Control)(object)X360GTTXT).Name = "X360GTTXT";
			X360GTTXT.set_PasswordChar('\0');
			X360GTTXT.set_SelectedText("");
			((System.Windows.Forms.Control)(object)X360GTTXT).Size = new System.Drawing.Size(158, 32);
			((System.Windows.Forms.Control)(object)X360GTTXT).TabIndex = 7;
			((System.Windows.Forms.Control)(object)X360GTTXT).Text = "Gamertag";
			X360GTTXT.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			X360PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			X360PictureBox.Location = new System.Drawing.Point(16, 28);
			X360PictureBox.Name = "X360PictureBox";
			X360PictureBox.Size = new System.Drawing.Size(136, 301);
			X360PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			X360PictureBox.TabIndex = 5;
			X360PictureBox.TabStop = false;
			tabPage3.BackColor = System.Drawing.Color.Black;
			tabPage3.Controls.Add((System.Windows.Forms.Control)(object)CounterTXT);
			tabPage3.Controls.Add((System.Windows.Forms.Control)(object)CretaeClubGroupBox);
			tabPage3.Controls.Add(pictureBox3);
			tabPage3.Location = new System.Drawing.Point(4, 20);
			tabPage3.Name = "tabPage3";
			tabPage3.Size = new System.Drawing.Size(998, 458);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Club";
			((System.Windows.Forms.Control)(object)CounterTXT).AutoSize = true;
			((System.Windows.Forms.Control)(object)CounterTXT).Font = new System.Drawing.Font("Arial Black", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)CounterTXT).ForeColor = System.Drawing.Color.FromArgb(64, 0, 64);
			((System.Windows.Forms.Control)(object)CounterTXT).Location = new System.Drawing.Point(6, 167);
			((System.Windows.Forms.Control)(object)CounterTXT).Name = "CounterTXT";
			((System.Windows.Forms.Control)(object)CounterTXT).Size = new System.Drawing.Size(95, 27);
			((System.Windows.Forms.Control)(object)CounterTXT).TabIndex = 16;
			((System.Windows.Forms.Control)(object)CounterTXT).Text = "Counter";
			((System.Windows.Forms.Control)(object)CounterTXT).Visible = false;
			CretaeClubGroupBox.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CretaeClubGroupBox.set_BorderRadius(1);
			CretaeClubGroupBox.set_BorderThickness(5);
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).Controls.Add((System.Windows.Forms.Control)(object)ClubTypeComboBox);
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).Controls.Add((System.Windows.Forms.Control)(object)CreateClubbtn);
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).Controls.Add((System.Windows.Forms.Control)(object)ReserveClubbtn);
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).Controls.Add((System.Windows.Forms.Control)(object)ClubNameTXT);
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold);
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).ForeColor = System.Drawing.Color.Lime;
			CretaeClubGroupBox.set_LabelAlign(System.Windows.Forms.HorizontalAlignment.Center);
			CretaeClubGroupBox.set_LabelIndent(10);
			CretaeClubGroupBox.set_LineStyle((LineStyles)0);
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).Location = new System.Drawing.Point(3, 3);
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).Name = "CretaeClubGroupBox";
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).Size = new System.Drawing.Size(300, 161);
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).TabIndex = 1;
			((System.Windows.Forms.GroupBox)(object)CretaeClubGroupBox).TabStop = false;
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).Text = "Xbox Club Create";
			((System.Windows.Forms.Control)(object)ClubTypeComboBox).BackColor = System.Drawing.Color.Transparent;
			ClubTypeComboBox.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ClubTypeComboBox.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.ComboBox)(object)ClubTypeComboBox).DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			((System.Windows.Forms.ComboBox)(object)ClubTypeComboBox).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			ClubTypeComboBox.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)ClubTypeComboBox).Font = new System.Drawing.Font("Segoe UI", 10f);
			((System.Windows.Forms.Control)(object)ClubTypeComboBox).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.ListControl)(object)ClubTypeComboBox).FormattingEnabled = true;
			((System.Windows.Forms.ComboBox)(object)ClubTypeComboBox).Items.AddRange(new object[3] { "Open", "Closed", "Secret" });
			((System.Windows.Forms.Control)(object)ClubTypeComboBox).Location = new System.Drawing.Point(8, 128);
			((System.Windows.Forms.Control)(object)ClubTypeComboBox).Name = "ClubTypeComboBox";
			ClubTypeComboBox.set_OnHoverItemBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ClubTypeComboBox.set_OnHoverItemForeColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)ClubTypeComboBox).Size = new System.Drawing.Size(286, 26);
			((System.Windows.Forms.Control)(object)ClubTypeComboBox).TabIndex = 17;
			CreateClubbtn.set_Animated(true);
			CreateClubbtn.set_AnimationHoverSpeed(0.07f);
			CreateClubbtn.set_AnimationSpeed(0.03f);
			CreateClubbtn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CreateClubbtn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			CreateClubbtn.set_BorderSize(3);
			CreateClubbtn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			CreateClubbtn.set_CheckedBorderColor(System.Drawing.Color.Black);
			CreateClubbtn.set_CheckedForeColor(System.Drawing.Color.Black);
			CreateClubbtn.set_CheckedImage((System.Drawing.Image)null);
			CreateClubbtn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CreateClubbtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			CreateClubbtn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)CreateClubbtn).Font = new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)CreateClubbtn).ForeColor = System.Drawing.Color.Black;
			CreateClubbtn.set_Image((System.Drawing.Image)null);
			CreateClubbtn.set_ImageSize(new System.Drawing.Size(20, 20));
			CreateClubbtn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)CreateClubbtn).Location = new System.Drawing.Point(8, 96);
			((System.Windows.Forms.Control)(object)CreateClubbtn).Name = "CreateClubbtn";
			CreateClubbtn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CreateClubbtn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			CreateClubbtn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			CreateClubbtn.set_OnHoverImage((System.Drawing.Image)null);
			CreateClubbtn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CreateClubbtn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)CreateClubbtn).Size = new System.Drawing.Size(285, 30);
			((System.Windows.Forms.Control)(object)CreateClubbtn).TabIndex = 16;
			((System.Windows.Forms.Control)(object)CreateClubbtn).Text = "Create Club";
			CreateClubbtn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)CreateClubbtn).Click += new System.EventHandler(CreateClubbtn_Click);
			ReserveClubbtn.set_Animated(true);
			ReserveClubbtn.set_AnimationHoverSpeed(0.07f);
			ReserveClubbtn.set_AnimationSpeed(0.03f);
			ReserveClubbtn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ReserveClubbtn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			ReserveClubbtn.set_BorderSize(3);
			ReserveClubbtn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			ReserveClubbtn.set_CheckedBorderColor(System.Drawing.Color.Black);
			ReserveClubbtn.set_CheckedForeColor(System.Drawing.Color.Black);
			ReserveClubbtn.set_CheckedImage((System.Drawing.Image)null);
			ReserveClubbtn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ReserveClubbtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			ReserveClubbtn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)ReserveClubbtn).Font = new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)ReserveClubbtn).ForeColor = System.Drawing.Color.Black;
			ReserveClubbtn.set_Image((System.Drawing.Image)null);
			ReserveClubbtn.set_ImageSize(new System.Drawing.Size(20, 20));
			ReserveClubbtn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)ReserveClubbtn).Location = new System.Drawing.Point(8, 63);
			((System.Windows.Forms.Control)(object)ReserveClubbtn).Name = "ReserveClubbtn";
			ReserveClubbtn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ReserveClubbtn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			ReserveClubbtn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			ReserveClubbtn.set_OnHoverImage((System.Drawing.Image)null);
			ReserveClubbtn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ReserveClubbtn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)ReserveClubbtn).Size = new System.Drawing.Size(286, 30);
			((System.Windows.Forms.Control)(object)ReserveClubbtn).TabIndex = 15;
			((System.Windows.Forms.Control)(object)ReserveClubbtn).Text = "Reserve Club";
			ReserveClubbtn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)ReserveClubbtn).Click += new System.EventHandler(ReserveClubbtn_Click);
			ClubNameTXT.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ClubNameTXT.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)ClubNameTXT).Cursor = System.Windows.Forms.Cursors.IBeam;
			ClubNameTXT.set_FocusedBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ClubNameTXT.set_FocusedBorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			ClubNameTXT.set_FocusedForeColor(System.Drawing.SystemColors.ControlText);
			((System.Windows.Forms.Control)(object)ClubNameTXT).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)ClubNameTXT).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)ClubNameTXT).Location = new System.Drawing.Point(8, 28);
			((System.Windows.Forms.Control)(object)ClubNameTXT).Name = "ClubNameTXT";
			ClubNameTXT.set_PasswordChar('\0');
			ClubNameTXT.set_SelectedText("");
			((System.Windows.Forms.Control)(object)ClubNameTXT).Size = new System.Drawing.Size(286, 32);
			((System.Windows.Forms.Control)(object)ClubNameTXT).TabIndex = 14;
			((System.Windows.Forms.Control)(object)ClubNameTXT).Text = "Club Name";
			ClubNameTXT.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			AuthTokenTXT.set_AcceptsReturn(true);
			AuthTokenTXT.set_AcceptsTab(true);
			AuthTokenTXT.set_AnimationSpeed(200);
			AuthTokenTXT.set_AutoCompleteMode(System.Windows.Forms.AutoCompleteMode.None);
			AuthTokenTXT.set_AutoCompleteSource(System.Windows.Forms.AutoCompleteSource.None);
			AuthTokenTXT.set_AutoSizeHeight(true);
			((System.Windows.Forms.Control)(object)AuthTokenTXT).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)AuthTokenTXT).BackgroundImage = (System.Drawing.Image)resources.GetObject("AuthTokenTXT.BackgroundImage");
			AuthTokenTXT.set_BorderColorActive(System.Drawing.Color.FromArgb(64, 0, 64));
			AuthTokenTXT.set_BorderColorDisabled(System.Drawing.Color.FromArgb(64, 0, 64));
			AuthTokenTXT.set_BorderColorHover(System.Drawing.Color.FromArgb(64, 0, 64));
			AuthTokenTXT.set_BorderColorIdle(System.Drawing.Color.FromArgb(64, 0, 64));
			AuthTokenTXT.set_BorderRadius(1);
			AuthTokenTXT.set_BorderThickness(1);
			AuthTokenTXT.set_CharacterCasing(System.Windows.Forms.CharacterCasing.Normal);
			((System.Windows.Forms.Control)(object)AuthTokenTXT).Cursor = System.Windows.Forms.Cursors.IBeam;
			AuthTokenTXT.set_DefaultFont(new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0));
			AuthTokenTXT.set_DefaultText("");
			AuthTokenTXT.set_FillColor(System.Drawing.Color.FromArgb(0, 0, 64));
			((System.Windows.Forms.Control)(object)AuthTokenTXT).ForeColor = System.Drawing.Color.White;
			AuthTokenTXT.set_HideSelection(true);
			AuthTokenTXT.set_IconLeft((System.Drawing.Image)null);
			AuthTokenTXT.set_IconLeftCursor(System.Windows.Forms.Cursors.IBeam);
			AuthTokenTXT.set_IconPadding(10);
			AuthTokenTXT.set_IconRight((System.Drawing.Image)null);
			AuthTokenTXT.set_IconRightCursor(System.Windows.Forms.Cursors.IBeam);
			AuthTokenTXT.set_Lines(new string[0]);
			((System.Windows.Forms.Control)(object)AuthTokenTXT).Location = new System.Drawing.Point(2, 2);
			AuthTokenTXT.set_MaxLength(32767);
			((System.Windows.Forms.Control)(object)AuthTokenTXT).MinimumSize = new System.Drawing.Size(1, 1);
			AuthTokenTXT.set_Modified(false);
			AuthTokenTXT.set_Multiline(false);
			((System.Windows.Forms.Control)(object)AuthTokenTXT).Name = "AuthTokenTXT";
			val.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val.set_FillColor(System.Drawing.Color.Empty);
			val.set_ForeColor(System.Drawing.Color.Empty);
			val.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			AuthTokenTXT.set_OnActiveState(val);
			val2.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val2.set_FillColor(System.Drawing.Color.FromArgb(240, 240, 240));
			val2.set_ForeColor(System.Drawing.Color.FromArgb(109, 109, 109));
			val2.set_PlaceholderForeColor(System.Drawing.Color.DarkGray);
			AuthTokenTXT.set_OnDisabledState(val2);
			val3.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val3.set_FillColor(System.Drawing.Color.Empty);
			val3.set_ForeColor(System.Drawing.Color.Empty);
			val3.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			AuthTokenTXT.set_OnHoverState(val3);
			val4.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val4.set_FillColor(System.Drawing.Color.FromArgb(0, 0, 64));
			val4.set_ForeColor(System.Drawing.Color.White);
			val4.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			AuthTokenTXT.set_OnIdleState(val4);
			((System.Windows.Forms.Control)(object)AuthTokenTXT).Padding = new System.Windows.Forms.Padding(3);
			AuthTokenTXT.set_PasswordChar('\0');
			AuthTokenTXT.set_PlaceholderForeColor(System.Drawing.Color.Silver);
			AuthTokenTXT.set_PlaceholderText("XBL 3.0 Token");
			AuthTokenTXT.set_ReadOnly(false);
			AuthTokenTXT.set_ScrollBars(System.Windows.Forms.ScrollBars.None);
			AuthTokenTXT.set_SelectedText("");
			AuthTokenTXT.set_SelectionLength(0);
			AuthTokenTXT.set_SelectionStart(0);
			AuthTokenTXT.set_ShortcutsEnabled(true);
			((System.Windows.Forms.Control)(object)AuthTokenTXT).Size = new System.Drawing.Size(260, 41);
			AuthTokenTXT.set_Style((_Style)0);
			((System.Windows.Forms.Control)(object)AuthTokenTXT).TabIndex = 1;
			AuthTokenTXT.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Left);
			AuthTokenTXT.set_TextMarginBottom(0);
			AuthTokenTXT.set_TextMarginLeft(3);
			AuthTokenTXT.set_TextMarginTop(1);
			AuthTokenTXT.set_TextPlaceholder("XBL 3.0 Token");
			AuthTokenTXT.set_UseSystemPasswordChar(false);
			AuthTokenTXT.set_WordWrap(true);
			ClubTimer.Interval = 5000;
			ClubTimer.Tick += new System.EventHandler(ClubTimer_Tick);
			tabPage4.BackColor = System.Drawing.Color.Black;
			tabPage4.Controls.Add((System.Windows.Forms.Control)(object)StatusSpooferGroupBox);
			tabPage4.Controls.Add((System.Windows.Forms.Control)(object)ProfilePicToolsBox);
			tabPage4.Controls.Add(pictureBox4);
			tabPage4.Location = new System.Drawing.Point(4, 20);
			tabPage4.Name = "tabPage4";
			tabPage4.Size = new System.Drawing.Size(998, 458);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Misc";
			pictureBox2.Location = new System.Drawing.Point(-4, 3);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(1007, 458);
			pictureBox2.TabIndex = 15;
			pictureBox2.TabStop = false;
			pictureBox3.Location = new System.Drawing.Point(-4, 0);
			pictureBox3.Name = "pictureBox3";
			pictureBox3.Size = new System.Drawing.Size(1007, 462);
			pictureBox3.TabIndex = 17;
			pictureBox3.TabStop = false;
			pictureBox4.Location = new System.Drawing.Point(-4, 0);
			pictureBox4.Name = "pictureBox4";
			pictureBox4.Size = new System.Drawing.Size(1007, 462);
			pictureBox4.TabIndex = 15;
			pictureBox4.TabStop = false;
			ProfilePicToolsBox.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			ProfilePicToolsBox.set_BorderRadius(1);
			ProfilePicToolsBox.set_BorderThickness(5);
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).Controls.Add((System.Windows.Forms.Control)(object)SetPictureXboxBtn);
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).Controls.Add((System.Windows.Forms.Control)(object)XboxOneComboBox);
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold);
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).ForeColor = System.Drawing.Color.Lime;
			ProfilePicToolsBox.set_LabelAlign(System.Windows.Forms.HorizontalAlignment.Center);
			ProfilePicToolsBox.set_LabelIndent(10);
			ProfilePicToolsBox.set_LineStyle((LineStyles)0);
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).Location = new System.Drawing.Point(3, 3);
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).Name = "ProfilePicToolsBox";
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).Size = new System.Drawing.Size(300, 97);
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).TabIndex = 16;
			((System.Windows.Forms.GroupBox)(object)ProfilePicToolsBox).TabStop = false;
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).Text = "Xbox Modded PFP";
			((System.Windows.Forms.Control)(object)XboxOneComboBox).BackColor = System.Drawing.Color.Transparent;
			XboxOneComboBox.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			XboxOneComboBox.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.ComboBox)(object)XboxOneComboBox).DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			((System.Windows.Forms.ComboBox)(object)XboxOneComboBox).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			XboxOneComboBox.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)XboxOneComboBox).Font = new System.Drawing.Font("Segoe UI", 10f);
			((System.Windows.Forms.Control)(object)XboxOneComboBox).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.ListControl)(object)XboxOneComboBox).FormattingEnabled = true;
			((System.Windows.Forms.ComboBox)(object)XboxOneComboBox).Items.AddRange(new object[5] { "Green XBOX ONE Dev", "Transparent XBOX ONE Dev", "Blank Gray Profile", "Xbox 360 Picture", "Blank Profile Picture" });
			((System.Windows.Forms.Control)(object)XboxOneComboBox).Location = new System.Drawing.Point(8, 28);
			((System.Windows.Forms.Control)(object)XboxOneComboBox).Name = "XboxOneComboBox";
			XboxOneComboBox.set_OnHoverItemBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			XboxOneComboBox.set_OnHoverItemForeColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)XboxOneComboBox).Size = new System.Drawing.Size(284, 26);
			((System.Windows.Forms.Control)(object)XboxOneComboBox).TabIndex = 18;
			SetPictureXboxBtn.set_Animated(true);
			SetPictureXboxBtn.set_AnimationHoverSpeed(0.07f);
			SetPictureXboxBtn.set_AnimationSpeed(0.03f);
			SetPictureXboxBtn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetPictureXboxBtn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			SetPictureXboxBtn.set_BorderSize(3);
			SetPictureXboxBtn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			SetPictureXboxBtn.set_CheckedBorderColor(System.Drawing.Color.Black);
			SetPictureXboxBtn.set_CheckedForeColor(System.Drawing.Color.Black);
			SetPictureXboxBtn.set_CheckedImage((System.Drawing.Image)null);
			SetPictureXboxBtn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetPictureXboxBtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			SetPictureXboxBtn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)SetPictureXboxBtn).Font = new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)SetPictureXboxBtn).ForeColor = System.Drawing.Color.Black;
			SetPictureXboxBtn.set_Image((System.Drawing.Image)null);
			SetPictureXboxBtn.set_ImageSize(new System.Drawing.Size(20, 20));
			SetPictureXboxBtn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)SetPictureXboxBtn).Location = new System.Drawing.Point(8, 60);
			((System.Windows.Forms.Control)(object)SetPictureXboxBtn).Name = "SetPictureXboxBtn";
			SetPictureXboxBtn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetPictureXboxBtn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			SetPictureXboxBtn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			SetPictureXboxBtn.set_OnHoverImage((System.Drawing.Image)null);
			SetPictureXboxBtn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SetPictureXboxBtn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)SetPictureXboxBtn).Size = new System.Drawing.Size(284, 30);
			((System.Windows.Forms.Control)(object)SetPictureXboxBtn).TabIndex = 19;
			((System.Windows.Forms.Control)(object)SetPictureXboxBtn).Text = "Set Selected Profile Picture";
			SetPictureXboxBtn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)SetPictureXboxBtn).Click += new System.EventHandler(SetPictureXboxBtn_Click);
			StatusSpooferGroupBox.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			StatusSpooferGroupBox.set_BorderRadius(1);
			StatusSpooferGroupBox.set_BorderThickness(5);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Controls.Add((System.Windows.Forms.Control)(object)OnOffCheckBox);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Controls.Add((System.Windows.Forms.Control)(object)StopSpoofingbtn);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Controls.Add((System.Windows.Forms.Control)(object)CheckAppsCheckBox);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Controls.Add((System.Windows.Forms.Control)(object)CheckGamesCheckBox);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Controls.Add((System.Windows.Forms.Control)(object)SpoofStatusbtn2);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Controls.Add((System.Windows.Forms.Control)(object)SpoofStatusbtn);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Controls.Add((System.Windows.Forms.Control)(object)Number);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Controls.Add((System.Windows.Forms.Control)(object)AppsComboBox);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Controls.Add((System.Windows.Forms.Control)(object)GamesComboBox);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).ForeColor = System.Drawing.Color.Lime;
			StatusSpooferGroupBox.set_LabelAlign(System.Windows.Forms.HorizontalAlignment.Center);
			StatusSpooferGroupBox.set_LabelIndent(10);
			StatusSpooferGroupBox.set_LineStyle((LineStyles)0);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Location = new System.Drawing.Point(502, 3);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Name = "StatusSpooferGroupBox";
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Size = new System.Drawing.Size(496, 164);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).TabIndex = 17;
			((System.Windows.Forms.GroupBox)(object)StatusSpooferGroupBox).TabStop = false;
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).Text = "Xbox Status";
			((System.Windows.Forms.Control)(object)GamesComboBox).BackColor = System.Drawing.Color.Transparent;
			GamesComboBox.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			GamesComboBox.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.ComboBox)(object)GamesComboBox).DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			((System.Windows.Forms.ComboBox)(object)GamesComboBox).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			GamesComboBox.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)GamesComboBox).Font = new System.Drawing.Font("Segoe UI", 10f);
			((System.Windows.Forms.Control)(object)GamesComboBox).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.ListControl)(object)GamesComboBox).FormattingEnabled = true;
			((System.Windows.Forms.ComboBox)(object)GamesComboBox).Items.AddRange(new object[19]
			{
				"GTA V", "GTA IV", "GTA Vice City", "R6", "Modern Warfare [360]", "CoD Cold War", "Dying Light [PC]", "Rust", "Stranded Deep", "Subnautica",
				"Far Cry 6", "Black Ops 4", "Back 4 Blood", "Forza Horizon 5", "Hue", "CoD Vanguard", "Sonic Colors", "BattleField 2042", "San Andreas Definitive"
			});
			((System.Windows.Forms.Control)(object)GamesComboBox).Location = new System.Drawing.Point(9, 28);
			((System.Windows.Forms.Control)(object)GamesComboBox).Name = "GamesComboBox";
			GamesComboBox.set_OnHoverItemBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			GamesComboBox.set_OnHoverItemForeColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)GamesComboBox).Size = new System.Drawing.Size(284, 26);
			((System.Windows.Forms.Control)(object)GamesComboBox).TabIndex = 19;
			((System.Windows.Forms.Control)(object)AppsComboBox).BackColor = System.Drawing.Color.Transparent;
			AppsComboBox.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			AppsComboBox.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.ComboBox)(object)AppsComboBox).DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			((System.Windows.Forms.ComboBox)(object)AppsComboBox).DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			AppsComboBox.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)AppsComboBox).Font = new System.Drawing.Font("Segoe UI", 10f);
			((System.Windows.Forms.Control)(object)AppsComboBox).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.ListControl)(object)AppsComboBox).FormattingEnabled = true;
			((System.Windows.Forms.ComboBox)(object)AppsComboBox).Items.AddRange(new object[12]
			{
				"YouTube", "Netflix", "Hulu", "Twitch", "Hacked?", "IP Grabber 2", "Quarrel [Insider]", "Media Player", "Amazon Prime Video", "---------xxx----------",
				"Home", "Disney+"
			});
			((System.Windows.Forms.Control)(object)AppsComboBox).Location = new System.Drawing.Point(9, 28);
			((System.Windows.Forms.Control)(object)AppsComboBox).Name = "AppsComboBox";
			AppsComboBox.set_OnHoverItemBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			AppsComboBox.set_OnHoverItemForeColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)AppsComboBox).Size = new System.Drawing.Size(284, 26);
			((System.Windows.Forms.Control)(object)AppsComboBox).TabIndex = 20;
			Number.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Number.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)Number).Cursor = System.Windows.Forms.Cursors.IBeam;
			Number.set_FocusedBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Number.set_FocusedBorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			Number.set_FocusedForeColor(System.Drawing.SystemColors.ControlText);
			((System.Windows.Forms.Control)(object)Number).Font = new System.Drawing.Font("Arial Black", 11.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)Number).ForeColor = System.Drawing.Color.Black;
			((System.Windows.Forms.Control)(object)Number).Location = new System.Drawing.Point(9, 126);
			((System.Windows.Forms.Control)(object)Number).Name = "Number";
			Number.set_PasswordChar('\0');
			Number.set_SelectedText("");
			((System.Windows.Forms.Control)(object)Number).Size = new System.Drawing.Size(10, 32);
			((System.Windows.Forms.Control)(object)Number).TabIndex = 21;
			((System.Windows.Forms.Control)(object)Number).Text = "Gamertag";
			Number.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)Number).Visible = false;
			SpoofStatusbtn.set_Animated(true);
			SpoofStatusbtn.set_AnimationHoverSpeed(0.07f);
			SpoofStatusbtn.set_AnimationSpeed(0.03f);
			SpoofStatusbtn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SpoofStatusbtn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			SpoofStatusbtn.set_BorderSize(3);
			SpoofStatusbtn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			SpoofStatusbtn.set_CheckedBorderColor(System.Drawing.Color.Black);
			SpoofStatusbtn.set_CheckedForeColor(System.Drawing.Color.Black);
			SpoofStatusbtn.set_CheckedImage((System.Drawing.Image)null);
			SpoofStatusbtn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SpoofStatusbtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			SpoofStatusbtn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn).Font = new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn).ForeColor = System.Drawing.Color.Black;
			SpoofStatusbtn.set_Image((System.Drawing.Image)null);
			SpoofStatusbtn.set_ImageSize(new System.Drawing.Size(20, 20));
			SpoofStatusbtn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)SpoofStatusbtn).Location = new System.Drawing.Point(9, 60);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn).Name = "SpoofStatusbtn";
			SpoofStatusbtn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SpoofStatusbtn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			SpoofStatusbtn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			SpoofStatusbtn.set_OnHoverImage((System.Drawing.Image)null);
			SpoofStatusbtn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SpoofStatusbtn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn).Size = new System.Drawing.Size(284, 30);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn).TabIndex = 22;
			((System.Windows.Forms.Control)(object)SpoofStatusbtn).Text = "Spoof Status";
			SpoofStatusbtn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn).Click += new System.EventHandler(SpoofStatusbtn_Click);
			SpoofStatusbtn2.set_Animated(true);
			SpoofStatusbtn2.set_AnimationHoverSpeed(0.07f);
			SpoofStatusbtn2.set_AnimationSpeed(0.03f);
			SpoofStatusbtn2.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SpoofStatusbtn2.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			SpoofStatusbtn2.set_BorderSize(3);
			SpoofStatusbtn2.set_CheckedBaseColor(System.Drawing.Color.Lime);
			SpoofStatusbtn2.set_CheckedBorderColor(System.Drawing.Color.Black);
			SpoofStatusbtn2.set_CheckedForeColor(System.Drawing.Color.Black);
			SpoofStatusbtn2.set_CheckedImage((System.Drawing.Image)null);
			SpoofStatusbtn2.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SpoofStatusbtn2.set_DialogResult(System.Windows.Forms.DialogResult.None);
			SpoofStatusbtn2.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn2).Font = new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn2).ForeColor = System.Drawing.Color.Black;
			SpoofStatusbtn2.set_Image((System.Drawing.Image)null);
			SpoofStatusbtn2.set_ImageSize(new System.Drawing.Size(20, 20));
			SpoofStatusbtn2.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)SpoofStatusbtn2).Location = new System.Drawing.Point(9, 60);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn2).Name = "SpoofStatusbtn2";
			SpoofStatusbtn2.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SpoofStatusbtn2.set_OnHoverBorderColor(System.Drawing.Color.Black);
			SpoofStatusbtn2.set_OnHoverForeColor(System.Drawing.Color.Lime);
			SpoofStatusbtn2.set_OnHoverImage((System.Drawing.Image)null);
			SpoofStatusbtn2.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			SpoofStatusbtn2.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn2).Size = new System.Drawing.Size(284, 30);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn2).TabIndex = 23;
			((System.Windows.Forms.Control)(object)SpoofStatusbtn2).Text = "Spoof Status";
			SpoofStatusbtn2.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)SpoofStatusbtn2).Click += new System.EventHandler(SpoofStatusbtn2_Click);
			((System.Windows.Forms.Control)(object)CheckGamesCheckBox).BackColor = System.Drawing.Color.Transparent;
			CheckGamesCheckBox.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CheckGamesCheckBox.set_CheckedOffColor(System.Drawing.Color.Red);
			CheckGamesCheckBox.set_CheckedOnColor(System.Drawing.Color.Lime);
			CheckGamesCheckBox.set_FillColor(System.Drawing.Color.FromArgb(64, 0, 64));
			((System.Windows.Forms.Control)(object)CheckGamesCheckBox).Location = new System.Drawing.Point(299, 28);
			((System.Windows.Forms.Control)(object)CheckGamesCheckBox).Name = "CheckGamesCheckBox";
			((System.Windows.Forms.Control)(object)CheckGamesCheckBox).Size = new System.Drawing.Size(89, 25);
			((System.Windows.Forms.Control)(object)CheckGamesCheckBox).TabIndex = 24;
			((System.Windows.Forms.Control)(object)CheckGamesCheckBox).Text = "Games";
			CheckGamesCheckBox.add_CheckedChanged(new System.EventHandler(CheckGamesCheckBox_CheckedChanged));
			((System.Windows.Forms.Control)(object)CheckAppsCheckBox).BackColor = System.Drawing.Color.Transparent;
			CheckAppsCheckBox.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CheckAppsCheckBox.set_CheckedOffColor(System.Drawing.Color.Red);
			CheckAppsCheckBox.set_CheckedOnColor(System.Drawing.Color.Lime);
			CheckAppsCheckBox.set_FillColor(System.Drawing.Color.FromArgb(64, 0, 64));
			((System.Windows.Forms.Control)(object)CheckAppsCheckBox).Location = new System.Drawing.Point(299, 60);
			((System.Windows.Forms.Control)(object)CheckAppsCheckBox).Name = "CheckAppsCheckBox";
			((System.Windows.Forms.Control)(object)CheckAppsCheckBox).Size = new System.Drawing.Size(73, 25);
			((System.Windows.Forms.Control)(object)CheckAppsCheckBox).TabIndex = 25;
			((System.Windows.Forms.Control)(object)CheckAppsCheckBox).Text = "Apps";
			CheckAppsCheckBox.add_CheckedChanged(new System.EventHandler(CheckAppsCheckBox_CheckedChanged));
			StopSpoofingbtn.set_Animated(true);
			StopSpoofingbtn.set_AnimationHoverSpeed(0.07f);
			StopSpoofingbtn.set_AnimationSpeed(0.03f);
			StopSpoofingbtn.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			StopSpoofingbtn.set_BorderColor(System.Drawing.Color.FromArgb(64, 64, 64));
			StopSpoofingbtn.set_BorderSize(3);
			StopSpoofingbtn.set_CheckedBaseColor(System.Drawing.Color.Lime);
			StopSpoofingbtn.set_CheckedBorderColor(System.Drawing.Color.Black);
			StopSpoofingbtn.set_CheckedForeColor(System.Drawing.Color.Black);
			StopSpoofingbtn.set_CheckedImage((System.Drawing.Image)null);
			StopSpoofingbtn.set_CheckedLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			StopSpoofingbtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			StopSpoofingbtn.set_FocusedColor(System.Drawing.Color.Empty);
			((System.Windows.Forms.Control)(object)StopSpoofingbtn).Font = new System.Drawing.Font("Arial Black", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)StopSpoofingbtn).ForeColor = System.Drawing.Color.Black;
			StopSpoofingbtn.set_Image((System.Drawing.Image)null);
			StopSpoofingbtn.set_ImageSize(new System.Drawing.Size(20, 20));
			StopSpoofingbtn.set_LineColor(System.Drawing.Color.FromArgb(64, 64, 64));
			((System.Windows.Forms.Control)(object)StopSpoofingbtn).Location = new System.Drawing.Point(9, 96);
			((System.Windows.Forms.Control)(object)StopSpoofingbtn).Name = "StopSpoofingbtn";
			StopSpoofingbtn.set_OnHoverBaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			StopSpoofingbtn.set_OnHoverBorderColor(System.Drawing.Color.Black);
			StopSpoofingbtn.set_OnHoverForeColor(System.Drawing.Color.Lime);
			StopSpoofingbtn.set_OnHoverImage((System.Drawing.Image)null);
			StopSpoofingbtn.set_OnHoverLineColor(System.Drawing.Color.FromArgb(64, 0, 64));
			StopSpoofingbtn.set_OnPressedColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)StopSpoofingbtn).Size = new System.Drawing.Size(284, 30);
			((System.Windows.Forms.Control)(object)StopSpoofingbtn).TabIndex = 26;
			((System.Windows.Forms.Control)(object)StopSpoofingbtn).Text = "Stop Spoofing";
			StopSpoofingbtn.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Center);
			((System.Windows.Forms.Control)(object)StopSpoofingbtn).Click += new System.EventHandler(StopSpoofingbtn_Click);
			((System.Windows.Forms.Control)(object)OnOffCheckBox).BackColor = System.Drawing.Color.Transparent;
			OnOffCheckBox.set_BaseColor(System.Drawing.Color.FromArgb(64, 0, 64));
			OnOffCheckBox.set_CheckedOffColor(System.Drawing.Color.Red);
			OnOffCheckBox.set_CheckedOnColor(System.Drawing.Color.Lime);
			OnOffCheckBox.set_FillColor(System.Drawing.Color.FromArgb(64, 0, 64));
			((System.Windows.Forms.Control)(object)OnOffCheckBox).Location = new System.Drawing.Point(299, 96);
			((System.Windows.Forms.Control)(object)OnOffCheckBox).Name = "OnOffCheckBox";
			((System.Windows.Forms.Control)(object)OnOffCheckBox).Size = new System.Drawing.Size(190, 25);
			((System.Windows.Forms.Control)(object)OnOffCheckBox).TabIndex = 27;
			((System.Windows.Forms.Control)(object)OnOffCheckBox).Text = "Spam Online/Offline";
			OnOffCheckBox.add_CheckedChanged(new System.EventHandler(OnOffCheckBox_CheckedChanged));
			OnOffSpam.Interval = 3700;
			OnOffSpam.Tick += new System.EventHandler(OnOffSpam_Tick_1);
			Closebtn.set_AllowAnimations(true);
			Closebtn.set_AllowMouseEffects(true);
			Closebtn.set_AllowToggling(false);
			Closebtn.set_AnimationSpeed(200);
			Closebtn.set_AutoGenerateColors(false);
			Closebtn.set_AutoRoundBorders(false);
			Closebtn.set_AutoSizeLeftIcon(true);
			Closebtn.set_AutoSizeRightIcon(true);
			((System.Windows.Forms.Control)(object)Closebtn).BackColor = System.Drawing.Color.Transparent;
			Closebtn.set_BackColor1(System.Drawing.Color.FromArgb(51, 122, 183));
			((System.Windows.Forms.Control)(object)Closebtn).BackgroundImage = (System.Drawing.Image)resources.GetObject("Closebtn.BackgroundImage");
			Closebtn.set_BorderStyle((BorderStyles)0);
			Closebtn.set_ButtonText("X");
			Closebtn.set_ButtonTextMarginLeft(0);
			Closebtn.set_ColorContrastOnClick(45);
			Closebtn.set_ColorContrastOnHover(45);
			((System.Windows.Forms.Control)(object)Closebtn).Cursor = System.Windows.Forms.Cursors.Default;
			val5.set_BottomLeft(true);
			val5.set_BottomRight(true);
			val5.set_TopLeft(true);
			val5.set_TopRight(true);
			Closebtn.set_CustomizableEdges(val5);
			Closebtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			Closebtn.set_DisabledBorderColor(System.Drawing.Color.FromArgb(191, 191, 191));
			Closebtn.set_DisabledFillColor(System.Drawing.Color.Empty);
			Closebtn.set_DisabledForecolor(System.Drawing.Color.Empty);
			Closebtn.set_FocusState((ButtonStates)2);
			((System.Windows.Forms.Control)(object)Closebtn).Font = new System.Drawing.Font("Arial Black", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)Closebtn).ForeColor = System.Drawing.Color.White;
			Closebtn.set_IconLeft((System.Drawing.Image)null);
			Closebtn.set_IconLeftAlign(System.Drawing.ContentAlignment.MiddleLeft);
			Closebtn.set_IconLeftCursor(System.Windows.Forms.Cursors.Default);
			Closebtn.set_IconLeftPadding(new System.Windows.Forms.Padding(11, 3, 3, 3));
			Closebtn.set_IconMarginLeft(11);
			Closebtn.set_IconPadding(10);
			Closebtn.set_IconRight((System.Drawing.Image)null);
			Closebtn.set_IconRightAlign(System.Drawing.ContentAlignment.MiddleRight);
			Closebtn.set_IconRightCursor(System.Windows.Forms.Cursors.Default);
			Closebtn.set_IconRightPadding(new System.Windows.Forms.Padding(3, 3, 7, 3));
			Closebtn.set_IconSize(25);
			Closebtn.set_IdleBorderColor(System.Drawing.Color.Empty);
			Closebtn.set_IdleBorderRadius(0);
			Closebtn.set_IdleBorderThickness(0);
			Closebtn.set_IdleFillColor(System.Drawing.Color.Empty);
			Closebtn.set_IdleIconLeftImage((System.Drawing.Image)null);
			Closebtn.set_IdleIconRightImage((System.Drawing.Image)null);
			Closebtn.set_IndicateFocus(false);
			((System.Windows.Forms.Control)(object)Closebtn).Location = new System.Drawing.Point(963, 3);
			((System.Windows.Forms.Control)(object)Closebtn).Name = "Closebtn";
			Closebtn.get_OnDisabledState().set_BorderColor(System.Drawing.Color.Black);
			Closebtn.get_OnDisabledState().set_BorderRadius(1);
			Closebtn.get_OnDisabledState().set_BorderStyle((BorderStyles)0);
			Closebtn.get_OnDisabledState().set_BorderThickness(1);
			Closebtn.get_OnDisabledState().set_FillColor(System.Drawing.Color.Transparent);
			Closebtn.get_OnDisabledState().set_ForeColor(System.Drawing.Color.White);
			Closebtn.get_OnDisabledState().set_IconLeftImage((System.Drawing.Image)null);
			Closebtn.get_OnDisabledState().set_IconRightImage((System.Drawing.Image)null);
			Closebtn.get_onHoverState().set_BorderColor(System.Drawing.Color.Black);
			Closebtn.get_onHoverState().set_BorderRadius(1);
			Closebtn.get_onHoverState().set_BorderStyle((BorderStyles)0);
			Closebtn.get_onHoverState().set_BorderThickness(1);
			Closebtn.get_onHoverState().set_FillColor(System.Drawing.Color.Transparent);
			Closebtn.get_onHoverState().set_ForeColor(System.Drawing.Color.White);
			Closebtn.get_onHoverState().set_IconLeftImage((System.Drawing.Image)null);
			Closebtn.get_onHoverState().set_IconRightImage((System.Drawing.Image)null);
			Closebtn.get_OnIdleState().set_BorderColor(System.Drawing.Color.Black);
			Closebtn.get_OnIdleState().set_BorderRadius(1);
			Closebtn.get_OnIdleState().set_BorderStyle((BorderStyles)0);
			Closebtn.get_OnIdleState().set_BorderThickness(1);
			Closebtn.get_OnIdleState().set_FillColor(System.Drawing.Color.Transparent);
			Closebtn.get_OnIdleState().set_ForeColor(System.Drawing.Color.White);
			Closebtn.get_OnIdleState().set_IconLeftImage((System.Drawing.Image)null);
			Closebtn.get_OnIdleState().set_IconRightImage((System.Drawing.Image)null);
			Closebtn.get_OnPressedState().set_BorderColor(System.Drawing.Color.Black);
			Closebtn.get_OnPressedState().set_BorderRadius(1);
			Closebtn.get_OnPressedState().set_BorderStyle((BorderStyles)0);
			Closebtn.get_OnPressedState().set_BorderThickness(1);
			Closebtn.get_OnPressedState().set_FillColor(System.Drawing.Color.Black);
			Closebtn.get_OnPressedState().set_ForeColor(System.Drawing.Color.Wheat);
			Closebtn.get_OnPressedState().set_IconLeftImage((System.Drawing.Image)null);
			Closebtn.get_OnPressedState().set_IconRightImage((System.Drawing.Image)null);
			((System.Windows.Forms.Control)(object)Closebtn).Size = new System.Drawing.Size(36, 30);
			((System.Windows.Forms.Control)(object)Closebtn).TabIndex = 14;
			Closebtn.set_TextAlign(System.Drawing.ContentAlignment.MiddleCenter);
			Closebtn.set_TextAlignment(System.Windows.Forms.HorizontalAlignment.Center);
			Closebtn.set_TextMarginLeft(0);
			Closebtn.set_TextPadding(new System.Windows.Forms.Padding(0));
			Closebtn.set_UseDefaultRadiusAndThickness(true);
			((System.Windows.Forms.Control)(object)Closebtn).Click += new System.EventHandler(Closebtn_Click);
			Minimizebtn.set_AllowAnimations(true);
			Minimizebtn.set_AllowMouseEffects(true);
			Minimizebtn.set_AllowToggling(false);
			Minimizebtn.set_AnimationSpeed(200);
			Minimizebtn.set_AutoGenerateColors(false);
			Minimizebtn.set_AutoRoundBorders(false);
			Minimizebtn.set_AutoSizeLeftIcon(true);
			Minimizebtn.set_AutoSizeRightIcon(true);
			((System.Windows.Forms.Control)(object)Minimizebtn).BackColor = System.Drawing.Color.Transparent;
			Minimizebtn.set_BackColor1(System.Drawing.Color.FromArgb(51, 122, 183));
			((System.Windows.Forms.Control)(object)Minimizebtn).BackgroundImage = (System.Drawing.Image)resources.GetObject("Minimizebtn.BackgroundImage");
			Minimizebtn.set_BorderStyle((BorderStyles)0);
			Minimizebtn.set_ButtonText("-");
			Minimizebtn.set_ButtonTextMarginLeft(0);
			Minimizebtn.set_ColorContrastOnClick(45);
			Minimizebtn.set_ColorContrastOnHover(45);
			((System.Windows.Forms.Control)(object)Minimizebtn).Cursor = System.Windows.Forms.Cursors.Default;
			val6.set_BottomLeft(true);
			val6.set_BottomRight(true);
			val6.set_TopLeft(true);
			val6.set_TopRight(true);
			Minimizebtn.set_CustomizableEdges(val6);
			Minimizebtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			Minimizebtn.set_DisabledBorderColor(System.Drawing.Color.FromArgb(191, 191, 191));
			Minimizebtn.set_DisabledFillColor(System.Drawing.Color.Empty);
			Minimizebtn.set_DisabledForecolor(System.Drawing.Color.Empty);
			Minimizebtn.set_FocusState((ButtonStates)2);
			((System.Windows.Forms.Control)(object)Minimizebtn).Font = new System.Drawing.Font("Arial Black", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			((System.Windows.Forms.Control)(object)Minimizebtn).ForeColor = System.Drawing.Color.White;
			Minimizebtn.set_IconLeft((System.Drawing.Image)null);
			Minimizebtn.set_IconLeftAlign(System.Drawing.ContentAlignment.MiddleLeft);
			Minimizebtn.set_IconLeftCursor(System.Windows.Forms.Cursors.Default);
			Minimizebtn.set_IconLeftPadding(new System.Windows.Forms.Padding(11, 3, 3, 3));
			Minimizebtn.set_IconMarginLeft(11);
			Minimizebtn.set_IconPadding(10);
			Minimizebtn.set_IconRight((System.Drawing.Image)null);
			Minimizebtn.set_IconRightAlign(System.Drawing.ContentAlignment.MiddleRight);
			Minimizebtn.set_IconRightCursor(System.Windows.Forms.Cursors.Default);
			Minimizebtn.set_IconRightPadding(new System.Windows.Forms.Padding(3, 3, 7, 3));
			Minimizebtn.set_IconSize(25);
			Minimizebtn.set_IdleBorderColor(System.Drawing.Color.Empty);
			Minimizebtn.set_IdleBorderRadius(0);
			Minimizebtn.set_IdleBorderThickness(0);
			Minimizebtn.set_IdleFillColor(System.Drawing.Color.Empty);
			Minimizebtn.set_IdleIconLeftImage((System.Drawing.Image)null);
			Minimizebtn.set_IdleIconRightImage((System.Drawing.Image)null);
			Minimizebtn.set_IndicateFocus(false);
			((System.Windows.Forms.Control)(object)Minimizebtn).Location = new System.Drawing.Point(925, 3);
			((System.Windows.Forms.Control)(object)Minimizebtn).Name = "Minimizebtn";
			Minimizebtn.get_OnDisabledState().set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			Minimizebtn.get_OnDisabledState().set_BorderRadius(1);
			Minimizebtn.get_OnDisabledState().set_BorderStyle((BorderStyles)0);
			Minimizebtn.get_OnDisabledState().set_BorderThickness(1);
			Minimizebtn.get_OnDisabledState().set_FillColor(System.Drawing.Color.Transparent);
			Minimizebtn.get_OnDisabledState().set_ForeColor(System.Drawing.Color.White);
			Minimizebtn.get_OnDisabledState().set_IconLeftImage((System.Drawing.Image)null);
			Minimizebtn.get_OnDisabledState().set_IconRightImage((System.Drawing.Image)null);
			Minimizebtn.get_onHoverState().set_BorderColor(System.Drawing.Color.Black);
			Minimizebtn.get_onHoverState().set_BorderRadius(1);
			Minimizebtn.get_onHoverState().set_BorderStyle((BorderStyles)0);
			Minimizebtn.get_onHoverState().set_BorderThickness(1);
			Minimizebtn.get_onHoverState().set_FillColor(System.Drawing.Color.Transparent);
			Minimizebtn.get_onHoverState().set_ForeColor(System.Drawing.Color.White);
			Minimizebtn.get_onHoverState().set_IconLeftImage((System.Drawing.Image)null);
			Minimizebtn.get_onHoverState().set_IconRightImage((System.Drawing.Image)null);
			Minimizebtn.get_OnIdleState().set_BorderColor(System.Drawing.Color.Black);
			Minimizebtn.get_OnIdleState().set_BorderRadius(1);
			Minimizebtn.get_OnIdleState().set_BorderStyle((BorderStyles)0);
			Minimizebtn.get_OnIdleState().set_BorderThickness(1);
			Minimizebtn.get_OnIdleState().set_FillColor(System.Drawing.Color.Transparent);
			Minimizebtn.get_OnIdleState().set_ForeColor(System.Drawing.Color.White);
			Minimizebtn.get_OnIdleState().set_IconLeftImage((System.Drawing.Image)null);
			Minimizebtn.get_OnIdleState().set_IconRightImage((System.Drawing.Image)null);
			Minimizebtn.get_OnPressedState().set_BorderColor(System.Drawing.Color.Black);
			Minimizebtn.get_OnPressedState().set_BorderRadius(1);
			Minimizebtn.get_OnPressedState().set_BorderStyle((BorderStyles)0);
			Minimizebtn.get_OnPressedState().set_BorderThickness(1);
			Minimizebtn.get_OnPressedState().set_FillColor(System.Drawing.Color.Transparent);
			Minimizebtn.get_OnPressedState().set_ForeColor(System.Drawing.Color.White);
			Minimizebtn.get_OnPressedState().set_IconLeftImage((System.Drawing.Image)null);
			Minimizebtn.get_OnPressedState().set_IconRightImage((System.Drawing.Image)null);
			((System.Windows.Forms.Control)(object)Minimizebtn).Size = new System.Drawing.Size(36, 30);
			((System.Windows.Forms.Control)(object)Minimizebtn).TabIndex = 13;
			Minimizebtn.set_TextAlign(System.Drawing.ContentAlignment.MiddleCenter);
			Minimizebtn.set_TextAlignment(System.Windows.Forms.HorizontalAlignment.Center);
			Minimizebtn.set_TextMarginLeft(0);
			Minimizebtn.set_TextPadding(new System.Windows.Forms.Padding(0));
			Minimizebtn.set_UseDefaultRadiusAndThickness(true);
			((System.Windows.Forms.Control)(object)Minimizebtn).Click += new System.EventHandler(Minimizebtn_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(1004, 525);
			base.Controls.Add(panel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Main";
			base.Load += new System.EventHandler(Main_Load);
			panel1.ResumeLayout(false);
			((System.Windows.Forms.Control)(object)xuiFlatTab1).ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			tabPage2.ResumeLayout(false);
			((System.Windows.Forms.Control)(object)XboxOneModdedAvatar).ResumeLayout(false);
			((System.Windows.Forms.Control)(object)X360AvatarCustomisation).ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)X360PictureBox2).EndInit();
			((System.Windows.Forms.Control)(object)Xbox360AvatarViewer).ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)X360PictureBox).EndInit();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			((System.Windows.Forms.Control)(object)CretaeClubGroupBox).ResumeLayout(false);
			tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
			((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
			((System.Windows.Forms.Control)(object)ProfilePicToolsBox).ResumeLayout(false);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).ResumeLayout(false);
			((System.Windows.Forms.Control)(object)StatusSpooferGroupBox).PerformLayout();
			ResumeLayout(false);
		}
	}
}
