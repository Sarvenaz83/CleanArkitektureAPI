using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public class DataBaseConfiguration : IDatabaseConfiguration
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlServer(connectionString).AddInterceptors(new CommandLoggingInterceptor());
        }
    }
}
