using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public interface IDatabaseConfiguration
    {
        void Configure(DbContextOptionsBuilder optionBuilder, string connectionString);
    }
}
