using GatePass.Core.Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GatePass.Business
{
    public static class Startup
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            // automatically register all BusinessProviders
            foreach (var type in Assembly.GetAssembly(typeof(Startup))?
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i == typeof(IBusinessProvider)))
                ?? [])
            {
                services.AddScoped(type);
            }
        }

        public static void UseBusiness(this IApplicationBuilder app) { }
    }
}
