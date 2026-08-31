using CoffeeQueue.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<QueueService>();
builder.Services.AddHostedService<QueueWorker>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.MapGet("/favicon.ico", () => Results.NoContent());
app.MapControllerRoute(name: "default", pattern: "{controller=Queue}/{action=Index}/{id?}");
app.Run();
