using Application.Commands.Users.Register;
using Application.Dtos.Users;
using Application.Dtos.Validation;
using Application.Validators.User;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Exceptions.Authorize;
using Application.Queries.UsersLogin;

namespace API.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        internal readonly IMediator _imediator;
        internal readonly UserValidator _userValidator;

        public UserController(IMediator mediator, UserValidator userValidator)
        {
            _imediator = mediator;
            _userValidator = userValidator;
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserCredentialsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Errors), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<User>> Register([FromBody] UserCredentialsDto userToRegister)
        {
            var inputValidation = _userValidator.Validate(userToRegister);

            if (!inputValidation.IsValid)
            {
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                return Ok(await _imediator.Send(new RegisterUserCommand(userToRegister)));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Errors), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<User>> Login([FromBody] UserCredentialsDto userToLogin)
        {
            var inputValidation = _userValidator.Validate(userToLogin);

            if (!inputValidation.IsValid)
            {
                return BadRequest(inputValidation.Errors.ConvertAll(errors => errors.ErrorMessage));
            }

            try
            {
                string token = await _imediator.Send(new LoginUserQuery(userToLogin));
                return Ok(new TokenDto { TokenValue = token });
            }

            catch (UnAuthorizedException ex)
            {
                return BadRequest(ex.Message);
            }
        }




    }
}
