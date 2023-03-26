using Microsoft.EntityFrameworkCore;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;
using TatBlog.WebApp.Extensions;
using TatBlog.WebApp.Mapsters;
using TatBlog.WebApp.Validations;
using NLog;
using NLog.Web;
using System;

namespace TatBlog.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder
                    .ConfigureMvc()
                    .ConfigureServices()
                    .ConfiggureNLog()
                    .ConfigureMapster()
                    .ConfigureFluentValidation();

                //Add services to the container
                builder.Services.AddControllersWithViews();
                // Nlog: setup Nlog for Dependency
                builder.Logging.ClearProviders();
                builder.Host.UseNLog();  


            };

            var app = builder.Build();
            {
                app.UseRequestPipeLine();
                app.UseBlogRoutes();
                app.UseDataSeeder();

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

                app.UseHttpsRedirection();
                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();

                app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            }

          
            app.Run();

  
        }
    }
}