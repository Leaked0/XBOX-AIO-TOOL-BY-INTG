using System;

namespace XboxAIOTool.Objects.Exceptions
{
	public class InvalidAuthorizationToken : Exception
	{
		public InvalidAuthorizationToken()
			: base("Unauthorized XBL Token")
		{
		}
	}
}
