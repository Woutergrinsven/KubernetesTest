// See https://aka.ms/new-console-template for more information
using ConsoleApp2.Service.Tracker;

Console.WriteLine("Hello, World!");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();

// allow Vue dev server
builder.Services.AddCors(options =>
{
    options.AddPolicy("dev", policy =>
    {
        policy
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});



// Required for k8s, because if it binds to localhost instead, k8s routing breaks.
builder.WebHost.UseUrls("http://0.0.0.0:8080");

builder.Services.AddSingleton<ServiceTracker>();

var app = builder.Build();
app.UseCors("dev");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();



app.Run();