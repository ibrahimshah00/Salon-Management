using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
    using ShopAdmin.Authentication;
    using ShopAdmin;

    using ShopAdmin.Data;
using Entities;

var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddAuthenticationCore();
    builder.Services.AddRazorPages();
    builder.Services.AddAntDesign();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddScoped<ProtectedSessionStorage>();
    builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
    builder.Services.AddSingleton<UserAccountService>();
    builder.Services.AddSingleton<WeatherForecastService>();
    builder.Services.AddSingleton<Appstate>();

    builder.Services.AddSingleton<AllBusinessOwner>();
    builder.Services.AddHttpClient<IAllBusinessOwner, AllBusinessOwner>(
        c => { c.BaseAddress = new Uri("https://localhost:7095/"); });


    builder.Services.AddSingleton<Shop>();
    builder.Services.AddHttpClient<IShop, Shop>(
        c => { c.BaseAddress = new Uri("https://localhost:7095/"); });

    builder.Services.AddSingleton<UserInfo>();
    builder.Services.AddHttpClient<IUserInfo, UserInfo>(
        c => { c.BaseAddress = new Uri("https://localhost:7095/"); });


    builder.Services.AddSingleton<Employee>();
    builder.Services.AddHttpClient<IEmployee, Employee>
        (
            c=> { c.BaseAddress = new Uri("https://localhost:7095/");  }
        );

    builder.Services.AddSingleton<Services>();
    builder.Services.AddHttpClient<IServices, Services>
        (
            c => { c.BaseAddress = new Uri("https://localhost:7095/"); }
        );

    builder.Services.AddSingleton<Packages>();
    builder.Services.AddHttpClient<IPackages, Packages>
        (
            c => { c.BaseAddress = new Uri("https://localhost:7095/"); }
        );

    builder.Services.AddSingleton<ServiceIconService>();
    builder.Services.AddHttpClient<IServiceIconService, ServiceIconService>
    (
        c => { c.BaseAddress = new Uri("https://localhost:7095/"); }
    );

    builder.Services.AddSingleton<MonthlySales>();
    builder.Services.AddHttpClient<IMonthlySales, MonthlySales>
    (
        c => { c.BaseAddress = new Uri("https://localhost:7095/"); }
    );



var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
    }


    app.UseStaticFiles();

    app.UseRouting();

    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    app.Run();
