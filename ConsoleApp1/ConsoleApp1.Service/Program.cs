// See https://aka.ms/new-console-template for more information
using ConsoleApp1.Service.Tracker;

Console.WriteLine("Hello, World!");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Required for k8s, because if it binds to localhost instead, k8s routing breaks.
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddSingleton<ServiceTracker>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.Run();