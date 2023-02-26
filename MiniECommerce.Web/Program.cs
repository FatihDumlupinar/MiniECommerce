using MiniECommerce.Application.Extensions;
using MiniECommerce.Persistence.Extensions;
using MiniECommerce.Web.Utilities.Extensions;
using MiniECommerce.Web.Utilities.Handlers;

var builder = WebApplication.CreateBuilder(args);

var config = AppsettingsConfig.AddAppsettingsConfig();

builder.Services.AddDbContextConfig(config);

builder.Services.AddApplicationDependecyConfig();

builder.Services.AddControllersWithViews();

builder.Services.AddCorsConfig();

var app = builder.Build();

app.UseCustomExceptionHandler(builder.Environment);

app.UseCustomCors();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
