using GatePass.Core.Framework;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GatePass.Data
{
    public static class Startup
    {
        public static void AddData(this IServiceCollection services, IConfiguration configuration)
        {
            // automatically register all DataProviders
            foreach (var type in Assembly.GetAssembly(typeof(Startup))?
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i == typeof(IDataProvider)))
                ?? [])
            {
                services.AddScoped(type);
            }

            // add database context
            services.AddDbContext<DatabaseContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("GatePassDb");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)); // TODO lookup lazy loading
            });
        }

        public static async void UseData(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            using var sqlContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            await sqlContext.Database.MigrateAsync();
        }
    }
}
