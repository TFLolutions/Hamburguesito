using HamburguesitoNet.Application.Common.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Utils
{
    public class JwtHelper
    {
        private readonly IConfiguration _configuration;
        public readonly IDateTime _dateTime;
        public JwtHelper(IConfiguration configuration, IDateTime dateTime)
        {
            _configuration = configuration;
            _dateTime = dateTime;
        }

        public JwtSecurityToken GenerateJwtToken(string userName, IList<string>? roleUser, int? tenantId = null)
        {
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userName),
                };
            if (tenantId != null)
            {
                authClaims.Add(new Claim("TenantId", tenantId.ToString()));
            }
            if (roleUser != null)
            {
                foreach (string role in roleUser)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecretKey"]));

            var token = new JwtSecurityToken(issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                expires: _dateTime.Now.AddDays(30));

            return token;
        }
    }
}
