using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Reservations.FrameworkExtensions;
using Reservations.Localization;
using System.Threading.Tasks;

namespace Reservations.Middleware
{
    public class DataLocalizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public DataLocalizationMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionHandlingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Setting up data localization middleware");

            ILocalizationService _localizationService = context.ResolveHttpContextDependency<ILocalizationService>();

            _localizationService.SetupLocalization(context);

            await _next.Invoke(context);
        }
    }
}
