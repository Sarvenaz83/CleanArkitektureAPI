using Application.Queries.Birds.GetAll;
using Domain.Models;
using Infrastructure.Database;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetAllBirdsQueryHandlerTest
    {
        private MockDatabase? _mockDatabase;
        private GetAllBirdsQueryHandler _handler;
        private MockDatabase _originalDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new GetAllBirdsQueryHandler(_mockDatabase);
            _originalDatabase = new MockDatabase();
        }

        [Test]
        public async Task Handle_GetAllBirds_FromDatabase_ReturnsCorrect()
        {
            //Arrange
            List<Bird> listOfBird = _originalDatabase.Birds.ToList();

            //Act
            List<Bird> result = await _handler.Handle(new GetAllBirdsQuery(), CancellationToken.None);

            //Assert
            CollectionAssert.AreEqual(listOfBird, result);
        }

        [Test]
        public async Task Handle_InvalidBirdsInDatabase_ReturnsEmptyList()
        {
            //Arrange
            _mockDatabase = null;
            _handler = new GetAllBirdsQueryHandler(_mockDatabase!);

            //Act
            List<Bird> result = await _handler.Handle(new GetAllBirdsQuery(), CancellationToken.None);

            //Assert
            Assert.IsNull(result);

        }
    }
}
