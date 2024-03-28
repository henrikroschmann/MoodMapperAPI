using Microsoft.AspNetCore.Identity;

namespace MoodMapperAPI.Abstractions;

public interface IAccountService
{
    Task<ApplicationUser> AuthenticateUser(LoginDto model);
    Task<IdentityResult> CreateUser(RegisterDto model);
    Task DeleteUser(string email);
    Task<string> GetToken(ApplicationUser result);
}