using FluentValidation;
using Microsoft.AspNetCore.Builder;
using System.Reflection;

namespace TatBlog.WebApi.Validations
{
    public static class FluentValidationDependencyInjection
    {
        public static WebApplicationBuilder ConfigureFluentValidation(
            this WebApplicationBuilder builder)
        {
            // San and register all validation in given assembly
            builder.Services.AddValidatorsFromAssembly(
                Assembly.GetExecutingAssembly());

            return builder;
        }
    }
}
