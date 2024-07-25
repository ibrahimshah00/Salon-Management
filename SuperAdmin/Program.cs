using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using SuperAdmin.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<BusinessOwnerService>();
builder.Services.AddHttpClient<IBusniessOwner, BusinessOwnerService>(
    c => { c.BaseAddress = new Uri("https://localhost:7095/"); }
    );

builder.Services.AddSingleton<Shop>();
builder.Services.AddHttpClient<IShop,Shop>
    (
    c => { c.BaseAddress = new Uri("https://localhost:7095/"); }
    );

builder.Services.AddSingleton<ShopManager>();
builder.Services.AddHttpClient<IShopManager, ShopManager>
    (
    c => { c.BaseAddress = new Uri("https://localhost:7095/"); }
    );




builder.Services.AddSingleton<Employee>();
builder.Services.AddHttpClient<IEmployee, Employee>(

    c => { c.BaseAddress = new Uri("https://localhost:7095/"); }
);

builder.Services.AddSingleton<Services>();
builder.Services.AddHttpClient<IServices, Services>(

    c => { c.BaseAddress = new Uri("https://localhost:7095/"); }
);

builder.Services.AddSingleton<Packages>();
builder.Services.AddHttpClient<IPackages, Packages>(

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
