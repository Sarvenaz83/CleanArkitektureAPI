﻿using Application.Commands.Cats.DeleteCat;
using Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure.Database;

namespace Test.DogTests.CommandTest
{
    [TestFixture]
    public class DeleteDogByIdCommandHandlerTest
    {
        private DeleteDogByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new DeleteDogByIdCommandHandler(_mockDatabase);
        }
        [Test]
        public async Task Handle_DeleteDogById_InDatabase()
        {
            //Arrange
            var newDog = new Dog { Id = Guid.NewGuid(), Name = "" };
            _mockDatabase.Dogs.Add(newDog);

            //Create a sample of DleteDogByIdCommand
            var deleteDogByIdCommand = new DeleteDogByIdCommand(dogId: newDog.Id);

            //Act
            var result = await _handler.Handle(deleteDogByIdCommand, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task Handle_WithNonExistentDogId_ShouldReturnNull()
        {
            //Arrang
            var nonExistentDogId = Guid.NewGuid();
            var deleteDogCommand = new DeleteDogByIdCommand(nonExistentDogId);

            //Act
            var result = await _handler.Handle(deleteDogCommand, CancellationToken.None);

            //Assert
            Assert.Null(result);

        }
    }
}
