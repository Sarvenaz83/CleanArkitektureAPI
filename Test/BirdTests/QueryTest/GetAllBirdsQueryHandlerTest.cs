using Application.Queries.Birds.GetAll;
using Domain.Models;
using Infrastructure.Database;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetAllBirdsQueryHandlerTest
    {
        private MockDatabase _mockDatabase;
        private GetAllBirdsQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetAllBirdsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_GetAllBirds_FromDatabase_ReturnsCorrect()
        {
            //Arrange
            var getAllBirdQuery = new GetAllBirdsQuery();

            //Act
            var result = await _handler.Handle(getAllBirdQuery, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Bird>>(result);
        }
    }
}
