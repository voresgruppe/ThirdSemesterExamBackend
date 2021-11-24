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
            AddMockData_Customer();
            _ctx.SaveChanges();
        }

        void addMockData_Hairstyle()
        {
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "kort"});
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "langt"});
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "gryde"});
        }

        void AddMockData_Customer()
        {
            _ctx.Customer.Add(new CustomerEntity
                {Name = "Per", Email = "postmandper@hotmail.com", PhoneNumber = "22334422"});
            _ctx.Customer.Add(new CustomerEntity
                {Name = "Birgit", Email = "boomerbirgit@boomermail.com", PhoneNumber = "12341234"});
            _ctx.Customer.Add(new CustomerEntity
                {Name = "Frederik", Email = "prinsen@gmail.com", PhoneNumber = "11111111"});

        }
    }
}