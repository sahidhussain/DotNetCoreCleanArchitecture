using DotnetCore.Core.DTO.ApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace DotnetCore.Core.Utility
{
    public class JwtFactory : IJwtFactory
    {
        #region MEMBERS
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructor
        public JwtFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region METHOD: Create JWT Token
        public string GetJwtToken(CreateTokenDto dto)
        {
            // authentication successful so generate jwt token

            string SecretKey = Configuration.GetSection("JwtIssuerOptions:SecretKey").Value;
            SymmetricSecurityKey _signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SecretKey));
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString("dd-MM-yyyy")),
                    new Claim(JwtRegisteredClaimNames.Exp, ToUnixEpochDate(DateTime.UtcNow.AddDays(7)).ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("UserId", dto.UserId.ToString()),
                    new Claim("FirstName", dto.FirstName??string.Empty),
                    new Claim("LastName", dto.LastName??string.Empty),
                    new Claim(ClaimTypes.Email, dto.Email??string.Empty),
                    new Claim(ClaimTypes.Name, dto.FullName??string.Empty),
                    new Claim(ClaimTypes.Role, dto.UserInRole)
                }),

                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(_signingKey, SecurityAlgorithms.HmacSha256Signature)
            };
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        #endregion

        #region METHOD: Get User Id From JWT Token
        public string GetUserIdFromToken(HttpContext context)

        {
            try
            {
                ClaimsPrincipal principal = context.User;
                string UserId = string.Empty;
                string nameidentifier = @"http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
                if (principal?.Claims != null)
                {
                    foreach (Claim claim in principal.Claims)
                    {
                        UserId = principal?.Claims?.SingleOrDefault(p => (p.Type == nameidentifier || p.Type == "uniqueid"))?.Value;
                    }
                }
                return UserId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Convert To Seconds

        #endregion

        private static long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() -
                                  new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero))
                                 .TotalSeconds);
        }
    }
}
