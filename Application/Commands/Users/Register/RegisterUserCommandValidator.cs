using Domain;
using FluentValidation;
using Infrastructure.Repositories.Users;

namespace Application.Commands.Users.Register
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(command => command.NewUser.Username)
                .NotEmpty().WithMessage("Username is required")
                .Must(BeUniqeUsername).WithMessage("Username is already taken.");
        }

        private bool BeUniqeUsername(string username)
        {
            List<User> allUsersFromDatabase = _userRepository.GetAllUser().Result;

            return !allUsersFromDatabase.Any(user => user.Username == username);
        }
    }
}
