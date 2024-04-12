using Microsoft.AspNetCore.Authentication.JwtBearer;
using MoodMapperAPI.Infrastructure.Data;
using MoodMapperAPI.Infrastructure.Repositories;

namespace MoodMapperAPI.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddAuth(this IServiceCollection services, JwtTokenSettings jwtTokenSettings)
    {
        services.AddIdentityApiEndpoints<ApplicationUser>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtTokenSettings.ValidIssuer,
                    ValidAudience = jwtTokenSettings.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtTokenSettings.SymmetricSecurityKey)
                    ),
                };
            });

        return services;
    }

    public static IServiceCollection AddDbContextAndInterceptors(
    this IServiceCollection services, string connectionString) =>
        services
        //.AddSingleton<SoftDeleteInterceptor>()
        .AddDbContext<ApplicationDbContext>((options) =>
            options.UseSqlite(connectionString));

    // .AddInterceptors(sp.GetRequiredService<SoftDeleteInterceptor>()));

    public static IServiceCollection AddServiceRegistration(this IServiceCollection services) =>
    services
        .AddScoped<ApplicationDbContext>()
            // Generic Repository
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

    // Generic services

    // Serivces

    //.AddTransient<IAccountService, AccountService>()
    //.AddTransient<ITokenService, TokenService>()
    //.AddTransient<IInvitationService, InvitationService>()
    //.AddTransient<IMappingService, MappingService>()
    //.AddTransient<IUserService, UserService>()

    //.AddTransient<IUserOrganizationService, UserOrganizationService>()
    //.AddTransient<IOrganizationService, OrganizationService>();
}

public interface IReadServiceAsync<TEntity, TDto> where TEntity : class where TDto : class
{
    Task<IEnumerable<TDto>> GetAllAsync();

    Task<TDto> GetByIdAsync(int id);
}

public interface IGenericServiceAsync<TEntity, TDto> : IReadServiceAsync<TEntity, TDto>
       where TEntity : class
       where TDto : class

{
    Task AddAsync(TDto dto);

    Task DeleteAsync(int id);

    Task UpdateAsync(TDto dto);
}