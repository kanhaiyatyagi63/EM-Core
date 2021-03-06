global using EM.Services.Abstracts;
global using Microsoft.AspNetCore.Mvc;

using EM.DataLayer.Context;
using EM.Services;
using EM.Web.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();


builder.Services
       .AddDbContext<EmployeeContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataConnection")));

builder.Services.RegisterServices();

// http request piple
var app = builder.Build();
// middlewares => 

// 1. Bi-directional middleware
// 2. Unidirectional middleware
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseExceptionHandlerMiddleware();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();



// Heirarchy for getting configuration value

// appsetting
// application-secret
// system environment variable
// project environment variable
// argunment