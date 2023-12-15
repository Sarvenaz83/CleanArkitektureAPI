using Domain;
using Domain.Models;
using Infrastructure.Database.DatabaseHelpers;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Infrastructure.Database.MySQLDatabase
{
    public class RealDatabase : DbContext
    {
        public RealDatabase() { }

        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options)
        {

        }


        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<Bird> Birds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MINAZ\\SQLEXPRESS; Database=minaz-claen-api-database; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DataSeedHelper.SeedData(modelBuilder);
        }
    }
}
