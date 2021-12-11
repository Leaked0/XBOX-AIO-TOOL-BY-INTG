using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Best_AIO_Tool.Properties;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using Bunifu.UI.WinForms.BunifuButton;
using XBOX_AIO_TOOl;

namespace Xbox_AIO_By_Intg
{
	public class Register : Form
	{
		private int MouseX;

		private int Mousey;

		private bool MouseM;

		private IContainer components;

		private BunifuElipse bunifuElipse1;

		private BunifuElipse bunifuElipse3;

		private BunifuElipse bunifuElipse4;

		private PictureBox pictureBox1;

		private BunifuTextBox UsernameTXT;

		private BunifuTextBox LicenseTXT;

		private BunifuTextBox EmailTXT;

		private BunifuTextBox PasswordTXT;

		private BunifuButton2 Registerbtn;

		private BunifuButton2 LoginBtn;

		private Timer KillProc;

		private BunifuButton Closebtn;

		private BunifuButton Minimizebtn;

		public Register()
		{
			InitializeComponent();
		}

		public void Alert(string msg, Notify.enmType type)
		{
			Notify notify = new Notify();
			notify.showAlert(msg, type);
		}

		private void Register_Load(object sender, EventArgs e)
		{
			((Control)(object)Closebtn).Parent = pictureBox1;
			((Control)(object)Minimizebtn).Parent = pictureBox1;
			((Control)(object)UsernameTXT).Parent = pictureBox1;
			((Control)(object)PasswordTXT).Parent = pictureBox1;
			((Control)(object)EmailTXT).Parent = pictureBox1;
			((Control)(object)LicenseTXT).Parent = pictureBox1;
		}

