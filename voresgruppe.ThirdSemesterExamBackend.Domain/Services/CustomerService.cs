using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            string searchNumber = CheckValidPhoneNumber(phone);
            return _customerRepository.FindByPhoneNumber(searchNumber);
        }

        public bool DeleteCustomerById(int id)
        {
            return _customerRepository.DeleteById(id);
        }

        public Customer CreateCustomer(Customer customer)
        {
            customer.PhoneNumber = CheckValidPhoneNumber(customer.PhoneNumber);
            return _customerRepository.CreateCustomer(customer);
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            return _customerRepository.UpdateCustomer(id,customer);
        }

        private string CheckValidPhoneNumber(string phone)
        {
            string nr = phone.Trim();
            string finalNr = "";
            if (nr.StartsWith("00"))
            {
                string s = string.Join(string.Empty, nr.Skip(2));
                nr = "+" + s.Substring(nr.LastIndexOf('+') + 1);
            }

            if (nr.StartsWith("+"))
            {
                string nonPlusNumber = nr.Substring(nr.LastIndexOf('+') + 1);
                finalNr = "+" + CheckIfStringIsNumberAndAddSpaceEveryTwoNumbers(nonPlusNumber);
            }
            else
            {
                finalNr = CheckIfStringIsNumberAndAddSpaceEveryTwoNumbers(nr);
            }

            return finalNr;
        }

        private string CheckIfStringIsNumberAndAddSpaceEveryTwoNumbers(string nr)
        {
            ulong num;
            bool isNumber = ulong.TryParse(nr, out num);
            string realNumber = num.ToString();
            if (!isNumber)
            {
                throw new InvalidDataException("Phone number must be a number (+ as first character is fine) or phone number is more than 19 digits");
            }
            string returnValue = "";
            if (isNumber)
            {
                var list = Enumerable.Range(0, realNumber.Length / 2)
                    .Select(i => realNumber.Substring(i * 2, 2));
                returnValue = string.Join(" ", list);
            }

            return returnValue;
        }
    }
}