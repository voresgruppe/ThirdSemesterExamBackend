using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories
{
    public interface IEmployeeRepository
    {
        public List<Employee> FindAll();
        
        public Employee ReadById(int expectedId);

        public bool DeleteById(int id);

        public Employee Create(Employee employee);

        public Employee Update(int id, Employee updatedEmployee);
    }
}