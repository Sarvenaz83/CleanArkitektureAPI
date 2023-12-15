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
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(newBird.Name));
            Assert.IsTrue(_mockDatabase.Birds.Contains(result));
        }
        [Test]
        public async Task Handle_WithNullName_ShouldNotCreateBird()
        {
            //Arrang
            var newBird = new BirdDto { Name = "" };
            var addBirdCommand = new AddBirdCommand(newBird);


            //Act
            var result = await _handler.Handle(addBirdCommand, CancellationToken.None);

            //Assert
            Assert.IsNull(result);

        }
    }
}
