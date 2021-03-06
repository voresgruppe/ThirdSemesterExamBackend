using Microsoft.EntityFrameworkCore;
using voresgruppe.ThirdSemesterExamBackend.Security.Entities;

namespace voresgruppe.ThirdSemesterExamBackend.Security
{
    public class AuthDbContext:DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            
        }

        public DbSet<AuthUserEntity> AuthUsers { get; set; }
    }
}