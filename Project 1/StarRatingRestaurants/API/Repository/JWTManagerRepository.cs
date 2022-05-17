using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Models;
using BL;

namespace API.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private IConfiguration _configuration;
        private readonly IUserLogic _userlogic;
        
        public JWTManagerRepository(IConfiguration _configuration, IUserLogic _userLogic)
        {
            this._configuration = _configuration;
            this._userlogic = _userLogic;
        }
 
        public Token Authenticate(User user)
        {
            string thisUser = _userlogic.LogingIn(user);

            if (thisUser != "AdminMenu" && thisUser != "UserMenu")
            { return null; }

            var tokenhangler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity
                (
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName)
                    }
                ),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256)
            };
            var tokn = tokenhangler.CreateToken(tokenDescriptor);
            return new Token { Tokens = tokenhangler.WriteToken(tokn) };

        }
    }
}
