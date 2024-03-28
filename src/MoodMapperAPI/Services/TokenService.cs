namespace MoodMapperAPI.Services;

public class TokenService(ILogger<TokenService> logger, IOptions<JwtTokenSettings> jwtTokenSettings) : ITokenService
{
    private const int ExpirationMinutes = 60;
    private readonly ILogger<TokenService> _logger = logger;
    private readonly JwtTokenSettings _jwtTokenSettings = jwtTokenSettings.Value;

    public async Task<string> CreateToken(ApplicationUser user)
    {
        var expiration = DateTime.UtcNow.AddMinutes(ExpirationMinutes);
        var token = CreateJwtToken(
            await CreateClaims(user),
            CreateSigningCredentials(),
            expiration
        );
        var tokenHandler = new JwtSecurityTokenHandler();

        _logger.LogInformation("JWT Token created");

        return tokenHandler.WriteToken(token);
    }

    private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials,
     DateTime expiration) =>
     new(
         _jwtTokenSettings.ValidIssuer,
         _jwtTokenSettings.ValidAudience,
         claims,
         expires: expiration,
         signingCredentials: credentials
     );

    private async Task<List<Claim>> CreateClaims(ApplicationUser user)
    {
        var jwtSub = _jwtTokenSettings.JwtRegisteredClaimNamesSub;

        try
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, jwtSub),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString()),
                new(ClaimTypes.NameIdentifier, user.Id),
                new(ClaimTypes.Name, user.UserName),
                new(ClaimTypes.Email, user.Email),
            };

            return claims;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private SigningCredentials CreateSigningCredentials()
    {
        var symmetricSecurityKey = _jwtTokenSettings.SymmetricSecurityKey;

        return new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(symmetricSecurityKey)
            ),
            SecurityAlgorithms.HmacSha256
        );
    }
}