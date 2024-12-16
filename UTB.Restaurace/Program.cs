using Microsoft.EntityFrameworkCore;
using UTB.Restaurace.Infrastructure.Database;
using UTB.Restaurace.Application.Abstraction;
using UTB.Restaurace.Application.Implementation;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
using UTB.Restaurace.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string connectionString = builder.Configuration.GetConnectionString("MySQL");
ServerVersion serverVersion = new MySqlServerVersion("8.0.38");
builder.Services.AddDbContext<RestauraceDbContext>(optionsBuilder => optionsBuilder.UseMySql(connectionString, serverVersion));
//Configuration for Identity
builder.Services.AddIdentity<User, Role>()
     .AddEntityFrameworkStores<RestauraceDbContext>()
     .AddDefaultTokenProviders();


//registrace služeb aplikaèní vrstvy
builder.Services.AddScoped<IMealAppService, MealAppService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Set the culture to use comma as decimal separator
var cultureInfo = new CultureInfo("cs-CZ");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
app.Run();
