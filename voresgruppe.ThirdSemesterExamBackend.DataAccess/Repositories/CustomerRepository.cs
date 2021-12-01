using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly MainDbContext _ctx;
        private CustomerEntityUtils _customerEntityUtils = new();

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

        public Customer CreateCustomer(Customer customer)
        {
            var ce = _ctx.Customer.Add(new CustomerEntity
            {
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            }).Entity;
            _ctx.SaveChanges();
            return _customerEntityUtils.EntityToCustomer(ce);
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}