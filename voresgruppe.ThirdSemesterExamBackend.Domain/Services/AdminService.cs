using System.Collections.Generic;
using System.IO;
using voresgruppe.ThirdSemesterExamBackend.Core.IServices;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;
using voresgruppe.ThirdSemesterExamBackend.Domain.IRepositories;

namespace voresgruppe.ThirdSemesterExamBackend.Domain.Services
{
    public class AdminService: IAdminService
    {
        private IAdminRepository _adminRepository;

        public AdminService(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository ?? throw new InvalidDataException("AdminRepository cannot be null");
        }

        public List<Admin> GetAdmins()
        {
            return _adminRepository.FindAll();
        }

        public Admin GetAdminById(int id)
        {
            return _adminRepository.ReadById(id);
        }

        public bool DeleteAdminById(int id)
        {
            return _adminRepository.DeleteById(id);
        }

        public Admin CreateAdmin(Admin admin)
        {
            return _adminRepository.Create(admin);
        }

        public Admin UpdateAdmin(int adminId, Admin updatedAdmin)
        {
            return _adminRepository.Update(adminId, updatedAdmin);
        }
    }
}