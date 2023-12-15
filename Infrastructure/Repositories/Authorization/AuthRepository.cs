using Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Infrastructure.Database.MySQLDatabase;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Repositories.Authorization
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly RealDatabase _realDatabase;

        public AuthRepository(IConfiguration configuration, RealDatabase realDatabase)
        {
            _configuration = configuration;
            _realDatabase = realDatabase;
        }

        public virtual User AuthenticateUser(string username, string password)
        {
            var user = _realDatabase.Users.FirstOrDefault(user => user.Username == username && user.Password == password);

            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }

        public string GenerateJwtToken(User user)
        {
            var key = Encoding.ASCII.GetBytes(s: _configuration["JWTToken:Token"]!);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role,"Admin")
                }),

                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


    }
}
