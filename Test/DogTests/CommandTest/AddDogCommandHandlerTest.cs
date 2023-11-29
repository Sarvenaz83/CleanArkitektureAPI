using Application.Commands.Dogs;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class AddDogCommandHandlerTest
    {
        private AddDogCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new AddDogCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_AddNewDogToDatabase()
        {
            //Arrange
            var newDog = new DogDto { Name = "NewDogName" };
            var addDogCommand = new AddDogCommand(newDog);

            //Act
            var result = await _handler.Handle(addDogCommand, CancellationToken.None);

            //Assert
            Assert.That(result, Is.Not.Null);
        }
    }
}
