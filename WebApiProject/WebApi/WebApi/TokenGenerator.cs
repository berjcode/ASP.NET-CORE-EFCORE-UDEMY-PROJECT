using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WebApi
{
    public class TokenGenerator
    {

        public string GenerateToken()
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Abdullah"));

            SigningCredentials credentials =new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(issuer:"http//localhost",audience :"http//localhost",notBefore:DateTime.Now,expires:DateTime.Now.AddMinutes(1),signingCredentials:credentials);

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }
}
