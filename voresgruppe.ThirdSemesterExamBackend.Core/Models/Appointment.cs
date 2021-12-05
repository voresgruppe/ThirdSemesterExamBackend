using System;

namespace voresgruppe.ThirdSemesterExamBackend.Core.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        
        //public int CustomerId { get; set; }
        
        //public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        
        public Customer Customer { get; set; }
        public String AppointmentTime { get; set; }
    }
}