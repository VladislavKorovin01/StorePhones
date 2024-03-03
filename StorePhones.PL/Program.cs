using Microsoft.Extensions.Options;
using StorePhones.DAL;
using StorePhones.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseStaticFiles();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Phone}/{action=Index}/{id?}");

app.Run();
