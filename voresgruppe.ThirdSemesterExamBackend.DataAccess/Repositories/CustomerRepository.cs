using System.Collections.Generic;
using System.IO;
using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MainDbContext _ctx;

        public CustomerRepository(MainDbContext ctx)
        {
            if (ctx == null)
            {
                throw new InvalidDataException("Customer Repository must have a DBContext");
            }

            _ctx = ctx;
        }

        public List<Customer> FindAll()
        {
            return _ctx.Customer.Select(pe => new Customer
            {
                Id = pe.Id,
                Name = pe.Name,
                Email = pe.Email,
                PhoneNumber = pe.PhoneNumber
            }).ToList();
        }

        public Customer FindById(int i)
        {
            throw new System.NotImplementedException();
        }
    }
}