using Application.Commands.Birds.DeleteBird;
using Domain.Models;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class DeleteBirdByIdCommandHandlerTest
    {
        private DeleteBirdByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteBirdByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_DeleteBirdById_InDatabase()
        {
            //Arrange
            var newBird = new Bird { Id = Guid.NewGuid() };
            _mockDatabase.Birds.Add(newBird);

            //Create a sample of DleteBirdByIdCommand
            var deleteBirdByIdCommand = new DeleteBirdByIdCommand(birdId: newBird.Id);

            //Act
            var result = await _handler.Handle(deleteBirdByIdCommand, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);

            //Chech That bird has deleted from mock database
            var deletedBirdByIdInDatabase = _mockDatabase.Birds.FirstOrDefault(bird => bird.Id == deleteBirdByIdCommand.Id);
            Assert.IsNull(deletedBirdByIdInDatabase);
        }
    }
}
