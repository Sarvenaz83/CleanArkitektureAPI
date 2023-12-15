using Domain.Models.Animal;

namespace Domain.Models
{
    public class Dog : AnimalModel
    {
        public new Guid Id { get; set; }
        public new required string Name { get; set; } = string.Empty;
        public override string TypeOfAnimal => "Dog";
        public override string animalCanDo => "This animal can bark.";
    }
}
