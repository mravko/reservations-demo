using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Hosting;


namespace Reservations.Middleware
{
    public static class MiddlewareExtensions
    {
        public static void KeepAliveMiddleware(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("I AM ALIVE");
            });
        }
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }

        public static IApplicationBuilder UseDataLocalizationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DataLocalizationMiddleware>();
        }

        public static IApplicationBuilder SetupLocalizationMiddleware(this IApplicationBuilder app)
        {
            var supportedCultures = new[]
               {
                    new CultureInfo("en-US"),
                    new CultureInfo("fr-FR")
                };
            return app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
        }
    }
}
