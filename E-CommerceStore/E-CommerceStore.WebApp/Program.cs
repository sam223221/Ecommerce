using Blazored.Modal;
using E_Commerce.Plugin.InMemmory;
using E_Commerce.Plugin.MySQL;
using E_Commerce.UseCase.PluginInterfaces;
using E_Commerce.UseCase.Products;
using E_Commerce.UseCase.Products.InMemoryTest;
using E_Commerce.UseCase.Products.InMemoryTest.InterfaceTest;
using E_Commerce.UseCase.Products.Interfaces;
using E_CommerceStore.WebApp.Components;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register MySQLDbContext with DI as scoped
builder.Services.AddDbContext<MySQLDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(10, 4, 32)) //
    ));

// Authentication and Authorization
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(
        options =>
        {
            options.Cookie.Name = "auth_Token";
            options.LoginPath = "/login";
            options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
            options.AccessDeniedPath = "/accessdenied";
        });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();

builder.Services.AddAntiforgery(options =>
{

    options.Cookie.Expiration = TimeSpan.Zero;

});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IdbRepository, dbRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IAccountsService, AccountService>();
builder.Services.AddTransient<EmailService>();
builder.Services.AddBlazoredModal();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .DisableAntiforgery()
    .AddInteractiveServerRenderMode();

app.Run();