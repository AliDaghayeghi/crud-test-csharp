using Mc2.CrudTest.Api.Extensions.DependencyInjections;
using Mc2.CrudTest.Api.Extensions.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog();

var env = builder.Environment.EnvironmentName;

var configs = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false)
    .AddJsonFile($"appsettings.{env}.json", true)
    .AddEnvironmentVariables()
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configs)
    .Enrich.WithMachineName()
    .CreateLogger();

// Configure services
builder.Services.AddControllers();
builder.Services.AddConfiguredSwagger();
builder.Services.AddConfiguredMediatR();
builder.Services.AddConfiguredDatabase(configs);
builder.Services.AddServices();

var app = builder.Build();

// Configure
app.UseRouting();
app.MapControllers();
app.UseConfiguredSwagger();
app.UseConfiguredMigration();

app.Run();