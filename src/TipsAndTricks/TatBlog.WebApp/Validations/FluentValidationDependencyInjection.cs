using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace TatBlog.WebApp.Validations
{
    public static class FluentValidationDependencyInjection
    {
        public static WebApplicationBuilder ConfigureFluentValidation(
           this WebApplicationBuilder builder)
        {
            // Enable client-side intergration
            builder.Services.AddFluentValidationClientsideAdapters();

            // Scan and register all validators in give asembly
            builder.Services.AddValidatorsFromAssembly(
                   Assembly.GetExecutingAssembly());

            return builder;
        }
    }
   
}
