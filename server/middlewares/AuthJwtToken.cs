using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace server.middlewares
{
    public class AuthJwtToken
    {
        private readonly IConfiguration _configuration;

        public AuthJwtToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(string email)
        {
            List<Claim> claims = new List<Claim>{
            new Claim(ClaimTypes.UserData,email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!
            ));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        public string ValidateToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero,
                    //ValidAlgorithms = SecurityAlgorithms.HmacSha256Signature
                };

                handler.ValidateToken(token, validationParameters, out var validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountEmail = jwtToken.Claims.First(x => x.Type == ClaimTypes.UserData).Value;
                return accountEmail;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi giải mã thất bại
                throw new Exception(ex.Message);
            }
        }
    }
}
