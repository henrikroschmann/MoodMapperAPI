using MoodMapperAPI.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder();
builder.AddServiceDefaults();
builder.Services.AddControllers();
builder.Services.AddRouting();

var app = builder.Build();
app.MapDefaultEndpoints();

app.UseRouting();
app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();
await app.RunAsync();