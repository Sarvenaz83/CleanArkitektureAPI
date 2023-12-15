using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
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
            var updateDogCommand = new UpdateDogByIdCommand(updatedDog: new DogDto { Name = "UpdatedDogName" }, id: newDog.Id);

            //Act
            var result = await _handler.Handle(updateDogCommand, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task Handle_WithNonExistentId_ShouldReturnNull()
        {
            //Arrang
            var nonExistentDogId = Guid.NewGuid();
            var updatedDogDto = new DogDto { Name = "UpdatedDogName" };
            var mockDatabase = new MockDatabase();
            var handler = new UpdateDogByIdCommandHandler(mockDatabase);

            var updateDogCommand = new UpdateDogByIdCommand(updatedDogDto, nonExistentDogId);

            //Act
            var updatedDog = await handler.Handle(updateDogCommand, CancellationToken.None);

            //Assert
            Assert.IsNull(updatedDog, "No dog should be updated for a non-existent dogId.");
        }
    }

}
