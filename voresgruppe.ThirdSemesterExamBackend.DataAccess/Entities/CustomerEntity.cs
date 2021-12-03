using System.Collections.Generic;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public List<AppointmentEntity> AppointmentEntities { get; set; } = new List<AppointmentEntity>();
    }
}