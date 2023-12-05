using Application.Queries.Cats.GetAll;
using Application.Queries.Dogs.GetAll;
using Application.Queries.Dogs;
using Domain.Models;
using Infrastructure.Database;

namespace Test.CatTests.QueryTest
{
    [TestFixture]
    public class GetAllCatsQueryHandlerTest
    {
        private MockDatabase _mockDatabase;
        private GetAllCatsQueryHandler _handler;
        private MockDatabase _originalDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetAllCatsQueryHandler(_mockDatabase);
            _originalDatabase = new MockDatabase();
        }

        [Test]
        public async Task Handle_GetAllCats_FromDatabase_ReturnsCorrect()
        {
            //Arrange
            List<Cat> listOfCat = _originalDatabase.Cats;

            //Act
            List<Cat> result = await _handler.Handle(new GetAllCatsQuery(), CancellationToken.None);

            //Assert
            CollectionAssert.AreEqual(listOfCat, result);
        }

        [Test]
        public async Task Handle_InvalidCatsInDatabase_ReturnsEmptyList()
        {
            //Arrange
            _mockDatabase = null;
            _handler = new GetAllCatsQueryHandler(_mockDatabase!);

            //Act
            List<Cat> result = await _handler.Handle(new GetAllCatsQuery(), CancellationToken.None);

            //Assert
            Assert.IsNull(result);

        }
    }
}
