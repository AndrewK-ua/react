using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Lab1.Helpers
{
    public static class JsonWebTokenHelper
    {
        public static string GenerateJsonWebToken(int userId, string userEmail)
        {
            var issuer = "WebApi";
            var audience = "WebApi-User";
            var secretKey = "WebApi-SecretKey";
            int tokenLifeTime = 10;

            var encodedSecretKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(secretKey));
            var credentials = new SigningCredentials(
                encodedSecretKey,
                SecurityAlgorithms.HmacSha256
            );

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, userEmail)
            };

            int expirationTime = tokenLifeTime;

            // creating JWT
            var jwt = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(expirationTime),
                signingCredentials: credentials
            );

            string encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return encodedJwt;
        }
    }
}
