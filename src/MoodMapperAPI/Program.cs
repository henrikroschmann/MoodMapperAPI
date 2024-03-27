var builder = WebApplication.CreateBuilder();
builder.Services.AddControllers();
builder.Services.AddRouting();
var app = builder.Build();
app.UseRouting();
app.MapControllers();
await app.RunAsync();
