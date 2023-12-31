﻿using Application.Queries.Cats.GetById;
using Domain.Models;
using Infrastructure.Database;

namespace Test.CatTests.QueryTest
{
    [TestFixture]
    public class GetCatByIdQueryHandlerTest
    {
        private GetCatByIdQueryHandler _handler;
        private MockDatabase _mockDatabase;


        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new GetCatByIdQueryHandler(_mockDatabase);

        }
        [Test]
        public async Task Handle_ValidId_ReturnsCorrectCat()
        {
            // Arrange
            var Id = new Guid("09876543-1234-0987-6543-098765432109");

            var query = new GetCatByIdQuery(Id);

            // Act
            var result = await _handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(Id));
        }

        [Test]
        public async Task Handle_InvalidCatId_ReturnsNull()
        {
            //Arrange
            var invalidCatId = Guid.NewGuid();

            var query = new GetCatByIdQuery(invalidCatId);

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsNull(result);
        }

    }
}
