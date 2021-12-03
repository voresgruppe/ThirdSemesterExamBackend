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
            return _ctx.Customer.Select(pe => _customerEntityUtils.EntityToCustomer(pe)).ToList();
        }

        public Customer FindById(int id)
        {
            if (FindAll().Count < id)
            {
                throw new InvalidDataException("Id is too high");
            }
            
            return _customerEntityUtils.EntityToCustomer(_ctx.Customer.Find(id));
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
            CustomerEntity ce = _ctx.Customer.Find(id);
            ce.Name = customer.Name;
            ce.Email = customer.Email;
            ce.PhoneNumber = customer.PhoneNumber;
            CustomerEntity returnEntity = _ctx.Customer.Update(ce).Entity;
            _ctx.SaveChanges();
            return _customerEntityUtils.EntityToCustomer(returnEntity);
        }
    }
}