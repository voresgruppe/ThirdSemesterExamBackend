using System.Collections.Generic;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public string AboutMe { get; set; }
        
        public List<AppointmentEntity> AppointmentEntities { get; set; } = new List<AppointmentEntity>();
    }
}