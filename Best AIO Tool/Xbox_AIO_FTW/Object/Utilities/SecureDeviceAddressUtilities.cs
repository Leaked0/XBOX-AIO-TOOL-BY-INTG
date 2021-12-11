using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xbox_AIO_By_Intg.Classes_Avatar;

namespace Xbox_AIO_FTW.Object.Utilities
{
	public class SecureDeviceAddressUtilities
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<string, int> _003C_003E9__1_0;

			internal int _003CGenerateNewSecureDeviceAddress_003Eb__1_0(string n)
			{
				return Convert.ToInt32(n);
			}
		}

		public static string DecodeSecureDeviceAddress(string encodedSecureDeviceAddress)
		{
			if (string.IsNullOrEmpty(encodedSecureDeviceAddress))
			{
				return "N/A";
			}
			try
			{
				byte[] array = Convert.FromBase64String(encodedSecureDeviceAddress);
				List<int> list = new List<int> { 0, 0, 0, 0 };
				List<int> second = new List<int> { 32, 1, 0, 0 };
				int num = 0;
				byte[] array2 = array;
				foreach (byte item in array2)
				{
					num++;
					list.RemoveAt(0);
					list.Add(item);
					if (list.SequenceEqual(second))
					{
						break;
					}
				}
				if (!list.SequenceEqual(second))
				{
					return "N/A";
				}
				StringBuilder stringBuilder = new StringBuilder();
				int num2 = 0;
				for (int j = 0; j < 4; j++)
				{
					if (j < 2)
					{
						num2 += (255 - array[num + 7 - j]) * (1 + 255 * j);
					}
					stringBuilder.Append($".{255 - array[num + 8 + j]}");
				}
				return $"{stringBuilder.Remove(0, 1)}:{num2}";
			}
			catch
			{
				return "N/A";
			}
		}

		public static string GenerateNewSecureDeviceAddress(string ipAddress, int port)
		{
			if (port > 65535)
			{
				throw new Exception("Port must be between 1-65535!");
			}
			byte[] array = new byte[39];
			AvatarClass.Constants1.Random.NextBytes(array);
			byte[] sourceArray = new byte[2] { 1, 0 };
			Array.Copy(sourceArray, 0, array, 0, 2);
			byte[] sourceArray2 = new byte[4] { 32, 1, 0, 0 };
			Array.Copy(sourceArray2, 0, array, 19, 4);
			int[] array2 = PortBytes(port);
			int[] array3 = (from n in ipAddress.Split('.')
				select Convert.ToInt32(n)).ToArray();
			for (int i = 0; i < array3.Length; i++)
			{
				if (i < 2)
				{
					array[30 - i] = Convert.ToByte(array2[i]);
				}
				array[31 + i] = Convert.ToByte(255 - array3[i]);
			}
			return Convert.ToBase64String(array);
		}

		private static int[] PortBytes(int port)
		{
			int num = port / 256;
			return new int[2]
			{
				255 - (port - num * 256),
				255 - num
			};
		}
	}
}
