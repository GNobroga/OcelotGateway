using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(Path.Combine("ocelot.json"));
builder.Configuration.AddJsonFile(Path.Combine("appsettings.json"));
builder.Configuration.AddJsonFile(Path.Combine("appsettings.Development.json"));

builder.Services.AddOcelot();

var app = builder.Build();


app.MapGet("/", () => "Ocelot is started");

app.UseOcelot().Wait();

app.Run();