using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using Glory77.Data;
using Glory77.Models;
// Removed incorrect bundling reference
// using System.Web.Optimization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR();

// Add database context
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (!string.IsNullOrEmpty(connectionString))
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseMySQL(connectionString));
}

// Add authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
    {
        config.Cookie.Name = "Auth.Cookie";
        config.LoginPath = "/Auth3/SignIn";
        config.AccessDeniedPath = "/Auth3/SignIn";
        config.SlidingExpiration = true;
        config.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error/Error404");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Add authentication middleware
app.UseAuthentication();
app.UseAuthorization();

// Map SignalR hubs
app.MapHub<Glory77.Hubs.NotificationHub>("/notificationHub");

// Removed incorrect bundling registration
// BundleConfig.RegisterBundles(BundleTable.Bundles);

app.MapStaticAssets();

// Seed the database with test data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    
    // Ensure the database is created
    context.Database.EnsureCreated();
    
    // Check if we already have providers
    if (!context.Providers.Any())
    {
        // Add some test providers
        context.Providers.AddRange(
            new Provider { ProviderName = "يمن موبايل", Status = 1, CreatedAt = DateTime.Now },
            new Provider { ProviderName = "سبافون", Status = 1, CreatedAt = DateTime.Now },
            new Provider { ProviderName = "YOU-يو", Status = 1, CreatedAt = DateTime.Now }
        );
        context.SaveChanges();
    }
    
    // Check if we already have system connections
    if (!context.SystemConnections.Any())
    {
        // Add some test system connections
        var providers = context.Providers.ToList();
        context.SystemConnections.AddRange(
            new SystemConnection 
            { 
                ProviderId = providers.FirstOrDefault()?.Id, 
                SystemName = "نظام يمن موبايل", 
                ConnectionStatus = "مفعل", 
                ProviderType = "mobile", 
                Balance = 1000.00m, 
                ResponseTime = 200,
                Direction = "شمال",
                CreatedAt = DateTime.Now 
            },
            new SystemConnection 
            { 
                ProviderId = providers.Skip(1).FirstOrDefault()?.Id, 
                SystemName = "نظام سبافون", 
                ConnectionStatus = "مفعل", 
                ProviderType = "saba", 
                Balance = 2500.50m, 
                ResponseTime = 150,
                Direction = "جنوب",
                CreatedAt = DateTime.Now 
            },
            new SystemConnection 
            { 
                ProviderId = providers.Skip(2).FirstOrDefault()?.Id, 
                SystemName = "نظام YOU-يو", 
                ConnectionStatus = "متوقف", 
                ProviderType = "mtn", 
                Balance = 500.75m, 
                ResponseTime = 300,
                Direction = "شمال",
                CreatedAt = DateTime.Now 
            }
        );
        context.SaveChanges();
    }
}

// Changed the default route to not have a default action, so all URLs will be explicit
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth3}/{action=SignIn}/{id?}")
    .WithStaticAssets();

app.Run();