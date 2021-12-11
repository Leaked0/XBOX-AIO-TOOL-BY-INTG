using System.Collections.Generic;
using Newtonsoft.Json;

namespace Xbox_AIO_FTW.Objects.Models.Json
{
	public class Friends
	{
		[JsonProperty("people")]
		public List<Friend> People { get; set; }
	}
}
