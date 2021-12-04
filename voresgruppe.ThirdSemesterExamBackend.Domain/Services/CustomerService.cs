using System.Collections.Generic;
using System.IO;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            if (customerRepository == null)
            {
                throw new InvalidDataException();
            }
            _customerRepository = customerRepository;
        }
        public List<Customer> GetCustomers()
        {
            return _customerRepository.FindAll();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepository.FindById(id);
        }

        public Customer GetByPhoneNumber(string phone)
        {
            return _customerRepository.FindByPhoneNumber(phone);
        }

        public bool DeleteCustomerById(int id)
        {
            return _customerRepository.DeleteById(id);
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _customerRepository.CreateCustomer(customer);
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            return _customerRepository.UpdateCustomer(id,customer);
        }
    }
}