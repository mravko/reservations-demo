using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Reservations.Exceptions;
using System;
using System.Threading.Tasks;

namespace Reservations.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionHandlingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            _logger.LogInformation("Setting up exception handling middleware");
            try
            {
                await _next.Invoke(context);
            }
            catch (ReservationException e)
            {
                _logger.LogError("Reservation exception: " + e.Message);
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";
                var json = JsonConvert.SerializeObject(new
                {
                    message = e.Message
                });

                await context.Response.WriteAsync(json);
            }
            catch (Exception e)
            {
                _logger.LogCritical("Unhandled exception: " + e.Message);

                _logger.LogTrace(new EventId(), e, e.Message);
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var json = JsonConvert.SerializeObject(new
                {
                    message = "UNHANDLED EXCEPTION"
                });

                await context.Response.WriteAsync(json);
            }
        }
    }
}
