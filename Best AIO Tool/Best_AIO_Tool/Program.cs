using System;
using System.Windows.Forms;
using Xbox_AIO_By_Intg;

namespace Best_AIO_Tool
{
	internal static class Program
	{
		[STAThread]
		private static void Main()
		{
			OnProgramStart.Initialize("XBOXAIO", "828221", "g4Lpm8OzWa9bvHpFq7n69yek2XVLqaw8P4u", "1.0");
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			Application.Run(new Login());
		}
	}
}
