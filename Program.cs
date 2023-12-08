using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore;
using PortfolioSecondVersion.Data;
using PortfolioSecondVersion.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PortfolioSecondVersionContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddControllersWithViews();      
var app = builder.Build();

using (var scope = app.Services.CreateScope()) 
{
    var service = scope.ServiceProvider;
    SeedData.Initialize(service);
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
