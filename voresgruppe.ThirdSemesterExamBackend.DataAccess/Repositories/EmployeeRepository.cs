using System.Collections.Generic;
using System.IO;
using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MainDbContext _ctx;
        private EmployeeEntityUtils _employeeEntityUtils = new EmployeeEntityUtils();

        public EmployeeRepository(MainDbContext ctx)
        {
            if (ctx == null)
            {
                throw new InvalidDataException("AdminRepository need a DBcontext");
            }
            _ctx = ctx;
        }

        public List<Employee> FindAll()
        {
            return _ctx.Employee
                .Select(a => _employeeEntityUtils.EntityToAdmin(a))
                .ToList();
        }

        public Employee ReadById(int expectedId)
        {
            return _employeeEntityUtils.EntityToAdmin(_ctx.Employee.Find(expectedId));
        }

        public bool DeleteById(int id)
        {
            _ctx.Remove(_ctx.Employee.Find(id));
            _ctx.SaveChanges();
            return true;
        }

        public Employee Create(Employee employee)
        {
            EmployeeEntity employeeEntity = new EmployeeEntity()
            {
                Name = employee.Name,
            };
            
            Employee createdEmployee = _employeeEntityUtils.EntityToAdmin(_ctx.Employee.Add(employeeEntity).Entity);
            _ctx.SaveChanges();
            return createdEmployee;

        }

        public Employee Update(int id, Employee updatedEmployee)
        {
            EmployeeEntity entityToUpdate = _ctx.Employee.Find(id);
            entityToUpdate.Name = updatedEmployee.Name;
            _ctx.Employee.Update(entityToUpdate);
            _ctx.SaveChanges();
            return _employeeEntityUtils.EntityToAdmin(_ctx.Employee.Find(id));
        }
    }
}