
using System.Diagnostics.CodeAnalysis;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.AutoFac;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here.
// Don't call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(
	builder => builder.RegisterModule(new AutoFacBusinessModule()));


// Add services to the container.
builder.Services.AddRazorPages();

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

app.MapControllers();

app.MapRazorPages();



app.Run();



