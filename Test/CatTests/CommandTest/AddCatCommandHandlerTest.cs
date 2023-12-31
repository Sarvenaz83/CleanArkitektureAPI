﻿using Application.Commands.Cats.AddCat;
using Infrastructure.Database;
using Domain.Models;
using Application.Dtos;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatCommandHandlerTest
    {
        private AddCatCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            _mockDatabase = new MockDatabase();
            _handler = new AddCatCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_AddNewCatToDatabase()
        {
            //Arrange
            var newCat = new CatDto { Name = "NewCatName" };
            var addCatCommand = new AddCatCommand(newCat);

            //Act
            var result = await _handler.Handle(addCatCommand, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
            Assert.That(result.Name, Is.EqualTo(newCat.Name));
            Assert.IsTrue(_mockDatabase.Cats.Contains(result));
        }

        [Test]
        public async Task Handle_WithNullName_ShouldNotCreateCat()
        {
            //Arrang
            var newCat = new CatDto { Name = "" };
            var addCatCommand = new AddCatCommand(newCat);


            //Act
            var result = await _handler.Handle(addCatCommand, CancellationToken.None);

            //Assert
            Assert.IsNull(result);

        }
    }


}
