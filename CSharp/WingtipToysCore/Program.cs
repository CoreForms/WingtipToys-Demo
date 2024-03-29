using CoreForms.Web.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

LegacyAspNetInitialization.License =
    "I hereby confirm that I use CoreForms only for trial purposes and have read and accept the CoreForms Trial License.";

LegacyAspNetInitialization.Initialize(
    new LegacyAspNetInitializationOptions(
        virtualPath: "/",
        physicalPath: Environment.CurrentDirectory));

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddLegacyAspNet();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapLegacyAspNet("/{**remainder}");

app.Run();
