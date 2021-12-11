using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace XboxAIOTool.Forms.Objects.Utilities
{
	public class AuthenticatedXblHttpClient : WebClient
	{
		private string _003CXblAuthorizationHeader_003Ek__BackingField;

		private int _003CXblContractVersion_003Ek__BackingField;

		private string XblAuthorizationHeader
		{
			get
			{
				return _003CXblAuthorizationHeader_003Ek__BackingField;
			}
			set
			{
				_003CXblAuthorizationHeader_003Ek__BackingField = value;
			}
		}

		public int XblContractVersion
		{
			[CompilerGenerated]
			get
			{
				return _003CXblContractVersion_003Ek__BackingField;
			}
			set
			{
				_003CXblContractVersion_003Ek__BackingField = value;
			}
		}

		public AuthenticatedXblHttpClient(string xblAuthorizationHeader, int xblContractVersion = 105)
		{
			XblAuthorizationHeader = xblAuthorizationHeader;
			XblContractVersion = xblContractVersion;
		}

		protected override WebRequest GetWebRequest(Uri address)
		{
			WebRequest webRequest = base.GetWebRequest(address);
			if (!(webRequest is HttpWebRequest httpWebRequest))
			{
				return webRequest;
			}
			httpWebRequest.Proxy = null;
			httpWebRequest.Timeout = 10000;
			httpWebRequest.Headers.Add(HttpRequestHeader.Authorization, XblAuthorizationHeader);
			httpWebRequest.Headers.Add("x-xbl-contract-version", XblContractVersion.ToString());
			return webRequest;
		}
	}
}
