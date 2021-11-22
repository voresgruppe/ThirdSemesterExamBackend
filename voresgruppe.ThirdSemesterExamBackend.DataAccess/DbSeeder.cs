using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess
{
    public class DbSeeder
    {
        private readonly MainDbContext _ctx;

        public DbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            addMockData_Hairstyle();
            _ctx.SaveChanges();
        }

        void addMockData_Hairstyle()
        {
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "kort"});
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "langt"});
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "gryde"});
        }
    }
}