using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Users.Model;
using Auth;

namespace ecommerce_api.Service;
public class TokenService
{

    public static object GenerateToken(User user)
    {
        if(user.Role != Roles.Admin)
        {
            throw new Exception("Common users cannot get permissions");
        }
        
        var key = Encoding.UTF8.GetBytes(ApiKey.Secret);
        var tokenConfig = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("userId", user.UserId.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(3),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenConfig);
        var tokenString = tokenHandler.WriteToken(token);

        return new
        {
            token = tokenString
        };

    }

}