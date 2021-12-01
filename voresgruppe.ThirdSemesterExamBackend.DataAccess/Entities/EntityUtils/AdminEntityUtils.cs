using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils
{
    public class AdminEntityUtils
    {
        public Admin EntityToAdmin(AdminEntity entity)
        {
            return new Admin()
            {
                Id = entity.Id,
                Username = entity.Username,
                Password = entity.Password,
            };
        }
    }
}