using System;
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

        public Customer FindById(int id)
        {
            if (FindAll().Count < id)
            {
                throw new InvalidDataException("Id is too high");
            }
            
            return _ctx.Customer.Select(ce => new Customer
            {
                Id = ce.Id,
                Name = ce.Name,
                Email = ce.Email,
                PhoneNumber = ce.PhoneNumber
            }).FirstOrDefault(ce => ce.Id == id);
        }

        public bool DeleteById(int id)
        {
            var customer = _ctx.Customer.Find(id);
            _ctx.Customer.Remove(customer);
            _ctx.SaveChanges();
            return true;
        }

    }
}