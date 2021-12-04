using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;


namespace voresgruppe.ThirdSemesterExamBackend.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new InvalidDataException("AdminService cannot be null");
        }

        [HttpGet]
        public ActionResult<List<Employee>> GetAll()
        {
            return _employeeService.GetAll();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Employee> GetById(int id)
        {
            return _employeeService.GetById(id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteById(int id)
        {
            return _employeeService.DeleteById(id);
        }
        
        [HttpPost]
        public ActionResult<Employee> Create([FromBody]Employee employee)
        {
            var createdAdmin = _employeeService.Create(employee);
            return Created($"https://localhost/api/hairstyles/{createdAdmin}", createdAdmin);
        }
        
        [HttpPut]
        public ActionResult<Employee> Update(int id, string username, string password)
        {
            Employee employee = new Employee() {Name = username};
            var updatedAdmin = _employeeService.Update(id, employee);
            return Created($"https://localhost/api/hairstyles/{updatedAdmin}", updatedAdmin);
        }
    }
}