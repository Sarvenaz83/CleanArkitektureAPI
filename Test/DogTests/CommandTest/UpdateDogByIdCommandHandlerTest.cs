using Application.Commands.Dogs.UpdateDog;
using Domain.Models;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class UpdateDogByIdCommandHandlerTest
    {
        private UpdateDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;
        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateDogByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_UpdateDogByIdInDatabase()
        {
            //Arrange
            var newDog = new Dog { Id = Guid.NewGuid(), Name = "UpdateDogName" };
            _mockDatabase.Dogs.Add(newDog);

            //Create a sample
            var updateDogCommand = new UpdateDogByIdCommand(updatedDog: new Application.Dtos.DogDto { Name = "UpdatedDogName" }, id: newDog.Id);

            //Act
            var result = await _handler.Handle(updateDogCommand, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.That(result, Is.Not.Null);
        }
    }

}
