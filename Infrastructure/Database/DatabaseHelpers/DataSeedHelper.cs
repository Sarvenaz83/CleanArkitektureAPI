using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.DatabaseHelpers
{
    public class DataSeedHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            SeedDogs(modelBuilder);
            SeedCats(modelBuilder);
            SeedBirds(modelBuilder);
        }

        private static void SeedDogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { Id = Guid.NewGuid(), Name = "Nonika" },
                new Dog { Id = Guid.NewGuid(), Name = "Mandy" },
                new Dog { Id = Guid.NewGuid(), Name = "Pappy" },
                new Dog { Id = Guid.NewGuid(), Name = "Sherek" }
                );
        }

        private static void SeedCats(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { Id = Guid.NewGuid(), Name = "Serdar" },
                new Dog { Id = Guid.NewGuid(), Name = "Simba" },
                new Dog { Id = Guid.NewGuid(), Name = "Misholak" },
                new Dog { Id = Guid.NewGuid(), Name = "Sezar" }
                );
        }

        private static void SeedBirds(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dog>().HasData(
                new Dog { Id = Guid.NewGuid(), Name = "Blåmess" },
                new Dog { Id = Guid.NewGuid(), Name = "Cortex" },
                new Dog { Id = Guid.NewGuid(), Name = "Fench" },
                new Dog { Id = Guid.NewGuid(), Name = "Feri" }
                );
        }
    }
}
