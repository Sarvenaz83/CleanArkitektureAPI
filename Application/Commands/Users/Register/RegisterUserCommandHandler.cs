using Domain;
using Infrastructure.Repositories.Users;
using MediatR;

namespace Application.Commands.Users.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, User>
    {

        private IUserRepository _userRepository;
        private RegisterUserCommandValidator _validator;

        public RegisterUserCommandHandler(IUserRepository userRepository, RegisterUserCommandValidator validator)
        {
            _userRepository = userRepository;
            _validator = validator;
        }

        public async Task<User> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var registerCommandValidation = _validator.Validate(request);

            if (!registerCommandValidation.IsValid)
            {
                var allErrors = registerCommandValidation.Errors.ConvertAll(errors => errors.ErrorMessage);

                throw new ArgumentException("Registration error: " + string.Join(", ", allErrors));
            }

            var userToCreate = new User
            {
                Id = Guid.NewGuid(),
                Username = request.NewUser.Username,
                Password = request.NewUser.Password,
            };

            var createdUser = await _userRepository.RegisterUser(userToCreate);

            return createdUser;
        }
    }
}
