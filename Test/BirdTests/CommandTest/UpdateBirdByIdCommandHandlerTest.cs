using Application.Commands.Birds.UpdateBird;
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
    }
}
