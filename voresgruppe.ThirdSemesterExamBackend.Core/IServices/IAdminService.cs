using System.Collections.Generic;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.Core.IServices
{
    public interface IAdminService
    {
        List<Admin> GetAdmins();
        Admin GetAdminById(int id);
        bool DeleteAdminById(int id);

        Admin CreateAdmin(Admin admin);

        Admin UpdateAdmin(int AdminId, Admin updatedAdmin);
    }
}