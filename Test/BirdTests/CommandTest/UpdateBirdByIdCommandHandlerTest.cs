using Application.Commands.Birds.UpdateBird;
using Application.Commands.Dogs.UpdateDog;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class UpdateBirdByIdCommandHandlerTest
    {
        private UpdateBirdByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_UpdateBirdByIdInDatabase()
        {
            //Arrange
            var newBird = new Bird { Id = Guid.NewGuid(), Name = "UpdateBirdName", CanFly = true };
            _mockDatabase.Birds.Add(newBird);

            //Create a sample
            var updateBirdCommand = new UpdateBirdByIdCommand(updatedBird: new Application.Dtos.BirdDto { Name = "UpdatedBirdName", CanFly = false }, id: newBird.Id);

            //Act
            var result = await _handler.Handle(updateBirdCommand, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task Handle_WithNonExistentId_ShouldReturnNull()
        {
            //Arrang
            var nonExistentBirdId = Guid.NewGuid();
            var updatedBirdDto = new BirdDto { Name = "UpdatedBirdName" };
            var mockDatabse = new MockDatabase();
            var handler = new UpdateBirdByIdCommandHandler(mockDatabse);

            var updateBirdCommand = new UpdateBirdByIdCommand(updatedBirdDto, nonExistentBirdId);

            //Act
            var updatedBird = await handler.Handle(updateBirdCommand, CancellationToken.None);

            //Assert
            Assert.IsNull(updatedBird, "No bird should be updated for a non-existent birdId.");
        }
    }
}
