using Application.Queries.Dogs;
using Application.Queries.Dogs.GetAll;
using Domain.Models;
using Infrastructure.Database;

namespace Test.DogTests.QueryTest
{
    [TestFixture]
    public class GetAllDogsQueryHandlerTest
    {
        private MockDatabase _mockDatabase;
        private GetAllDogsQueryHandler _handler;
        private MockDatabase _originalDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetAllDogsQueryHandler(_mockDatabase);
            _originalDatabase = new MockDatabase();
        }

        [Test]
        public async Task Handle_GetAllDogs_FromDatabase_ReturnsCorrect()
        {
            //Arrange
            List<Dog> listOfDog = _originalDatabase.Dogs.ToList();

            //Act
            List<Dog> result = await _handler.Handle(new GetAllDogsQuery(), CancellationToken.None);

            //Assert
            CollectionAssert.AreEqual(listOfDog, result);
        }

        [Test]
        public async Task Handle_InvalidDogsInDatabase_ReturnsEmptyList()
        {
            //Arrange
            _mockDatabase = null;
            _handler = new GetAllDogsQueryHandler(_mockDatabase!);

            //Act
            List<Dog> result = await _handler.Handle(new GetAllDogsQuery(), CancellationToken.None);

            //Assert
            Assert.IsNull(result);

        }
    }
}
