using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Xbox_AIO_FTW.Classes_Avatar;
using Xbox_AIO_FTW.Objects.Models.Json;
using XboxAIOTool.Objects.Exceptions;
using XboxAIOTool.Objects.Extensions;
using XboxAIOTool.Objects.Models;
using XboxAIOTool.Objects.Models.Json;

namespace XboxAIOTool.Objects.Core
{
	public class Xbox
	{
		[StructLayout(LayoutKind.Auto)]
		private struct _003CGetGame_003Ed__1 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<GameLoading> _003C_003Et__builder;

			private TaskAwaiter<HttpResponseMessage> _003C_003Eu__1;

			private TaskAwaiter<GameLoading> _003C_003Eu__2;

			private void MoveNext()
			{
				int num = _003C_003E1__state;
				GameLoading result3;
				try
				{
					TaskAwaiter<GameLoading> awaiter;
					TaskAwaiter<HttpResponseMessage> awaiter2;
					if (num != 0)
					{
						if (num == 1)
						{
							awaiter = _003C_003Eu__2;
							_003C_003Eu__2 = default(TaskAwaiter<GameLoading>);
							num = -1;
							_003C_003E1__state = -1;
							goto IL_018f;
						}
						if (string.IsNullOrWhiteSpace(""))
						{
							throw new Exception("Error");
						}
						((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Remove("x-xbl-contract-version");
						((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("x-xbl-contract-version", "107");
						((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("Accept-Language", "json");
						((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("Accept-Encoding", "gzip; q=1.0, deflate; q=0.5, identity; q=0.1");
						((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("Accept-Language", "en-US, en, en-AU, en");
						((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("Signature", "AAAAAQHXFG1JrlzoBHDHwomoKb0Ikrh3GrVR5eaDSDrYcwKpFsKbttOceFrC/ivqWIQggqv72QUZ7Gl2kO1e3r8/nZR1yHDexYjr+g==");
						awaiter2 = Constants1.HttpClient.GetAsync(EndPoints.GetGame()).GetAwaiter();
						if (!awaiter2.IsCompleted)
						{
							num = 0;
							_003C_003E1__state = 0;
							_003C_003Eu__1 = awaiter2;
							_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
							return;
						}
					}
					else
					{
						awaiter2 = _003C_003Eu__1;
						_003C_003Eu__1 = default(TaskAwaiter<HttpResponseMessage>);
						num = -1;
						_003C_003E1__state = -1;
					}
					HttpResponseMessage result = awaiter2.GetResult();
					HttpResponseMessage val = result;
					if (!val.get_IsSuccessStatusCode())
					{
						throw new InvalidOperationException("Error");
					}
					awaiter = val.ToJsonAsync<GameLoading>().GetAwaiter();
					if (!awaiter.IsCompleted)
					{
						num = 1;
						_003C_003E1__state = 1;
						_003C_003Eu__2 = awaiter;
						_003C_003Et__builder.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						return;
					}
					goto IL_018f;
					IL_018f:
					GameLoading result2 = awaiter.GetResult();
					GameLoading gameLoading = result2;
					val = null;
					result3 = gameLoading;
				}
				catch (Exception exception)
				{
					_003C_003E1__state = -2;
					_003C_003Et__builder.SetException(exception);
					return;
				}
				_003C_003E1__state = -2;
				_003C_003Et__builder.SetResult(result3);
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
				_003C_003Et__builder.SetStateMachine(stateMachine);
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		public static async Task<User.ProfileModel> ValidateAuthorizationTokenAsync(string authorizationToken)
		{
			if (string.IsNullOrWhiteSpace(authorizationToken))
			{
				throw new InvalidAuthorizationToken();
			}
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("Authorization", authorizationToken);
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Remove("x-xbl-contract-version");
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("x-xbl-contract-version", "2");
			HttpResponseMessage val = await Constants1.HttpClient.GetAsync(EndPoints.MyProfile());
			if (!val.get_IsSuccessStatusCode())
			{
				throw new InvalidAuthorizationToken();
			}
			return await val.ToJsonAsync<User.ProfileModel>();
		}

		public static async Task<GameLoading> GetGame()
		{
			if (string.IsNullOrWhiteSpace(""))
			{
				throw new Exception("Error");
			}
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Remove("x-xbl-contract-version");
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("x-xbl-contract-version", "107");
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("Accept-Language", "json");
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("Accept-Encoding", "gzip; q=1.0, deflate; q=0.5, identity; q=0.1");
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("Accept-Language", "en-US, en, en-AU, en");
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("Signature", "AAAAAQHXFG1JrlzoBHDHwomoKb0Ikrh3GrVR5eaDSDrYcwKpFsKbttOceFrC/ivqWIQggqv72QUZ7Gl2kO1e3r8/nZR1yHDexYjr+g==");
			HttpResponseMessage val = await Constants1.HttpClient.GetAsync(EndPoints.GetGame());
			if (!val.get_IsSuccessStatusCode())
			{
				throw new InvalidOperationException("Error");
			}
			return await val.ToJsonAsync<GameLoading>();
		}

		public static async Task<Friends> GetFriends(string xuid)
		{
			if (string.IsNullOrWhiteSpace(xuid))
			{
				throw new Exception("Xuid can not be null.");
			}
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Remove("x-xbl-contract-version");
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("x-xbl-contract-version", "1");
			((HttpHeaders)Constants1.HttpClient.get_DefaultRequestHeaders()).Add("Accept-Language", "json");
			HttpResponseMessage val = await Constants1.HttpClient.GetAsync(EndPoints.GetFriends(xuid));
			if (!val.get_IsSuccessStatusCode())
			{
				throw new InvalidOperationException("Unable to get friends list.");
			}
			return await val.ToJsonAsync<Friends>();
		}
	}
}
