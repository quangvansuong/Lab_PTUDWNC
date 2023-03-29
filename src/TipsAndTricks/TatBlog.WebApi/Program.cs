using NLog;
using NLog.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System;
using TatBlog.WebApi.Extensions;
using TatBlog.WebApi.Mapsters;
using TatBlog.WebApi.Validations;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");


    var builder = WebApplication.CreateBuilder(args);
    {
    // Add services to the container.
    builder
    .ConfigureCors()
    .ConfigureNLog()
    .ConfigureServices()
    .ConfigureSwaggerOpenApi()
    .ConfigureMapster()
    .ConfigureFluentValidation();



        //builder.Services.AddControllersWithViews();
    }
    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();
    {
        // Configure the HTTP request pipeline.
        app.SetupRequestPipeline();

        app.Run();
       
    }