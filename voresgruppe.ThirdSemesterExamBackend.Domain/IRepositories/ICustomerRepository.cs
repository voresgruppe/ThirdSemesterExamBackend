using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories
{
    public interface ICustomerRepository
    {
        List<Customer> FindAll();
        Customer FindById(int id);
        Customer FindByPhoneNumber(string phone);
        bool DeleteById(int id);
        Customer CreateCustomer(Customer customer);
        Customer UpdateCustomer(int id, Customer customer);
        
    }
}