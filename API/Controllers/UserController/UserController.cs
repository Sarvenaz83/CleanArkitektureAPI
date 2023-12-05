using Application.Dtos;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.Username = request.Username;
            user.Password = password;

            return Ok(user);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserDto request)
        {
            if (user.Username != request.Username)
            {
                return BadRequest("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest("Password is wrong!");
            }

            string token = GenerateJWTToken(user);
            return Ok(token);
        }

        private string GenerateJWTToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin"),
            };

            var key = Encoding.ASCII.GetBytes(
                _configuration["JWTToken:Token"]!);


            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
