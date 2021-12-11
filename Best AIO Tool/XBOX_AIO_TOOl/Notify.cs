using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Best_AIO_Tool.Properties;
using Bunifu.UI.WinForms;

namespace XBOX_AIO_TOOl
{
	public class Notify : Form
	{
		public enum enmAction
		{
			wait,
			start,
			close
		}

		public enum enmType
		{
			Success,
			Warning,
			Error,
			info
		}

		private int x;

		private int y;

		private enmAction action;

		private IContainer components;

		private PictureBox pictureBox1;

		private Timer timer1;

		private BunifuLabel UsernameTXT;

		private BunifuLabel XBOXAIOTXT;

		public Notify()
		{
			InitializeComponent();
		}

		private void Notify_Load(object sender, EventArgs e)
		{
		}

		public void showAlert(string msg, enmType type)
		{
			base.Opacity = 0.0;
			base.StartPosition = FormStartPosition.Manual;
			for (int i = 0; i < 10; i++)
			{
				string name = "AIO TOOL" + i;
				Notify notify = (Notify)Application.OpenForms[name];
				if (notify == null)
				{
					base.Name = name;
					x = Screen.PrimaryScreen.WorkingArea.Width - base.Width + 15;
					y = Screen.PrimaryScreen.WorkingArea.Height - base.Height * i - 100;
					base.Location = new Point(x, y);
					break;
				}
			}
			x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;
			switch (type)
			{
			case enmType.Success:
				BackColor = Color.GreenYellow;
				break;
			case enmType.Warning:
				BackColor = Color.Red;
				break;
			case enmType.Error:
				BackColor = Color.DarkRed;
				break;
			case enmType.info:
				BackColor = Color.RoyalBlue;
				break;
			}
			((Control)(object)UsernameTXT).Text = msg;
			Show();
			action = enmAction.start;
			timer1.Interval = 1;
			timer1.Start();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			switch (action)
			{
			case enmAction.wait:
				timer1.Interval = 5000;
				action = enmAction.close;
				break;
			case enmAction.start:
				timer1.Interval = 1;
				base.Opacity += 0.1;
				if (x < base.Location.X)
				{
					base.Left--;
				}
				else if (base.Opacity == 1.0)
				{
					action = enmAction.wait;
				}
				break;
			case enmAction.close:
				timer1.Interval = 1;
				base.Opacity -= 0.1;
				base.Left -= 3;
				if (base.Opacity == 0.0)
				{
					Close();
				}
				break;
			}
		}

		public void Alert(string msg, enmType type)
		{
			Notify notify = new Notify();
			notify.showAlert(msg, type);
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
			//IL_0038: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Expected O, but got Unknown
			//IL_0043: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Expected O, but got Unknown
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XBOX_AIO_TOOl.Notify));
			pictureBox1 = new System.Windows.Forms.PictureBox();
			timer1 = new System.Windows.Forms.Timer(components);
			UsernameTXT = new BunifuLabel();
			XBOXAIOTXT = new BunifuLabel();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			pictureBox1.Image = Best_AIO_Tool.Properties.Resources.RickLOL;
			pictureBox1.Location = new System.Drawing.Point(1, 0);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(100, 98);
			pictureBox1.TabIndex = 0;
			pictureBox1.TabStop = false;
			timer1.Tick += new System.EventHandler(timer1_Tick);
			UsernameTXT.set_AllowParentOverrides(false);
			UsernameTXT.set_AutoEllipsis(false);
			UsernameTXT.set_CursorType(System.Windows.Forms.Cursors.Default);
			UsernameTXT.set_Font(new System.Drawing.Font("Arial Black", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0));
			UsernameTXT.set_ForeColor(System.Drawing.Color.FromArgb(64, 0, 64));
			((System.Windows.Forms.Control)(object)UsernameTXT).Location = new System.Drawing.Point(107, 3);
			((System.Windows.Forms.Control)(object)UsernameTXT).Name = "UsernameTXT";
			((System.Windows.Forms.Control)(object)UsernameTXT).RightToLeft = System.Windows.Forms.RightToLeft.No;
			((System.Windows.Forms.Control)(object)UsernameTXT).Size = new System.Drawing.Size(95, 19);
			((System.Windows.Forms.Control)(object)UsernameTXT).TabIndex = 3;
			((System.Windows.Forms.Control)(object)UsernameTXT).Text = "Username:";
			UsernameTXT.set_TextAlignment(System.Drawing.ContentAlignment.MiddleLeft);
			UsernameTXT.set_TextFormat((TextFormattingOptions)0);
			XBOXAIOTXT.set_AllowParentOverrides(false);
			XBOXAIOTXT.set_AutoEllipsis(false);
			XBOXAIOTXT.set_CursorType((System.Windows.Forms.Cursor)null);
			XBOXAIOTXT.set_Font(new System.Drawing.Font("Arial Black", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0));
			XBOXAIOTXT.set_ForeColor(System.Drawing.Color.FromArgb(64, 0, 64));
			((System.Windows.Forms.Control)(object)XBOXAIOTXT).Location = new System.Drawing.Point(107, 75);
			((System.Windows.Forms.Control)(object)XBOXAIOTXT).Name = "XBOXAIOTXT";
			((System.Windows.Forms.Control)(object)XBOXAIOTXT).RightToLeft = System.Windows.Forms.RightToLeft.No;
			((System.Windows.Forms.Control)(object)XBOXAIOTXT).Size = new System.Drawing.Size(85, 23);
			((System.Windows.Forms.Control)(object)XBOXAIOTXT).TabIndex = 4;
			((System.Windows.Forms.Control)(object)XBOXAIOTXT).Text = "XBOX AIO";
			XBOXAIOTXT.set_TextAlignment(System.Drawing.ContentAlignment.MiddleLeft);
			XBOXAIOTXT.set_TextFormat((TextFormattingOptions)0);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.Color.Black;
			base.ClientSize = new System.Drawing.Size(434, 98);
			base.ControlBox = false;
			base.Controls.Add((System.Windows.Forms.Control)(object)XBOXAIOTXT);
			base.Controls.Add((System.Windows.Forms.Control)(object)UsernameTXT);
			base.Controls.Add(pictureBox1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "Notify";
			Text = "Notify";
			base.Load += new System.EventHandler(Notify_Load);
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}
	}
}
