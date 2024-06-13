using eShop.MetallFactorUI.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Serilog;
//using Serilog.Events;
using Microsoft.Extensions.Hosting;
using MetallFactorUI.Infrastructure;
using eShop.MetallFactorUI.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog for logging
//builder.Logging.ClearProviders(); // Clear other logging providers

/*
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
   // builder.Logging.AddSerilog(Log.Logger);
*/
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//builder.Services.AddScoped<EmailService>();
builder.Services.AddHttpClient<EmailService>(o => o.BaseAddress = new("http://localhost:5047/api/"));

builder.Services.AddSingleton<CacheService>();

builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("WorkRequestDB")));
/*
        builder.AddNpgsqlDbContext<AppDbContext>("catalogdb", configureDbContextOptions: dbContextOptionsBuilder =>
        {
            dbContextOptionsBuilder.UseNpgsql(builder =>
            {
                builder.UseVector();
            });
        });
*/

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();