using Microsoft.EntityFrameworkCore;
using voresgruppe.ThirdSemesterExamBackend.Security.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Security
{
    public class AuthDbContext:DbContext
    {
        protected AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
            
        }

        public DbSet<LoginUserEntity> LoginUsers { get; set; }
    }
}