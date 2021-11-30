using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories
{
    public interface IAdminRepository
    {
        public List<Admin> FindAll();
        
        public Admin ReadById(int expectedId);

        public bool DeleteById(int id);

        public Admin Create(Admin admin);

        public Admin Update(int id, Admin updatedAdmin);
    }
}