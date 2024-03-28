namespace MoodMapperAPI.Infrastructure.Extensions;

public static class HostApplicationBuilderExtension
{
    public static IHostApplicationBuilder AddServiceDefaults(this IHostApplicationBuilder builder)
    {
        //builder.AddDefaultHelthChecks();

        //// Database context
        string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
        builder.Services.AddDbContextAndInterceptors(connection!);

        // Autentication
        var jwtTokenSettings = builder.Configuration.GetRequiredSection(nameof(JwtTokenSettings)).Get<JwtTokenSettings>()!;
        builder.Services.AddAuth(jwtTokenSettings);
        //builder.Services.AddServiceRegistration();

        builder.Services.AddControllers();

        builder.Services.Configure<CookiePolicyOptions>(options =>
        {
            options.CheckConsentNeeded = context => true;
            options.MinimumSameSitePolicy = SameSiteMode.None;
        }); // not used?

        builder.Services.AddSession();
        builder.Services.AddDistributedMemoryCache(); // not used?

        return builder;
    }
}