using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Best_AIO_Tool.Forms;
using Best_AIO_Tool.Properties;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using Xbox_AIO_By_Intg.Properties;
using XBOX_AIO_TOOl;

namespace Xbox_AIO_By_Intg
{
	public class Login : Form
	{
		private int r = 255;

		private int g;

		private int b;

		private int MouseX;

		private int Mousey;

		private bool MouseM;

		private IContainer components;

		private BunifuElipse bunifuElipse1;

		private Timer timer1;

		private PictureBox pictureBox1;

		private BunifuElipse bunifuElipse2;

		private BunifuElipse bunifuElipse3;

		private BunifuElipse bunifuElipse4;

		private BunifuTextBox UsernameTXT;

		private BunifuCheckBox CheckRememberMe;

		private BunifuTextBox PasswordTXT;

		private BunifuLabel RememberMeLabel;

		private BunifuButton2 Registerbtn;

		private BunifuButton2 LoginBtn;

		private BunifuLabel ShowPasswordLabel;

		private BunifuCheckBox CheckShowPassword;

		private Timer Fade1;

		private Timer Fade2;

		private Timer Fade3;

		private Timer KillProc;

		private BunifuButton Closebtn;

		private BunifuButton Minimizebtn;

		public Login()
		{
			InitializeComponent();
			KillProc.Start();
		}

		public void Alert(string msg, Notify.enmType type)
		{
			Notify notify = new Notify();
			notify.showAlert(msg, type);
		}

		private void Login_Load(object sender, EventArgs e)
		{
			timer1.Start();
			((Control)(object)Closebtn).Parent = pictureBox1;
			((Control)(object)Minimizebtn).Parent = pictureBox1;
			((Control)(object)CheckRememberMe).Parent = pictureBox1;
			((Control)(object)RememberMeLabel).Parent = pictureBox1;
			((Control)(object)CheckShowPassword).Parent = pictureBox1;
			((Control)(object)ShowPasswordLabel).Parent = pictureBox1;
			((Control)(object)LoginBtn).Parent = pictureBox1;
			((Control)(object)Registerbtn).Parent = pictureBox1;
			if (Settings.Default.Username != string.Empty)
			{
				UsernameTXT.set_Text(Settings.Default.Username);
				PasswordTXT.set_Text(Settings.Default.Password);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			UsernameTXT.set_BorderColorIdle(Color.FromArgb(r, g, b));
			PasswordTXT.set_BorderColorIdle(Color.FromArgb(r, g, b));
			LoginBtn.set_IdleBorderColor(Color.FromArgb(r, g, b));
			Registerbtn.set_IdleBorderColor(Color.FromArgb(r, g, b));
			if (r > 0 && b == 0)
			{
				r--;
				g++;
			}
			if (g > 0 && r == 0)
			{
				g--;
				b++;
			}
			if (b > 0 && g == 0)
			{
				b--;
				r++;
			}
		}

		private void LoginBtn_Click(object sender, EventArgs e)
		{
			if (API.Login(UsernameTXT.get_Text(), PasswordTXT.get_Text()))
			{
				MessageBox.Show("Login successful!", "LMFAO Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				Main main = new Main();
				main.Show();
				Hide();
			}
			if (CheckRememberMe.get_Checked())
			{
				Settings.Default.Username = UsernameTXT.get_Text();
				Settings.Default.Password = PasswordTXT.get_Text();
				Settings.Default.Save();
			}
			if (!CheckRememberMe.get_Checked())
			{
				Settings.Default.Username = "";
				Settings.Default.Password = "";
				Settings.Default.Save();
			}
		}

		private void Registerbtn_Click(object sender, EventArgs e)
		{
			Hide();
			Register register = new Register();
			register.Show();
		}

		private void CheckRememberMe_CheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			if (CheckRememberMe.get_Checked())
			{
				Settings.Default.Username = UsernameTXT.get_Text();
				Settings.Default.Password = PasswordTXT.get_Text();
				Settings.Default.Save();
			}
		}

		private void CheckShowPassword_CheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			if (CheckShowPassword.get_Checked())
			{
				PasswordTXT.set_UseSystemPasswordChar(true);
				CheckBox checkBox = (CheckBox)sender;
				checkBox.Text = "Hide";
			}
			else
			{
				PasswordTXT.set_UseSystemPasswordChar(false);
				CheckBox checkBox2 = (CheckBox)sender;
				checkBox2.Text = "Show";
			}
		}

		private void Closebtn_Click(object sender, EventArgs e)
		{
			Application.ExitThread();
			Close();
		}

