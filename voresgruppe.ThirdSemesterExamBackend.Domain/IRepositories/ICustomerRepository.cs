using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories
{
    public interface ICustomerRepository
    {
        List<Customer> FindAll();
        Customer FindById(int id);
        bool DeleteById(int id);
    }
}