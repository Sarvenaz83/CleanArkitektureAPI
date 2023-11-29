using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        //Dogs in mockDatabase
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }

        private static List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Björn"},
            new Dog { Id = Guid.NewGuid(), Name = "Patrik"},
            new Dog { Id = Guid.NewGuid(), Name = "Alfred"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"}
        };

        //Cats in mockDatabase
        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        private static List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Simba", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Sezar", LikesToPlay = false },
            new Cat { Id = Guid.NewGuid(), Name = "Micky", LikesToPlay= false },
            new Cat { Id = Guid.NewGuid(), Name = "Mini", LikesToPlay = true},
            new Cat { Id = new Guid("09876543-1234-0987-6543-098765432109"), Name = "TestCatForUnitTests"}
        };
    }
}
