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

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetAllDogsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_GetAllDogs_FromDatabase_ReturnsCorrect()
        {
            //Arrange
            var getAllDogQuery = new GetAllDogsQuery();

            //Act
            var result = await _handler.Handle(getAllDogQuery, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Dog>>(result);
        }
    }
}
