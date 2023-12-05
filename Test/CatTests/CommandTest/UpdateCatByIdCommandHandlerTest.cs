using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Domain.Models;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class UpdateCatByIdCommandHandlerTest
    {
        private UpdateCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new UpdateCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_UpdateCatByIdInDatabase()
        {
            //Arrange
            var newCat = new Cat { Id = Guid.NewGuid(), Name = "UpdateCatName", LikesToPlay = true };
            _mockDatabase.Cats.Add(newCat);

            //Create a sample
            var updateCatCommand = new UpdateCatByIdCommand(updatedCat: new CatDto { Name = "UpdatedCatName", LikesToPlay = false }, id: newCat.Id);

            //Act
            var result = await _handler.Handle(updateCatCommand, CancellationToken.None);

            //Assert
            Assert.NotNull(result);
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task Handle_WithNonExistentId_ShouldReturnNull()
        {
            //Arrang
            var nonExistentCatId = Guid.NewGuid();
            var updatedCatDto = new CatDto { Name = "UpdatedCatName" };
            var mockDatabse = new MockDatabase();
            var handler = new UpdateCatByIdCommandHandler(mockDatabse);

            var updateCatCommand = new UpdateCatByIdCommand(updatedCatDto, nonExistentCatId);

            //Act
            var updatedCat = await handler.Handle(updateCatCommand, CancellationToken.None);

            //Assert
            Assert.IsNull(updatedCat, "No cat should be updated for a non-existent catId.");
        }
    }
}
