namespace MoodMapperAPI.Domain.Options;

public class JwtTokenSettings
{
    public string ValidIssuer { get; set; } = null!;
    public string ValidAudience { get; set; } = null!;
    public string SymmetricSecurityKey { get; set; } = null!;
    public string JwtRegisteredClaimNamesSub { get; set; } = null!;

    public int ExpiryMinutes { get; set; }
}