using Application.Commands.Birds.AddBird;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.BirdTests.CommandTest
{
    [TestFixture]
    public class AddBirdCommandHandlerTest
    {
        private AddBirdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new AddBirdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_AddNewBirdToDatabase()
        {
            //Arrange
            var newBird = new BirdDto { Name = "NewBirdName" };
            var addBirdCommand = new AddBirdCommand(newBird);

            //Act
            var result = await _handler.Handle(addBirdCommand, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
