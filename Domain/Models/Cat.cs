using Domain.Models.Animal;

namespace Domain.Models
{
    public class Cat : AnimalModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public bool LikesToPlay { get; set; }
        public override string TypeOfAnimal => "Cat";
        public override string animalCanDo => "This animal can climp of tree.";
    }
}
