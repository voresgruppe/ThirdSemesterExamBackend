using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;


namespace voresgruppe.ThirdSemesterExamBackend.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService ?? throw new InvalidDataException("AdminService cannot be null");
        }

        [HttpGet]
        public ActionResult<List<Admin>> GetAll()
        {
            return _adminService.GetAdmins();
        }
        
        [HttpGet("{id}")]
        public ActionResult<Admin> GetById(int id)
        {
            return _adminService.GetAdminById(id);
        }

        [HttpDelete]
        public ActionResult<bool> DeleteById(int id)
        {
            return _adminService.DeleteAdminById(id);
        }
        
        [HttpPost]
        public ActionResult<Admin> Create([FromBody]Admin admin)
        {
            var createdAdmin = _adminService.CreateAdmin(admin);
            return Created($"https://localhost/api/hairstyles/{createdAdmin}", createdAdmin);
        }
        
        [HttpPut]
        public ActionResult<Admin> Update(int id, string username, string password)
        {
            Admin admin = new Admin() {Username = username, Password = password};
            var updatedAdmin = _adminService.UpdateAdmin(id, admin);
            return Created($"https://localhost/api/hairstyles/{updatedAdmin}", updatedAdmin);
        }
    }
}