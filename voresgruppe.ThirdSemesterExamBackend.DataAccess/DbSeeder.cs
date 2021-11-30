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
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "kort", EstimatedTime = 40});
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "langt", EstimatedTime = 50});
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "gryde", EstimatedTime = 35});
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

        void AddMockData_Admins()
        {
            _ctx.Admins.Add(new AdminEntity() {Username = "John", Password = "John123"});
            _ctx.Admins.Add(new AdminEntity() {Username = "Gerda", Password = "Gerda123"});
        }
    }
}