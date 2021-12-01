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
            return _customerService.GetCustomers();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetById(int id)
        {
            return _customerService.GetCustomerById(id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteById(int id)
        {
            return _customerService.DeleteCustomerById(id);
        }

        [HttpPost]
        public ActionResult<Customer> CreateCustomer([FromBody] Customer customer)
        {
            Customer createdCustomer = _customerService.CreateCustomer(customer);
            return Created($"https://localhost/api/products/{createdCustomer}", createdCustomer);
            
        }
    }
}