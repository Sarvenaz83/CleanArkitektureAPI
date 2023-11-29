using Application.Commands.Cats.DeleteCat;
using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class DeleteCatByIdCommandHandlerTest
    {
        private DeleteCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_DeleteCatById_InDatabase()
        {
            //Arrange
            var newCat = new Cat { Id = Guid.NewGuid() };
            _mockDatabase.Cats.Add(newCat);

            //Create a sample of DleteCatByIdCommand
            var deleteCatByIdCommand = new DeleteCatByIdCommand(catId: newCat.Id);

            //Act
            var result = await _handler.Handle(deleteCatByIdCommand, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);

            //Chech That cat has deleted from mock database
            var deletedCatByIdInDatabase = _mockDatabase.Cats.FirstOrDefault(cat => cat.Id == deleteCatByIdCommand.Id);
            Assert.IsNull(deletedCatByIdInDatabase);
        }
    }
}
