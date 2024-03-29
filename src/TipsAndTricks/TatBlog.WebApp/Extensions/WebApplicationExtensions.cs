﻿using Microsoft.EntityFrameworkCore;
using NLog.Web;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;
using TatBlog.Services.Media;
using TatBlog.WebApp.Middlewares;

namespace TatBlog.WebApp.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplicationBuilder ConfiggureNLog(
            this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Host.UseNLog();

            return builder;
        }
        public static WebApplicationBuilder ConfigureMvc(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddControllersWithViews();
            builder.Services.AddResponseCompression();

            return builder;
        }
        // Đăng ký các dịch vụ với DI Container
        public static WebApplicationBuilder ConfigureServices(
            this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<BlogDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration
                        .GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IMediaManager, LocalFileSystemMediaManager>();
            builder.Services.AddScoped<IBlogRepository, BlogRepository>();
            builder.Services.AddScoped<IDataSeeder, DataSeeder>();
         
            return builder;
        }

        public static WebApplication UseRequestPipeLine(
            this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Blog/Error");

                app.UseHsts();
            }

            app.UseResponseCompression();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // Thêm middleware lựa chọn endpoint phù hợp nhất
            // để xử lý 1 HTTP reques
            app.UseRouting();

            // Thêm middleware để lưu vết người dùng
            app.UseMiddleware<UserActivityMiddleware>();
            return app;
        }

        public static IApplicationBuilder UseDataSeeder(
            this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            try
            {
                scope.ServiceProvider
                    .GetRequiredService<IDataSeeder>()
                    .Initialize();
            }
            catch (Exception ex)
            {
                scope.ServiceProvider
                    .GetRequiredService<ILogger<Program>>()
                    .LogError(ex, "Could not insert data into database");
            }

            return app;
        }
    }
}