using Microsoft.AspNetCore.Http;

namespace Reservations.FrameworkExtensions
{
    public static class HttpContextDependencyResolver
    {
        public static T ResolveHttpContextDependency<T>(this HttpContext context)
        {
            T resolvedService = (T)context.RequestServices.GetService(typeof(T));
            return resolvedService;
        }
    }
}
