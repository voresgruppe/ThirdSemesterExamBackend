using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Core.IServices
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        bool DeleteById(int id);

        Employee Create(Employee employee);

        Employee Update(int id, Employee updatedEmployee);
    }
}