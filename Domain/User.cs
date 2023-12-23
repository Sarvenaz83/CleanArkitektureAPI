using Domain.Models;

namespace Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        //Navigation property for many-to-many relationship
        public ICollection<UserAnimal> UserAnimals { get; set; } = new List<UserAnimal>();
    }
}