		private void Minimizebtn_Click_1(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void Closebtn_Click_1(object sender, EventArgs e)
		{
			Application.ExitThread();
			Close();
		}

		private void Registerbtn_Click(object sender, EventArgs e)
		{
			if (API.Register(UsernameTXT.get_Text(), PasswordTXT.get_Text(), EmailTXT.get_Text(), LicenseTXT.get_Text()))
			{
				Hide();
				Login login = new Login();
				login.Show();
			}
		}

		private void LoginBtn_Click(object sender, EventArgs e)
		{
			Hide();
			Login login = new Login();
			login.Show();
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
			//IL_006d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0074: Expected O, but got Unknown
			//IL_0074: Unknown result type (might be due to invalid IL or missing references)
			//IL_007b: Expected O, but got Unknown
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0082: Expected O, but got Unknown
			//IL_0082: Unknown result type (might be due to invalid IL or missing references)
			//IL_0089: Expected O, but got Unknown
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_0090: Expected O, but got Unknown
			//IL_0090: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Expected O, but got Unknown
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009e: Expected O, but got Unknown
			//IL_009e: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a5: Expected O, but got Unknown
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b6: Expected O, but got Unknown
			//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c7: Expected O, but got Unknown
			//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Expected O, but got Unknown
			//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Expected O, but got Unknown
			//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ee: Expected O, but got Unknown
			//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
			//IL_0104: Expected O, but got Unknown
			//IL_0105: Unknown result type (might be due to invalid IL or missing references)
			//IL_010f: Expected O, but got Unknown
			//IL_0110: Unknown result type (might be due to invalid IL or missing references)
			//IL_011a: Expected O, but got Unknown
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0125: Expected O, but got Unknown
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_0130: Expected O, but got Unknown
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_013b: Expected O, but got Unknown
			components = new System.ComponentModel.Container();
			BorderEdges val = new BorderEdges();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Xbox_AIO_By_Intg.Register));
			BorderEdges val2 = new BorderEdges();
			StateProperties val3 = new StateProperties();
			StateProperties val4 = new StateProperties();
			StateProperties val5 = new StateProperties();
			StateProperties val6 = new StateProperties();
			StateProperties val7 = new StateProperties();
			StateProperties val8 = new StateProperties();
			StateProperties val9 = new StateProperties();
			StateProperties val10 = new StateProperties();
			StateProperties val11 = new StateProperties();
			StateProperties val12 = new StateProperties();
			StateProperties val13 = new StateProperties();
			StateProperties val14 = new StateProperties();
			StateProperties val15 = new StateProperties();
			StateProperties val16 = new StateProperties();
			StateProperties val17 = new StateProperties();
			StateProperties val18 = new StateProperties();
			BorderEdges val19 = new BorderEdges();
			BorderEdges val20 = new BorderEdges();
			bunifuElipse1 = new BunifuElipse(components);
			bunifuElipse3 = new BunifuElipse(components);
			Minimizebtn = new BunifuButton();
			bunifuElipse4 = new BunifuElipse(components);
			Closebtn = new BunifuButton();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			UsernameTXT = new BunifuTextBox();
			PasswordTXT = new BunifuTextBox();
			EmailTXT = new BunifuTextBox();
			LicenseTXT = new BunifuTextBox();
			Registerbtn = new BunifuButton2();
			LoginBtn = new BunifuButton2();
			KillProc = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			bunifuElipse1.set_ElipseRadius(15);
			bunifuElipse1.set_TargetControl((System.Windows.Forms.Control)this);
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
			((System.Windows.Forms.Control)(object)Minimizebtn).TabIndex = 21;
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
			((System.Windows.Forms.Control)(object)Closebtn).TabIndex = 22;
			Closebtn.set_TextAlign(System.Drawing.ContentAlignment.MiddleCenter);
			Closebtn.set_TextAlignment(System.Windows.Forms.HorizontalAlignment.Center);
			Closebtn.set_TextMarginLeft(0);
			Closebtn.set_TextPadding(new System.Windows.Forms.Padding(0));
			Closebtn.set_UseDefaultRadiusAndThickness(true);
			((System.Windows.Forms.Control)(object)Closebtn).Click += new System.EventHandler(Closebtn_Click_1);
			pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			pictureBox1.Image = Best_AIO_Tool.Properties.Resources.rsz_1909639_1;
			pictureBox1.Location = new System.Drawing.Point(0, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(372, 294);
			pictureBox1.TabIndex = 5;
			pictureBox1.TabStop = false;
			pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseDown);
			pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseMove);
			pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(pictureBox1_MouseUp);
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
			val3.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val3.set_FillColor(System.Drawing.Color.Empty);
			val3.set_ForeColor(System.Drawing.Color.Empty);
			val3.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			UsernameTXT.set_OnActiveState(val3);
			val4.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val4.set_FillColor(System.Drawing.Color.Black);
			val4.set_ForeColor(System.Drawing.Color.Lime);
			val4.set_PlaceholderForeColor(System.Drawing.Color.DarkGray);
			UsernameTXT.set_OnDisabledState(val4);
			val5.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val5.set_FillColor(System.Drawing.Color.Empty);
			val5.set_ForeColor(System.Drawing.Color.Empty);
			val5.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			UsernameTXT.set_OnHoverState(val5);
			val6.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val6.set_FillColor(System.Drawing.Color.Black);
			val6.set_ForeColor(System.Drawing.Color.Lime);
			val6.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			UsernameTXT.set_OnIdleState(val6);
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
			((System.Windows.Forms.Control)(object)UsernameTXT).TabIndex = 15;
			UsernameTXT.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Left);
			UsernameTXT.set_TextMarginBottom(0);
			UsernameTXT.set_TextMarginLeft(3);
			UsernameTXT.set_TextMarginTop(1);
			UsernameTXT.set_TextPlaceholder("Username");
			UsernameTXT.set_UseSystemPasswordChar(false);
			UsernameTXT.set_WordWrap(true);
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
			((System.Windows.Forms.Control)(object)PasswordTXT).Location = new System.Drawing.Point(12, 74);
			PasswordTXT.set_MaxLength(32767);
			((System.Windows.Forms.Control)(object)PasswordTXT).MinimumSize = new System.Drawing.Size(1, 1);
			PasswordTXT.set_Modified(false);
			PasswordTXT.set_Multiline(false);
			((System.Windows.Forms.Control)(object)PasswordTXT).Name = "PasswordTXT";
			val7.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val7.set_FillColor(System.Drawing.Color.Empty);
			val7.set_ForeColor(System.Drawing.Color.Empty);
			val7.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			PasswordTXT.set_OnActiveState(val7);
			val8.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val8.set_FillColor(System.Drawing.Color.Black);
			val8.set_ForeColor(System.Drawing.Color.Lime);
			val8.set_PlaceholderForeColor(System.Drawing.Color.DarkGray);
			PasswordTXT.set_OnDisabledState(val8);
			val9.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val9.set_FillColor(System.Drawing.Color.Empty);
			val9.set_ForeColor(System.Drawing.Color.Empty);
			val9.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			PasswordTXT.set_OnHoverState(val9);
			val10.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val10.set_FillColor(System.Drawing.Color.Black);
			val10.set_ForeColor(System.Drawing.Color.Lime);
			val10.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			PasswordTXT.set_OnIdleState(val10);
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
			((System.Windows.Forms.Control)(object)PasswordTXT).TabIndex = 16;
			PasswordTXT.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Left);
			PasswordTXT.set_TextMarginBottom(0);
			PasswordTXT.set_TextMarginLeft(3);
			PasswordTXT.set_TextMarginTop(1);
			PasswordTXT.set_TextPlaceholder("Password");
			PasswordTXT.set_UseSystemPasswordChar(false);
			PasswordTXT.set_WordWrap(true);
			EmailTXT.set_AcceptsReturn(true);
			EmailTXT.set_AcceptsTab(true);
			EmailTXT.set_AnimationSpeed(200);
			EmailTXT.set_AutoCompleteMode(System.Windows.Forms.AutoCompleteMode.None);
			EmailTXT.set_AutoCompleteSource(System.Windows.Forms.AutoCompleteSource.None);
			EmailTXT.set_AutoSizeHeight(true);
			((System.Windows.Forms.Control)(object)EmailTXT).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)EmailTXT).BackgroundImage = (System.Drawing.Image)resources.GetObject("EmailTXT.BackgroundImage");
			EmailTXT.set_BorderColorActive(System.Drawing.Color.FromArgb(64, 0, 64));
			EmailTXT.set_BorderColorDisabled(System.Drawing.Color.FromArgb(64, 0, 64));
			EmailTXT.set_BorderColorHover(System.Drawing.Color.FromArgb(64, 0, 64));
			EmailTXT.set_BorderColorIdle(System.Drawing.Color.FromArgb(64, 0, 64));
			EmailTXT.set_BorderRadius(5);
			EmailTXT.set_BorderThickness(3);
			EmailTXT.set_CharacterCasing(System.Windows.Forms.CharacterCasing.Normal);
			((System.Windows.Forms.Control)(object)EmailTXT).Cursor = System.Windows.Forms.Cursors.IBeam;
			EmailTXT.set_DefaultFont(new System.Drawing.Font("Segoe UI", 9.25f));
			EmailTXT.set_DefaultText("");
			EmailTXT.set_FillColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)EmailTXT).ForeColor = System.Drawing.Color.Lime;
			EmailTXT.set_HideSelection(true);
			EmailTXT.set_IconLeft((System.Drawing.Image)null);
			EmailTXT.set_IconLeftCursor(System.Windows.Forms.Cursors.IBeam);
			EmailTXT.set_IconPadding(10);
			EmailTXT.set_IconRight((System.Drawing.Image)null);
			EmailTXT.set_IconRightCursor(System.Windows.Forms.Cursors.IBeam);
			EmailTXT.set_Lines(new string[0]);
			((System.Windows.Forms.Control)(object)EmailTXT).Location = new System.Drawing.Point(12, 114);
			EmailTXT.set_MaxLength(32767);
			((System.Windows.Forms.Control)(object)EmailTXT).MinimumSize = new System.Drawing.Size(1, 1);
			EmailTXT.set_Modified(false);
			EmailTXT.set_Multiline(false);
			((System.Windows.Forms.Control)(object)EmailTXT).Name = "EmailTXT";
			val11.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val11.set_FillColor(System.Drawing.Color.Empty);
			val11.set_ForeColor(System.Drawing.Color.Empty);
			val11.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			EmailTXT.set_OnActiveState(val11);
			val12.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val12.set_FillColor(System.Drawing.Color.Black);
			val12.set_ForeColor(System.Drawing.Color.Lime);
			val12.set_PlaceholderForeColor(System.Drawing.Color.DarkGray);
			EmailTXT.set_OnDisabledState(val12);
			val13.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val13.set_FillColor(System.Drawing.Color.Empty);
			val13.set_ForeColor(System.Drawing.Color.Empty);
			val13.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			EmailTXT.set_OnHoverState(val13);
			val14.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val14.set_FillColor(System.Drawing.Color.Black);
			val14.set_ForeColor(System.Drawing.Color.Lime);
			val14.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			EmailTXT.set_OnIdleState(val14);
			((System.Windows.Forms.Control)(object)EmailTXT).Padding = new System.Windows.Forms.Padding(3);
			EmailTXT.set_PasswordChar('\0');
			EmailTXT.set_PlaceholderForeColor(System.Drawing.Color.Silver);
			EmailTXT.set_PlaceholderText("Email");
			EmailTXT.set_ReadOnly(false);
			EmailTXT.set_ScrollBars(System.Windows.Forms.ScrollBars.None);
			EmailTXT.set_SelectedText("");
			EmailTXT.set_SelectionLength(0);
			EmailTXT.set_SelectionStart(0);
			EmailTXT.set_ShortcutsEnabled(true);
			((System.Windows.Forms.Control)(object)EmailTXT).Size = new System.Drawing.Size(348, 39);
			EmailTXT.set_Style((_Style)0);
			((System.Windows.Forms.Control)(object)EmailTXT).TabIndex = 17;
			EmailTXT.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Left);
			EmailTXT.set_TextMarginBottom(0);
			EmailTXT.set_TextMarginLeft(3);
			EmailTXT.set_TextMarginTop(1);
			EmailTXT.set_TextPlaceholder("Email");
			EmailTXT.set_UseSystemPasswordChar(false);
			EmailTXT.set_WordWrap(true);
			LicenseTXT.set_AcceptsReturn(true);
			LicenseTXT.set_AcceptsTab(true);
			LicenseTXT.set_AnimationSpeed(200);
			LicenseTXT.set_AutoCompleteMode(System.Windows.Forms.AutoCompleteMode.None);
			LicenseTXT.set_AutoCompleteSource(System.Windows.Forms.AutoCompleteSource.None);
			LicenseTXT.set_AutoSizeHeight(true);
			((System.Windows.Forms.Control)(object)LicenseTXT).BackColor = System.Drawing.Color.Transparent;
			((System.Windows.Forms.Control)(object)LicenseTXT).BackgroundImage = (System.Drawing.Image)resources.GetObject("LicenseTXT.BackgroundImage");
			LicenseTXT.set_BorderColorActive(System.Drawing.Color.FromArgb(64, 0, 64));
			LicenseTXT.set_BorderColorDisabled(System.Drawing.Color.FromArgb(64, 0, 64));
			LicenseTXT.set_BorderColorHover(System.Drawing.Color.FromArgb(64, 0, 64));
			LicenseTXT.set_BorderColorIdle(System.Drawing.Color.FromArgb(64, 0, 64));
			LicenseTXT.set_BorderRadius(5);
			LicenseTXT.set_BorderThickness(3);
			LicenseTXT.set_CharacterCasing(System.Windows.Forms.CharacterCasing.Normal);
			((System.Windows.Forms.Control)(object)LicenseTXT).Cursor = System.Windows.Forms.Cursors.IBeam;
			LicenseTXT.set_DefaultFont(new System.Drawing.Font("Segoe UI", 9.25f));
			LicenseTXT.set_DefaultText("");
			LicenseTXT.set_FillColor(System.Drawing.Color.Black);
			((System.Windows.Forms.Control)(object)LicenseTXT).ForeColor = System.Drawing.Color.Lime;
			LicenseTXT.set_HideSelection(true);
			LicenseTXT.set_IconLeft((System.Drawing.Image)null);
			LicenseTXT.set_IconLeftCursor(System.Windows.Forms.Cursors.IBeam);
			LicenseTXT.set_IconPadding(10);
			LicenseTXT.set_IconRight((System.Drawing.Image)null);
			LicenseTXT.set_IconRightCursor(System.Windows.Forms.Cursors.IBeam);
			LicenseTXT.set_Lines(new string[0]);
			((System.Windows.Forms.Control)(object)LicenseTXT).Location = new System.Drawing.Point(12, 154);
			LicenseTXT.set_MaxLength(32767);
			((System.Windows.Forms.Control)(object)LicenseTXT).MinimumSize = new System.Drawing.Size(1, 1);
			LicenseTXT.set_Modified(false);
			LicenseTXT.set_Multiline(false);
			((System.Windows.Forms.Control)(object)LicenseTXT).Name = "LicenseTXT";
			val15.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val15.set_FillColor(System.Drawing.Color.Empty);
			val15.set_ForeColor(System.Drawing.Color.Empty);
			val15.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			LicenseTXT.set_OnActiveState(val15);
			val16.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val16.set_FillColor(System.Drawing.Color.Black);
			val16.set_ForeColor(System.Drawing.Color.Lime);
			val16.set_PlaceholderForeColor(System.Drawing.Color.DarkGray);
			LicenseTXT.set_OnDisabledState(val16);
			val17.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val17.set_FillColor(System.Drawing.Color.Empty);
			val17.set_ForeColor(System.Drawing.Color.Empty);
			val17.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			LicenseTXT.set_OnHoverState(val17);
			val18.set_BorderColor(System.Drawing.Color.FromArgb(64, 0, 64));
			val18.set_FillColor(System.Drawing.Color.Black);
			val18.set_ForeColor(System.Drawing.Color.Lime);
			val18.set_PlaceholderForeColor(System.Drawing.Color.Empty);
			LicenseTXT.set_OnIdleState(val18);
			((System.Windows.Forms.Control)(object)LicenseTXT).Padding = new System.Windows.Forms.Padding(3);
			LicenseTXT.set_PasswordChar('\0');
			LicenseTXT.set_PlaceholderForeColor(System.Drawing.Color.Silver);
			LicenseTXT.set_PlaceholderText("License");
			LicenseTXT.set_ReadOnly(false);
			LicenseTXT.set_ScrollBars(System.Windows.Forms.ScrollBars.None);
			LicenseTXT.set_SelectedText("");
			LicenseTXT.set_SelectionLength(0);
			LicenseTXT.set_SelectionStart(0);
			LicenseTXT.set_ShortcutsEnabled(true);
			((System.Windows.Forms.Control)(object)LicenseTXT).Size = new System.Drawing.Size(348, 39);
			LicenseTXT.set_Style((_Style)0);
			((System.Windows.Forms.Control)(object)LicenseTXT).TabIndex = 18;
			LicenseTXT.set_TextAlign(System.Windows.Forms.HorizontalAlignment.Left);
			LicenseTXT.set_TextMarginBottom(0);
			LicenseTXT.set_TextMarginLeft(3);
			LicenseTXT.set_TextMarginTop(1);
			LicenseTXT.set_TextPlaceholder("License");
			LicenseTXT.set_UseSystemPasswordChar(false);
			LicenseTXT.set_WordWrap(true);
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
			val19.set_BottomLeft(true);
			val19.set_BottomRight(true);
			val19.set_TopLeft(true);
			val19.set_TopRight(true);
			Registerbtn.set_CustomizableEdges(val19);
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
			((System.Windows.Forms.Control)(object)Registerbtn).Location = new System.Drawing.Point(12, 199);
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
			((System.Windows.Forms.Control)(object)Registerbtn).TabIndex = 20;
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
			LoginBtn.set_ButtonText("Back To Login");
			LoginBtn.set_ButtonTextMarginLeft(0);
			LoginBtn.set_ColorContrastOnClick(45);
			LoginBtn.set_ColorContrastOnHover(45);
			((System.Windows.Forms.Control)(object)LoginBtn).Cursor = System.Windows.Forms.Cursors.Default;
			val20.set_BottomLeft(true);
			val20.set_BottomRight(true);
			val20.set_TopLeft(true);
			val20.set_TopRight(true);
			LoginBtn.set_CustomizableEdges(val20);
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
			((System.Windows.Forms.Control)(object)LoginBtn).Location = new System.Drawing.Point(12, 236);
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
			((System.Windows.Forms.Control)(object)LoginBtn).TabIndex = 19;
			LoginBtn.set_TextAlign(System.Drawing.ContentAlignment.MiddleCenter);
			LoginBtn.set_TextAlignment(System.Windows.Forms.HorizontalAlignment.Center);
			LoginBtn.set_TextMarginLeft(0);
			LoginBtn.set_TextPadding(new System.Windows.Forms.Padding(0));
			LoginBtn.set_UseDefaultRadiusAndThickness(true);
			((System.Windows.Forms.Control)(object)LoginBtn).Click += new System.EventHandler(LoginBtn_Click);
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
			base.Controls.Add((System.Windows.Forms.Control)(object)LicenseTXT);
			base.Controls.Add((System.Windows.Forms.Control)(object)EmailTXT);
			base.Controls.Add((System.Windows.Forms.Control)(object)PasswordTXT);
			base.Controls.Add((System.Windows.Forms.Control)(object)UsernameTXT);
			base.Controls.Add(pictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Register";
			Text = "Register";
			base.Load += new System.EventHandler(Register_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
		}
	}
}
