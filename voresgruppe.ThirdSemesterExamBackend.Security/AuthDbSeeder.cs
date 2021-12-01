using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security
{
    public class AuthDbSeeder
    {
        private readonly AuthDbContext _ctx;

        public AuthDbSeeder(AuthDbContext authDbContext)
        {
            _ctx = authDbContext;
        }

        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            _ctx.LoginUsers.Add(new LoginUserEntity()
            {
                Username = "Knud",
                Password = "123"
            });
            _ctx.SaveChanges();
        }
    }
}