		private void Minimizebtn_Click_1(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void Fade1_Tick(object sender, EventArgs e)
		{
			if (base.Opacity == 1.0)
			{
				Fade1.Stop();
			}
			base.Opacity += 0.2;
		}

		private void Fade2_Tick(object sender, EventArgs e)
		{
			if (base.Opacity <= 0.0)
			{
				Close();
			}
			base.Opacity += 0.2;
		}

		private void Fade3_Tick(object sender, EventArgs e)
		{
			if (base.Opacity > 0.0)
			{
				base.Opacity -= 0.025;
				return;
			}
			Fade3.Stop();
			Application.Exit();
		}

		private void KillProc_Tick(object sender, EventArgs e)
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				if (process.ProcessName == "LANC Remastered")
				{
					process.Kill();
					Alert("Blocked:       " + process.ProcessName, Notify.enmType.Warning);
				}
				if (process.ProcessName == "PCPS")
				{
					process.Kill();
					Alert("Blocked:       " + process.ProcessName, Notify.enmType.Warning);
				}
			}
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			MouseX = e.X;
			Mousey = e.Y;
			MouseM = true;
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (MouseM)
			{
				SetDesktopLocation(Control.MousePosition.X - MouseX, Control.MousePosition.Y - Mousey);
			}
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			MouseM = false;
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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0035: Expected O, but got Unknown
			//IL_0035: Unknown result type (might be due to invalid IL or missing references)
			//IL_003c: Expected O, but got Unknown
			//IL_003c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0043: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004a: Expected O, but got Unknown
			//IL_004a: Unknown result type (might be due to invalid IL or missing references)
			//IL_0051: Expected O, but got Unknown
			//IL_0051: Unknown result type (might be due to invalid IL or missing references)
			//IL_0058: Expected O, but got Unknown
			//IL_0058: Unknown result type (might be due to invalid IL or missing references)
			//IL_005f: Expected O, but got Unknown
			//IL_005f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0066: Expected O, but got Unknown
			//IL_0066: Unknown result type (might be due to invalid IL or missing references)
			//IL_006d: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007e: Expected O, but got Unknown
			//IL_0096: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a0: Expected O, but got Unknown
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00bc: Expected O, but got Unknown
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Expected O, but got Unknown
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected O, but got Unknown
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f9: Expected O, but got Unknown
			//IL_012d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0137: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0142: Expected O, but got Unknown
			//IL_0143: Unknown result type (might be due to invalid IL or missing references)
			//IL_014d: Expected O, but got Unknown
			//IL_014e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0158: Expected O, but got Unknown
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0163: Expected O, but got Unknown
			//IL_0164: Unknown result type (might be due to invalid IL or missing references)
			//IL_016e: Expected O, but got Unknown
			components = new System.ComponentModel.Container();
			BorderEdges val = new BorderEdges();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Xbox_AIO_By_Intg.Login));
			BorderEdges val2 = new BorderEdges();
			BorderEdges val3 = new BorderEdges();
			BorderEdges val4 = new BorderEdges();
			StateProperties val5 = new StateProperties();
			StateProperties val6 = new StateProperties();
			StateProperties val7 = new StateProperties();
			StateProperties val8 = new StateProperties();
			StateProperties val9 = new StateProperties();
			StateProperties val10 = new StateProperties();
			StateProperties val11 = new StateProperties();
			StateProperties val12 = new StateProperties();
			bunifuElipse1 = new BunifuElipse(components);
			timer1 = new System.Windows.Forms.Timer(components);
			bunifuElipse2 = new BunifuElipse(components);
			pictureBox1 = new System.Windows.Forms.PictureBox();
			bunifuElipse3 = new BunifuElipse(components);
			Minimizebtn = new BunifuButton();
			bunifuElipse4 = new BunifuElipse(components);
			Closebtn = new BunifuButton();
			RememberMeLabel = new BunifuLabel();
			ShowPasswordLabel = new BunifuLabel();
			Fade1 = new System.Windows.Forms.Timer(components);
			Fade2 = new System.Windows.Forms.Timer(components);
			Fade3 = new System.Windows.Forms.Timer(components);
			Registerbtn = new BunifuButton2();
			LoginBtn = new BunifuButton2();
			CheckShowPassword = new BunifuCheckBox();
			CheckRememberMe = new BunifuCheckBox();
			PasswordTXT = new BunifuTextBox();
			UsernameTXT = new BunifuTextBox();
			KillProc = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			bunifuElipse1.set_ElipseRadius(15);
			bunifuElipse1.set_TargetControl((System.Windows.Forms.Control)this);
			timer1.Interval = 1;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			bunifuElipse2.set_ElipseRadius(15);
			bunifuElipse2.set_TargetControl((System.Windows.Forms.Control)pictureBox1);
			pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			pictureBox1.Image = Best_AIO_Tool.Properties.Resources.rsz_1606024;
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(372, 294);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseDown);
			pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseMove);
			pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseUp);
			bunifuElipse3.set_ElipseRadius(5);
			bunifuElipse3.set_TargetControl((System.Windows.Forms.Control)(object)Minimizebtn);
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
			val.set_BottomLeft(true);
			val.set_BottomRight(true);
			val.set_TopLeft(true);
			val.set_TopRight(true);
			Minimizebtn.set_CustomizableEdges(val);
			Minimizebtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			Minimizebtn.set_DisabledBorderColor(System.Drawing.Color.FromArgb(191, 191, 191));
			Minimizebtn.set_DisabledFillColor(System.Drawing.Color.Empty);
			Minimizebtn.set_DisabledForecolor(System.Drawing.Color.Empty);
			Minimizebtn.set_FocusState((ButtonStates)2);
			((System.Windows.Forms.Control)(object)Minimizebtn).Font = new System.Drawing.Font("Segoe UI", 9f);
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
			((System.Windows.Forms.Control)(object)Minimizebtn).Location = new System.Drawing.Point(294, 0);
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
			((System.Windows.Forms.Control)(object)Minimizebtn).TabIndex = 11;
			Minimizebtn.set_TextAlign(System.Drawing.ContentAlignment.MiddleCenter);
			Minimizebtn.set_TextAlignment(System.Windows.Forms.HorizontalAlignment.Center);
			Minimizebtn.set_TextMarginLeft(0);
			Minimizebtn.set_TextPadding(new System.Windows.Forms.Padding(0));
			Minimizebtn.set_UseDefaultRadiusAndThickness(true);
			((System.Windows.Forms.Control)(object)Minimizebtn).Click += new System.EventHandler(Minimizebtn_Click_1);
			bunifuElipse4.set_ElipseRadius(5);
			bunifuElipse4.set_TargetControl((System.Windows.Forms.Control)(object)Closebtn);
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
			val2.set_BottomLeft(true);
			val2.set_BottomRight(true);
			val2.set_TopLeft(true);
			val2.set_TopRight(true);
			Closebtn.set_CustomizableEdges(val2);
			Closebtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			Closebtn.set_DisabledBorderColor(System.Drawing.Color.FromArgb(191, 191, 191));
			Closebtn.set_DisabledFillColor(System.Drawing.Color.Empty);
			Closebtn.set_DisabledForecolor(System.Drawing.Color.Empty);
			Closebtn.set_FocusState((ButtonStates)2);
			((System.Windows.Forms.Control)(object)Closebtn).Font = new System.Drawing.Font("Segoe UI", 9f);
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
			((System.Windows.Forms.Control)(object)Closebtn).Location = new System.Drawing.Point(336, 0);
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
			((System.Windows.Forms.Control)(object)Closebtn).TabIndex = 12;
			Closebtn.set_TextAlign(System.Drawing.ContentAlignment.MiddleCenter);
			Closebtn.set_TextAlignment(System.Windows.Forms.HorizontalAlignment.Center);
			Closebtn.set_TextMarginLeft(0);
			Closebtn.set_TextPadding(new System.Windows.Forms.Padding(0));
			Closebtn.set_UseDefaultRadiusAndThickness(true);
			((System.Windows.Forms.Control)(object)Closebtn).Click += new System.EventHandler(Closebtn_Click);
			RememberMeLabel.set_AllowParentOverrides(false);
			RememberMeLabel.set_AutoEllipsis(true);
			((System.Windows.Forms.Control)(object)RememberMeLabel).AutoSize = false;
			RememberMeLabel.set_Cursor(System.Windows.Forms.Cursors.Default);
			RememberMeLabel.set_CursorType(System.Windows.Forms.Cursors.Default);
			RememberMeLabel.set_Font(new System.Drawing.Font("Segoe UI", 9f));
			RememberMeLabel.set_ForeColor(System.Drawing.Color.Gray);
			((System.Windows.Forms.Control)(object)RememberMeLabel).Location = new System.Drawing.Point(39, 124);
			((System.Windows.Forms.Control)(object)RememberMeLabel).Name = "RememberMeLabel";
			((System.Windows.Forms.Control)(object)RememberMeLabel).RightToLeft = System.Windows.Forms.RightToLeft.No;
			((System.Windows.Forms.Control)(object)RememberMeLabel).Size = new System.Drawing.Size(90, 21);
			((System.Windows.Forms.Control)(object)RememberMeLabel).TabIndex = 6;
			((System.Windows.Forms.Control)(object)RememberMeLabel).Text = "Remember Me";
			RememberMeLabel.set_TextAlignment(System.Drawing.ContentAlignment.MiddleCenter);
			RememberMeLabel.set_TextFormat((TextFormattingOptions)0);
			ShowPasswordLabel.set_AllowParentOverrides(false);
			ShowPasswordLabel.set_AutoEllipsis(true);
			((System.Windows.Forms.Control)(object)ShowPasswordLabel).AutoSize = false;
			ShowPasswordLabel.set_CursorType((System.Windows.Forms.Cursor)null);
			ShowPasswordLabel.set_Font(new System.Drawing.Font("Segoe UI", 9f));
			ShowPasswordLabel.set_ForeColor(System.Drawing.Color.Gray);
			((System.Windows.Forms.Control)(object)ShowPasswordLabel).Location = new System.Drawing.Point(270, 124);
			((System.Windows.Forms.Control)(object)ShowPasswordLabel).Name = "ShowPasswordLabel";
			((System.Windows.Forms.Control)(object)ShowPasswordLabel).RightToLeft = System.Windows.Forms.RightToLeft.No;
			((System.Windows.Forms.Control)(object)ShowPasswordLabel).Size = new System.Drawing.Size(90, 21);
			((System.Windows.Forms.Control)(object)ShowPasswordLabel).TabIndex = 8;
			((System.Windows.Forms.Control)(object)ShowPasswordLabel).Text = "Show Password";
			ShowPasswordLabel.set_TextAlignment(System.Drawing.ContentAlignment.MiddleCenter);
			ShowPasswordLabel.set_TextFormat((TextFormattingOptions)0);
			((System.Windows.Forms.Control)(object)ShowPasswordLabel).Visible = false;
			Fade1.Tick += new System.EventHandler(Fade1_Tick);
			Fade2.Enabled = true;
			Fade2.Interval = 30;
			Fade2.Tick += new System.EventHandler(Fade2_Tick);
			Fade3.Tick += new System.EventHandler(Fade3_Tick);
			Registerbtn.set_AllowAnimations(true);
			Registerbtn.set_AllowMouseEffects(true);
			Registerbtn.set_AllowToggling(false);
			Registerbtn.set_AnimationSpeed(200);
			Registerbtn.set_AutoGenerateColors(false);
			Registerbtn.set_AutoRoundBorders(false);
			Registerbtn.set_AutoSizeLeftIcon(true);
			Registerbtn.set_AutoSizeRightIcon(true);
			((System.Windows.Forms.Control)(object)Registerbtn).BackColor = System.Drawing.Color.Transparent;
			Registerbtn.set_BackColor1(System.Drawing.Color.Transparent);
			((System.Windows.Forms.Control)(object)Registerbtn).BackgroundImage = (System.Drawing.Image)resources.GetObject("Registerbtn.BackgroundImage");
			Registerbtn.set_BorderStyle((BorderStyles)0);
			Registerbtn.set_ButtonText("Register");
			Registerbtn.set_ButtonTextMarginLeft(0);
			Registerbtn.set_ColorContrastOnClick(45);
			Registerbtn.set_ColorContrastOnHover(45);
			((System.Windows.Forms.Control)(object)Registerbtn).Cursor = System.Windows.Forms.Cursors.Default;
			val3.set_BottomLeft(true);
			val3.set_BottomRight(true);
			val3.set_TopLeft(true);
			val3.set_TopRight(true);
			Registerbtn.set_CustomizableEdges(val3);
			Registerbtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			Registerbtn.set_DisabledBorderColor(System.Drawing.Color.Transparent);
			Registerbtn.set_DisabledFillColor(System.Drawing.Color.Transparent);
			Registerbtn.set_DisabledForecolor(System.Drawing.Color.FromArgb(168, 160, 168));
			Registerbtn.set_FocusState((ButtonStates)2);
			((System.Windows.Forms.Control)(object)Registerbtn).Font = new System.Drawing.Font("Segoe UI", 9f);
			((System.Windows.Forms.Control)(object)Registerbtn).ForeColor = System.Drawing.Color.Gray;
			Registerbtn.set_IconLeftAlign(System.Drawing.ContentAlignment.MiddleLeft);
			Registerbtn.set_IconLeftCursor(System.Windows.Forms.Cursors.Default);
			Registerbtn.set_IconLeftPadding(new System.Windows.Forms.Padding(11, 3, 3, 3));
			Registerbtn.set_IconMarginLeft(11);
			Registerbtn.set_IconPadding(10);
			Registerbtn.set_IconRightAlign(System.Drawing.ContentAlignment.MiddleRight);
			Registerbtn.set_IconRightCursor(System.Windows.Forms.Cursors.Default);
			Registerbtn.set_IconRightPadding(new System.Windows.Forms.Padding(3, 3, 7, 3));
			Registerbtn.set_IconSize(25);
			Registerbtn.set_IdleBorderColor(System.Drawing.Color.Transparent);
			Registerbtn.set_IdleBorderRadius(5);
			Registerbtn.set_IdleBorderThickness(3);
			Registerbtn.set_IdleFillColor(System.Drawing.Color.Transparent);
			Registerbtn.set_IdleIconLeftImage((System.Drawing.Image)null);
			Registerbtn.set_IdleIconRightImage((System.Drawing.Image)null);
			Registerbtn.set_IndicateFocus(false);
			((System.Windows.Forms.Control)(object)Registerbtn).Location = new System.Drawing.Point(12, 188);
			((System.Windows.Forms.Control)(object)Registerbtn).Name = "Registerbtn";
			Registerbtn.get_OnDisabledState().set_BorderColor(System.Drawing.Color.Transparent);
			Registerbtn.get_OnDisabledState().set_BorderRadius(5);
			Registerbtn.get_OnDisabledState().set_BorderStyle((BorderStyles)0);
			Registerbtn.get_OnDisabledState().set_BorderThickness(3);
			Registerbtn.get_OnDisabledState().set_FillColor(System.Drawing.Color.Transparent);
			Registerbtn.get_OnDisabledState().set_ForeColor(System.Drawing.Color.FromArgb(168, 160, 168));
			Registerbtn.get_OnDisabledState().set_IconLeftImage((System.Drawing.Image)null);
			Registerbtn.get_OnDisabledState().set_IconRightImage((System.Drawing.Image)null);
			Registerbtn.get_onHoverState().set_BorderColor(System.Drawing.Color.Transparent);
			Registerbtn.get_onHoverState().set_BorderRadius(5);
			Registerbtn.get_onHoverState().set_BorderStyle((BorderStyles)0);
			Registerbtn.get_onHoverState().set_BorderThickness(3);
			Registerbtn.get_onHoverState().set_FillColor(System.Drawing.Color.Transparent);
			Registerbtn.get_onHoverState().set_ForeColor(System.Drawing.Color.Gray);
			Registerbtn.get_onHoverState().set_IconLeftImage((System.Drawing.Image)null);
			Registerbtn.get_onHoverState().set_IconRightImage((System.Drawing.Image)null);
			Registerbtn.get_OnIdleState().set_BorderColor(System.Drawing.Color.Transparent);
			Registerbtn.get_OnIdleState().set_BorderRadius(5);
			Registerbtn.get_OnIdleState().set_BorderStyle((BorderStyles)0);
			Registerbtn.get_OnIdleState().set_BorderThickness(3);
			Registerbtn.get_OnIdleState().set_FillColor(System.Drawing.Color.Transparent);
			Registerbtn.get_OnIdleState().set_ForeColor(System.Drawing.Color.Gray);
			Registerbtn.get_OnIdleState().set_IconLeftImage((System.Drawing.Image)null);
			Registerbtn.get_OnIdleState().set_IconRightImage((System.Drawing.Image)null);
			Registerbtn.get_OnPressedState().set_BorderColor(System.Drawing.Color.Transparent);
			Registerbtn.get_OnPressedState().set_BorderRadius(5);
			Registerbtn.get_OnPressedState().set_BorderStyle((BorderStyles)0);
			Registerbtn.get_OnPressedState().set_BorderThickness(3);
			Registerbtn.get_OnPressedState().set_FillColor(System.Drawing.Color.Transparent);
			Registerbtn.get_OnPressedState().set_ForeColor(System.Drawing.Color.Gray);
			Registerbtn.get_OnPressedState().set_IconLeftImage((System.Drawing.Image)null);
			Registerbtn.get_OnPressedState().set_IconRightImage((System.Drawing.Image)null);
			((System.Windows.Forms.Control)(object)Registerbtn).Size = new System.Drawing.Size(348, 31);
			((System.Windows.Forms.Control)(object)Registerbtn).TabIndex = 10;
			Registerbtn.set_TextAlign(System.Drawing.ContentAlignment.MiddleCenter);
			Registerbtn.set_TextAlignment(System.Windows.Forms.HorizontalAlignment.Center);
			Registerbtn.set_TextMarginLeft(0);
			Registerbtn.set_TextPadding(new System.Windows.Forms.Padding(0));
			Registerbtn.set_UseDefaultRadiusAndThickness(true);
			((System.Windows.Forms.Control)(object)Registerbtn).Click += new System.EventHandler(Registerbtn_Click);
			LoginBtn.set_AllowAnimations(true);
			LoginBtn.set_AllowMouseEffects(true);
			LoginBtn.set_AllowToggling(false);
			LoginBtn.set_AnimationSpeed(200);
			LoginBtn.set_AutoGenerateColors(false);
			LoginBtn.set_AutoRoundBorders(false);
			LoginBtn.set_AutoSizeLeftIcon(true);
			LoginBtn.set_AutoSizeRightIcon(true);
			((System.Windows.Forms.Control)(object)LoginBtn).BackColor = System.Drawing.Color.Transparent;
			LoginBtn.set_BackColor1(System.Drawing.Color.Transparent);
			((System.Windows.Forms.Control)(object)LoginBtn).BackgroundImage = (System.Drawing.Image)resources.GetObject("LoginBtn.BackgroundImage");
			LoginBtn.set_BorderStyle((BorderStyles)0);
			LoginBtn.set_ButtonText("Login");
			LoginBtn.set_ButtonTextMarginLeft(0);
			LoginBtn.set_ColorContrastOnClick(45);
			LoginBtn.set_ColorContrastOnHover(45);
			((System.Windows.Forms.Control)(object)LoginBtn).Cursor = System.Windows.Forms.Cursors.Default;
			val4.set_BottomLeft(true);
			val4.set_BottomRight(true);
			val4.set_TopLeft(true);
			val4.set_TopRight(true);
			LoginBtn.set_CustomizableEdges(val4);
			LoginBtn.set_DialogResult(System.Windows.Forms.DialogResult.None);
			LoginBtn.set_DisabledBorderColor(System.Drawing.Color.Transparent);
			LoginBtn.set_DisabledFillColor(System.Drawing.Color.Transparent);
			LoginBtn.set_DisabledForecolor(System.Drawing.Color.Gray);
			LoginBtn.set_FocusState((ButtonStates)2);
			((System.Windows.Forms.Control)(object)LoginBtn).Font = new System.Drawing.Font("Segoe UI", 9f);
			((System.Windows.Forms.Control)(object)LoginBtn).ForeColor = System.Drawing.Color.Gray;
			LoginBtn.set_IconLeftAlign(System.Drawing.ContentAlignment.MiddleLeft);
			LoginBtn.set_IconLeftCursor(System.Windows.Forms.Cursors.Default);
			LoginBtn.set_IconLeftPadding(new System.Windows.Forms.Padding(11, 3, 3, 3));
			LoginBtn.set_IconMarginLeft(11);
			LoginBtn.set_IconPadding(10);
			LoginBtn.set_IconRightAlign(System.Drawing.ContentAlignment.MiddleRight);
			LoginBtn.set_IconRightCursor(System.Windows.Forms.Cursors.Default);
			LoginBtn.set_IconRightPadding(new System.Windows.Forms.Padding(3, 3, 7, 3));
			LoginBtn.set_IconSize(25);
			LoginBtn.set_IdleBorderColor(System.Drawing.Color.Transparent);
			LoginBtn.set_IdleBorderRadius(5);
			LoginBtn.set_IdleBorderThickness(3);
			LoginBtn.set_IdleFillColor(System.Drawing.Color.Transparent);
			LoginBtn.set_IdleIconLeftImage((System.Drawing.Image)null);
			LoginBtn.set_IdleIconRightImage((System.Drawing.Image)null);
			LoginBtn.set_IndicateFocus(false);
			((System.Windows.Forms.Control)(object)LoginBtn).Location = new System.Drawing.Point(12, 151);
			((System.Windows.Forms.Control)(object)LoginBtn).Name = "LoginBtn";
			LoginBtn.get_OnDisabledState().set_BorderColor(System.Drawing.Color.Transparent);
			LoginBtn.get_OnDisabledState().set_BorderRadius(5);
			LoginBtn.get_OnDisabledState().set_BorderStyle((BorderStyles)0);
			LoginBtn.get_OnDisabledState().set_BorderThickness(3);
			LoginBtn.get_OnDisabledState().set_FillColor(System.Drawing.Color.Transparent);
			LoginBtn.get_OnDisabledState().set_ForeColor(System.Drawing.Color.Gray);
			LoginBtn.get_OnDisabledState().set_IconLeftImage((System.Drawing.Image)null);
			LoginBtn.get_OnDisabledState().set_IconRightImage((System.Drawing.Image)null);
			LoginBtn.get_onHoverState().set_BorderColor(System.Drawing.Color.Transparent);
			LoginBtn.get_onHoverState().set_BorderRadius(5);
			LoginBtn.get_onHoverState().set_BorderStyle((BorderStyles)0);
			LoginBtn.get_onHoverState().set_BorderThickness(3);
			LoginBtn.get_onHoverState().set_FillColor(System.Drawing.Color.Transparent);
			LoginBtn.get_onHoverState().set_ForeColor(System.Drawing.Color.Gray);
			LoginBtn.get_onHoverState().set_IconLeftImage((System.Drawing.Image)null);
			LoginBtn.get_onHoverState().set_IconRightImage((System.Drawing.Image)null);
			LoginBtn.get_OnIdleState().set_BorderColor(System.Drawing.Color.Transparent);
			LoginBtn.get_OnIdleState().set_BorderRadius(5);
			LoginBtn.get_OnIdleState().set_BorderStyle((BorderStyles)0);
			LoginBtn.get_OnIdleState().set_BorderThickness(3);
			LoginBtn.get_OnIdleState().set_FillColor(System.Drawing.Color.Transparent);
			LoginBtn.get_OnIdleState().set_ForeColor(System.Drawing.Color.Gray);
			LoginBtn.get_OnIdleState().set_IconLeftImage((System.Drawing.Image)null);
			LoginBtn.get_OnIdleState().set_IconRightImage((System.Drawing.Image)null);
			LoginBtn.get_OnPressedState().set_BorderColor(System.Drawing.Color.Transparent);
			LoginBtn.get_OnPressedState().set_BorderRadius(5);
			LoginBtn.get_OnPressedState().set_BorderStyle((BorderStyles)0);
			LoginBtn.get_OnPressedState().set_BorderThickness(3);
			LoginBtn.get_OnPressedState().set_FillColor(System.Drawing.Color.Transparent);
			LoginBtn.get_OnPressedState().set_ForeColor(System.Drawing.Color.Gray);
			LoginBtn.get_OnPressedState().set_IconLeftImage((System.Drawing.Image)null);
			LoginBtn.get_OnPressedState().set_IconRightImage((System.Drawing.Image)null);
			((System.Windows.Forms.Control)(object)LoginBtn).Size = new System.Drawing.Size(348, 31);
			((System.Windows.Forms.Control)(object)LoginBtn).TabIndex = 9;
			LoginBtn.set_TextAlign(System.Drawing.ContentAlignment.MiddleCenter);
			LoginBtn.set_TextAlignment(System.Windows.Forms.HorizontalAlignment.Center);
			LoginBtn.set_TextMarginLeft(0);
			LoginBtn.set_TextPadding(new System.Windows.Forms.Padding(0));
			LoginBtn.set_UseDefaultRadiusAndThickness(true);
			((System.Windows.Forms.Control)(object)LoginBtn).Click += new System.EventHandler(LoginBtn_Click);
			CheckShowPassword.set_AllowBindingControlAnimation(true);
			CheckShowPassword.set_AllowBindingControlColorChanges(false);
			CheckShowPassword.set_AllowBindingControlLocation(true);
			CheckShowPassword.set_AllowCheckBoxAnimation(false);
			CheckShowPassword.set_AllowCheckmarkAnimation(true);
			CheckShowPassword.set_AllowOnHoverStates(true);
			CheckShowPassword.set_AutoCheck(true);
			((System.Windows.Forms.Control)(object)CheckShowPassword).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)CheckShowPassword).BackgroundImage = (System.Drawing.Image)resources.GetObject("CheckShowPassword.BackgroundImage");
			((System.Windows.Forms.Control)(object)CheckShowPassword).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			CheckShowPassword.set_BindingControlPosition((BindingControlPositions)1);
			CheckShowPassword.set_BorderRadius(12);
			CheckShowPassword.set_Checked(true);
			CheckShowPassword.set_CheckState((CheckStates)0);
			((System.Windows.Forms.Control)(object)CheckShowPassword).Cursor = System.Windows.Forms.Cursors.Default;
			CheckShowPassword.set_CustomCheckmarkImage((System.Drawing.Image)null);
			((System.Windows.Forms.Control)(object)CheckShowPassword).Location = new System.Drawing.Point(243, 124);
			((System.Windows.Forms.Control)(object)CheckShowPassword).MinimumSize = new System.Drawing.Size(17, 17);
			((System.Windows.Forms.Control)(object)CheckShowPassword).Name = "CheckShowPassword";
			CheckShowPassword.get_OnCheck().set_BorderColor(System.Drawing.Color.Transparent);
			CheckShowPassword.get_OnCheck().set_BorderRadius(12);
			CheckShowPassword.get_OnCheck().set_BorderThickness(2);
			CheckShowPassword.get_OnCheck().set_CheckBoxColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CheckShowPassword.get_OnCheck().set_CheckmarkColor(System.Drawing.Color.Lime);
			CheckShowPassword.get_OnCheck().set_CheckmarkThickness(2);
			CheckShowPassword.get_OnDisable().set_BorderColor(System.Drawing.Color.Transparent);
			CheckShowPassword.get_OnDisable().set_BorderRadius(12);
			CheckShowPassword.get_OnDisable().set_BorderThickness(2);
			CheckShowPassword.get_OnDisable().set_CheckBoxColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CheckShowPassword.get_OnDisable().set_CheckmarkColor(System.Drawing.Color.Red);
			CheckShowPassword.get_OnDisable().set_CheckmarkThickness(2);
			CheckShowPassword.get_OnHoverChecked().set_BorderColor(System.Drawing.Color.Transparent);
			CheckShowPassword.get_OnHoverChecked().set_BorderRadius(12);
			CheckShowPassword.get_OnHoverChecked().set_BorderThickness(2);
			CheckShowPassword.get_OnHoverChecked().set_CheckBoxColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CheckShowPassword.get_OnHoverChecked().set_CheckmarkColor(System.Drawing.Color.Lime);
			CheckShowPassword.get_OnHoverChecked().set_CheckmarkThickness(2);
			CheckShowPassword.get_OnHoverUnchecked().set_BorderColor(System.Drawing.Color.Transparent);
			CheckShowPassword.get_OnHoverUnchecked().set_BorderRadius(12);
			CheckShowPassword.get_OnHoverUnchecked().set_BorderThickness(1);
			CheckShowPassword.get_OnHoverUnchecked().set_CheckBoxColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CheckShowPassword.get_OnUncheck().set_BorderColor(System.Drawing.Color.Transparent);
			CheckShowPassword.get_OnUncheck().set_BorderRadius(12);
			CheckShowPassword.get_OnUncheck().set_BorderThickness(1);
			CheckShowPassword.get_OnUncheck().set_CheckBoxColor(System.Drawing.Color.FromArgb(64, 0, 64));
			((System.Windows.Forms.Control)(object)CheckShowPassword).Size = new System.Drawing.Size(21, 21);
			CheckShowPassword.set_Style((CheckBoxStyles)0);
			((System.Windows.Forms.Control)(object)CheckShowPassword).TabIndex = 7;
			CheckShowPassword.set_ThreeState(false);
			CheckShowPassword.set_ToolTipText((string)null);
			((System.Windows.Forms.Control)(object)CheckShowPassword).Visible = false;
			CheckShowPassword.add_CheckedChanged(new System.EventHandler<CheckedChangedEventArgs>(CheckShowPassword_CheckedChanged));
			CheckRememberMe.set_AllowBindingControlAnimation(true);
			CheckRememberMe.set_AllowBindingControlColorChanges(false);
			CheckRememberMe.set_AllowBindingControlLocation(true);
			CheckRememberMe.set_AllowCheckBoxAnimation(false);
			CheckRememberMe.set_AllowCheckmarkAnimation(true);
			CheckRememberMe.set_AllowOnHoverStates(true);
			CheckRememberMe.set_AutoCheck(true);
			((System.Windows.Forms.Control)(object)CheckRememberMe).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)CheckRememberMe).BackgroundImage = (System.Drawing.Image)resources.GetObject("CheckRememberMe.BackgroundImage");
			((System.Windows.Forms.Control)(object)CheckRememberMe).BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			CheckRememberMe.set_BindingControlPosition((BindingControlPositions)1);
			CheckRememberMe.set_BorderRadius(12);
			CheckRememberMe.set_Checked(true);
			CheckRememberMe.set_CheckState((CheckStates)0);
			((System.Windows.Forms.Control)(object)CheckRememberMe).Cursor = System.Windows.Forms.Cursors.Default;
			CheckRememberMe.set_CustomCheckmarkImage((System.Drawing.Image)null);
			((System.Windows.Forms.Control)(object)CheckRememberMe).Location = new System.Drawing.Point(12, 124);
			((System.Windows.Forms.Control)(object)CheckRememberMe).MinimumSize = new System.Drawing.Size(17, 17);
			((System.Windows.Forms.Control)(object)CheckRememberMe).Name = "CheckRememberMe";
			CheckRememberMe.get_OnCheck().set_BorderColor(System.Drawing.Color.Transparent);
			CheckRememberMe.get_OnCheck().set_BorderRadius(12);
			CheckRememberMe.get_OnCheck().set_BorderThickness(2);
			CheckRememberMe.get_OnCheck().set_CheckBoxColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CheckRememberMe.get_OnCheck().set_CheckmarkColor(System.Drawing.Color.Lime);
			CheckRememberMe.get_OnCheck().set_CheckmarkThickness(2);
			CheckRememberMe.get_OnDisable().set_BorderColor(System.Drawing.Color.Transparent);
			CheckRememberMe.get_OnDisable().set_BorderRadius(12);
			CheckRememberMe.get_OnDisable().set_BorderThickness(2);
			CheckRememberMe.get_OnDisable().set_CheckBoxColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CheckRememberMe.get_OnDisable().set_CheckmarkColor(System.Drawing.Color.Red);
			CheckRememberMe.get_OnDisable().set_CheckmarkThickness(2);
			CheckRememberMe.get_OnHoverChecked().set_BorderColor(System.Drawing.Color.Transparent);
			CheckRememberMe.get_OnHoverChecked().set_BorderRadius(12);
			CheckRememberMe.get_OnHoverChecked().set_BorderThickness(2);
			CheckRememberMe.get_OnHoverChecked().set_CheckBoxColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CheckRememberMe.get_OnHoverChecked().set_CheckmarkColor(System.Drawing.Color.Lime);
			CheckRememberMe.get_OnHoverChecked().set_CheckmarkThickness(2);
			CheckRememberMe.get_OnHoverUnchecked().set_BorderColor(System.Drawing.Color.Transparent);
			CheckRememberMe.get_OnHoverUnchecked().set_BorderRadius(12);
			CheckRememberMe.get_OnHoverUnchecked().set_BorderThickness(1);
			CheckRememberMe.get_OnHoverUnchecked().set_CheckBoxColor(System.Drawing.Color.FromArgb(64, 0, 64));
			CheckRememberMe.get_OnUncheck().set_BorderColor(System.Drawing.Color.Transparent);
			CheckRememberMe.get_OnUncheck().set_BorderRadius(12);
			CheckRememberMe.get_OnUncheck().set_BorderThickness(1);
			CheckRememberMe.get_OnUncheck().set_CheckBoxColor(System.Drawing.Color.FromArgb(64, 0, 64));
			((System.Windows.Forms.Control)(object)CheckRememberMe).Size = new System.Drawing.Size(21, 21);
			CheckRememberMe.set_Style((CheckBoxStyles)0);
			((System.Windows.Forms.Control)(object)CheckRememberMe).TabIndex = 5;
			CheckRememberMe.set_ThreeState(false);
			CheckRememberMe.set_ToolTipText((string)null);
			CheckRememberMe.add_CheckedChanged(new System.EventHandler<CheckedChangedEventArgs>(CheckRememberMe_CheckedChanged));
			PasswordTXT.set_AcceptsReturn(true);
			PasswordTXT.set_AcceptsTab(true);
			PasswordTXT.set_AnimationSpeed(200);
			PasswordTXT.set_AutoCompleteMode(System.Windows.Forms.AutoCompleteMode.None);
			PasswordTXT.set_AutoCompleteSource(System.Windows.Forms.AutoCompleteSource.None);
			PasswordTXT.set_AutoSizeHeight(true);
			((System.Windows.Forms.Control)(object)PasswordTXT).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)PasswordTXT).BackgroundImage = (System.Drawing.Image)resources.GetObject("PasswordTXT.BackgroundImage");
			PasswordTXT.set_BorderColorActive(System.Drawing.Color.FromArgb(64, 0, 64));
			PasswordTXT.set_BorderColorDisabled(System.Drawing.Color.FromArgb(64, 0, 64));
			PasswordTXT.set_BorderColorHover(System.Drawing.Color.FromArgb(64, 0, 64));
			PasswordTXT.set_BorderColorIdle(System.Drawing.Color.FromArgb(64, 0, 64));
			PasswordTXT.set_BorderRadius(5);
			PasswordTXT.set_BorderThickness(3);
			PasswordTXT.set_CharacterCasing(System.Windows.Forms.CharacterCasing.Normal);
			((System.Windows.Forms.Control)(object)PasswordTXT).Cursor = System.Windows.Forms.Cursors.IBeam;
			PasswordTXT.set_DefaultFont(new System.Drawing.Font("Segoe UI", 9.25f));
			PasswordTXT.set_DefaultText("");
			PasswordTXT.set_FillColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)PasswordTXT).ForeColor = System.Drawing.Color.Lime;
			PasswordTXT.set_HideSelection(true);
			PasswordTXT.set_IconLeft((System.Drawing.Image)null);
			PasswordTXT.set_IconLeftCursor(System.Windows.Forms.Cursors.IBeam);
			PasswordTXT.set_IconPadding(10);
			PasswordTXT.set_IconRight((System.Drawing.Image)null);
			PasswordTXT.set_IconRightCursor(System.Windows.Forms.Cursors.IBeam);
			PasswordTXT.set_Lines(new string[0]);
			((System.Windows.Forms.Control)(object)PasswordTXT).Location = new System.Drawing.Point(12, 79);
			PasswordTXT.set_MaxLength(32767);
			((System.Windows.Forms.Control)(object)PasswordTXT).MinimumSize = new System.Drawing.Size(1, 1);
			PasswordTXT.set_Modified(false);
			PasswordTXT.set_Multiline(false);
			((System.Windows.Forms.Control)(object)PasswordTXT).Name = "PasswordTXT";
			val5.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val5.set_FillColor(System.Drawing.Color.Empty);
			val5.set_ForeColor(System.Drawing.Color.Empty);
			val5.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			PasswordTXT.set_OnActiveState(val5);
			val6.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val6.set_FillColor(System.Drawing.Color.Black);
			val6.set_ForeColor(System.Drawing.Color.Lime);
			val6.set_PlaceholderForeColor(System.Drawing.Color.DarkGray);
			PasswordTXT.set_OnDisabledState(val6);
			val7.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val7.set_FillColor(System.Drawing.Color.Empty);
			val7.set_ForeColor(System.Drawing.Color.Empty);
			val7.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			PasswordTXT.set_OnHoverState(val7);
			val8.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val8.set_FillColor(System.Drawing.Color.Black);
			val8.set_ForeColor(System.Drawing.Color.Lime);
			val8.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			PasswordTXT.set_OnIdleState(val8);
			((System.Windows.Forms.Control)(object)PasswordTXT).Padding = new System.Windows.Forms.Padding(3);
			PasswordTXT.set_PasswordChar('\0');
			PasswordTXT.set_PlaceholderForeColor(System.Drawing.Color.Silver);
			PasswordTXT.set_PlaceholderText("Password");
			PasswordTXT.set_ReadOnly(false);
			PasswordTXT.set_ScrollBars(System.Windows.Forms.ScrollBars.None);
			PasswordTXT.set_SelectedText("");
			PasswordTXT.set_SelectionLength(0);
			PasswordTXT.set_SelectionStart(0);
			PasswordTXT.set_ShortcutsEnabled(true);
			((System.Windows.Forms.Control)(object)PasswordTXT).Size = new System.Drawing.Size(348, 39);
			PasswordTXT.set_Style((_Style)0);
			((System.Windows.Forms.Control)(object)PasswordTXT).TabIndex = 4;
			PasswordTXT.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Left);
			PasswordTXT.set_TextMarginBottom(0);
			PasswordTXT.set_TextMarginLeft(3);
			PasswordTXT.set_TextMarginTop(1);
			PasswordTXT.set_TextPlaceholder("Password");
			PasswordTXT.set_UseSystemPasswordChar(false);
			PasswordTXT.set_WordWrap(true);
			UsernameTXT.set_AcceptsReturn(true);
			UsernameTXT.set_AcceptsTab(true);
			UsernameTXT.set_AnimationSpeed(200);
			UsernameTXT.set_AutoCompleteMode(System.Windows.Forms.AutoCompleteMode.None);
			UsernameTXT.set_AutoCompleteSource(System.Windows.Forms.AutoCompleteSource.None);
			UsernameTXT.set_AutoSizeHeight(true);
			((System.Windows.Forms.Control)(object)UsernameTXT).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)UsernameTXT).BackgroundImage = (System.Drawing.Image)resources.GetObject("UsernameTXT.BackgroundImage");
			UsernameTXT.set_BorderColorActive(System.Drawing.Color.FromArgb(64, 0, 64));
			UsernameTXT.set_BorderColorDisabled(System.Drawing.Color.FromArgb(64, 0, 64));
			UsernameTXT.set_BorderColorHover(System.Drawing.Color.FromArgb(64, 0, 64));
			UsernameTXT.set_BorderColorIdle(System.Drawing.Color.FromArgb(64, 0, 64));
			UsernameTXT.set_BorderRadius(5);
			UsernameTXT.set_BorderThickness(3);
			UsernameTXT.set_CharacterCasing(System.Windows.Forms.CharacterCasing.Normal);
			((System.Windows.Forms.Control)(object)UsernameTXT).Cursor = System.Windows.Forms.Cursors.IBeam;
			UsernameTXT.set_DefaultFont(new System.Drawing.Font("Segoe UI", 9.25f));
			UsernameTXT.set_DefaultText("");
			UsernameTXT.set_FillColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)UsernameTXT).ForeColor = System.Drawing.Color.Lime;
			UsernameTXT.set_HideSelection(true);
			UsernameTXT.set_IconLeft((System.Drawing.Image)null);
			UsernameTXT.set_IconLeftCursor(System.Windows.Forms.Cursors.IBeam);
			UsernameTXT.set_IconPadding(10);
			UsernameTXT.set_IconRight((System.Drawing.Image)null);
			UsernameTXT.set_IconRightCursor(System.Windows.Forms.Cursors.IBeam);
			UsernameTXT.set_Lines(new string[0]);
			((System.Windows.Forms.Control)(object)UsernameTXT).Location = new System.Drawing.Point(12, 34);
			UsernameTXT.set_MaxLength(32767);
			((System.Windows.Forms.Control)(object)UsernameTXT).MinimumSize = new System.Drawing.Size(1, 1);
			UsernameTXT.set_Modified(false);
			UsernameTXT.set_Multiline(false);
			((System.Windows.Forms.Control)(object)UsernameTXT).Name = "UsernameTXT";
			val9.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val9.set_FillColor(System.Drawing.Color.Empty);
			val9.set_ForeColor(System.Drawing.Color.Empty);
			val9.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			UsernameTXT.set_OnActiveState(val9);
			val10.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val10.set_FillColor(System.Drawing.Color.Black);
			val10.set_ForeColor(System.Drawing.Color.Lime);
			val10.set_PlaceholderForeColor(System.Drawing.Color.DarkGray);
			UsernameTXT.set_OnDisabledState(val10);
			val11.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val11.set_FillColor(System.Drawing.Color.Empty);
			val11.set_ForeColor(System.Drawing.Color.Empty);
			val11.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			UsernameTXT.set_OnHoverState(val11);
			val12.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val12.set_FillColor(System.Drawing.Color.Black);
			val12.set_ForeColor(System.Drawing.Color.Lime);
			val12.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			UsernameTXT.set_OnIdleState(val12);
			((System.Windows.Forms.Control)(object)UsernameTXT).Padding = new System.Windows.Forms.Padding(3);
			UsernameTXT.set_PasswordChar('\0');
			UsernameTXT.set_PlaceholderForeColor(System.Drawing.Color.Silver);
			UsernameTXT.set_PlaceholderText("Username");
			UsernameTXT.set_ReadOnly(false);
			UsernameTXT.set_ScrollBars(System.Windows.Forms.ScrollBars.None);
			UsernameTXT.set_SelectedText("");
			UsernameTXT.set_SelectionLength(0);
			UsernameTXT.set_SelectionStart(0);
			UsernameTXT.set_ShortcutsEnabled(true);
			((System.Windows.Forms.Control)(object)UsernameTXT).Size = new System.Drawing.Size(348, 39);
			UsernameTXT.set_Style((_Style)0);
			((System.Windows.Forms.Control)(object)UsernameTXT).TabIndex = 3;
			UsernameTXT.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Left);
			UsernameTXT.set_TextMarginBottom(0);
			UsernameTXT.set_TextMarginLeft(3);
			UsernameTXT.set_TextMarginTop(1);
			UsernameTXT.set_TextPlaceholder("Username");
			UsernameTXT.set_UseSystemPasswordChar(false);
			UsernameTXT.set_WordWrap(true);
			KillProc.Interval = 1;
			KillProc.Tick += new System.EventHandler(KillProc_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(372, 294);
			base.Controls.Add((System.Windows.Forms.Control)(object)Closebtn);
			base.Controls.Add((System.Windows.Forms.Control)(object)Minimizebtn);
			base.Controls.Add((System.Windows.Forms.Control)(object)Registerbtn);
			base.Controls.Add((System.Windows.Forms.Control)(object)LoginBtn);
			base.Controls.Add((System.Windows.Forms.Control)(object)ShowPasswordLabel);
			base.Controls.Add((System.Windows.Forms.Control)(object)CheckShowPassword);
			base.Controls.Add((System.Windows.Forms.Control)(object)RememberMeLabel);
			base.Controls.Add((System.Windows.Forms.Control)(object)CheckRememberMe);
			base.Controls.Add((System.Windows.Forms.Control)(object)PasswordTXT);
			base.Controls.Add((System.Windows.Forms.Control)(object)UsernameTXT);
			base.Controls.Add(pictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Login";
			base.Load += new System.EventHandler(Login_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
