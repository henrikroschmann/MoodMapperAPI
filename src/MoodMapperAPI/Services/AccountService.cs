namespace MoodMapperAPI.Services;

public class AccountService(ITokenService tokenService, UserManager<ApplicationUser> userManager) : IAccountService
{
    private readonly UserManager<ApplicationUser> _userManager = userManager;
    private readonly ITokenService _tokenService = tokenService;

    public async Task<ApplicationUser> AuthenticateUser(LoginDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email) ?? throw new KeyNotFoundException("User not found");
        var success = await _userManager.CheckPasswordAsync(user, model.Password);
        user.LastLoggedIn = DateTime.UtcNow;
        await _userManager.UpdateAsync(user);
        if (!success)
        {
            throw new UnauthorizedAccessException("Invalid password");
        }

        return user;
    }

    public async Task<IdentityResult> CreateUser(RegisterDto model)
    {
        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
        };
        return await _userManager.CreateAsync(user, model.Password);
    }

    public async Task DeleteUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email) ?? throw new KeyNotFoundException("User not found");
        await _userManager.DeleteAsync(user);
    }

    public async Task<string> GetToken(ApplicationUser result) =>
        await _tokenService.CreateToken(result);
}