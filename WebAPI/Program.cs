
using System.Diagnostics.CodeAnalysis;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.AutoFac;
using Core.Utilities.Security.Encription;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

// Register services directly with Autofac here.
// Don't call builder.Populate(), that happens in AutofacServiceProviderFactory.
builder.Host.ConfigureContainer<ContainerBuilder>(
	builder => builder.RegisterModule(new AutoFacBusinessModule()));


//Cors
builder.Services.AddCors(options =>
	options.AddPolicy("AllowOrigin",
		builder => builder.WithOrigins("http://localhost:3000")));



//Get Token Options
var configuration = builder.Configuration;
var tokenOptions = new TokenOptions();
configuration.GetSection("TokenOptions").Bind(tokenOptions);

//Json Web Token Service

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidIssuer = tokenOptions.Issuer,
				ValidAudience = tokenOptions.Audience,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

			};
		});

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

//Cors
// Cors
app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// UseAuthentication ve UseAuthorization middleware'lerini ekleme sýrasýný deðiþtir
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();



