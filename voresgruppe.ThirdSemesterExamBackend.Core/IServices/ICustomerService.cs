using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Core.IServices
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();
        Customer GetCustomerById(int id);

        public Customer GetByPhoneNumber(string phone);
        bool DeleteCustomerById(int id);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(int id, Customer customer);
    }
}