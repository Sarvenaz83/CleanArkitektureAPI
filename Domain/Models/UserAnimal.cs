using Domain.Models.Animal;

namespace Domain.Models
{
    public class UserAnimal
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = new User();

        public Guid AnimalId { get; set; }
        public AnimalModel Animal { get; set; } = new AnimalModel();
    }
}
