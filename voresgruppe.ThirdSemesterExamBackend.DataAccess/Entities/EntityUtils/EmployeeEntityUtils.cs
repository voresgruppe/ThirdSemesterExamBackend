using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities.EntityUtils
{
    public class EmployeeEntityUtils
    {
        public Employee EntityToAdmin(EmployeeEntity entity)
        {
            return new Employee()
            {
                Id = entity.Id,
                Name = entity.Name,
            };
        }
    }
}