using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace XboxAIOTool.Objects.Extensions
{
	public static class HttpClientExtensions
	{
		public static async Task<T> ToJsonAsync<T>(this HttpResponseMessage httpResponseMessage)
		{
			return JsonConvert.DeserializeObject<T>(await httpResponseMessage.get_Content().ReadAsStringAsync());
		}
	}
}
