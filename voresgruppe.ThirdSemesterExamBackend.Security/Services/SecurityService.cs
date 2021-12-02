using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using voresgruppe.ThirdSemesterExamBackend.Security.IServices;
using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security.Services
{
    public class SecurityService: ISecurityService
    {
        
        public IConfiguration Configuration { get; }
        private readonly IAuthService _authService;

        public SecurityService(IConfiguration configuration, IAuthService authService)
        {
            Configuration = configuration;
            _authService = authService;
        }

        public JwtToken GenerateJwtToken(string username, string password)
        {
            var user = _authService.GetUser(username);
            
            if (Authenticate(password,user))
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

            return new JwtToken()
            {
                Message = "Login Denied"
            };
        }

        private bool Authenticate(string plainPassword, AuthUser user)
        {
            if (user == null || user.HashedPassword.Length <=0 || user.Salt.Length <=0)
            {
                return false;
            }

            var hashedPasswordFromPlain = HashedPassword(plainPassword, user.Salt);
            return user.HashedPassword.Equals(hashedPasswordFromPlain) ;

        }

        public string HashedPassword(string plainPassword, byte[] userSalt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: plainPassword,
                salt: userSalt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}