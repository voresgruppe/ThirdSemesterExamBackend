using System.Collections.Generic;
using System.IO;
using System.Linq;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities;
using voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly MainDbContext _ctx;
        private AdminEntityUtils _adminEntityUtils = new AdminEntityUtils();

        public AdminRepository(MainDbContext ctx)
        {
            if (ctx == null)
            {
                throw new InvalidDataException("AdminRepository need a DBcontext");
            }
            _ctx = ctx;
        }

        public List<Admin> FindAll()
        {
            return _ctx.Admins
                .Select(a => _adminEntityUtils.EntityToAdmin(a))
                .ToList();
        }

        public Admin ReadById(int expectedId)
        {
            return _adminEntityUtils.EntityToAdmin(_ctx.Admins.Find(expectedId));
        }

        public bool DeleteById(int id)
        {
            _ctx.Remove(_ctx.Admins.Find(id));
            _ctx.SaveChanges();
            return true;
        }

        public Admin Create(Admin admin)
        {
            AdminEntity adminEntity = new AdminEntity()
            {
                Username = admin.Username,
                Password = admin.Password,
            };
            
            Admin createdAdmin = _adminEntityUtils.EntityToAdmin(_ctx.Admins.Add(adminEntity).Entity);
            _ctx.SaveChanges();
            return createdAdmin;

        }

        public Admin Update(int id, Admin updatedAdmin)
        {
            AdminEntity entityToUpdate = _ctx.Admins.Find(id);
            entityToUpdate.Username = updatedAdmin.Username;
            entityToUpdate.Password = updatedAdmin.Password;
            _ctx.Admins.Update(entityToUpdate);
            _ctx.SaveChanges();
            return _adminEntityUtils.EntityToAdmin(_ctx.Admins.Find(id));
        }
    }
}