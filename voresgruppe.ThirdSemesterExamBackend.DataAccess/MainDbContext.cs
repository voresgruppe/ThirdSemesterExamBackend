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
        public virtual DbSet<CustomerEntity> Customer { get; set; }
        public virtual DbSet<EmployeeEntity> Admins { get; set; }
        public virtual DbSet<AppointmentEntity> Appointment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppointmentEntity>()
                .HasOne(a => a.Customer)
                .WithMany(customerEntity => customerEntity.AppointmentEntities);
        }

        
    }
}