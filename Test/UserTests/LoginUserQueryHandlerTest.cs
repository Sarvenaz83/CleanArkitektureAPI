using Application.Dtos.Users;
using Application.Queries.UsersLogin;
using Domain;
using Infrastructure.Repositories.Authorization;
using Moq;

namespace Test.UserTests
{
    [TestFixture]
    public class LoginUserQueryHandlerTest
    {
        private LoginUserQueryHandler _handler;
        private Mock<IAuthRepository> _authRepository;

        [SetUp]
        public void SetUp()
        {
            _authRepository = new Mock<IAuthRepository>();
            _handler = new LoginUserQueryHandler(_authRepository.Object);
        }

        private void SetupMockUserRepository(List<User> users)
        {
            _authRepository.Setup(repository => repository.AuthenticateUser(It.IsAny<string>(), It.IsAny<string>())).Returns<string, string>((username, password) =>
            {
                return users.FirstOrDefault(user => user.Username == username && user.Password == password)!;
            });

            _authRepository.Setup(repository => repository.GenerateJwtToken(It.IsAny<User>())).Returns("FakeJwtToken");
        }

        [Test]
        public async Task Handle_ValidUserForLogin_ReturnsToken()
        {
            //Arrange
            var users = new List<User>
            {
                new() { Username = "TestUsername", Password = "Testpassword!" }
            };

            SetupMockUserRepository(users);

            var loginUserQuery = new LoginUserQuery(new UserCredentialsDto
            {
                Username = "TestUsername",
                Password = "Testpassword!"
            });

            //Act
            var result = await _handler.Handle(loginUserQuery, CancellationToken.None);

            //Assert
            Assert.That(result, Is.EqualTo("FakeJwtToken"));
        }

        [Test]
        public void Handle_InvalidUserForLogin_ThrowsUnauthorizedAccessException()
        {
            //Arrange
            var users = new List<User>();
            SetupMockUserRepository(users);

            var loginUserQuery = new LoginUserQuery(new UserCredentialsDto
            {
                Username = "nonExisttentUser",
                Password = "incorrectTestPassword!"
            });

            //Act & Assert
            Assert.ThrowsAsync<UnauthorizedAccessException>(() =>
            _handler.Handle(loginUserQuery, CancellationToken.None
            ));
        }
    }
}
