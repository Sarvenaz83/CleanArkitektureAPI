using Infrastructure.Database.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<MyAppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Server=MINAZ\\SQLEXPRESS; Database=CleanArkitektureAPI; Trusted_Connection=true; TrustServerCertificate=true;")));

            return services;
        }
    }
}
