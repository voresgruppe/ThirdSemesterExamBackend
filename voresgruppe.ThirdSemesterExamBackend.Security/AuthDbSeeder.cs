using System.Text;
using voresgruppe.ThirdSemesterExamBackend.Security.Entities;
using voresgruppe.ThirdSemesterExamBackend.Security.IServices;

namespace voresgruppe.ThirdSemesterExamBackend.Security
{
    public class AuthDbSeeder : IAuthDbSeeder
    {
        private readonly AuthDbContext _ctx;
        private readonly ISecurityService _securityService;

        public AuthDbSeeder(AuthDbContext authDbContext, ISecurityService securityService)
        {
            _ctx = authDbContext;
            _securityService = securityService;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();

            var salt = "123#!";
            _ctx.AuthUsers.Add(new AuthUserEntity()
            {
                Username = "Knud",
                Salt = salt,
                HashedPassword = _securityService.HashedPassword("123456", Encoding.ASCII.GetBytes(salt)),
                EmployeeId = 1,
            });
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
        }
    }
}