using Domain.Models.Animal;

namespace Domain.Models
{
    public class Dog : AnimalModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public override string TypeOfAnimal => "Dog";
        public override string animalCanDo => "This animal can bark.";
    }
}
