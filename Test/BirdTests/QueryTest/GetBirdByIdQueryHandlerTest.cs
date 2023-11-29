using Application.Queries.Birds.GetById;
using Application.Queries.Cats.GetById;
using Infrastructure.Database;

namespace Test.BirdTests.QueryTest
{
    [TestFixture]
    public class GetBirdByIdQueryHandlerTest
    {
        private GetBirdByIdQueryHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetBirdByIdQueryHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_ValidId_ReturnsCorrectBird()
        {
            // Arrange
            var birdId = new Guid("98765432-6543-6789-9867-987654567890");

            var query = new GetBirdByIdQuery(birdId);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(birdId));
        }
    }
}
