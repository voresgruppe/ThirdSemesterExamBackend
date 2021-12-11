using System;
using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess
{
    public class MainDbSeeder : IMainDbSeeder
    {
        private readonly MainDbContext _ctx;

        public MainDbSeeder(MainDbContext ctx)
        {
            _ctx = ctx;
        }
        
        public void SeedDevelopment()
        {
            _ctx.Database.EnsureDeleted();
            _ctx.Database.EnsureCreated();
            addMockData_Hairstyle();
            AddMockData_Customer();
            AddMockData_employees();
            AddMockData_Appointment();
            _ctx.SaveChanges();
        }

        public void SeedProduction()
        {
            _ctx.Database.EnsureCreated();
            int hairstylesCount = _ctx.Hairstyles.Count();
            if (hairstylesCount == 0)
            {
                addMockData_Hairstyle();
            }
            
            int customerCount = _ctx.Customer.Count();
            if (customerCount == 0)
            {
                AddMockData_Customer();
            }
            
            int appointmentCount = _ctx.Appointment.Count();
            if (appointmentCount == 0)
            {
                AddMockData_Appointment();
            }
            
            int employeeCount = _ctx.Employee.Count();
            if (employeeCount == 0)
            {
                AddMockData_employees();
            }

            _ctx.SaveChanges();
        }

        void addMockData_Hairstyle()
        {
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "kort", EstimatedTime = 40, Description = "det mindre langt", Price = 3, PossibleStyles = "2", IsStarterHairstyle = true});
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "spidser", EstimatedTime = 50, Description = "det blir nogenlunde lige", Price = 45, PossibleStyles = "1", IsStarterHairstyle = false});
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "gryde", EstimatedTime = 35, Description = "bedre end pandehår", Price = 20, PossibleStyles = "1", IsStarterHairstyle = true});
            _ctx.Hairstyles.Add(new HairstyleEntity(){Name = "skulderlangt", EstimatedTime = 35, Description = "ca samme længde som fra din hovedbund til dine skuldre", Price = 0, PossibleStyles = "1,2,3", IsStarterHairstyle = true});
            _ctx.SaveChanges();
        }

        void AddMockData_Customer()
        {
            _ctx.Customer.Add(new CustomerEntity
                {Name = "Per", Email = "postmandper@hotmail.com", PhoneNumber = "22 33 44 22"});
            _ctx.Customer.Add(new CustomerEntity
                {Name = "Birgit", Email = "boomerbirgit@boomermail.com", PhoneNumber = "12 34 12 34"});
            _ctx.Customer.Add(new CustomerEntity
                {Name = "Frederik", Email = "prinsen@gmail.com", PhoneNumber = "11 11 11 11"});
            _ctx.SaveChanges();

        }

        void AddMockData_employees()
        {
            _ctx.Employee.Add(new EmployeeEntity() {Name = "John", AboutMe = "Jeg er Frisør"});
            _ctx.Employee.Add(new EmployeeEntity() {Name = "Gerda", AboutMe = "Jeg er Gerda"});
            _ctx.SaveChanges();
        }

        void AddMockData_Appointment()
        {
            _ctx.Appointment.Add(new AppointmentEntity() {AppointmentTime = DateTime.Today, CustomerId = 1, EmployeeId = 2, HairstyleStarterId = 1, HairstyleEndId = 2});
            _ctx.Appointment.Add(new AppointmentEntity() {AppointmentTime = DateTime.Today.AddDays(-1), CustomerId = 1, EmployeeId = 1, HairstyleStarterId = 4, HairstyleEndId = 1});
            _ctx.Appointment.Add(new AppointmentEntity() {AppointmentTime = DateTime.Today.AddDays(1), CustomerId = 2, EmployeeId = 1, HairstyleStarterId = 4, HairstyleEndId = 2});
            _ctx.SaveChanges();
        }
    }
}