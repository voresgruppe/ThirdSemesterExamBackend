using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            if (customerService == null)
                throw new InvalidDataException("CustomerService cannot be null");
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAll()
        {
            Console.WriteLine("get");
            return _customerService.GetCustomers();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            return Ok(_customerService.GetCustomerById(id));
        }
        
        [HttpGet(nameof(GetByPhone)+"{phone}")]
        public ActionResult<Customer> GetByPhone(string phone)
        {
            return Ok(_customerService.GetByPhoneNumber(phone));
        }
        
        

        [HttpDelete]
        public ActionResult<bool> DeleteById(int id)
        {
            return _customerService.DeleteCustomerById(id);
        }

        [HttpPost(nameof(CreateCustomer))]
        public ActionResult<Customer> CreateCustomer(Customer customer)
        {
            Console.WriteLine("add");
            Customer createdCustomer = _customerService.CreateCustomer(customer);
            Console.WriteLine(customer);
            return createdCustomer;
        }

        [HttpPut]
        public ActionResult<Customer> UpdateCustomer(int id, Customer customer)
        {
            var c = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
            Customer updateCustomer = _customerService.UpdateCustomer(id, c);
            return Created($"https://localhost/api/customers/{updateCustomer}", updateCustomer);
        }
    }
}