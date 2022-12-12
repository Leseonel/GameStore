using GameStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using GameStore.ValidateData;

#pragma warning disable S3010 // remove when initializing '_config' statically or removing


namespace GameStore.Services.TokenService
{
    public class JwtTokenService
    {
        private static IConfiguration _config;

        public JwtTokenService(IConfiguration config)
        {
            _config = config;
        }
        public Task<string> GenerateJwtAccessToken(UserModel userInfo, IList<string> userRoles)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName)
            };
            foreach (var role in userRoles)
            {
                _ = claims.Append(new Claim(ClaimTypes.Role, role));
            }


            var token = GenerateJwtToken(_config["JWT:Issuer"], _config["JWT:Audience"], _config["JWT:SecretKey"], 10, claims);

            return token;
        }

        private static Task<string> GenerateJwtToken(string issuer, string audience, string secretKey,
            double expirationTimeInMinutes, IEnumerable<Claim> claims = null)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credintials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(issuer, audience, claims,
                expires: DateTime.Now.AddMinutes(expirationTimeInMinutes),
                signingCredentials: credintials);

            return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token));
        }
        public Task<string> GenerateJwtRefreshToken()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var token = GenerateJwtToken(_config["JWT:Issuer"], _config["JWT:Audience"], _config["JWT:SecretKey"], 262800, claims);

            return token;
        }
        public Task<bool> ValidateRefreshToken(string refreshToken)
        {
            ValidateOnNullAndEmpty<string>.ValidateDataOnNullAndEmpty(refreshToken);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidIssuer = _config["JWT:Issuer"],
                ValidAudience = _config["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SecretKey"])),
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            _ = tokenHandler.ValidateToken(refreshToken, validationParameters, out SecurityToken validToken);

            return Task.FromResult(true);

        }
    }
}
