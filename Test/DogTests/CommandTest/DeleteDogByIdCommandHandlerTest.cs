using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class DeleteDogByIdCommandHandlerTest
    {
        private DeleteDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteDogByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_DeleteDogById_InDatabase()
        {
            //Arrange
            var newDog = new Dog { Id = Guid.NewGuid() };
            _mockDatabase.Dogs.Add(newDog);

            //Create a sample of DleteDogByIdCommand
            var deleteDogByIdCommand = new DeleteDogByIdCommand(dogId: newDog.Id);

            //Act
            var result = await _handler.Handle(deleteDogByIdCommand, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);

            //Chech That dog has deleted from mock database
            var deletedDogByIdInDatabase = _mockDatabase.Dogs.FirstOrDefault(dog => dog.Id == deleteDogByIdCommand.Id);
            Assert.IsNull(deletedDogByIdInDatabase);
        }
    }
}
