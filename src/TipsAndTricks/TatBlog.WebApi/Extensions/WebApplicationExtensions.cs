﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TatBlog.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using TatBlog.Services.Timing;
using TatBlog.Services.Media;
using TatBlog.Services.Blogs;
using Microsoft.Extensions.Logging;
using NLog.Web;
using Microsoft.Extensions.Hosting;


namespace TatBlog.WebApi.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplicationBuilder ConfigureServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddMemoryCache();

            builder.Services.AddDbContext<BlogDbContext>(options =>
                    options.UseSqlServer(
                        builder.Configuration
                        .GetConnectionString("DefaultConnection")));

            builder.Services
                .AddScoped<ITimeProvider, LocalTimeProvider>();
            builder.Services
                .AddScoped<IMediaManager, LocalFileSystemMediaManager>();
            builder.Services
                .AddScoped<IBlogRepository, BlogRepository>();
            builder.Services
                .AddScoped<IAuthorRepository, AuthorRepository>();

            return builder;
        }

        public static WebApplicationBuilder ConfigureCors(
           this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("TatBlogApp", policyBuider =>
                policyBuider
                .AllowAnyOrigin()
                 .AllowAnyHeader()
                .AllowAnyMethod());
            });

            return builder;
        }

        // Cấu hình việc sử dụng NLong
        public static WebApplicationBuilder ConfigureNLog(
           this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            return builder;
        }

        public static WebApplicationBuilder ConfigureSwaggerOpenApi
           (this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder;
        }

        public static WebApplication SetupRequestPipeline
           (this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseCors("TatBlogApp");

            return app;
        }
        }
}
