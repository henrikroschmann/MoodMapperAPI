using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace MoodMapperAPI.Infrastructure.Extensions;

public static class WebHostExtension
{
    public static WebApplication MapDefaultEndpoints(this WebApplication app)
    {
        // All healthChecks must pass to be considered ready to accept traffic
        app.MapHealthChecks("/health");

        // Only health cehcks tagged with the "live" tag must pass
        app.MapHealthChecks("/alive", new HealthCheckOptions
        {
            Predicate = r => r.Tags.Contains("live")
        });

        return app;
    }
}
