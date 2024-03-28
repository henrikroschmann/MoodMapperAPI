namespace MoodMapperAPI.Abstractions;

public interface ITokenService
{
    Task<string> CreateToken(ApplicationUser user);
}