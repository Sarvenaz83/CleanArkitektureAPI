using Domain.Models.Animal;

namespace Domain.Models
{
    public class Bird : AnimalModel
    {
        public new Guid Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public override string TypeOfAnimal => "Bird";
        public override string animalCanDo => "This animal can fly";
        public bool CanFly { get; set; }
    }
}
