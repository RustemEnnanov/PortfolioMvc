using Microsoft.AspNetCore;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using PortfolioSecondVersion;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddDbContext<ProfileSecondVersionContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
   
var app = builder.Build();

using (var scope = app.Services.CreateScope()) 
{
    var service = scope.ServiceProvider;
    SeedData.Initialize(service);
}


app.UseRouting();
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
