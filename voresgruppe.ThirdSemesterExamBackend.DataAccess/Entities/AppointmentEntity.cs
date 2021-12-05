using System;
using voresgruppe.ThirdSemesterExamBackend.Core.Models;

namespace voresgruppe.ThirdSemesterExamBackend.DataAccess.Entities
{
    public class AppointmentEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }
        public DateTime AppointmentTime { get; set; }
        public EmployeeEntity Employee { get; set; }
        
        public int EmployeeId { get; set; }
    }
}