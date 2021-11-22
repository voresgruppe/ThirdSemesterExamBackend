using Microsoft.EntityFrameworkCore;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options): base(options)
        {
            
        }

        public virtual DbSet<HairstyleEntity> Hairstyles { get; set; } 
    }
}