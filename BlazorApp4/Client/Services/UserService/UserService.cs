using BlazorApp4.Shared;
using System.Net.Http.Json;

namespace BlazorApp4.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authStateProvider;

        public UserService(HttpClient httpClient, AuthenticationStateProvider authStateProvider)
        {
            this.httpClient = httpClient;
            this.authStateProvider = authStateProvider;
        }

        public async Task<bool> IsUserAuthenticated()
        {
            return (await authStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task<ServiceResponse<string>> Login(UserLogin request)
        {
            var result = await httpClient.PostAsJsonAsync("api/User/login", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<int>> Register(UserRegister request)
        {
            var result = await httpClient.PostAsJsonAsync("api/User/register", request);
            return await result.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
    }
}
