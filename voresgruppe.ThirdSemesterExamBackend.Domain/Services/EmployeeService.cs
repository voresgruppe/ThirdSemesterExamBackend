using System.Collections.Generic;
using System.IO;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.Services
{
    public class EmployeeService: IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new InvalidDataException("AdminRepository cannot be null");
        }

        public List<Employee> GetAll()
        {
            return _employeeRepository.FindAll();
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.ReadById(id);
        }

        public bool DeleteById(int id)
        {
            return _employeeRepository.DeleteById(id);
        }

        public Employee Create(Employee employee)
        {
            return _employeeRepository.Create(employee);
        }

        public Employee Update(int adminId, Employee updatedEmployee)
        {
            return _employeeRepository.Update(adminId, updatedEmployee);
        }
    }
}