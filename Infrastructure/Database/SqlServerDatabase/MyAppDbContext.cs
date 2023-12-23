using Domain;
using Domain.Models;
using Domain.Models.Animal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Database
{
    public class MyAppDbContext : DbContext
    {
        public MyAppDbContext() { }

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MINAZ\\SQLEXPRESS; Database=CleanArkitektureAPI; Trusted_Connection=true; TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuration many-to-many relationship
            modelBuilder.Entity<UserAnimal>().HasKey(_userAnimal => new { _userAnimal.UserId, _userAnimal.AnimalId });

            modelBuilder.Entity<UserAnimal>()
                .HasOne(_userAnimal => _userAnimal.User)
                .WithMany(_user => _user.UserAnimals)
                .HasForeignKey(_userAnimal => _userAnimal.UserId);

            modelBuilder.Entity<UserAnimal>()
                .HasOne(_userAnimal => _userAnimal.Animal)
                .WithMany(_animal => _animal.UserAnimals)
                .HasForeignKey(_userAnimal => _userAnimal.AnimalId);


        }
    }
}
