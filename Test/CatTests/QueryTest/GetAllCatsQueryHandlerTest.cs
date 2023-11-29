using Application.Queries.Cats.GetAll;
using Domain.Models;
using Infrastructure.Database;

namespace Test.CatTests.QueryTest
{
    public class GetAllCatsQueryHandlerTest
    {
        private MockDatabase _mockDatabase;
        private GetAllCatsQueryHandler _handler;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetAllCatsQueryHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_GetAllCats_FromDatabase_ReturnsCorrect()
        {
            //Arrange
            var getAllCatQuery = new GetAllCatsQuery();

            //Act
            var result = await _handler.Handle(getAllCatQuery, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<List<Cat>>(result);
        }
    }
}
