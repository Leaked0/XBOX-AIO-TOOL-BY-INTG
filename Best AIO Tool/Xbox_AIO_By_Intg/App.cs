using System.Collections.Generic;

namespace Xbox_AIO_By_Intg
{
	internal class App
	{
		public static string Error = null;

		public static Dictionary<string, string> Variables = new Dictionary<string, string>();

		public static string GrabVariable(string name)
		{
			try
			{
				if (UserV.ID == null && UserV.HWID == null && UserV.IP == null && Constants.Breached)
				{
					Constants.Breached = true;
					return "User is not logged in, possible breach detected!";
				}
				return Variables[name];
			}
			catch
			{
				return "N/A";
			}
		}
	}
}
