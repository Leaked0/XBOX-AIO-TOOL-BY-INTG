using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Xbox_AIO_By_Intg
{
	internal class InfoManager
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<NetworkInterface, bool> _003C_003E9__5_0;

			public static Func<NetworkInterface, bool> _003C_003E9__5_1;

			public static Func<NetworkInterface, IEnumerable<GatewayIPAddressInformation>> _003C_003E9__5_2;

			public static Func<GatewayIPAddressInformation, IPAddress> _003C_003E9__5_3;

			public static Func<IPAddress, bool> _003C_003E9__5_4;

			internal bool _003CGetDefaultGateway_003Eb__5_0(NetworkInterface n)
			{
				return n.OperationalStatus == OperationalStatus.Up;
			}

			internal bool _003CGetDefaultGateway_003Eb__5_1(NetworkInterface n)
			{
				return n.NetworkInterfaceType != NetworkInterfaceType.Loopback;
			}

			internal IEnumerable<GatewayIPAddressInformation> _003CGetDefaultGateway_003Eb__5_2(NetworkInterface n)
			{
				return n.GetIPProperties()?.GatewayAddresses;
			}

			internal IPAddress _003CGetDefaultGateway_003Eb__5_3(GatewayIPAddressInformation g)
			{
				return g?.Address;
			}

			internal bool _003CGetDefaultGateway_003Eb__5_4(IPAddress a)
			{
				return a != null;
			}
		}

		private System.Threading.Timer timer;

		private string lastGateway;

		public InfoManager()
		{
			lastGateway = GetGatewayMAC();
		}

		public void StartListener()
		{
			timer = new System.Threading.Timer(delegate
			{
				OnCallBack();
			}, null, 5000, -1);
		}

		private void OnCallBack()
		{
			timer.Dispose();
			if (!(GetGatewayMAC() == lastGateway))
			{
				Constants.Breached = true;
				MessageBox.Show("ARP Cache poisoning has been detected!", OnProgramStart.Name);
				Process.GetCurrentProcess().Kill();
			}
			else
			{
				lastGateway = GetGatewayMAC();
			}
			timer = new System.Threading.Timer(delegate
			{
				OnCallBack();
			}, null, 5000, -1);
		}

		public static IPAddress GetDefaultGateway()
		{
			return (from g in (from n in NetworkInterface.GetAllNetworkInterfaces()
					where n.OperationalStatus == OperationalStatus.Up
					where n.NetworkInterfaceType != NetworkInterfaceType.Loopback
					select n).SelectMany((NetworkInterface n) => n.GetIPProperties()?.GatewayAddresses)
				select g?.Address into a
				where a != null
				select a).FirstOrDefault();
		}

		private string GetArpTable()
		{
			string pathRoot = Path.GetPathRoot(Environment.SystemDirectory);
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.FileName = pathRoot + "Windows\\System32\\arp.exe";
			processStartInfo.Arguments = "-a";
			processStartInfo.UseShellExecute = false;
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.CreateNoWindow = true;
			using Process process = Process.Start(processStartInfo);
			using StreamReader streamReader = process.StandardOutput;
			return streamReader.ReadToEnd();
		}

		private string GetGatewayMAC()
		{
			string arg = GetDefaultGateway().ToString();
			string pattern = $"({arg} [\\W]*) ([a-z0-9-]*)";
			Regex regex = new Regex(pattern);
			Match match = regex.Match(GetArpTable());
			return match.Groups[2].ToString();
		}
	}
}
