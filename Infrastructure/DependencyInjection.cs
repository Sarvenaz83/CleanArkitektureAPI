using Infrastructure.Database.MySQLDatabase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<RealDatabase>();

            services.AddDbContext<RealDatabase>(option =>
            {
                option.UseSqlServer("Server=MINAZ\\SQLEXPRESS; Database=minaz-claen-api-database; Trusted_Connection=True; TrustServerCertificate=True");
            });
            return services;
        }
    }
}
