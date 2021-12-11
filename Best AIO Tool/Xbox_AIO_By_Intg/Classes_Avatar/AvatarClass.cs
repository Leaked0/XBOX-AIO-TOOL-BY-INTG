using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XboxAIOTool.Classes_Avatar;
using XboxAIOTool.Objects.Models.Json;

namespace Xbox_AIO_By_Intg.Classes_Avatar
{
	public static class AvatarClass
	{
		public class Constants1
		{
			public static Random Random = new Random();

			public static readonly HttpClientHandler HttpClientHandler;

			public static HttpClient HttpClient;

			public static User.Profile Profile { get; set; }

			static Constants1()
			{
				//IL_000a: Unknown result type (might be due to invalid IL or missing references)
				//IL_000f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				//IL_0022: Expected O, but got Unknown
				//IL_0028: Unknown result type (might be due to invalid IL or missing references)
				//IL_0032: Expected O, but got Unknown
				HttpClientHandler val = new HttpClientHandler();
				val.set_AllowAutoRedirect(false);
				val.set_PreAuthenticate(true);
				HttpClientHandler = val;
				HttpClient = new HttpClient((HttpMessageHandler)(object)HttpClientHandler, false);
			}
		}

		private static WebClient XBLCV(string string0, string string1)
		{
			WebClient webClient = new WebClient();
			webClient.Proxy = null;
			webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
			webClient.Headers[HttpRequestHeader.Authorization] = string0;
			webClient.Headers[HttpRequestHeader.AcceptCharset] = "UTF-8";
			webClient.Headers[HttpRequestHeader.Accept] = "*/*";
			webClient.Headers["X-XBL-Contract-Version"] = string1;
			return webClient;
		}

		private static WebClient XBLCV2(string string02, string string12)
		{
			WebClient webClient = new WebClient();
			webClient.Proxy = null;
			webClient.Headers[HttpRequestHeader.ContentType] = "application/json";
			webClient.Headers[HttpRequestHeader.Authorization] = string02;
			webClient.Headers[HttpRequestHeader.AcceptCharset] = "UTF-8";
			webClient.Headers[HttpRequestHeader.Accept] = "*/*";
			webClient.Headers["X-XBL-Contract-Version"] = string12;
			return webClient;
		}

		public static async Task<Response> PostAsync(string uri, string body, string xststoken, string contractVersion = "3")
		{
			return await UploadBodyAsync(uri, body, xststoken, contractVersion, "POST");
		}

		public static async Task<Response> PutAsync(string uri, string body, string xststoken, string contractVersion = "2")
		{
			return await UploadBodyAsync(uri, body, xststoken, contractVersion);
		}

		public static async Task<Response> GetAsync(string uri, string xststoken, string contractVersion = "2")
		{
			Response response = new Response();
			WebClient webClient = XBLCV(xststoken, contractVersion);
			webClient.Proxy = null;
			byte[] array = await webClient.DownloadDataTaskAsync(uri);
			response.responseBody = Encoding.UTF8.GetString(array, 0, array.Length);
			response.valid = true;
			return response;
		}

		public static async Task<Response> UploadBodyAsync(string uri, string requestBody, string xststoken, string contractVersion = "1", string method = "PUT")
		{
			Response resp = new Response();
			try
			{
				WebClient webClient = XBLCV(xststoken, contractVersion);
				webClient.Proxy = null;
				byte[] bytes = Encoding.UTF8.GetBytes(requestBody);
				byte[] array = await webClient.UploadDataTaskAsync(uri, method, bytes);
				resp.responseBody = Encoding.UTF8.GetString(array, 0, array.Length);
				resp.valid = true;
				return resp;
			}
			catch (WebException ex)
			{
				WebException ex2 = ex;
				File.AppendAllText("faildata.txt", ex2.ToString() + "\n");
				return resp;
			}
			catch (Exception ex3)
			{
				Exception ex4 = ex3;
				throw ex4;
			}
		}
	}
}
