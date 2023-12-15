using Domain.Models.Animal;

namespace Domain.Models
{
    public class Cat : AnimalModel
    {
        public new Guid Id { get; set; }
        public new string Name { get; set; } = string.Empty;
        public bool LikesToPlay { get; set; }
        public override string TypeOfAnimal => "Cat";
        public override string animalCanDo => "This animal can climp of tree.";
    }
}
