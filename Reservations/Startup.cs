using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Reservations.Middleware;
using Reservations.Localization;
using Microsoft.EntityFrameworkCore;
using Reservations.Business.ContainerSetup;

namespace Reservations
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)

                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(typeof(ILocalizationService), typeof(DataLocalizationService));

            //this is Microsoft localization using files
            services.AddLocalization();

            services.AddMvc();
            
            services.AddDbContext<ReservationsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.RegisterScopedServices();
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory,
            ILocalizationService localization)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseExceptionHandlingMiddleware();
            app.Map("/keepalive", MiddlewareExtensions.KeepAliveMiddleware);

            app.SetupLocalizationMiddleware();
            app.UseDataLocalizationMiddleware();

            app.UseMvc();
        }
    }
}