using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JWTtoken
{
    public class Auth : IJwtAuth
    {
        private readonly string username = "Sankeerth";
        private readonly string password = "123456";
        private readonly string key;
        public Auth(string key)
        {
            this.key = key;
        }
        public string Authentication(string username, string password)
        {
            if(!(username.Equals(username)|| password.Equals(password)))
            {
                return null;
            }
            //Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();
            //Creating private Key to Encrypt
            var tokenKey = System.Text.Encoding.ASCII.GetBytes(key);
            //setting cryptographic algorithm
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials=new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);//create token
            return tokenHandler.WriteToken(token);//return token from method 
        }
        //public string Authentication(string username, string password)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
