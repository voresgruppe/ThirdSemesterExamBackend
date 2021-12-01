using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security.Services
{
    public class SecurityService: ISecurityService
    {
        private readonly AuthDbContext _ctx;
        public IConfiguration Configuration { get; }

        public SecurityService(IConfiguration configuration, AuthDbContext ctx)
        {
            _ctx = ctx;
            Configuration = configuration;
        }

        public JwtToken GenerateJwtToken(string username, string password)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(Configuration["Jwt:Issuer"],
                Configuration["Jwt:Audience"],
                null,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);
            return new JwtToken()
            {
                Jwt = new JwtSecurityTokenHandler().WriteToken(token),
                Message = "Ok"
            };
        }
    }
}