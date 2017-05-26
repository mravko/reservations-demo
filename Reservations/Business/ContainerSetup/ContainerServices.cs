using Microsoft.Extensions.DependencyInjection;
using Reservations.Business.Contracts;
using Reservations.Implementations.Business;

namespace Reservations.Business.ContainerSetup
{
    public static class ContainerServices
    {
        public static void RegisterTransientServices(this IServiceCollection services) {
            
        }
        
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddTransient<IReservationConductor, ReservationConductor>();
        }
    }
}
