using BlazorApp4.Shared;

namespace BlazorApp4.Client.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<int>> Register(UserRegister request);
        Task<ServiceResponse<string>> Login(UserLogin request);
        Task<bool> IsUserAuthenticated();
    }
}

