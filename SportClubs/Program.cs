using Microsoft.EntityFrameworkCore;
using SportClubs.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("SportClubs"));
});
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
